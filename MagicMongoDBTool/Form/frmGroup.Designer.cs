﻿namespace MagicMongoDBTool
{
    partial class frmGroup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroup));
            this.cmbForReduce = new System.Windows.Forms.ComboBox();
            this.cmdSaveReduceJs = new System.Windows.Forms.VistaButton();
            this.lblReduceFunction = new System.Windows.Forms.Label();
            this.txtReduceJs = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.VistaButton();
            this.txtfinalizeJs = new System.Windows.Forms.TextBox();
            this.lblfinalize = new System.Windows.Forms.Label();
            this.cmdForSavefinalize = new System.Windows.Forms.VistaButton();
            this.cmbForfinalize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panColumn = new System.Windows.Forms.Panel();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panBsonEl = new System.Windows.Forms.Panel();
            this.cmdAddFld = new System.Windows.Forms.VistaButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tabGroup = new System.Windows.Forms.TabControl();
            this.tabReduce = new System.Windows.Forms.TabPage();
            this.tabFinalize = new System.Windows.Forms.TabPage();
            this.tabGroupField = new System.Windows.Forms.TabPage();
            this.tabInitialize = new System.Windows.Forms.TabPage();
            this.tabResult = new System.Windows.Forms.TabPage();
            this.cmdQuery = new System.Windows.Forms.VistaButton();
            this.contentPanel.SuspendLayout();
            this.tabGroup.SuspendLayout();
            this.tabReduce.SuspendLayout();
            this.tabFinalize.SuspendLayout();
            this.tabGroupField.SuspendLayout();
            this.tabInitialize.SuspendLayout();
            this.tabResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.tabGroup);
            this.contentPanel.Controls.Add(this.cmdOK);
            this.contentPanel.Controls.Add(this.cmdQuery);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(509, 559);
            // 
            // cmbForReduce
            // 
            this.cmbForReduce.FormattingEnabled = true;
            this.cmbForReduce.Location = new System.Drawing.Point(96, 29);
            this.cmbForReduce.Name = "cmbForReduce";
            this.cmbForReduce.Size = new System.Drawing.Size(151, 21);
            this.cmbForReduce.TabIndex = 18;
            // 
            // cmdSaveReduceJs
            // 
            this.cmdSaveReduceJs.BackColor = System.Drawing.Color.Transparent;
            this.cmdSaveReduceJs.Location = new System.Drawing.Point(263, 25);
            this.cmdSaveReduceJs.Name = "cmdSaveReduceJs";
            this.cmdSaveReduceJs.Size = new System.Drawing.Size(70, 30);
            this.cmdSaveReduceJs.TabIndex = 21;
            this.cmdSaveReduceJs.Text = "保存";
            this.cmdSaveReduceJs.Click += new System.EventHandler(this.cmdSaveReduceJs_Click);
            // 
            // lblReduceFunction
            // 
            this.lblReduceFunction.AutoSize = true;
            this.lblReduceFunction.BackColor = System.Drawing.Color.Transparent;
            this.lblReduceFunction.Location = new System.Drawing.Point(21, 37);
            this.lblReduceFunction.Name = "lblReduceFunction";
            this.lblReduceFunction.Size = new System.Drawing.Size(69, 13);
            this.lblReduceFunction.TabIndex = 20;
            this.lblReduceFunction.Text = "Reduce函数";
            // 
            // txtReduceJs
            // 
            this.txtReduceJs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReduceJs.Location = new System.Drawing.Point(17, 61);
            this.txtReduceJs.Multiline = true;
            this.txtReduceJs.Name = "txtReduceJs";
            this.txtReduceJs.Size = new System.Drawing.Size(418, 394);
            this.txtReduceJs.TabIndex = 19;
            this.txtReduceJs.Text = "function(obj,prev){ prev.count++;}";
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(386, 521);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(100, 32);
            this.cmdOK.TabIndex = 22;
            this.cmdOK.Text = "确认";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtfinalizeJs
            // 
            this.txtfinalizeJs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfinalizeJs.Location = new System.Drawing.Point(17, 53);
            this.txtfinalizeJs.Multiline = true;
            this.txtfinalizeJs.Name = "txtfinalizeJs";
            this.txtfinalizeJs.Size = new System.Drawing.Size(411, 402);
            this.txtfinalizeJs.TabIndex = 19;
            // 
            // lblfinalize
            // 
            this.lblfinalize.AutoSize = true;
            this.lblfinalize.BackColor = System.Drawing.Color.Transparent;
            this.lblfinalize.Location = new System.Drawing.Point(21, 29);
            this.lblfinalize.Name = "lblfinalize";
            this.lblfinalize.Size = new System.Drawing.Size(63, 13);
            this.lblfinalize.TabIndex = 20;
            this.lblfinalize.Text = "finalize函数";
            // 
            // cmdForSavefinalize
            // 
            this.cmdForSavefinalize.BackColor = System.Drawing.Color.Transparent;
            this.cmdForSavefinalize.Location = new System.Drawing.Point(246, 20);
            this.cmdForSavefinalize.Name = "cmdForSavefinalize";
            this.cmdForSavefinalize.Size = new System.Drawing.Size(70, 30);
            this.cmdForSavefinalize.TabIndex = 21;
            this.cmdForSavefinalize.Text = "保存";
            this.cmdForSavefinalize.Click += new System.EventHandler(this.cmdForSavefinalize_Click);
            // 
            // cmbForfinalize
            // 
            this.cmbForfinalize.FormattingEnabled = true;
            this.cmbForfinalize.Location = new System.Drawing.Point(89, 26);
            this.cmbForfinalize.Name = "cmbForfinalize";
            this.cmbForfinalize.Size = new System.Drawing.Size(151, 21);
            this.cmbForfinalize.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "请选择Group字段";
            // 
            // panColumn
            // 
            this.panColumn.BackColor = System.Drawing.Color.White;
            this.panColumn.Location = new System.Drawing.Point(20, 28);
            this.panColumn.Name = "panColumn";
            this.panColumn.Size = new System.Drawing.Size(430, 414);
            this.panColumn.TabIndex = 28;
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(27, 38);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(425, 424);
            this.txtResult.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(18, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "请添加初始化字段";
            // 
            // panBsonEl
            // 
            this.panBsonEl.Location = new System.Drawing.Point(12, 49);
            this.panBsonEl.Name = "panBsonEl";
            this.panBsonEl.Size = new System.Drawing.Size(436, 394);
            this.panBsonEl.TabIndex = 29;
            // 
            // cmdAddFld
            // 
            this.cmdAddFld.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddFld.Location = new System.Drawing.Point(148, 11);
            this.cmdAddFld.Name = "cmdAddFld";
            this.cmdAddFld.Size = new System.Drawing.Size(70, 27);
            this.cmdAddFld.TabIndex = 22;
            this.cmdAddFld.Text = "添加";
            this.cmdAddFld.Click += new System.EventHandler(this.cmdAddFld_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(24, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "执行结果";
            // 
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.tabReduce);
            this.tabGroup.Controls.Add(this.tabFinalize);
            this.tabGroup.Controls.Add(this.tabGroupField);
            this.tabGroup.Controls.Add(this.tabInitialize);
            this.tabGroup.Controls.Add(this.tabResult);
            this.tabGroup.Location = new System.Drawing.Point(11, 16);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.SelectedIndex = 0;
            this.tabGroup.Size = new System.Drawing.Size(479, 499);
            this.tabGroup.TabIndex = 5;
            // 
            // tabReduce
            // 
            this.tabReduce.Controls.Add(this.lblReduceFunction);
            this.tabReduce.Controls.Add(this.txtReduceJs);
            this.tabReduce.Controls.Add(this.cmdSaveReduceJs);
            this.tabReduce.Controls.Add(this.cmbForReduce);
            this.tabReduce.Location = new System.Drawing.Point(4, 22);
            this.tabReduce.Name = "tabReduce";
            this.tabReduce.Padding = new System.Windows.Forms.Padding(3);
            this.tabReduce.Size = new System.Drawing.Size(471, 473);
            this.tabReduce.TabIndex = 0;
            this.tabReduce.Text = "Reduce";
            this.tabReduce.UseVisualStyleBackColor = true;
            // 
            // tabFinalize
            // 
            this.tabFinalize.Controls.Add(this.lblfinalize);
            this.tabFinalize.Controls.Add(this.txtfinalizeJs);
            this.tabFinalize.Controls.Add(this.cmdForSavefinalize);
            this.tabFinalize.Controls.Add(this.cmbForfinalize);
            this.tabFinalize.Location = new System.Drawing.Point(4, 22);
            this.tabFinalize.Name = "tabFinalize";
            this.tabFinalize.Padding = new System.Windows.Forms.Padding(3);
            this.tabFinalize.Size = new System.Drawing.Size(471, 473);
            this.tabFinalize.TabIndex = 1;
            this.tabFinalize.Text = "Finalize";
            this.tabFinalize.UseVisualStyleBackColor = true;
            // 
            // tabGroupField
            // 
            this.tabGroupField.Controls.Add(this.label1);
            this.tabGroupField.Controls.Add(this.panColumn);
            this.tabGroupField.Location = new System.Drawing.Point(4, 22);
            this.tabGroupField.Name = "tabGroupField";
            this.tabGroupField.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroupField.Size = new System.Drawing.Size(471, 473);
            this.tabGroupField.TabIndex = 2;
            this.tabGroupField.Text = "Group字段";
            this.tabGroupField.UseVisualStyleBackColor = true;
            // 
            // tabInitialize
            // 
            this.tabInitialize.Controls.Add(this.cmdAddFld);
            this.tabInitialize.Controls.Add(this.panBsonEl);
            this.tabInitialize.Controls.Add(this.label2);
            this.tabInitialize.Location = new System.Drawing.Point(4, 22);
            this.tabInitialize.Name = "tabInitialize";
            this.tabInitialize.Padding = new System.Windows.Forms.Padding(3);
            this.tabInitialize.Size = new System.Drawing.Size(471, 473);
            this.tabInitialize.TabIndex = 3;
            this.tabInitialize.Text = "初始化字段";
            this.tabInitialize.UseVisualStyleBackColor = true;
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.label3);
            this.tabResult.Controls.Add(this.txtResult);
            this.tabResult.Location = new System.Drawing.Point(4, 22);
            this.tabResult.Name = "tabResult";
            this.tabResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabResult.Size = new System.Drawing.Size(471, 473);
            this.tabResult.TabIndex = 4;
            this.tabResult.Text = "执行结果";
            this.tabResult.UseVisualStyleBackColor = true;
            // 
            // cmdQuery
            // 
            this.cmdQuery.BackColor = System.Drawing.Color.Transparent;
            this.cmdQuery.Location = new System.Drawing.Point(263, 521);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(100, 32);
            this.cmdQuery.TabIndex = 5;
            this.cmdQuery.Text = "载入查询条件";
            this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
            // 
            // frmGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 622);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmGroup";
            this.ShowSelectSkinButton = false;
            this.Text = "Group";
            this.Load += new System.EventHandler(this.frmGroup_Load);
            this.contentPanel.ResumeLayout(false);
            this.tabGroup.ResumeLayout(false);
            this.tabReduce.ResumeLayout(false);
            this.tabReduce.PerformLayout();
            this.tabFinalize.ResumeLayout(false);
            this.tabFinalize.PerformLayout();
            this.tabGroupField.ResumeLayout(false);
            this.tabGroupField.PerformLayout();
            this.tabInitialize.ResumeLayout(false);
            this.tabInitialize.PerformLayout();
            this.tabResult.ResumeLayout(false);
            this.tabResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VistaButton cmdOK;
        private System.Windows.Forms.ComboBox cmbForReduce;
        private System.Windows.Forms.VistaButton cmdSaveReduceJs;
        private System.Windows.Forms.Label lblReduceFunction;
        private System.Windows.Forms.TextBox txtReduceJs;
        private System.Windows.Forms.ComboBox cmbForfinalize;
        private System.Windows.Forms.VistaButton cmdForSavefinalize;
        private System.Windows.Forms.Label lblfinalize;
        private System.Windows.Forms.TextBox txtfinalizeJs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panColumn;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panBsonEl;
        private System.Windows.Forms.VistaButton cmdAddFld;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabGroup;
        private System.Windows.Forms.TabPage tabReduce;
        private System.Windows.Forms.TabPage tabFinalize;
        private System.Windows.Forms.TabPage tabGroupField;
        private System.Windows.Forms.TabPage tabInitialize;
        private System.Windows.Forms.TabPage tabResult;
        private System.Windows.Forms.VistaButton cmdQuery;
    }
}