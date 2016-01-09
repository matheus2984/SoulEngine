using System.ComponentModel;
using System.Windows.Forms;
using Soul.MapEditor.Core.Components;
using Button = Soul.MapEditor.Core.Button;

namespace Soul.MapEditor.Forms
{
    partial class FrmNewTileset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewTileset));
            this.txtTilesetPath = new System.Windows.Forms.TextBox();
            this.btnSearchPath = new Soul.MapEditor.Core.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new Soul.MapEditor.Core.Button();
            this.btnClose = new Soul.MapEditor.Core.Button();
            this.editorView = new Soul.MapEditor.Core.Components.EditorViewControl();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // txtTilesetPath
            // 
            this.txtTilesetPath.Location = new System.Drawing.Point(14, 82);
            this.txtTilesetPath.Name = "txtTilesetPath";
            this.txtTilesetPath.Size = new System.Drawing.Size(189, 20);
            this.txtTilesetPath.TabIndex = 0;
            // 
            // btnSearchPath
            // 
            this.btnSearchPath.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchPath.Caption = "...";
            this.btnSearchPath.Hover = false;
            this.btnSearchPath.Image = null;
            this.btnSearchPath.Location = new System.Drawing.Point(209, 82);
            this.btnSearchPath.Name = "btnSearchPath";
            this.btnSearchPath.Pressed = false;
            this.btnSearchPath.Size = new System.Drawing.Size(48, 20);
            this.btnSearchPath.TabIndex = 1;
            this.btnSearchPath.Click += new System.EventHandler(this.btnSearchPath_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(14, 33);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(243, 20);
            this.txtName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tileset:";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.Caption = "ADD";
            this.btnAdd.Hover = false;
            this.btnAdd.Image = null;
            this.btnAdd.Location = new System.Drawing.Point(41, 413);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Pressed = false;
            this.btnAdd.Size = new System.Drawing.Size(85, 28);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Caption = "Close";
            this.btnClose.Hover = false;
            this.btnClose.Image = null;
            this.btnClose.Location = new System.Drawing.Point(132, 413);
            this.btnClose.Name = "btnClose";
            this.btnClose.Pressed = false;
            this.btnClose.Size = new System.Drawing.Size(85, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // editorView
            // 
            this.editorView.Component = null;
            this.editorView.GameLoopEnabled = true;
            this.editorView.Location = new System.Drawing.Point(274, 14);
            this.editorView.Name = "editorView";
            this.editorView.Size = new System.Drawing.Size(262, 427);
            this.editorView.TabIndex = 5;
            this.editorView.Text = "editorViewControl1";
            this.editorView.TimeStep = 16.66666F;
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // FrmNewTileset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 453);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.editorView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearchPath);
            this.Controls.Add(this.txtTilesetPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNewTileset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Tileset";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtTilesetPath;
        private Button btnSearchPath;
        private TextBox txtName;
        private Label label1;
        private Label label2;
        private EditorViewControl editorView;
        private Button btnAdd;
        private Button btnClose;
        private OpenFileDialog ofd;
    }
}