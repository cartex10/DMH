
namespace Dungeon_Master_Helper
{
    partial class deleteCreatureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(deleteCreatureForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.creatureNameBox = new System.Windows.Forms.TextBox();
            this.removeButt = new System.Windows.Forms.Button();
            this.cancelButt = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.creatureNameBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.removeButt, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cancelButt, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.8312F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.1688F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(473, 549);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(122, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Are you sure you want to delete the following creatures from the Encounter?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // creatureNameBox
            // 
            this.creatureNameBox.Enabled = false;
            this.creatureNameBox.Location = new System.Drawing.Point(122, 127);
            this.creatureNameBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.creatureNameBox.Multiline = true;
            this.creatureNameBox.Name = "creatureNameBox";
            this.creatureNameBox.ReadOnly = true;
            this.creatureNameBox.Size = new System.Drawing.Size(227, 347);
            this.creatureNameBox.TabIndex = 1;
            // 
            // removeButt
            // 
            this.removeButt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.removeButt.Location = new System.Drawing.Point(363, 499);
            this.removeButt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.removeButt.Name = "removeButt";
            this.removeButt.Size = new System.Drawing.Size(100, 28);
            this.removeButt.TabIndex = 3;
            this.removeButt.Tag = "remove";
            this.removeButt.Text = "Delete";
            this.removeButt.UseVisualStyleBackColor = true;
            this.removeButt.Click += new System.EventHandler(this.butt_Click);
            // 
            // cancelButt
            // 
            this.cancelButt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancelButt.Location = new System.Drawing.Point(9, 499);
            this.cancelButt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelButt.Name = "cancelButt";
            this.cancelButt.Size = new System.Drawing.Size(100, 28);
            this.cancelButt.TabIndex = 2;
            this.cancelButt.Tag = "cancel";
            this.cancelButt.Text = "Cancel";
            this.cancelButt.UseVisualStyleBackColor = true;
            this.cancelButt.Click += new System.EventHandler(this.butt_Click);
            // 
            // deleteCreatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 544);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(494, 591);
            this.MinimumSize = new System.Drawing.Size(494, 591);
            this.Name = "deleteCreatureForm";
            this.Text = "Delete From Encounter";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox creatureNameBox;
        private System.Windows.Forms.Button removeButt;
        private System.Windows.Forms.Button cancelButt;
    }
}