﻿using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class frmServiceStatus : QLFUI.QLFForm
    {
        public frmServiceStatus()
        {
            InitializeComponent();
        }
        Timer refreshTimer = new Timer();

        private void frmServiceStatus_Load(object sender, EventArgs e)
        {
            refreshTimer.Interval = SystemManager.ConfigHelperInstance.RefreshStatusTimer * 1000;
            refreshTimer.Tick += new EventHandler((x, y) =>
            {
                MongoDBHelper.FillSrvStatusToList(this.lstSrvStatus);
                MongoDBHelper.FillSrvOprToList(this.lstSrvOpr);
                MongoDBHelper.FillDBStatusToList(this.lstDBStatus);
                //防止在查看树形状态的时候被打扰
                //MongoDBHelper.FillExtraSrvStatusToList(trvSvrStatus);
            });
            refreshTimer.Enabled = true;
            MongoDBHelper.FillSrvStatusToList(this.lstSrvStatus);
            MongoDBHelper.FillSrvOprToList(this.lstSrvOpr);
            MongoDBHelper.FillDBStatusToList(this.lstDBStatus);
            MongoDBHelper.FillExtraSrvStatusToList(trvSvrStatus);
        }
        /// <summary>
        /// 立刻刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            MongoDBHelper.FillSrvStatusToList(this.lstSrvStatus);
            MongoDBHelper.FillSrvOprToList(this.lstSrvOpr);
            MongoDBHelper.FillDBStatusToList(this.lstDBStatus);
            MongoDBHelper.FillExtraSrvStatusToList(trvSvrStatus);
        }
        /// <summary>
        /// Timer停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmServiceStatus_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            refreshTimer.Stop();
        }


    }
}
