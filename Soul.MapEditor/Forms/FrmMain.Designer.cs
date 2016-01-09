using System.ComponentModel;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Menu = Soul.MapEditor.UI.Menu.Menu;
using ToolBar = Soul.MapEditor.UI.Menu.ToolBar;

namespace Soul.MapEditor.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.vS2012LightTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2012LightTheme();
            this.toolBar = new Soul.MapEditor.UI.Menu.ToolBar();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCompile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPencil = new System.Windows.Forms.ToolStripButton();
            this.tsbFill = new System.Windows.Forms.ToolStripButton();
            this.tsbErase = new System.Windows.Forms.ToolStripButton();
            this.tsbSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbTeste = new System.Windows.Forms.ToolStripButton();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCompile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.objectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu = new Soul.MapEditor.UI.Menu.Menu();
            this.toolBar.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockPanel
            // 
            this.dockPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dockPanel.DefaultFloatWindowSize = new System.Drawing.Size(200, 200);
            this.dockPanel.DockBottomPortion = 150D;
            this.dockPanel.DockLeftPortion = 150D;
            this.dockPanel.DockRightPortion = 150D;
            this.dockPanel.DockTopPortion = 150D;
            this.dockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel.Location = new System.Drawing.Point(0, 67);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(835, 467);
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            autoHideStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            dockPaneStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.Control;
            tabGradient5.StartColor = System.Drawing.SystemColors.Control;
            tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.InactiveCaption;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.Transparent;
            tabGradient7.StartColor = System.Drawing.Color.Transparent;
            tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this.dockPanel.Skin = dockPanelSkin1;
            this.dockPanel.TabIndex = 1;
            this.dockPanel.Theme = this.dockPanel.Theme;
            // 
            // toolBar
            // 
            this.toolBar.AutoSize = false;
            this.toolBar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbOpen,
            this.tsbSave,
            this.tsbCompile,
            this.toolStripSeparator1,
            this.tsbPencil,
            this.tsbFill,
            this.tsbErase,
            this.tsbSelect,
            this.toolStripSeparator2,
            this.tsbTeste});
            this.toolBar.Location = new System.Drawing.Point(0, 29);
            this.toolBar.Name = "toolBar";
            this.toolBar.RenderBackground = true;
            this.toolBar.Size = new System.Drawing.Size(836, 38);
            this.toolBar.TabIndex = 3;
            this.toolBar.Text = "toolBar1";
            // 
            // tsbNew
            // 
            this.tsbNew.AutoSize = false;
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(30, 30);
            this.tsbNew.Text = "toolStripButton1";
            this.tsbNew.Click += new System.EventHandler(this.NewMap_Click);
            // 
            // tsbOpen
            // 
            this.tsbOpen.AutoSize = false;
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(30, 30);
            this.tsbOpen.Text = "toolStripButton2";
            this.tsbOpen.Click += new System.EventHandler(this.Open_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.AutoSize = false;
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(30, 30);
            this.tsbSave.Text = "toolStripButton3";
            this.tsbSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // tsbCompile
            // 
            this.tsbCompile.AutoSize = false;
            this.tsbCompile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCompile.Image = ((System.Drawing.Image)(resources.GetObject("tsbCompile.Image")));
            this.tsbCompile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCompile.Name = "tsbCompile";
            this.tsbCompile.Size = new System.Drawing.Size(30, 30);
            this.tsbCompile.Text = "toolStripButton1";
            this.tsbCompile.Click += new System.EventHandler(this.Compile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(30, 30);
            // 
            // tsbPencil
            // 
            this.tsbPencil.AutoSize = false;
            this.tsbPencil.CheckOnClick = true;
            this.tsbPencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPencil.Image = ((System.Drawing.Image)(resources.GetObject("tsbPencil.Image")));
            this.tsbPencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPencil.Name = "tsbPencil";
            this.tsbPencil.Size = new System.Drawing.Size(30, 30);
            this.tsbPencil.Text = "toolStripButton1";
            this.tsbPencil.Click += new System.EventHandler(this.tsbPencil_Click);
            // 
            // tsbFill
            // 
            this.tsbFill.AutoSize = false;
            this.tsbFill.CheckOnClick = true;
            this.tsbFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFill.Image = ((System.Drawing.Image)(resources.GetObject("tsbFill.Image")));
            this.tsbFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFill.Name = "tsbFill";
            this.tsbFill.Size = new System.Drawing.Size(30, 27);
            this.tsbFill.Text = "toolStripButton1";
            this.tsbFill.Click += new System.EventHandler(this.tsbFill_Click);
            // 
            // tsbErase
            // 
            this.tsbErase.AutoSize = false;
            this.tsbErase.CheckOnClick = true;
            this.tsbErase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbErase.Image = ((System.Drawing.Image)(resources.GetObject("tsbErase.Image")));
            this.tsbErase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbErase.Name = "tsbErase";
            this.tsbErase.Size = new System.Drawing.Size(30, 30);
            this.tsbErase.Text = "toolStripButton2";
            this.tsbErase.Click += new System.EventHandler(this.tsbErase_Click);
            // 
            // tsbSelect
            // 
            this.tsbSelect.AutoSize = false;
            this.tsbSelect.CheckOnClick = true;
            this.tsbSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSelect.Image = ((System.Drawing.Image)(resources.GetObject("tsbSelect.Image")));
            this.tsbSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelect.Name = "tsbSelect";
            this.tsbSelect.Size = new System.Drawing.Size(30, 30);
            this.tsbSelect.Text = "toolStripButton3";
            this.tsbSelect.Click += new System.EventHandler(this.tsbSelect_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(30, 30);
            // 
            // tsbTeste
            // 
            this.tsbTeste.AutoSize = false;
            this.tsbTeste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTeste.Image = ((System.Drawing.Image)(resources.GetObject("tsbTeste.Image")));
            this.tsbTeste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbTeste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTeste.Name = "tsbTeste";
            this.tsbTeste.Size = new System.Drawing.Size(50, 30);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNew,
            this.tsmOpen,
            this.tsmSave,
            this.tsmCompile,
            this.tsmExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmNew
            // 
            this.tsmNew.Name = "tsmNew";
            this.tsmNew.Size = new System.Drawing.Size(119, 22);
            this.tsmNew.Text = "New";
            this.tsmNew.Click += new System.EventHandler(this.NewMap_Click);
            // 
            // tsmOpen
            // 
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.Size = new System.Drawing.Size(119, 22);
            this.tsmOpen.Text = "Open";
            this.tsmOpen.Click += new System.EventHandler(this.Open_Click);
            // 
            // tsmSave
            // 
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.Size = new System.Drawing.Size(119, 22);
            this.tsmSave.Text = "Save";
            this.tsmSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // tsmCompile
            // 
            this.tsmCompile.Name = "tsmCompile";
            this.tsmCompile.Size = new System.Drawing.Size(119, 22);
            this.tsmCompile.Text = "Compile";
            this.tsmCompile.Click += new System.EventHandler(this.Compile_Click);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(119, 22);
            this.tsmExit.Text = "Exit";
            // 
            // objectsToolStripMenuItem
            // 
            this.objectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tilesetToolStripMenuItem});
            this.objectsToolStripMenuItem.Name = "objectsToolStripMenuItem";
            this.objectsToolStripMenuItem.Size = new System.Drawing.Size(59, 19);
            this.objectsToolStripMenuItem.Text = "Objects";
            // 
            // tilesetToolStripMenuItem
            // 
            this.tilesetToolStripMenuItem.Name = "tilesetToolStripMenuItem";
            this.tilesetToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.tilesetToolStripMenuItem.Text = "New Tileset";
            this.tilesetToolStripMenuItem.Click += new System.EventHandler(this.NewTileset_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.objectsToolStripMenuItem});
            this.menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(5);
            this.menu.RenderBackground = true;
            this.menu.Size = new System.Drawing.Size(836, 29);
            this.menu.TabIndex = 8;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 536);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.dockPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Editor ~ Pokemon Soul";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DockPanel dockPanel;
        private ToolBar toolBar;
        private ToolStripButton tsbNew;
        private ToolStripButton tsbOpen;
        private ToolStripButton tsbSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbPencil;
        private ToolStripButton tsbFill;
        private ToolStripButton tsbErase;
        private VS2012LightTheme vS2012LightTheme1;
        private ToolStripButton tsbSelect;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbCompile;
        private ToolStripButton tsbTeste;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem tsmNew;
        private ToolStripMenuItem tsmOpen;
        private ToolStripMenuItem tsmSave;
        private ToolStripMenuItem tsmCompile;
        private ToolStripMenuItem tsmExit;
        private ToolStripMenuItem objectsToolStripMenuItem;
        private ToolStripMenuItem tilesetToolStripMenuItem;
        private Menu menu;

    }
}