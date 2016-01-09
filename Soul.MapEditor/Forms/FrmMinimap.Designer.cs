using System.ComponentModel;
using Soul.MapEditor.Core.Components;

namespace Soul.MapEditor.Forms
{
    partial class FrmMinimap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMinimap));
            this.editorView = new Soul.MapEditor.Core.Components.EditorViewControl();
            this.SuspendLayout();
            // 
            // editorView
            // 
            this.editorView.Component = null;
            this.editorView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorView.GameLoopEnabled = true;
            this.editorView.Location = new System.Drawing.Point(0, 0);
            this.editorView.Name = "editorView";
            this.editorView.Size = new System.Drawing.Size(228, 193);
            this.editorView.TabIndex = 0;
            this.editorView.Text = "editorViewControl1";
            this.editorView.TimeStep = 16.66666F;
            // 
            // FrmMinimap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 193);
            this.Controls.Add(this.editorView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMinimap";
            this.Text = "Minimap";
            this.ResumeLayout(false);

        }

        #endregion

        private EditorViewControl editorView;
    }
}