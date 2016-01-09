using System.ComponentModel;
using System.Windows.Forms;
using Button = Soul.MapEditor.Core.Button;
using TextBox = Soul.MapEditor.UI.Common.TextBox;

namespace Soul.MapEditor.Forms
{
    partial class FrmNewFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewFile));
            this.btnClose = new Soul.MapEditor.Core.Button();
            this.btnCreate = new Soul.MapEditor.Core.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudMapHeight = new System.Windows.Forms.NumericUpDown();
            this.nudMapWidth = new System.Windows.Forms.NumericUpDown();
            this.txtName = new Soul.MapEditor.UI.Common.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudTilesetHeight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudTilesetWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapWidth)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTilesetHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTilesetWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Caption = "Close";
            this.btnClose.Hover = false;
            this.btnClose.Image = null;
            this.btnClose.Location = new System.Drawing.Point(142, 186);
            this.btnClose.Name = "btnClose";
            this.btnClose.Pressed = false;
            this.btnClose.Size = new System.Drawing.Size(85, 29);
            this.btnClose.TabIndex = 1;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Transparent;
            this.btnCreate.Caption = "Create";
            this.btnCreate.Hover = false;
            this.btnCreate.Image = null;
            this.btnCreate.Location = new System.Drawing.Point(32, 186);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Pressed = false;
            this.btnCreate.Size = new System.Drawing.Size(85, 29);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudMapHeight);
            this.groupBox2.Controls.Add(this.nudMapWidth);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 104);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Map";
            // 
            // nudMapHeight
            // 
            this.nudMapHeight.Location = new System.Drawing.Point(188, 71);
            this.nudMapHeight.Name = "nudMapHeight";
            this.nudMapHeight.Size = new System.Drawing.Size(51, 20);
            this.nudMapHeight.TabIndex = 13;
            // 
            // nudMapWidth
            // 
            this.nudMapWidth.Location = new System.Drawing.Point(64, 71);
            this.nudMapWidth.Name = "nudMapWidth";
            this.nudMapWidth.Size = new System.Drawing.Size(51, 20);
            this.nudMapWidth.TabIndex = 12;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(64, 33);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(182, 20);
            this.txtName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(132, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Height:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Width:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudTilesetHeight);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nudTilesetWidth);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(0, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 70);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tileset";
            // 
            // nudTilesetHeight
            // 
            this.nudTilesetHeight.Enabled = false;
            this.nudTilesetHeight.Location = new System.Drawing.Point(188, 32);
            this.nudTilesetHeight.Name = "nudTilesetHeight";
            this.nudTilesetHeight.Size = new System.Drawing.Size(51, 20);
            this.nudTilesetHeight.TabIndex = 17;
            this.nudTilesetHeight.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Width:";
            // 
            // nudTilesetWidth
            // 
            this.nudTilesetWidth.Enabled = false;
            this.nudTilesetWidth.Location = new System.Drawing.Point(64, 32);
            this.nudTilesetWidth.Name = "nudTilesetWidth";
            this.nudTilesetWidth.Size = new System.Drawing.Size(51, 20);
            this.nudTilesetWidth.TabIndex = 16;
            this.nudTilesetWidth.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(132, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Height:";
            // 
            // FrmNewFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 227);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNewFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Map";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapWidth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTilesetHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTilesetWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnCreate;
        private Button btnClose;
        private GroupBox groupBox2;
        private TextBox txtName;
        private Label label3;
        private Label label2;
        private Label label1;
        private NumericUpDown nudMapHeight;
        private NumericUpDown nudMapWidth;
        private GroupBox groupBox1;
        private NumericUpDown nudTilesetHeight;
        private Label label5;
        private NumericUpDown nudTilesetWidth;
        private Label label4;
    }
}