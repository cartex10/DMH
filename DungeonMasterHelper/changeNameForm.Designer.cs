namespace Dungeon_Master_Helper
{
    partial class changeNameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changeNameForm));
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.cancelButt = new System.Windows.Forms.Button();
            this.acceptButt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter new name for ";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(105, 99);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(174, 22);
            this.nameBox.TabIndex = 1;
            // 
            // cancelButt
            // 
            this.cancelButt.Location = new System.Drawing.Point(29, 163);
            this.cancelButt.Name = "cancelButt";
            this.cancelButt.Size = new System.Drawing.Size(75, 23);
            this.cancelButt.TabIndex = 2;
            this.cancelButt.Text = "Cancel";
            this.cancelButt.UseVisualStyleBackColor = true;
            this.cancelButt.Click += new System.EventHandler(this.ButtClick);
            // 
            // acceptButt
            // 
            this.acceptButt.Location = new System.Drawing.Point(301, 163);
            this.acceptButt.Name = "acceptButt";
            this.acceptButt.Size = new System.Drawing.Size(75, 23);
            this.acceptButt.TabIndex = 3;
            this.acceptButt.Text = "Accept";
            this.acceptButt.UseVisualStyleBackColor = true;
            this.acceptButt.Click += new System.EventHandler(this.ButtClick);
            // 
            // changeNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 208);
            this.Controls.Add(this.acceptButt);
            this.Controls.Add(this.cancelButt);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "changeNameForm";
            this.Text = "Change Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Button cancelButt;
        private System.Windows.Forms.Button acceptButt;
    }
}