
namespace Dungeon_Master_Helper
{
    partial class initiativeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(initiativeForm));
            this.mainTable = new System.Windows.Forms.TableLayoutPanel();
            this.namePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTable = new System.Windows.Forms.TableLayoutPanel();
            this.baseTable = new System.Windows.Forms.TableLayoutPanel();
            this.initNameLabel = new System.Windows.Forms.Label();
            this.initNumBox = new System.Windows.Forms.NumericUpDown();
            this.doneButton = new System.Windows.Forms.Button();
            this.mainTable.SuspendLayout();
            this.namePanel.SuspendLayout();
            this.nameTable.SuspendLayout();
            this.baseTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.initNumBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTable
            // 
            this.mainTable.ColumnCount = 5;
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.9779F));
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.0221F));
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.mainTable.Controls.Add(this.namePanel, 1, 1);
            this.mainTable.Controls.Add(this.label1, 1, 0);
            this.mainTable.Controls.Add(this.label2, 2, 0);
            this.mainTable.Controls.Add(this.doneButton, 4, 1);
            this.mainTable.Location = new System.Drawing.Point(0, 0);
            this.mainTable.Name = "mainTable";
            this.mainTable.RowCount = 2;
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.2329F));
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.7671F));
            this.mainTable.Size = new System.Drawing.Size(505, 494);
            this.mainTable.TabIndex = 0;
            // 
            // namePanel
            // 
            this.namePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.namePanel.AutoScroll = true;
            this.mainTable.SetColumnSpan(this.namePanel, 3);
            this.namePanel.Controls.Add(this.nameTable);
            this.namePanel.Location = new System.Drawing.Point(82, 70);
            this.namePanel.Margin = new System.Windows.Forms.Padding(0);
            this.namePanel.Name = "namePanel";
            this.namePanel.Size = new System.Drawing.Size(307, 424);
            this.namePanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Character Name";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(249, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Initiative Roll";
            // 
            // nameTable
            // 
            this.nameTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.nameTable.ColumnCount = 1;
            this.nameTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.59567F));
            this.nameTable.Controls.Add(this.baseTable, 0, 0);
            this.nameTable.Location = new System.Drawing.Point(0, 0);
            this.nameTable.Margin = new System.Windows.Forms.Padding(0);
            this.nameTable.Name = "nameTable";
            this.nameTable.RowCount = 2;
            this.nameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.13825F));
            this.nameTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.86175F));
            this.nameTable.Size = new System.Drawing.Size(289, 434);
            this.nameTable.TabIndex = 0;
            // 
            // baseTable
            // 
            this.baseTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baseTable.ColumnCount = 2;
            this.baseTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.59567F));
            this.baseTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.40433F));
            this.baseTable.Controls.Add(this.initNameLabel, 0, 0);
            this.baseTable.Controls.Add(this.initNumBox, 1, 0);
            this.baseTable.Location = new System.Drawing.Point(4, 4);
            this.baseTable.Name = "baseTable";
            this.baseTable.RowCount = 1;
            this.baseTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.baseTable.Size = new System.Drawing.Size(281, 37);
            this.baseTable.TabIndex = 0;
            // 
            // initNameLabel
            // 
            this.initNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.initNameLabel.AutoSize = true;
            this.initNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.initNameLabel.Location = new System.Drawing.Point(10, 6);
            this.initNameLabel.Name = "initNameLabel";
            this.initNameLabel.Size = new System.Drawing.Size(136, 25);
            this.initNameLabel.TabIndex = 0;
            this.initNameLabel.Text = "initNameLabel";
            // 
            // initNumBox
            // 
            this.initNumBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.initNumBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.initNumBox.Location = new System.Drawing.Point(188, 3);
            this.initNumBox.Name = "initNumBox";
            this.initNumBox.Size = new System.Drawing.Size(60, 30);
            this.initNumBox.TabIndex = 1;
            // 
            // doneButton
            // 
            this.doneButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.doneButton.Location = new System.Drawing.Point(409, 468);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 23);
            this.doneButton.TabIndex = 3;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.Finish);
            // 
            // initiativeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 493);
            this.Controls.Add(this.mainTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "initiativeForm";
            this.Text = "Add to Initiative";
            this.mainTable.ResumeLayout(false);
            this.mainTable.PerformLayout();
            this.namePanel.ResumeLayout(false);
            this.nameTable.ResumeLayout(false);
            this.baseTable.ResumeLayout(false);
            this.baseTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.initNumBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTable;
        private System.Windows.Forms.FlowLayoutPanel namePanel;
        private System.Windows.Forms.TableLayoutPanel nameTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel baseTable;
        private System.Windows.Forms.Label initNameLabel;
        private System.Windows.Forms.NumericUpDown initNumBox;
        private System.Windows.Forms.Button doneButton;
    }
}