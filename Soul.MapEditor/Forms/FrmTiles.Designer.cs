using System.ComponentModel;
using Soul.MapEditor.Core.Components;
using Soul.MapEditor.UI.Common;

namespace Soul.MapEditor.Forms
{
    partial class FrmTiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTiles));
            this.cbTileset = new Soul.MapEditor.UI.Common.EnumComboBox();
            this.editorView = new Soul.MapEditor.Core.Components.EditorViewControl();
            this.SuspendLayout();
            // 
            // cbTileset
            // 
            this.cbTileset.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbTileset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTileset.FormattingEnabled = true;
            this.cbTileset.Location = new System.Drawing.Point(0, 0);
            this.cbTileset.Name = "cbTileset";
            this.cbTileset.Size = new System.Drawing.Size(192, 21);
            this.cbTileset.TabIndex = 1;
            this.cbTileset.SelectedIndexChanged += new System.EventHandler(this.cbTileset_SelectedIndexChanged);
            // 
            // editorView
            // 
            this.editorView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorView.Component = null;
            this.editorView.GameLoopEnabled = true;
            this.editorView.Location = new System.Drawing.Point(0, 22);
            this.editorView.Name = "editorView";
            this.editorView.Size = new System.Drawing.Size(192, 372);
            this.editorView.TabIndex = 0;
            this.editorView.Text = "gameControl1";
            this.editorView.TimeStep = 16.66666F;
            // 
            // FrmTiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 394);
            this.Controls.Add(this.cbTileset);
            this.Controls.Add(this.editorView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTiles";
            this.Text = "Tileset";
            this.ResumeLayout(false);

        }

        #endregion

        private EditorViewControl editorView;
        private EnumComboBox cbTileset;
    }
}