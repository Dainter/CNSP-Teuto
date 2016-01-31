﻿namespace CNSP
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.NetworkMI = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNodeMI = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.SaveMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMI = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoMI = new System.Windows.Forms.ToolStripMenuItem();
            this.DegreeDistMI = new System.Windows.Forms.ToolStripMenuItem();
            this.LogDistMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionMI = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ContentMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutMI = new System.Windows.Forms.ToolStripMenuItem();
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.TabList = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.NodeList = new System.Windows.Forms.ListBox();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TypeBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.MinDegree = new System.Windows.Forms.TextBox();
            this.MaxDegree = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.NetNum = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.NetDeg = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.EdgeNum = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.MaxNode = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.TabMain = new System.Windows.Forms.TabControl();
            this.TabStructure = new System.Windows.Forms.TabPage();
            this.PanelPic = new System.Windows.Forms.Panel();
            this.PicCam = new System.Windows.Forms.PictureBox();
            this.StartTimer = new System.Windows.Forms.Timer(this.components);
            this.MainMenu.SuspendLayout();
            this.MainLayout.SuspendLayout();
            this.TabList.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            this.TabMain.SuspendLayout();
            this.TabStructure.SuspendLayout();
            this.PanelPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicCam)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NetworkMI,
            this.InfoMI,
            this.帮助HToolStripMenuItem1});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(738, 25);
            this.MainMenu.TabIndex = 14;
            this.MainMenu.Text = "MenuStrip1";
            // 
            // NetworkMI
            // 
            this.NetworkMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNodeMI,
            this.OpenMI,
            this.toolStripSeparator,
            this.SaveMI,
            this.toolStripSeparator5,
            this.ExitMI});
            this.NetworkMI.Name = "NetworkMI";
            this.NetworkMI.Size = new System.Drawing.Size(74, 21);
            this.NetworkMI.Text = "数据库(&N)";
            // 
            // AddNodeMI
            // 
            this.AddNodeMI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddNodeMI.Name = "AddNodeMI";
            this.AddNodeMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.AddNodeMI.Size = new System.Drawing.Size(189, 22);
            this.AddNodeMI.Text = "新建节点(&N)";
            // 
            // OpenMI
            // 
            this.OpenMI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenMI.Name = "OpenMI";
            this.OpenMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.OpenMI.Size = new System.Drawing.Size(189, 22);
            this.OpenMI.Text = "新增连边(&E)";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(186, 6);
            // 
            // SaveMI
            // 
            this.SaveMI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveMI.Name = "SaveMI";
            this.SaveMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveMI.Size = new System.Drawing.Size(189, 22);
            this.SaveMI.Text = "保存(&S)";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(186, 6);
            // 
            // ExitMI
            // 
            this.ExitMI.Name = "ExitMI";
            this.ExitMI.Size = new System.Drawing.Size(189, 22);
            this.ExitMI.Text = "退出(&X)";
            // 
            // InfoMI
            // 
            this.InfoMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DegreeDistMI,
            this.LogDistMI,
            this.toolStripSeparator1,
            this.OptionMI});
            this.InfoMI.Name = "InfoMI";
            this.InfoMI.Size = new System.Drawing.Size(56, 21);
            this.InfoMI.Text = "信息(&I)";
            // 
            // DegreeDistMI
            // 
            this.DegreeDistMI.Name = "DegreeDistMI";
            this.DegreeDistMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.DegreeDistMI.Size = new System.Drawing.Size(205, 22);
            this.DegreeDistMI.Text = "网络度分布(&D)";
            // 
            // LogDistMI
            // 
            this.LogDistMI.Name = "LogDistMI";
            this.LogDistMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.LogDistMI.Size = new System.Drawing.Size(205, 22);
            this.LogDistMI.Text = "网络对数分布(&L)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // OptionMI
            // 
            this.OptionMI.Name = "OptionMI";
            this.OptionMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OptionMI.Size = new System.Drawing.Size(205, 22);
            this.OptionMI.Text = "选项(&O)";
            // 
            // 帮助HToolStripMenuItem1
            // 
            this.帮助HToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContentMI,
            this.toolStripSeparator8,
            this.AboutMI});
            this.帮助HToolStripMenuItem1.Name = "帮助HToolStripMenuItem1";
            this.帮助HToolStripMenuItem1.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem1.Text = "帮助(&H)";
            // 
            // ContentMI
            // 
            this.ContentMI.Name = "ContentMI";
            this.ContentMI.Size = new System.Drawing.Size(125, 22);
            this.ContentMI.Text = "内容(&C)";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(122, 6);
            // 
            // AboutMI
            // 
            this.AboutMI.Name = "AboutMI";
            this.AboutMI.Size = new System.Drawing.Size(125, 22);
            this.AboutMI.Text = "关于(&A)...";
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 2;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.Controls.Add(this.TabList, 0, 0);
            this.MainLayout.Controls.Add(this.TabMain, 1, 0);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 25);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 1;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.Size = new System.Drawing.Size(738, 421);
            this.MainLayout.TabIndex = 16;
            // 
            // TabList
            // 
            this.TabList.Controls.Add(this.TabPage1);
            this.TabList.Controls.Add(this.TabPage2);
            this.TabList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabList.Location = new System.Drawing.Point(3, 3);
            this.TabList.Name = "TabList";
            this.TabList.SelectedIndex = 0;
            this.TabList.Size = new System.Drawing.Size(219, 415);
            this.TabList.TabIndex = 14;
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage1.Controls.Add(this.NodeList);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(211, 389);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "节点列表";
            // 
            // NodeList
            // 
            this.NodeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeList.FormattingEnabled = true;
            this.NodeList.ItemHeight = 12;
            this.NodeList.Location = new System.Drawing.Point(3, 3);
            this.NodeList.Name = "NodeList";
            this.NodeList.Size = new System.Drawing.Size(205, 383);
            this.NodeList.TabIndex = 0;
            // 
            // TabPage2
            // 
            this.TabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage2.Controls.Add(this.TableLayoutPanel2);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(211, 389);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "网络信息";
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 2;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.TableLayoutPanel2.Controls.Add(this.TypeBox, 1, 6);
            this.TableLayoutPanel2.Controls.Add(this.label18, 0, 6);
            this.TableLayoutPanel2.Controls.Add(this.MinDegree, 1, 5);
            this.TableLayoutPanel2.Controls.Add(this.MaxDegree, 1, 3);
            this.TableLayoutPanel2.Controls.Add(this.Label3, 0, 0);
            this.TableLayoutPanel2.Controls.Add(this.NetNum, 1, 0);
            this.TableLayoutPanel2.Controls.Add(this.Label4, 0, 1);
            this.TableLayoutPanel2.Controls.Add(this.NetDeg, 1, 1);
            this.TableLayoutPanel2.Controls.Add(this.Label5, 0, 2);
            this.TableLayoutPanel2.Controls.Add(this.EdgeNum, 1, 2);
            this.TableLayoutPanel2.Controls.Add(this.Label2, 0, 4);
            this.TableLayoutPanel2.Controls.Add(this.MaxNode, 1, 4);
            this.TableLayoutPanel2.Controls.Add(this.Label6, 0, 3);
            this.TableLayoutPanel2.Controls.Add(this.Label7, 0, 5);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 8;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(205, 383);
            this.TableLayoutPanel2.TabIndex = 0;
            // 
            // TypeBox
            // 
            this.TypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TypeBox.Location = new System.Drawing.Point(84, 321);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.ReadOnly = true;
            this.TypeBox.Size = new System.Drawing.Size(118, 21);
            this.TypeBox.TabIndex = 54;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(19, 325);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 12);
            this.label18.TabIndex = 53;
            this.label18.Text = "网络类型:";
            // 
            // MinDegree
            // 
            this.MinDegree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MinDegree.Location = new System.Drawing.Point(84, 270);
            this.MinDegree.Name = "MinDegree";
            this.MinDegree.ReadOnly = true;
            this.MinDegree.Size = new System.Drawing.Size(118, 21);
            this.MinDegree.TabIndex = 52;
            // 
            // MaxDegree
            // 
            this.MaxDegree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxDegree.Location = new System.Drawing.Point(84, 168);
            this.MaxDegree.Name = "MaxDegree";
            this.MaxDegree.ReadOnly = true;
            this.MaxDegree.Size = new System.Drawing.Size(118, 21);
            this.MaxDegree.TabIndex = 51;
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(31, 19);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(47, 12);
            this.Label3.TabIndex = 14;
            this.Label3.Text = "节点数:";
            // 
            // NetNum
            // 
            this.NetNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NetNum.Location = new System.Drawing.Point(84, 15);
            this.NetNum.Name = "NetNum";
            this.NetNum.ReadOnly = true;
            this.NetNum.Size = new System.Drawing.Size(118, 21);
            this.NetNum.TabIndex = 24;
            // 
            // Label4
            // 
            this.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(31, 70);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(47, 12);
            this.Label4.TabIndex = 25;
            this.Label4.Text = "平均度:";
            // 
            // NetDeg
            // 
            this.NetDeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NetDeg.Location = new System.Drawing.Point(84, 66);
            this.NetDeg.Name = "NetDeg";
            this.NetDeg.ReadOnly = true;
            this.NetDeg.Size = new System.Drawing.Size(118, 21);
            this.NetDeg.TabIndex = 26;
            // 
            // Label5
            // 
            this.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(43, 121);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(35, 12);
            this.Label5.TabIndex = 39;
            this.Label5.Text = "边数:";
            // 
            // EdgeNum
            // 
            this.EdgeNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EdgeNum.Location = new System.Drawing.Point(84, 117);
            this.EdgeNum.Name = "EdgeNum";
            this.EdgeNum.ReadOnly = true;
            this.EdgeNum.Size = new System.Drawing.Size(118, 21);
            this.EdgeNum.TabIndex = 40;
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(7, 223);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 12);
            this.Label2.TabIndex = 43;
            this.Label2.Text = "度最大节点:";
            // 
            // MaxNode
            // 
            this.MaxNode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxNode.Location = new System.Drawing.Point(84, 219);
            this.MaxNode.Name = "MaxNode";
            this.MaxNode.ReadOnly = true;
            this.MaxNode.Size = new System.Drawing.Size(118, 21);
            this.MaxNode.TabIndex = 46;
            // 
            // Label6
            // 
            this.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(31, 172);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(47, 12);
            this.Label6.TabIndex = 49;
            this.Label6.Text = "最大度:";
            // 
            // Label7
            // 
            this.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(31, 274);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(47, 12);
            this.Label7.TabIndex = 50;
            this.Label7.Text = "最小度:";
            // 
            // TabMain
            // 
            this.TabMain.Controls.Add(this.TabStructure);
            this.TabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabMain.Location = new System.Drawing.Point(228, 3);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(507, 415);
            this.TabMain.TabIndex = 15;
            // 
            // TabStructure
            // 
            this.TabStructure.BackColor = System.Drawing.SystemColors.Control;
            this.TabStructure.Controls.Add(this.PanelPic);
            this.TabStructure.Location = new System.Drawing.Point(4, 22);
            this.TabStructure.Name = "TabStructure";
            this.TabStructure.Padding = new System.Windows.Forms.Padding(3);
            this.TabStructure.Size = new System.Drawing.Size(499, 389);
            this.TabStructure.TabIndex = 0;
            this.TabStructure.Text = "网络结构图";
            // 
            // PanelPic
            // 
            this.PanelPic.AutoScroll = true;
            this.PanelPic.Controls.Add(this.PicCam);
            this.PanelPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPic.Location = new System.Drawing.Point(3, 3);
            this.PanelPic.Name = "PanelPic";
            this.PanelPic.Size = new System.Drawing.Size(493, 383);
            this.PanelPic.TabIndex = 14;
            // 
            // PicCam
            // 
            this.PicCam.BackColor = System.Drawing.Color.White;
            this.PicCam.BackgroundImage = global::CNSP.Properties.Resources.Background;
            this.PicCam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicCam.Location = new System.Drawing.Point(3, 3);
            this.PicCam.Name = "PicCam";
            this.PicCam.Size = new System.Drawing.Size(581, 482);
            this.PicCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicCam.TabIndex = 4;
            this.PicCam.TabStop = false;
            // 
            // StartTimer
            // 
            this.StartTimer.Enabled = true;
            this.StartTimer.Tick += new System.EventHandler(this.StartTimer_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 446);
            this.Controls.Add(this.MainLayout);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "图数据库演示程序";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.MainLayout.ResumeLayout(false);
            this.TabList.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TableLayoutPanel2.ResumeLayout(false);
            this.TableLayoutPanel2.PerformLayout();
            this.TabMain.ResumeLayout(false);
            this.TabStructure.ResumeLayout(false);
            this.PanelPic.ResumeLayout(false);
            this.PanelPic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicCam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.MenuStrip MainMenu;
        internal System.Windows.Forms.ToolStripMenuItem NetworkMI;
        internal System.Windows.Forms.ToolStripMenuItem AddNodeMI;
        internal System.Windows.Forms.ToolStripMenuItem OpenMI;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        internal System.Windows.Forms.ToolStripMenuItem SaveMI;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        internal System.Windows.Forms.ToolStripMenuItem ExitMI;
        internal System.Windows.Forms.ToolStripMenuItem InfoMI;
        internal System.Windows.Forms.ToolStripMenuItem DegreeDistMI;
        internal System.Windows.Forms.ToolStripMenuItem LogDistMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem OptionMI;
        internal System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem ContentMI;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        internal System.Windows.Forms.ToolStripMenuItem AboutMI;
        internal System.Windows.Forms.TableLayoutPanel MainLayout;
        internal System.Windows.Forms.TabControl TabList;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.ListBox NodeList;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.TextBox TypeBox;
        internal System.Windows.Forms.Label label18;
        internal System.Windows.Forms.TextBox MinDegree;
        internal System.Windows.Forms.TextBox MaxDegree;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox NetNum;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox NetDeg;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox EdgeNum;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox MaxNode;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TabControl TabMain;
        internal System.Windows.Forms.TabPage TabStructure;
        internal System.Windows.Forms.Panel PanelPic;
        internal System.Windows.Forms.PictureBox PicCam;
        internal System.Windows.Forms.Timer StartTimer;
    }
}

