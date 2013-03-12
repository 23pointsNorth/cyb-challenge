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
            this.CrashedMessageBox = new System.Windows.Forms.TextBox();
            this.requestMessageButton = new System.Windows.Forms.Button();
            this.sendEmailButton = new System.Windows.Forms.Button();
            this.decodedMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clearMsgButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CrashedMessageBox
            // 
            this.CrashedMessageBox.Location = new System.Drawing.Point(12, 83);
            this.CrashedMessageBox.Multiline = true;
            this.CrashedMessageBox.Name = "CrashedMessageBox";
            this.CrashedMessageBox.Size = new System.Drawing.Size(176, 171);
            this.CrashedMessageBox.TabIndex = 0;
            // 
            // requestMessageButton
            // 
            this.requestMessageButton.Location = new System.Drawing.Point(12, 12);
            this.requestMessageButton.Name = "requestMessageButton";
            this.requestMessageButton.Size = new System.Drawing.Size(176, 38);
            this.requestMessageButton.TabIndex = 1;
            this.requestMessageButton.Text = "Request Message";
            this.requestMessageButton.UseVisualStyleBackColor = true;
            this.requestMessageButton.Click += new System.EventHandler(this.requestMessageButton_Click);
            // 
            // sendEmailButton
            // 
            this.sendEmailButton.Location = new System.Drawing.Point(12, 260);
            this.sendEmailButton.Name = "sendEmailButton";
            this.sendEmailButton.Size = new System.Drawing.Size(176, 38);
            this.sendEmailButton.TabIndex = 2;
            this.sendEmailButton.Text = "Send E-mail";
            this.sendEmailButton.UseVisualStyleBackColor = true;
            this.sendEmailButton.Click += new System.EventHandler(this.sendEmailButton_Click);
            // 
            // decodedMessage
            // 
            this.decodedMessage.Location = new System.Drawing.Point(194, 83);
            this.decodedMessage.Multiline = true;
            this.decodedMessage.Name = "decodedMessage";
            this.decodedMessage.Size = new System.Drawing.Size(176, 171);
            this.decodedMessage.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Encoded Message";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Decoded Message";
            // 
            // clearMsgButton
            // 
            this.clearMsgButton.Location = new System.Drawing.Point(194, 260);
            this.clearMsgButton.Name = "clearMsgButton";
            this.clearMsgButton.Size = new System.Drawing.Size(176, 38);
            this.clearMsgButton.TabIndex = 6;
            this.clearMsgButton.Text = "Clear Messages";
            this.clearMsgButton.UseVisualStyleBackColor = true;
            this.clearMsgButton.Click += new System.EventHandler(this.clearMsgButton_Click);
            // 
            // CrashedRocketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 321);
            this.Controls.Add(this.clearMsgButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decodedMessage);
            this.Controls.Add(this.sendEmailButton);
            this.Controls.Add(this.requestMessageButton);
            this.Controls.Add(this.CrashedMessageBox);
            this.Name = "CrashedRocketForm";
            this.Text = "CrashedRocketForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CrashedRocketForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CrashedMessageBox;
        private System.Windows.Forms.Button requestMessageButton;
        private System.Windows.Forms.Button sendEmailButton;
        private System.Windows.Forms.TextBox decodedMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clearMsgButton;
    }
}