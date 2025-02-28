﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using System.Text;
using QLFUI;
using GUIResource;

namespace MagicMongoDBTool
{
    public partial class frmMain : QLFUI.QLFForm
    {
        #region"主程序"
        public frmMain()
        {
            InitializeComponent();
            GetSystemIcon.InitMainTreeImage();
            trvsrvlst.ImageList = GetSystemIcon.MainTreeImage;
            SetMenuImage();
            if (SystemManager.ConfigHelperInstance.currentLanguage != StringResource.Language.Default)
            {
                SetMenuText();
            }
            //初始化ToolBar
            InitToolBar();
            //设定工具栏
            SetToolBarEnabled();

            this.menuStripMain.BackgroundImage = QLFUI.IniHelper.getImage("_topMiddle");
            this.toolStripMain.BackgroundImage = QLFUI.IniHelper.getImage("_topMiddle");
            this.statusStripMain.BackgroundImage = QLFUI.IniHelper.getImage("_topMiddle");
            this.splitContainer1.BackColor = QLFUI.IniHelper.BackColor;
            this.SkinChanged += new SkinChangedEventHandler(() =>
            {
                this.menuStripMain.BackgroundImage = QLFUI.IniHelper.getImage("_topMiddle");
                this.toolStripMain.BackgroundImage = QLFUI.IniHelper.getImage("_topMiddle");
                this.statusStripMain.BackgroundImage = QLFUI.IniHelper.getImage("_topMiddle");
                this.splitContainer1.BackColor = System.Drawing.Color.GreenYellow;
                this.splitContainer1.BackColor = QLFUI.IniHelper.BackColor;
            });
            if (SystemManager.DEBUG_MODE)
            {
                //测试用自动连接
                List<ConfigHelper.MongoConnectionConfig> connLst = new List<ConfigHelper.MongoConnectionConfig>();
                connLst.Add(SystemManager.ConfigHelperInstance.ConnectionList["Master"]);
                MongoDBHelper.AddServer(connLst);
                RefreshToolStripMenuItem_Click(null, null);
            }
        }
        /// <summary>
        /// 设置文字
        /// </summary>
        private void SetMenuText()
        {

            //管理
            this.ManagerToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt);
            this.AddConnectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_AddConnection);
            this.RefreshToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Refresh);
            this.SrvStatusToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);
            this.ExpandAllConnectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Expansion);
            this.CollapseAllConnectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Collapse);
            this.ExitToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Exit);

            //数据视图
            this.DataNaviToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView);
            this.PrePageToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Previous);
            this.NextPageToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Next);
            this.FirstPageToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_First);
            this.LastPageToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Last);

            this.QueryDataToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Query);
            this.ConvertSqlToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_ConvertSql);
            this.AggregationToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Aggregation);
            this.DataFilterToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_DataFilter);
            
            this.CollapseAllDataToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Collapse);
            this.ExpandAllDataToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Expansion);


            //Operation
            this.OperationToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation);
            
            this.ServerToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server);
            this.CreateMongoDBToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_NewDB);
            this.AddUserToAdminToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_AddUserToAdmin);
            this.RemoveUserFromAdminToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_DelFromAdmin);
            this.ShutDownToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_CloseServer);
            this.SvrPropertyToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_Properties);

            this.DataBaseToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database);
            this.DelMongoDBToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_DelDB);
            this.CreateMongoCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_AddDC);
            this.AddUserToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_AddUser);
            this.RemoveUserToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_DelUser);
            this.evalJSToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_EvalJs);

            this.DataCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection);
            this.DelMongoCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_DelDC);
            this.RenameCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_Rename);
            this.IndexManageToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_Index);
            this.ReIndexToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_ReIndex);
            this.DelSelectRecordToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_DelSelect);

            this.GridFsToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem);
            this.DelFileToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_Del);
            this.UploadFileToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_Upload);
            this.DownloadFileToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_Download);
            this.OpenFileToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_Open);
            this.InitGFSToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_InitGFS);

            this.DumpAndRestoreToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore);
            this.RestoreMongoToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Restore);
            this.DumpCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_BackupDC);
            this.DumpDatabaseToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_BackupDB);
            this.ImportCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Import);
            this.ExportCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Export);

            //Tool
            this.ToolsToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Tool);
            this.DosCommandToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Tool_DOS);
            this.ImportDataFromAccessToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Tool_Access);
            this.OptionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Tool_Setting);

            
            //分布式
            this.DistributedToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Distributed);
            this.ReplicaSetToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Distributed_ReplicaSet);
            this.ShardingConfigToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Distributed_ShardingConfig);

            //帮助
            this.HelpToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Help);
            this.AboutToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Help_About);
            this.ThanksToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Help_Thanks);

            //就绪
            this.statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_StatusBar_Text_Ready);
            //数据显示区
            this.tabTreeView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Tree);
            this.tabTableView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Table);
            this.tabTextView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Text);
        }
        /// <summary>
        /// 数据展示
        /// </summary>
        private List<Control> _dataShower = new List<Control>();
        /// <summary>
        /// 数据展示控件
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.menuStripMain.Renderer = new CRD.WinUI.Misc.ToolStripRenderer(new ProfessionalColorTable());

            this.trvsrvlst.NodeMouseClick += new TreeNodeMouseClickEventHandler(trvsrvlst_NodeMouseClick);
            this.lstData.MouseClick += new MouseEventHandler(lstData_MouseClick);
            this.lstData.MouseDoubleClick += new MouseEventHandler(lstData_MouseDoubleClick);
            this.lstData.SelectedIndexChanged += new EventHandler(lstData_SelectedIndexChanged);
            this.trvData.MouseClick += new MouseEventHandler(trvData_MouseClick);
            this.trvData.AfterSelect += new TreeViewEventHandler(trvData_AfterSelect);
            this.tabDataShower.SelectedIndexChanged += new EventHandler(
                //变换TAB时候，选中项目自动消失，所以删除数据也消失
                    (x, y) =>
                    {
                        this.DelSelectRecordToolStripMenuItem.Enabled = false;
                    }
                );
            DisableAllOpr();
            _dataShower.Add(lstData);
            _dataShower.Add(trvData);
            _dataShower.Add(txtData);
            DataNaviToolStripLabel.Text = string.Empty;
        }
        /// <summary>
        /// 鼠标选中节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvsrvlst_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            String strNodeType = String.Empty;
            if (this.trvData.SelectedNode != null)
            {
                this.trvData.SelectedNode.ContextMenuStrip = null;
            }
            if (e.Node.ImageIndex != -1)
            {
                statusStripMain.Items[0].Image = GetSystemIcon.MainTreeImage.Images[e.Node.ImageIndex];
            }
            if (e.Node.Tag != null)
            {
                //选中节点的设置
                this.trvsrvlst.SelectedNode = e.Node;
                //先禁用所有的操作，然后根据选中对象解禁
                DisableAllOpr();
                //恢复数据：这个操作可以针对服务器，数据库，数据集，所以可以放在共通
                this.RestoreMongoToolStripMenuItem.Enabled = true;
                strNodeType = e.Node.Tag.ToString().Split(":".ToCharArray())[0];
                if (!(strNodeType == MongoDBHelper.DOCUMENT_TAG && e.Button == System.Windows.Forms.MouseButtons.Right))
                {
                    clearDataShower();
                }
                switch (strNodeType)
                {
                    case MongoDBHelper.INDEX_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中索引:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelper.INDEXES_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中索引集:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];

                        if (!MongoDBHelper.IsSystemCollection(SystemManager.GetCurrentCollection()))
                        {
                            this.IndexManageToolStripMenuItem.Enabled = true;
                            this.ReIndexToolStripMenuItem.Enabled = true;
                        }
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            this.contextMenuStripMain.Renderer = menuStripMain.Renderer;
                            this.contextMenuStripMain.Items.Add(this.IndexManageToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ReIndexToolStripMenuItem.Clone());
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show();
                        }
                        break;
                    case MongoDBHelper.DOCUMENT_TAG:
                        //BsonDocument
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中数据:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            SetDataNav();
                            this.contextMenuStripMain = new ContextMenuStrip();
                            this.contextMenuStripMain.Renderer = menuStripMain.Renderer;
                            this.contextMenuStripMain.Items.Add(this.countToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.distinctToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.groupToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.mapReduceToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.QueryDataToolStripMenuItem.Clone());
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show();
                        }
                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            MongoDBHelper.IsUseFilter = false;
                            this.DataFilterToolStripMenuItem.Checked = MongoDBHelper.IsUseFilter;
                            SystemManager.CurrDataFilter.Clear();
                            RefreshData();
                        }
                        break;
                    case MongoDBHelper.GRID_FILE_SYSTEM_TAG:
                        //GridFileSystem
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "文件系统:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];

                        MongoDBHelper.IsUseFilter = false;
                        this.DataFilterToolStripMenuItem.Checked = MongoDBHelper.IsUseFilter;
                        SystemManager.CurrDataFilter.Clear();
                        RefreshData();

                        UploadFileToolStripMenuItem.Enabled = true;
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            this.contextMenuStripMain.Renderer = menuStripMain.Renderer;
                            this.contextMenuStripMain.Items.Add(this.UploadFileToolStripMenuItem.Clone());
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show();
                        }
                        break;
                    case MongoDBHelper.USER_LIST_TAG:
                        //BsonDocument
                        MongoDBHelper.FillDataToControl(e.Node.Tag.ToString(), _dataShower);
                        SetDataNav();
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "用户列表:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelper.SINGLE_DB_SERVICE_TAG:
                        //单数据库模式,禁止所有服务器操作
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中服务器[单数据库]:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelper.SERVICE_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中服务器:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        //解禁 创建数据库,关闭服务器
                        this.CreateMongoDBToolStripMenuItem.Enabled = true;
                        this.ImportDataFromAccessToolStripMenuItem.Enabled = true;
                        this.ShutDownToolStripMenuItem.Enabled = true;
                        this.AddUserToAdminToolStripMenuItem.Enabled = true;
                        this.RemoveUserFromAdminToolStripMenuItem.Enabled = true;
                        this.SvrPropertyToolStripMenuItem.Enabled = true;

                        if (SystemManager.GetSelectedSvrProByName().ServerType == ConfigHelper.SvrType.ReplsetSvr)
                        {
                            //副本服务器专用。
                            //副本初始化的操作 改在连接设置里面完成
                            this.ReplicaSetToolStripMenuItem.Enabled = true;
                        }
                        if (SystemManager.GetSelectedSvrProByName().ServerType == ConfigHelper.SvrType.RouteSvr)
                        {
                            //Route用
                            this.ShardingConfigToolStripMenuItem.Enabled = true;
                        }
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            this.contextMenuStripMain.Renderer = menuStripMain.Renderer;
                            this.contextMenuStripMain.Items.Add(this.CreateMongoDBToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.AddUserToAdminToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.RemoveUserFromAdminToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ImportDataFromAccessToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ReplicaSetToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ShardingConfigToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ShutDownToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.SvrPropertyToolStripMenuItem.Clone());
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show();
                        }
                        break;
                    case MongoDBHelper.DATABASE_TAG:
                    case MongoDBHelper.SINGLE_DATABASE_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中数据库:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        //解禁 删除数据库 创建数据集
                        if (!MongoDBHelper.IsSystemDataBase(SystemManager.GetCurrentDataBase()))
                        {
                            //系统库不允许修改
                            this.DelMongoDBToolStripMenuItem.Enabled = true;
                            this.CreateMongoCollectionToolStripMenuItem.Enabled = true;
                            this.AddUserToolStripMenuItem.Enabled = true;
                            this.RemoveUserToolStripMenuItem.Enabled = true;
                            this.evalJSToolStripMenuItem.Enabled = true;
                            this.InitGFSToolStripMenuItem.Enabled = true;
                            this.ConvertSqlToolStripMenuItem.Enabled = true;
                        }
                        //备份数据库
                        this.DumpDatabaseToolStripMenuItem.Enabled = true;

                        if (strNodeType == MongoDBHelper.SINGLE_DATABASE_TAG)
                        {
                            //单一数据库模式
                            this.DelMongoDBToolStripMenuItem.Enabled = false;
                        }

                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            this.contextMenuStripMain.Renderer = menuStripMain.Renderer;
                            this.contextMenuStripMain.Items.Add(this.DelMongoDBToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.CreateMongoCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.AddUserToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.RemoveUserToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.evalJSToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.InitGFSToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.DumpDatabaseToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ConvertSqlToolStripMenuItem.Clone());

                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show();
                        }
                        break;
                    case MongoDBHelper.COLLECTION_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中数据集:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        //解禁 删除数据集
                        if (!MongoDBHelper.IsSystemCollection(SystemManager.GetCurrentCollection()))
                        {
                            //系统数据库无法删除！！
                            this.DelMongoCollectionToolStripMenuItem.Enabled = true;
                            this.RenameCollectionToolStripMenuItem.Enabled = true;
                        }
                        this.DumpCollectionToolStripMenuItem.Enabled = true;
                        this.ImportCollectionToolStripMenuItem.Enabled = true;
                        this.ExportCollectionToolStripMenuItem.Enabled = true;

                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            this.contextMenuStripMain.Renderer = menuStripMain.Renderer;
                            this.contextMenuStripMain.Items.Add(this.DelMongoCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.RenameCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.DumpCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ImportCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ExportCollectionToolStripMenuItem.Clone());

                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show();
                        }
                        break;
                    default:
                        SystemManager.SelectObjectTag = "";
                        statusStripMain.Items[0].Text = "选中对象:" + e.Node.Text;
                        break;
                }
            }
            else
            {
                statusStripMain.Items[0].Text = "选中对象:" + e.Node.Text;
            }
            //重新Reset工具栏
            SetToolBarEnabled();
            if (strNodeType != MongoDBHelper.DOCUMENT_TAG)
            {
                DataNaviToolStripLabel.Text = String.Empty;
            }
        }
        /// <summary>
        /// 禁止所有操作
        /// </summary>
        private void DisableAllOpr()
        {
            //管理-服务器
            this.CreateMongoDBToolStripMenuItem.Enabled = false;
            this.AddUserToAdminToolStripMenuItem.Enabled = false;
            this.RemoveUserFromAdminToolStripMenuItem.Enabled = false;
            this.SvrPropertyToolStripMenuItem.Enabled = false;
            this.ShutDownToolStripMenuItem.Enabled = false;

            //管理-数据库
            this.CreateMongoCollectionToolStripMenuItem.Enabled = false;
            this.DelMongoDBToolStripMenuItem.Enabled = false;
            this.AddUserToolStripMenuItem.Enabled = false;
            this.RemoveUserToolStripMenuItem.Enabled = false;
            this.evalJSToolStripMenuItem.Enabled = false;

            //管理-数据集
            this.IndexManageToolStripMenuItem.Enabled = false;
            this.ReIndexToolStripMenuItem.Enabled = false;
            this.RenameCollectionToolStripMenuItem.Enabled = false;
            this.DelMongoCollectionToolStripMenuItem.Enabled = false;
            this.DelSelectRecordToolStripMenuItem.Enabled = false;

            //管理-GFS
            this.UploadFileToolStripMenuItem.Enabled = false;
            this.DownloadFileToolStripMenuItem.Enabled = false;
            this.OpenFileToolStripMenuItem.Enabled = false;
            this.DelFileToolStripMenuItem.Enabled = false;
            this.InitGFSToolStripMenuItem.Enabled = false;

            //管理-备份和恢复
            this.DumpDatabaseToolStripMenuItem.Enabled = false;
            this.RestoreMongoToolStripMenuItem.Enabled = false;
            this.DumpCollectionToolStripMenuItem.Enabled = false;
            this.ImportCollectionToolStripMenuItem.Enabled = false;
            this.ExportCollectionToolStripMenuItem.Enabled = false;

            //数据导航
            this.FirstPageToolStripMenuItem.Enabled = false;
            this.FirstPageToolStripButton.Enabled = false;
            this.LastPageToolStripMenuItem.Enabled = false;
            this.LastPageToolStripButton.Enabled = false;
            this.NextPageToolStripMenuItem.Enabled = false;
            this.NextPageToolStripButton.Enabled = false;
            this.PrePageToolStripMenuItem.Enabled = false;
            this.PrePageToolStripButton.Enabled = false;
            this.QueryDataToolStripMenuItem.Enabled = false;
            this.QueryDataToolStripButton.Enabled = false;
            this.ConvertSqlToolStripMenuItem.Enabled = false;


            this.ExpandAllDataToolStripMenuItem.Enabled = false;
            this.CollapseAllDataToolStripMenuItem.Enabled = false;
            this.DataFilterToolStripMenuItem.Enabled = false;
            this.DataFilterToolStripMenuItem.Checked = false;
            this.DataFilterToolStripButton.Enabled = false;
            this.DataFilterToolStripButton.Checked = false;
            this.AggregationToolStripMenuItem.Enabled = false;


            //工具
            this.ImportDataFromAccessToolStripMenuItem.Enabled = false;
            this.ImportDataFromAccessToolStripButton.Enabled = false;

            //分布式
            this.ReplicaSetToolStripMenuItem.Enabled = false;
            this.ShardingConfigToolStripMenuItem.Enabled = false;
        }
        #endregion

        #region"数据展示区操作"
        /// <summary>
        /// 数据列表选中索引变换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SystemManager.GetCurrentCollection().Name == MongoDBHelper.COLLECTION_NAME_GFS_FILES)
            {
                //文件系统
                UploadFileToolStripMenuItem.Enabled = true;
                switch (lstData.SelectedItems.Count)
                {
                    case 0:
                        //禁止所有操作
                        DownloadFileToolStripMenuItem.Enabled = false;
                        OpenFileToolStripMenuItem.Enabled = false;
                        DelFileToolStripMenuItem.Enabled = false;
                        lstData.ContextMenuStrip = null;
                        break;
                    case 1:
                        //可以进行所有操作
                        DownloadFileToolStripMenuItem.Enabled = true;
                        OpenFileToolStripMenuItem.Enabled = true;
                        DelFileToolStripMenuItem.Enabled = true;
                        break;
                    default:
                        //可以删除多个文件
                        DownloadFileToolStripMenuItem.Enabled = false;
                        OpenFileToolStripMenuItem.Enabled = false;
                        DelFileToolStripMenuItem.Enabled = true;
                        break;
                }
            }
            else
            {
                //数据系统
                if (lstData.SelectedItems.Count > 0)
                {
                    if (!MongoDBHelper.IsSystemCollection(SystemManager.GetCurrentCollection()))
                    {
                        //系统数据禁止删除
                        DelSelectRecordToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        DelSelectRecordToolStripMenuItem.Enabled = false;
                    }
                }
                else
                {
                    DelSelectRecordToolStripMenuItem.Enabled = false;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SystemManager.GetCurrentCollection().Name == MongoDBHelper.COLLECTION_NAME_GFS_FILES)
            {
                String strFileName = lstData.SelectedItems[0].Text;
                MongoDBHelper.OpenFile(strFileName);
            }
        }
        /// <summary>
        /// 数据列表右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstData_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstData.SelectedItems.Count > 0)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this.contextMenuStripMain = new ContextMenuStrip();
                    this.contextMenuStripMain.Renderer = menuStripMain.Renderer;
                    if (SystemManager.GetCurrentCollection().Name == MongoDBHelper.COLLECTION_NAME_GFS_FILES)
                    {
                        //文件系统
                        this.contextMenuStripMain.Items.Add(this.DownloadFileToolStripMenuItem.Clone());
                        this.contextMenuStripMain.Items.Add(this.OpenFileToolStripMenuItem.Clone());
                        this.contextMenuStripMain.Items.Add(this.DelFileToolStripMenuItem.Clone());
                    }
                    else
                    {
                        this.contextMenuStripMain.Items.Add(this.DelSelectRecordToolStripMenuItem.Clone());
                    }
                    lstData.ContextMenuStrip = this.contextMenuStripMain;
                    contextMenuStripMain.Show();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvData.SelectedNode.Level == 0)
            {
                //顶层可以删除的节点
                DelSelectRecordToolStripMenuItem.Enabled = true;
            }
            else
            {
                DelSelectRecordToolStripMenuItem.Enabled = false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_MouseClick(object sender, MouseEventArgs e)
        {
            TreeNode node = this.trvData.GetNodeAt(e.Location);
            trvData.SelectedNode = node;
            if (trvData.SelectedNode != null && trvData.SelectedNode.Level == 0)
            {
                DelSelectRecordToolStripMenuItem.Enabled = true;
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this.contextMenuStripMain = new ContextMenuStrip();
                    this.contextMenuStripMain.Renderer = menuStripMain.Renderer;
                    this.contextMenuStripMain.Items.Add(this.DelSelectRecordToolStripMenuItem.Clone());
                    trvData.ContextMenuStrip = this.contextMenuStripMain;
                    contextMenuStripMain.Show();
                }
            }
        }
        /// <summary>
        /// 清除数据显示区
        /// </summary>
        private void clearDataShower()
        {
            lstData.Clear();
            txtData.Text = "";
            trvData.Nodes.Clear();
            lstData.ContextMenuStrip = null;
            trvData.ContextMenuStrip = null;
            this.contextMenuStripMain = null;
        }
        #endregion

        #region"数据库连接"
        /// <summary>
        /// 添加数据库连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmConnect());
            RefreshToolStripMenuItem_Click(sender, e);
        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableAllOpr();
            clearDataShower();
            MongoDBHelper.FillMongoServiceToTreeView(trvsrvlst);
        }
        /// <summary>
        /// 服务器状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SrvStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmServiceStatus());
        }
        /// <summary>
        /// 展开所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.trvsrvlst.ExpandAll();
        }
        /// <summary>
        /// 折叠所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.trvsrvlst.CollapseAll();
        }
        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region"工具"
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmOption());
        }
        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportDataFromAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog AccessFile = new OpenFileDialog();
            if (AccessFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoDBHelper.ImportAccessDataBase(AccessFile.FileName, SystemManager.SelectObjectTag, trvsrvlst.SelectedNode);
            }
        }
        /// <summary>
        /// DOS控制台
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DosCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmDosCommand());
        }
        #endregion

        #region"管理：服务器"
        /// <summary>
        /// 建立数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateMongoDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strPath = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            String strDBName = Microsoft.VisualBasic.Interaction.InputBox("请输入数据库名称：", "创建数据库");
            if (strDBName != string.Empty)
            {
                if (MongoDBHelper.DataBaseOpration(SystemManager.SelectObjectTag, strDBName, MongoDBHelper.Oprcode.Create, trvsrvlst.SelectedNode))
                {
                    DisableAllOpr();
                    lstData.Clear();
                }
            }
        }
        /// <summary>
        /// 建立Admin用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserToAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmUser());
        }
        /// <summary>
        /// 删除Admin用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUserFromAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //@那一剑风情 提出的删除前确认
            String strUserName = Microsoft.VisualBasic.Interaction.InputBox("请输入用户名：", "移除用户");
            if (MyMessageBox.ShowConfirm("确认", "删除Admin确认"))
            {
                MongoDBHelper.RemoveUserFromSvr(SystemManager.SelectObjectTag, strUserName);
            }
        }
        /// <summary>
        /// 服务器属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SvrPropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMessageBox.ShowMessage("服务器属性", "服务器属性", MongoDBHelper.GetCurrentSvrInfo(), true);
        }
        /// <summary>
        /// 关闭服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShutDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO:可能有异常
            MongoDBHelper.Shutdown();
            trvsrvlst.Nodes.Remove(trvsrvlst.SelectedNode);
        }
        #endregion

        #region"管理：数据库"

        /// <summary>
        /// 删除MongoDB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelMongoDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //@那一剑风情 提出的删除前确认
            if (MyMessageBox.ShowConfirm("确认", "删除数据库确认"))
            {
                String strPath = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                String strDBName = strPath.Split("/".ToCharArray())[1];
                if (trvsrvlst.SelectedNode == null)
                {
                    trvsrvlst.SelectedNode = null;
                }
                if (MongoDBHelper.DataBaseOpration(SystemManager.SelectObjectTag, strDBName, MongoDBHelper.Oprcode.Drop, trvsrvlst.SelectedNode))
                {
                    DisableAllOpr();
                    lstData.Clear();
                }

            }
        }
        /// <summary>
        /// 建立数据集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateMongoCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strCollection = Microsoft.VisualBasic.Interaction.InputBox("请输入数据集名称：", "创建数据集");
            if (strCollection == string.Empty)
            {
                return;
            }
            if (MongoDBHelper.CollectionOpration(SystemManager.SelectObjectTag, strCollection, MongoDBHelper.Oprcode.Create, trvsrvlst.SelectedNode))
            {
                DisableAllOpr();
                lstData.Clear();
            }
        }
        /// <summary>
        /// 建立用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmUser());
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //@那一剑风情 提出的删除前确认
            if (MyMessageBox.ShowConfirm("确认", "删除用户确认"))
            {
                String strUserName = Microsoft.VisualBasic.Interaction.InputBox("请输入用户名：", "移除用户");
                MongoDBHelper.RemoveUserFromDB(SystemManager.SelectObjectTag, strUserName);
            }
        }
        /// <summary>
        /// 执行JS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void evalJSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmevalJS());
        }
        /// <summary>
        /// 转换Sql到Query
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertSqlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmConvertSql());
        }
        #endregion

        #region"管理：数据集"
        /// <summary>
        /// 删除Mongo数据集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelMongoCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //@那一剑风情 提出的删除前确认
            if (MyMessageBox.ShowConfirm("确认", "删除数据库确认"))
            {
                String strPath = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                String strCollection = strPath.Split("/".ToCharArray())[2];
                if (trvsrvlst.SelectedNode == null)
                {
                    trvsrvlst.SelectedNode = null;
                }
                if (MongoDBHelper.CollectionOpration(SystemManager.SelectObjectTag, strCollection, MongoDBHelper.Oprcode.Drop, trvsrvlst.SelectedNode))
                {
                    DisableAllOpr();
                    clearDataShower();
                }
            }
        }
        /// <summary>
        /// 重命名数据集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RenameCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strPath = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            String strCollection = strPath.Split("/".ToCharArray())[2];
            String strNewCollectionName = Microsoft.VisualBasic.Interaction.InputBox("请输入新数据集名称：", "数据集改名");
            if (MongoDBHelper.CollectionOpration(SystemManager.SelectObjectTag, strCollection, MongoDBHelper.Oprcode.Rename, trvsrvlst.SelectedNode, strNewCollectionName))
            {
                DisableAllOpr();
                clearDataShower();
                SystemManager.SelectObjectTag = trvsrvlst.SelectedNode.Tag.ToString();
                statusStripMain.Items[0].Text = "选中数据集:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            }
        }
        /// <summary>
        /// 索引管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IndexManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmCollectionIndex());
        }
        /// <summary>
        /// 重新索引
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.GetCurrentCollection().ReIndex();
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //@那一剑风情 提出的删除前确认
            if (MyMessageBox.ShowConfirm("确认", "删除数据确认"))
            {
                if (tabDataShower.SelectedTab == tabTableView)
                {
                    //lstData
                    String strKey = lstData.Columns[0].Text;
                    foreach (ListViewItem item in lstData.SelectedItems)
                    {
                        MongoDBHelper.DropRecord(SystemManager.GetCurrentCollection(), item.Tag, strKey);
                    }
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    String strKey = trvData.SelectedNode.Text.Split(":".ToCharArray())[0];
                    MongoDBHelper.DropRecord(SystemManager.GetCurrentCollection(), trvData.SelectedNode.Tag, strKey);
                    trvData.ContextMenuStrip = null;
                }
                DelSelectRecordToolStripMenuItem.Enabled = false;
                RefreshData();
            }
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshData()
        {
            clearDataShower();
            MongoDBHelper.FillDataToControl(SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }
        #endregion

        #region"管理：GFS"
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog upfile = new OpenFileDialog();
            if (upfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoDBHelper.UpLoadFile(upfile.FileName);
            }
            RefreshData();
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog downfile = new SaveFileDialog();
            String strFileName = lstData.SelectedItems[0].Text;
            downfile.FileName = strFileName.Split(@"\".ToCharArray())[strFileName.Split(@"\".ToCharArray()).Length - 1];
            if (downfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoDBHelper.DownloadFile(downfile.FileName, strFileName);
            }
        }
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strFileName = lstData.SelectedItems[0].Text;
            MongoDBHelper.OpenFile(strFileName);
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //@那一剑风情 提出的删除前确认
            if (MyMessageBox.ShowConfirm("确认", "删除文件确认"))
            {
                String strFileName = lstData.SelectedItems[0].Text;
                MongoDBHelper.DelFile(strFileName);
                RefreshData();
            }
        }
        private void InitGFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.InitGFS();
        }
        #endregion

        #region"管理：备份和恢复"
        /// <summary>
        /// 检查MongoDB执行目录是否存在
        /// </summary>
        /// <returns></returns>
        private Boolean MongoPathCheck()
        {
            if (!MongodbDosCommand.IsMongoPathExist())
            {
                MyMessageBox.ShowMessage("异常",
                                         "Mongo目录没有找到，请确认",
                                         "Mongo目录[" + SystemManager.ConfigHelperInstance.MongoBinPath + "]没有找到，请重新设置。");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 执行DOS命令
        /// </summary>
        /// <param name="DosCommand"></param>
        private void RunCommand(String DosCommand)
        {
            StringBuilder Info = new StringBuilder();
            MongodbDosCommand.RunDosCommand(DosCommand, Info);
            MyMessageBox.ShowMessage("DOS", "Dos命令执行结果：", Info.ToString(), true);
        }
        /// <summary>
        /// 恢复数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestoreMongoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //@那一剑风情 提出的删除前确认
            if (MyMessageBox.ShowConfirm("确认", "恢复数据确认"))
            {
                if (!MongoPathCheck()) { return; }
                MongodbDosCommand.StruMongoRestore MongoRestore = new MongodbDosCommand.StruMongoRestore();
                MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentService().Instance;
                MongoRestore.HostAddr = Mongosrv.Address.Host;
                MongoRestore.Port = Mongosrv.Address.Port;
                FolderBrowserDialog dumpFile = new FolderBrowserDialog();
                if (dumpFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MongoRestore.DirectoryPerDB = dumpFile.SelectedPath;
                }
                String DosCommand = MongodbDosCommand.GetMongoRestoreCommandLine(MongoRestore);
                RunCommand(DosCommand);
                RefreshToolStripMenuItem_Click(null, null);
            }
        }
        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DumpDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MongoPathCheck()) { return; }
            MongodbDosCommand.StruMongoDump MongoDump = new MongodbDosCommand.StruMongoDump();
            MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentService().Instance;
            MongoDump.HostAddr = Mongosrv.Address.Host;
            MongoDump.Port = Mongosrv.Address.Port;
            MongoDump.DBName = SystemManager.GetCurrentDataBase().Name;
            FolderBrowserDialog dumpFile = new FolderBrowserDialog();
            if (dumpFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoDump.OutPutPath = dumpFile.SelectedPath;
            }
            String DosCommand = MongodbDosCommand.GetMongodumpCommandLine(MongoDump);
            RunCommand(DosCommand);
        }
        /// <summary>
        /// 备份数据集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DumpCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MongoPathCheck()) { return; }
            MongodbDosCommand.StruMongoDump MongoDump = new MongodbDosCommand.StruMongoDump();
            MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentService().Instance;
            MongoDump.HostAddr = Mongosrv.Address.Host;
            MongoDump.Port = Mongosrv.Address.Port;
            MongoDump.DBName = SystemManager.GetCurrentDataBase().Name;
            MongoDump.CollectionName = SystemManager.GetCurrentCollection().Name;
            FolderBrowserDialog dumpFile = new FolderBrowserDialog();
            if (dumpFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoDump.OutPutPath = dumpFile.SelectedPath;
            }
            String DosCommand = MongodbDosCommand.GetMongodumpCommandLine(MongoDump);
            RunCommand(DosCommand);
        }
        /// <summary>
        /// 导出数据集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MongoPathCheck()) { return; }
            MongodbDosCommand.StruImportExport MongoImportExport = new MongodbDosCommand.StruImportExport();
            MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentService().Instance;
            MongoImportExport.HostAddr = Mongosrv.Address.Host;
            MongoImportExport.Port = Mongosrv.Address.Port;
            MongoImportExport.DBName = SystemManager.GetCurrentDataBase().Name;
            MongoImportExport.CollectionName = SystemManager.GetCurrentCollection().Name;
            OpenFileDialog dumpFile = new OpenFileDialog();
            if (dumpFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoImportExport.FileName = dumpFile.FileName;
            }
            MongoImportExport.Direct = MongodbDosCommand.ImprotExport.Export;
            String DosCommand = MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExport);
            RunCommand(DosCommand);
        }
        /// <summary>
        /// 导入数据集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //@那一剑风情 提出的删除前确认
            if (MyMessageBox.ShowConfirm("确认", "导入数据集确认"))
            {
                if (!MongoPathCheck()) { return; }
                MongodbDosCommand.StruImportExport MongoImportExport = new MongodbDosCommand.StruImportExport();
                MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentService().Instance;
                MongoImportExport.HostAddr = Mongosrv.Address.Host;
                MongoImportExport.Port = Mongosrv.Address.Port;
                MongoImportExport.DBName = SystemManager.GetCurrentDataBase().Name;
                MongoImportExport.CollectionName = SystemManager.GetCurrentCollection().Name;
                OpenFileDialog dumpFile = new OpenFileDialog();
                if (dumpFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MongoImportExport.FileName = dumpFile.FileName;
                }
                MongoImportExport.Direct = MongodbDosCommand.ImprotExport.Import;
                String DosCommand = MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExport);
                RunCommand(DosCommand);
            }
        }
        #endregion

        #region"分布式"
        /// <summary>
        /// 副本管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReplicaSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmReplset());
        }
        /// <summary>
        /// 分片管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShardConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmShardingConfig());
        }

        #endregion

        #region"数据导航"
        private void PrePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.PrePage, SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }

        private void NextPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.NextPage, SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }

        private void FirstPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.FirstPage, SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }

        private void LastPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.LastPage, SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }
        private void ExpandAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trvData.ExpandAll();
        }

        private void CollapseAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trvData.CollapseAll();
        }
        private void QueryDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmQuery());
            this.DataFilterToolStripMenuItem.Checked = MongoDBHelper.IsUseFilter;
            //重新展示数据
            MongoDBHelper.FillDataToControl(SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }
        #region"聚合"
        /// <summary>
        /// Count
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void countToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SystemManager.CurrDataFilter.QueryConditionList.Count == 0)
            {
                MyMessageBox.ShowMessage("Count", "Count:" + SystemManager.GetCurrentCollection().Count().ToString());
            }
            else
            {
                MongoDB.Driver.IMongoQuery mQuery = MongoDBHelper.GetQuery(SystemManager.CurrDataFilter.QueryConditionList);
                MyMessageBox.ShowMessage("Count",
                "Count:" + SystemManager.GetCurrentCollection().Count(mQuery).ToString(),
                mQuery.ToString(), true);
            }
        }
        /// <summary>
        /// Distinct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void distinctToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmDistinct());
        }
        /// <summary>
        /// Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmGroup());
        }
        /// <summary>
        /// MapReduce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapReduceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmMapReduce());
        }
        #endregion
        /// <summary>
        /// 过滤切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.IsUseFilter = !MongoDBHelper.IsUseFilter;
            this.DataFilterToolStripMenuItem.Checked = MongoDBHelper.IsUseFilter;
            //过滤变更后，重新刷新
            MongoDBHelper.SkipCnt = 0;
            RefreshData();
        }
        /// <summary>
        /// 设置导航可用性
        /// </summary>
        private void SetDataNav()
        {
            PrePageToolStripMenuItem.Enabled = MongoDBHelper.HasPrePage;
            NextPageToolStripMenuItem.Enabled = MongoDBHelper.HasNextPage;
            FirstPageToolStripMenuItem.Enabled = MongoDBHelper.HasPrePage;
            LastPageToolStripMenuItem.Enabled = MongoDBHelper.HasNextPage;
            this.QueryDataToolStripMenuItem.Enabled = true;

            this.ExpandAllDataToolStripMenuItem.Enabled = true;
            this.CollapseAllDataToolStripMenuItem.Enabled = true;
            this.DataFilterToolStripMenuItem.Enabled = true;
            this.AggregationToolStripMenuItem.Enabled = true;
            SetToolBarEnabled();
            DataNaviToolStripLabel.Text = "数据视图：" + (MongoDBHelper.SkipCnt + 1).ToString() + "/" + MongoDBHelper.CurrentCollectionTotalCnt.ToString();
        }
        #endregion

        #region "帮助"
        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMessageBox.ShowMessage("关于", "MagicMongoDBTool",
                                     GUIResource.GetResource.GetImage(GUIResource.ImageType.Smile),
                                     "GitHub地址： https://github.com/magicdict/MagicMongoDBTool");
        }
        /// <summary>
        /// 感谢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThanksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strThanks = "感谢皮肤控件的作者：qianlifeng\r\n";
            strThanks += "感谢10gen的C# Driver开发者的技术支持\r\n";
            strThanks += "感谢Dragon同志的测试和代码规范化";
            strThanks += "感谢MoLing同志的国际化";
            MyMessageBox.ShowMessage("感谢", "MagicMongoDBTool",
                                     GUIResource.GetResource.GetImage(GUIResource.ImageType.Smile),
                                     strThanks);
        }
        #endregion

    }
}
