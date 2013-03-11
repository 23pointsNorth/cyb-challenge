namespace WIFIGUIDemo
{
    partial class CrashedRocketForm
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
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.requestMessageButton = new System.Windows.Forms.Button();
            this.sendEmailButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(12, 56);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(176, 123);
            this.MessageBox.TabIndex = 0;
            // 
            // requestMessageButton
            // 
            this.requestMessageButton.Location = new System.Drawing.Point(12, 12);
            this.requestMessageButton.Name = "requestMessageButton";
            this.requestMessageButton.Size = new System.Drawing.Size(176, 38);
            this.requestMessageButton.TabIndex = 1;
            this.requestMessageButton.Text = "Request Message";
            this.requestMessageButton.UseVisualStyleBackColor = true;
            // 
            // sendEmailButton
            // 
            this.sendEmailButton.Location = new System.Drawing.Point(12, 185);
            this.sendEmailButton.Name = "sendEmailButton";
            this.sendEmailButton.Size = new System.Drawing.Size(176, 38);
            this.sendEmailButton.TabIndex = 2;
            this.sendEmailButton.Text = "Send E-mail";
            this.sendEmailButton.UseVisualStyleBackColor = true;
            this.sendEmailButton.Click += new System.EventHandler(this.sendEmailButton_Click);
            // 
            // CrashedRocketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 234);
            this.Controls.Add(this.sendEmailButton);
            this.Controls.Add(this.requestMessageButton);
            this.Controls.Add(this.MessageBox);
            this.Name = "CrashedRocketForm";
            this.Text = "CrashedRocketForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Button requestMessageButton;
        private System.Windows.Forms.Button sendEmailButton;
    }
}