using System.Windows.Forms;

namespace CoinTicker
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.updater = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.leftMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftMenuAddCombo = new System.Windows.Forms.ToolStripComboBox();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftMenuRemoveCombo = new System.Windows.Forms.ToolStripComboBox();
            this.chartStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftMenuChartCombo = new System.Windows.Forms.ToolStripComboBox();
            this.opacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftMenuOpacityCombo = new System.Windows.Forms.ToolStripComboBox();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.leftMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // updater
            // 
            this.updater.Tick += new System.EventHandler(this.updater_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox1.Location = new System.Drawing.Point(135, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(43, 21);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // leftMenu
            // 
            this.leftMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chartStripMenuItem,
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.opacityToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.leftMenu.Name = "leftMenu";
            this.leftMenu.Size = new System.Drawing.Size(157, 114);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftMenuAddCombo});
            this.addToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9F);
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.addToolStripMenuItem.Text = "Add Ticker";
            // 
            // leftMenuAddCombo
            // 
            this.leftMenuAddCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.leftMenuAddCombo.Font = new System.Drawing.Font("Arial", 9F);
            this.leftMenuAddCombo.Name = "leftMenuAddCombo";
            this.leftMenuAddCombo.Size = new System.Drawing.Size(75, 23);
            this.leftMenuAddCombo.Sorted = true;
            this.leftMenuAddCombo.SelectedIndexChanged += new System.EventHandler(this.leftMenuAddCombo_SelectedIndexChanged);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftMenuRemoveCombo});
            this.deleteToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9F);
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.deleteToolStripMenuItem.Text = "Remove Ticker";
            // 
            // leftMenuRemoveCombo
            // 
            this.leftMenuRemoveCombo.BackColor = System.Drawing.SystemColors.Window;
            this.leftMenuRemoveCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.leftMenuRemoveCombo.Font = new System.Drawing.Font("Arial", 9F);
            this.leftMenuRemoveCombo.ForeColor = System.Drawing.Color.Black;
            this.leftMenuRemoveCombo.Name = "leftMenuRemoveCombo";
            this.leftMenuRemoveCombo.Size = new System.Drawing.Size(75, 23);
            this.leftMenuRemoveCombo.Sorted = true;
            this.leftMenuRemoveCombo.SelectedIndexChanged += new System.EventHandler(this.leftMenuRemoveCombo_SelectedIndexChanged);
            // 
            // chartStripMenuItem
            // 
            this.chartStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftMenuChartCombo});
            this.chartStripMenuItem.Font = new System.Drawing.Font("Arial", 9F);
            this.chartStripMenuItem.Name = "chartStripMenuItem";
            this.chartStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.chartStripMenuItem.Text = "Show Chart";
            // 
            // leftMenuChartCombo
            // 
            this.leftMenuChartCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.leftMenuChartCombo.Font = new System.Drawing.Font("Arial", 9F);
            this.leftMenuChartCombo.Name = "leftMenuChartCombo";
            this.leftMenuChartCombo.Size = new System.Drawing.Size(75, 23);
            this.leftMenuChartCombo.Sorted = true;
            this.leftMenuChartCombo.SelectedIndexChanged += new System.EventHandler(this.leftMenuChartCombo_SelectedIndexChanged);
            // 
            // opacityToolStripMenuItem
            // 
            this.opacityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftMenuOpacityCombo});
            this.opacityToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9F);
            this.opacityToolStripMenuItem.Name = "opacityToolStripMenuItem";
            this.opacityToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.opacityToolStripMenuItem.Text = "Opacity";
            // 
            // leftMenuOpacityCombo
            // 
            this.leftMenuOpacityCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.leftMenuOpacityCombo.Font = new System.Drawing.Font("Arial", 9F);
            this.leftMenuOpacityCombo.Items.AddRange(new object[] {
            "100",
            "90",
            "80",
            "70",
            "60",
            "50",
            "40",
            "30",
            "20",
            "10",
            "0"});
            this.leftMenuOpacityCombo.Name = "leftMenuOpacityCombo";
            this.leftMenuOpacityCombo.Size = new System.Drawing.Size(75, 23);
            this.leftMenuOpacityCombo.SelectedIndexChanged += new System.EventHandler(this.leftMenuOpacityCombo_SelectedIndexChanged);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9F);
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipTitle = "Coin Ticker";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Coin Ticker";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(190, 24);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Opacity = 0.7D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "MainForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.Shown += new System.EventHandler(this.mainForm_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainForm_MouseUp);
            this.leftMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer updater;
        private GroupBox groupBox1;
        private ContextMenuStrip leftMenu;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripComboBox leftMenuAddCombo;
        private ToolStripComboBox leftMenuRemoveCombo;
        private NotifyIcon notifyIcon;
        private ToolStripMenuItem opacityToolStripMenuItem;
        private ToolStripComboBox leftMenuOpacityCombo;
        private ToolStripMenuItem chartStripMenuItem;
        private ToolStripComboBox leftMenuChartCombo;
    }
}