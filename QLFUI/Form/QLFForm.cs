﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace QLFUI
{
    public partial class QLFForm : Form
    {
        public event SkinChangedEventHandler SkinChanged;
        public delegate void SkinChangedEventHandler();
        #region 变量

        private PartBase _topLeft;
        private PartBase _topMiddle;
        private PartBase _topRight;

        private PartBase _centerLeft;
        private PartBase _centerMiddle;
        private PartBase _centerRight;

        private PartBase _bottomLeft;
        private PartBase _bottomMiddle;
        private PartBase _bottomRight;

        private string _skinFolder;   //使用的皮肤目录路径
        private Point _titlePoint = new Point(6, 8);
        private bool _canMove = true;
        private bool _showSelectSkinButton = false;

        //窗体的最大化，最小化状态
        FormState _formState = FormState.Normal;
        enum FormState
        {
            Normal, Max, Min
        }

        //记录原始的用户设置的大小，用于最大化后返回正常的大小
        int _orginWidth;
        int _orginHeight;
        int _orginX;
        int _orginY;


        #endregion

        #region 属性

        [Browsable(true), Description("需要显示的皮肤目录"), Category("QLFUI")]
        [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public string SkinFolder
        {
            get { return _skinFolder; }
            set
            {
                //实际运行的时候客户端肯定不存在设计下设置的skinfolder
                //所以这里要区别设计模式和运行模式
                //设计模式下的时候设置的skinfolder不允许错误
                //实际运行的时候就直接读取设置的skinfolder了（要么没有要么正确）
                if (DesignMode)
                {
                    if (File.Exists(value + "\\config.ini"))
                    {
                        if (ReadIniFile(value))
                        {
                            CaculatePartLocation();
                            IniHelper.ChangeSkin(value);
                            SetImages();
                            Validate();
                        }
                    }
                    else if (string.IsNullOrEmpty(value))  //清除皮肤目录
                    {
                        InitDefaultSkin();
                    }
                    else
                    {
                        MessageBox.Show("皮肤目录错误");
                        return;   //错误这里返回，_skinFolder设置不到
                    }
                }
                _skinFolder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 正在使用的皮肤名字
        /// </summary>
        [Browsable(false)]
        public string SkinName
        {
            get { return SkinFolder != null ? SkinFolder.Substring(SkinFolder.LastIndexOf('\\') + 1) : null; }
        }

        /// <summary>
        /// 隐藏FormBorderStyle
        /// </summary>
        [Browsable(false)]
        public new FormBorderStyle FormBorderStyle
        {
            get { return base.FormBorderStyle; }
            set { base.FormBorderStyle = value; }
        }

        [Browsable(true), Description("窗体标题字体"), Category("QLFUI")]
        public Point TitlePoint
        {
            get { return _titlePoint; }
            set
            {
                _titlePoint = value;
                Invalidate();
            }
        }

        [Browsable(true), Description("是否允许调整窗体大小"), Category("QLFUI"), DefaultValue(false)]
        public bool SizeAble
        {
            get;
            set;
        }

        [Browsable(true), Description("是否允许鼠标移动窗体"), Category("QLFUI")]
        public bool CanMove
        {
            get { return _canMove; }
            set { _canMove = value; }
        }

        [Browsable(true), Description("是否允许选择皮肤按钮"), Category("QLFUI")]
        public bool ShowSelectSkinButton
        {
            get { return _showSelectSkinButton; }
            set
            {
                _showSelectSkinButton = value;
                Invalidate();
            }
        }

        #endregion

        #region 构造函数

        public QLFForm()
        {
            SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.AllPaintingInWmPaint, true);
            //皮肤初始化
            IniHelper.Init();
            InitializeComponent();
            //设置系统菜单（在构造函数中没有用，我也不懂为什么）
            Win32.SetWindowLong(Handle, -16, Win32.WS_SYSMENU + Win32.WS_MINIMIZEBOX);
           //初始化各部分
            _topLeft = new PartBase();
            _topMiddle = new PartBase();
            _topRight = new PartBase();
            _centerLeft = new PartBase();
            _centerMiddle = new PartBase();
            _centerRight = new PartBase();
            _bottomLeft = new PartBase();
            _bottomMiddle = new PartBase();
            _bottomRight = new PartBase();
        }

        #endregion

        #region 事件

        private void QLFForm_Load(object sender, EventArgs e)
        {

            //初始化这里的时候skinfolder没有初始化，总为null。
            //所以这里直接初始化默认皮肤。在后面初始化的skinfolder的时候会自动重新初始化皮肤
            InitDefaultSkin();

            foreach (Control item in this.Controls)
            {
                ColorfulControl(item);
            }
        }
        private void ColorfulControl(Control item)
        {
            switch (item.GetType().ToString())
            {
                case "System.Windows.Forms.Button":
                    Button button = (Button)item;
                    button.Image = _topMiddle.BackgroundBitmap;
                    break;
                case "System.Windows.Forms.VistaButton":
                    VistaButton vistabutton = (VistaButton)item;
                    vistabutton.BackColor = System.Drawing.Color.Transparent;
                    vistabutton.BaseColor = IniHelper.BackColor;
                    vistabutton.ButtonColor = IniHelper.DeepColor;
                    vistabutton.ButtonStyle = VistaButton.Style.Default;
                    vistabutton.BorderStyle = BorderStyle.None;
                    vistabutton.ForeColor = System.Drawing.Color.Black;
                    vistabutton.GlowColor = System.Drawing.Color.Orange;
                    vistabutton.Height = 30;
                    break;
                case "System.Windows.Forms.TrackBar":
                    TrackBar trackbar = (TrackBar)item;
                    break;
                case "System.Windows.Forms.TextBox":
                    TextBox textbox = (TextBox)item;
                    break;
                case "System.Windows.Forms.ListView":
                    ListView listview = (ListView)item;
                    listview.FullRowSelect = true;
                    listview.GridLines = true;
                    break;
                case "System.Windows.Forms.Label":
                    Label label = (Label)item;
                    label.BackColor = Color.Transparent;
                    break;
                case "System.Windows.Forms.MenuStrip":
                    //使用了ToolStripRenderer来美化
                    break;
                default:
                    foreach (Control ctl in item.Controls)
                    {
                        ColorfulControl(ctl);
                    }
                    break;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawBackground(e.Graphics);
            base.OnPaint(e);
        }

        #region 按钮

        protected virtual void maxButton_Click(object sender, EventArgs e)
        {
            if (_formState == FormState.Normal)
            {
                MaxWindow();
            }
            else
            {
                NormalWindow();
            }
        }

        protected virtual void minButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        protected virtual void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual void selectSkinButton_Click(object sender, EventArgs e)
        {
            List<String> skinNames = GetAllSkinName();
            skinContextMenu.Renderer = new CRD.WinUI.Misc.ToolStripRenderer(new ProfessionalColorTable());
            skinContextMenu.Items.Clear();
            for (int i = 0; i < skinNames.Count; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem { Text = skinNames[i] };
                item.Click += delegate { ChangeSkin(item.Text); };
                if (skinNames[i] == SkinName)
                {
                    item.Checked = true;
                }
                skinContextMenu.Items.Add(item);
            }

            skinContextMenu.Show(selectSkinButton,
                selectSkinButton.Width - 2,
                selectSkinButton.Height - 2);
        }

        #endregion

        private void QLFForm_MouseMove(object sender, MouseEventArgs e)
        {
            #region 拖动边框大小

            if (_formState != FormState.Max && SizeAble)   //非最大化状态且可调整
            {
                if (e.X > 4 && e.X < Width - 4 && e.Y >= Height - 4) //拖动下边框
                {
                    Cursor.Current = Cursors.SizeNS;
                    if (e.Button == MouseButtons.Left)
                    {
                        Win32.ReleaseCapture();
                        Win32.SendMessage(Handle, 274, 61440 + 6, 0);
                        return;
                    }
                }
                if (e.X <= 4 && e.Y >= Height - 4) //拖动左下角
                {
                    Cursor.Current = Cursors.SizeNESW;
                    if (e.Button == MouseButtons.Left)
                    {
                        Win32.ReleaseCapture();
                        Win32.SendMessage(Handle, 274, 61440 + 7, 0);
                        return;
                    }
                }
                if (e.X >= Width - 4 && e.Y >= Height - 4) //拖动右下角变化大小
                {
                    Cursor.Current = Cursors.SizeNWSE;
                    if (e.Button == MouseButtons.Left)
                    {
                        Win32.ReleaseCapture();
                        Win32.SendMessage(Handle, 274, 61440 + 8, 0);
                        return;
                    }
                }
                if (e.X >= Width - 4 && e.Y > 4 && e.Y < Height - 4) //拖动右边框
                {
                    Cursor.Current = Cursors.SizeWE;
                    if (e.Button == MouseButtons.Left)
                    {
                        Win32.ReleaseCapture();
                        Win32.SendMessage(Handle, 274, 61440 + 2, 0);
                        return;
                    }
                }
                if (e.X <= 4 && e.Y > 4 && e.Y < Height - 4) //拖动左边框
                {
                    Cursor.Current = Cursors.SizeWE;
                    if (e.Button == MouseButtons.Left)
                    {
                        Win32.ReleaseCapture();
                        Win32.SendMessage(Handle, 274, 61440 + 7, 0);
                        return;
                    }
                }
                if (e.X <= 4 && e.Y <= 4) //拖动左上角
                {
                    Cursor.Current = Cursors.SizeNWSE;
                    if (e.Button == MouseButtons.Left)
                    {
                        Win32.ReleaseCapture();
                        Win32.SendMessage(Handle, 274, 61440 + 4, 0);
                        return;
                    }
                }
                if (e.X > 4 && e.X < Width - 4 && e.Y <= 4) //拖动上边
                {
                    Cursor.Current = Cursors.SizeNS;
                    if (e.Button == MouseButtons.Left)
                    {
                        Win32.ReleaseCapture();
                        Win32.SendMessage(Handle, 274, 61440 + 3, 0);
                        return;
                    }
                }
                if (e.X >= Width - 4 && e.Y <= 4) //拖动右上角
                {
                    Cursor.Current = Cursors.SizeNESW;
                    if (e.Button == MouseButtons.Left)
                    {
                        Win32.ReleaseCapture();
                        Win32.SendMessage(Handle, 274, 61440 + 5, 0);
                        return;
                    }
                }
            }

            #endregion

            if (CanMove && e.Button == MouseButtons.Left && _formState != FormState.Max)   //拖动窗体
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(Handle, 274, 61440 + 9, 0);
                return;
            }
        }

        //双击标题栏
        private void QLFForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MaximizeBox)
            {
                Rectangle topRect = new Rectangle(0, 0, Width, _topMiddle.Height);
                if (topRect.Contains(e.Location))  //在标题栏双击
                {
                    //这里直接调用函数，防止子类maxbutton被重写这里反应不出来
                    maxButton_Click(null, null);
                }
            }
        }

        #endregion

        #region 辅助函数

        /// <summary>
        /// 初始化默认皮肤
        /// </summary>
        private void InitDefaultSkin()
        {
            if (IniHelper.skinName != String.Empty)
            {
                ReadIniFile(Application.StartupPath + @"\Skin\" + IniHelper.skinName);
            }
            else
            {
                SetDefaultIni();
            }
            CaculatePartLocation();
            //读取图片
            SetImages();
        }

        /// <summary>
        /// 设置位置
        /// </summary>
        private void SetDefaultIni()
        {
            //顶部
            _topLeft.Height = _topMiddle.Height = _topRight.Height = 38;
            _topLeft.Width = 1;
            _topRight.Width = 3;

            //底部
            _bottomLeft.Height = _bottomMiddle.Height = _bottomRight.Height = 25;
            _bottomRight.Width = 1;

            //中部
            _centerLeft.Width = 1;
            _centerRight.Width = 1;


            minButton.Width = 27;
            minButton.Height = 18;
            minButton.XOffset = 71;
            minButton.Top = 0;

            maxButton.Width = 27;
            maxButton.Height = 18;
            maxButton.XOffset = 45;
            maxButton.Top = 0;


            closeButton.Width = 45;
            closeButton.Height = 18;
            closeButton.XOffset = 4;
            closeButton.Top = 0;

            selectSkinButton.Width = 16;
            selectSkinButton.Height = 16;
            selectSkinButton.XOffset = 106;
            selectSkinButton.Top = 1;

        }
        /// <summary>
        /// 读取图片
        /// </summary>
        private void SetImages()
        {
            _topLeft.BackgroundBitmap = IniHelper.getImage("_topLeft");
            _topMiddle.BackgroundBitmap = IniHelper.getImage("_topMiddle");
            _topRight.BackgroundBitmap = IniHelper.getImage("_topRight");

            _centerLeft.BackgroundBitmap = IniHelper.getImage("_centerLeft");
            _centerMiddle.BackgroundBitmap = IniHelper.getImage("_centerMiddle");
            _centerRight.BackgroundBitmap = IniHelper.getImage("_centerRight");


            _bottomLeft.BackgroundBitmap = IniHelper.getImage("_bottomLeft");
            _bottomMiddle.BackgroundBitmap = IniHelper.getImage("_bottomMiddle");
            _bottomRight.BackgroundBitmap = IniHelper.getImage("_bottomRight");

            minButton.ReadButtonImage(IniHelper.getImage("MinNormal"), IniHelper.getImage("MinMove"), IniHelper.getImage("MinDown"));
            maxButton.ReadButtonImage(IniHelper.getImage("MaxNormal"), IniHelper.getImage("MaxMove"), IniHelper.getImage("MaxDown"));
            closeButton.ReadButtonImage(IniHelper.getImage("CloseNormal"), IniHelper.getImage("CloseMove"), IniHelper.getImage("CloseDown"));
            selectSkinButton.ReadButtonImage(IniHelper.getImage("SelectSkinNormal"), IniHelper.getImage("SelectSkinMove"), IniHelper.getImage("SelectSkinDown"));

        }
        /// <summary>
        /// 从配置中读取位置信息
        /// </summary>
        /// <param name="skinFolder"></param>
        /// <returns></returns>
        private bool ReadIniFile(string skinFolder)
        {
            try
            {
                string filePath = skinFolder + "\\config.ini";

                //顶部
                _topLeft.Height = _topMiddle.Height = _topRight.Height = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "Top_Height"));
                _topLeft.Width = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "TopLeft_Width"));
                _topRight.Width = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "TopRight_Width"));

                //底部
                _bottomLeft.Height = _bottomMiddle.Height = _bottomRight.Height = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "Bottom_Height"));
                _bottomLeft.Width = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "BottomLeft_Width"));
                _bottomRight.Width = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "BottomRight_Width"));

                //中部
                _centerLeft.Width = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "MiddleLeft_Width"));
                _centerRight.Width = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "MiddleRight_Width"));


                minButton.Width = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "MinButton_Width"));
                minButton.Height = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "MinButton_Height"));
                minButton.XOffset = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "MinButton_X"));
                minButton.Top = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "MinButton_Y"));

                maxButton.Width = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "MaxButton_Width"));
                maxButton.Height = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "MaxButton_Height"));
                maxButton.XOffset = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "MaxButton_X"));
                maxButton.Top = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "MaxButton_Y"));


                closeButton.Width = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "CloseButton_Width"));
                closeButton.Height = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "CloseButton_Height"));
                closeButton.XOffset = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "CloseButton_X"));
                closeButton.Top = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "CloseButton_Y"));

                selectSkinButton.Width = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "selectSkinButton_Width"));
                selectSkinButton.Height = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "selectSkinButton_Height"));
                selectSkinButton.XOffset = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "selectSkinButton_X"));
                selectSkinButton.Top = int.Parse(IniHelper.ReadIniValue(filePath, "Main", "selectSkinButton_Y"));


                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Resize事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void QLFForm_Resize(object sender, System.EventArgs e)
        {
            if (_topLeft != null)
            {
                //IDE设计器打开的时候，有一个Resize的动作，这个时候会出错
                CaculatePartLocation();
            }
        }
        /// <summary>
        /// 重新计算各个控件的位置
        /// </summary>
        private void CaculatePartLocation()
        {
            //顶部
            _topLeft.X = 0;
            _topLeft.Y = 0;

            _topRight.X = Width - _topRight.Width;
            _topRight.Y = 0;

            _topMiddle.X = _topLeft.Width;
            _topMiddle.Y = 0;
            _topMiddle.Width = Width - _topLeft.Width - _topRight.Width;

            //中间部分
            _centerLeft.X = 0;
            _centerLeft.Y = _topLeft.Height;
            _centerLeft.Height = Height - _topLeft.Height - _bottomLeft.Height;

            _centerRight.X = Width - _centerRight.Width;
            _centerRight.Y = _topRight.Height;
            _centerRight.Height = Height - _topLeft.Height - _bottomLeft.Height;

            _centerMiddle.X = _centerLeft.Width;
            _centerMiddle.Y = _topMiddle.Height;
            _centerMiddle.Width = Width - _centerLeft.Width - _centerRight.Width;
            _centerMiddle.Height = Height - _topMiddle.Height - _bottomMiddle.Height;

            //底部
            _bottomLeft.X = 0;
            _bottomLeft.Y = Height - _bottomLeft.Height;

            _bottomRight.X = Width - _bottomRight.Width;
            _bottomRight.Y = Height - _bottomRight.Height;

            _bottomMiddle.X = _bottomLeft.Width;
            _bottomMiddle.Y = Height - _bottomMiddle.Height;
            _bottomMiddle.Width = Width - _bottomLeft.Width - _bottomRight.Width;

            //按钮位置
            if (MaximizeBox && MinimizeBox)   // 允许最大化，最小化
            {
                maxButton.Left = Width - maxButton.Width - maxButton.XOffset;
                minButton.Left = Width - minButton.Width - minButton.XOffset;
                selectSkinButton.Left = Width - selectSkinButton.Width - selectSkinButton.XOffset;
            }
            if (MaximizeBox && !MinimizeBox)   //不允许最小化
            {
                maxButton.Left = Width - maxButton.Width - maxButton.XOffset;
                selectSkinButton.Left = Width - selectSkinButton.Width - minButton.XOffset;
                minButton.Top = -60;
            }
            if (!MaximizeBox && MinimizeBox)  //不允许最大化
            {
                maxButton.Top = -60;
                minButton.Left = Width - maxButton.XOffset - minButton.Width;
                selectSkinButton.Left = Width - selectSkinButton.Width - minButton.XOffset;
            }
            if (!MaximizeBox && !MinimizeBox)  //不允许最大化，最小化
            {
                minButton.Top = -60;
                maxButton.Top = -60;
                selectSkinButton.Left = Width - selectSkinButton.Width - maxButton.XOffset;
            }
            if (!_showSelectSkinButton)
            {
                selectSkinButton.Top = -60;
            }
            closeButton.Left = Width - closeButton.Width - closeButton.XOffset;



            //内容panel位置大小
            contentPanel.Top = _centerMiddle.Y;
            contentPanel.Left = _centerMiddle.X;
            contentPanel.Width = _centerMiddle.Width;
            contentPanel.Height = _centerMiddle.Height;

        }

        private void DrawBackground(Graphics g)
        {
            if (_topLeft.BackgroundBitmap == null)  //确认已经读取图片
            {
                return;
            }

            #region 绘制背景

            ImageAttributes attribute = new ImageAttributes();
            attribute.SetWrapMode(WrapMode.TileFlipXY);

            _topLeft.DrawSelf(g, null);
            _topMiddle.DrawSelf(g, attribute);
            _topRight.DrawSelf(g, null);
            _centerLeft.DrawSelf(g, attribute);
            contentPanel.BackgroundImage = _centerMiddle.BackgroundBitmap;  //中间的背景色用内容panel背景代替
            _centerRight.DrawSelf(g, attribute);
            _bottomLeft.DrawSelf(g, null);
            _bottomMiddle.DrawSelf(g, attribute);
            _bottomRight.DrawSelf(g, null);

            attribute.Dispose();  //释放资源

            #endregion

            #region 绘制标题和LOGO

            //绘制标题
            if (!string.IsNullOrEmpty(Text))
            {
                g.DrawString(Text, Font, new SolidBrush(ForeColor),
                             ShowIcon ? new Point(_titlePoint.X + 18, _titlePoint.Y) : _titlePoint);
            }

            //绘制图标
            if (ShowIcon)
            {
                g.DrawIcon(Icon, new Rectangle(4, 4, 18, 18));
            }

            #endregion
        }

        private void NormalWindow()
        {
            Hide();

            Left = _orginX;
            Top = _orginY;
            Width = _orginWidth;
            Height = _orginHeight;
            _formState = FormState.Normal;

            Application.DoEvents();
            Show();
        }

        private void MaxWindow()
        {
            Hide();

            //最大化之前记录窗口信息便于缩小
            _orginHeight = Height;
            _orginWidth = Width;
            _orginX = Location.X;
            _orginY = Location.Y;

            Width = Screen.PrimaryScreen.WorkingArea.Width + 4;
            Height = Screen.PrimaryScreen.WorkingArea.Height + 4;
            Top = -1;
            Left = -1;

            _formState = FormState.Max;

            Application.DoEvents();
            Show();
        }

        /// <summary>
        /// 获得所有皮肤名字
        /// </summary>
        /// <returns></returns>
        protected static List<string> GetAllSkinName()
        {
            List<string> list = new List<string>();
            string skinFloder = Application.StartupPath + "\\Skin";
            if (Directory.Exists(skinFloder))
            {
                string[] strs = Directory.GetDirectories(skinFloder);
                for (int i = 0; i < strs.Length; i++)
                {
                    if (File.Exists(strs[i] + "\\config.ini"))   //存在配置文件则认为皮肤有效
                    {
                        string name = strs[i].Substring(strs[i].LastIndexOf('\\') + 1);
                        list.Add(name);
                    }
                }
            }
            return list;
        }

        protected virtual void ChangeSkin(string skinName)
        {
            //读取配置文件
            _skinFolder = Application.StartupPath + @"\Skin\" + skinName;
            IniHelper.skinName = skinName;
            if (ReadIniFile(_skinFolder))  //成功读取皮肤配置文件
            {
                if (_formState == FormState.Max)
                {
                    NormalWindow();  //窗体恢复正常
                }
                CaculatePartLocation();

                IniHelper.ChangeSkin(_skinFolder);
                SetImages();
                TransparencyKey = IniHelper.trans;   //透明处理
                Invalidate();
            }
            SkinChanged();
        }

        #endregion
    }
}
