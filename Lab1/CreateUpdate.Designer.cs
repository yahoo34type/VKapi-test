namespace Lab1
{
    partial class CreateUpdate
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.confirmationBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(485, 244);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // confirmationBtn
            // 
            this.confirmationBtn.Location = new System.Drawing.Point(12, 265);
            this.confirmationBtn.Name = "confirmationBtn";
            this.confirmationBtn.Size = new System.Drawing.Size(81, 23);
            this.confirmationBtn.TabIndex = 1;
            this.confirmationBtn.Text = "button1";
            this.confirmationBtn.UseVisualStyleBackColor = true;
            this.confirmationBtn.Click += new System.EventHandler(this.confirmationBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(398, 265);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // CreateUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 300);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.confirmationBtn);
            this.Name = "CreateUpdate";
            this.Text = "CreateUpdate";
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button confirmationBtn;
        public System.Windows.Forms.Button cancelBtn;
        public System.Windows.Forms.RichTextBox richTextBox1;
    }
}