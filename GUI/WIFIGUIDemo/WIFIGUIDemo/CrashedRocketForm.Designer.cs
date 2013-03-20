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
            this._2ndDecodeMsgTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CrashedMessageBox
            // 
            this.CrashedMessageBox.BackColor = System.Drawing.SystemColors.Control;
            this.CrashedMessageBox.Location = new System.Drawing.Point(14, 83);
            this.CrashedMessageBox.Multiline = true;
            this.CrashedMessageBox.Name = "CrashedMessageBox";
            this.CrashedMessageBox.Size = new System.Drawing.Size(205, 171);
            this.CrashedMessageBox.TabIndex = 0;
            // 
            // requestMessageButton
            // 
            this.requestMessageButton.Location = new System.Drawing.Point(14, 12);
            this.requestMessageButton.Name = "requestMessageButton";
            this.requestMessageButton.Size = new System.Drawing.Size(205, 38);
            this.requestMessageButton.TabIndex = 1;
            this.requestMessageButton.Text = "Request Message";
            this.requestMessageButton.UseVisualStyleBackColor = true;
            this.requestMessageButton.Click += new System.EventHandler(this.requestMessageButton_Click);
            // 
            // sendEmailButton
            // 
            this.sendEmailButton.Location = new System.Drawing.Point(14, 260);
            this.sendEmailButton.Name = "sendEmailButton";
            this.sendEmailButton.Size = new System.Drawing.Size(205, 38);
            this.sendEmailButton.TabIndex = 2;
            this.sendEmailButton.Text = "Send E-mail";
            this.sendEmailButton.UseVisualStyleBackColor = true;
            this.sendEmailButton.Click += new System.EventHandler(this.sendEmailButton_Click);
            // 
            // decodedMessage
            // 
            this.decodedMessage.BackColor = System.Drawing.SystemColors.Control;
            this.decodedMessage.Location = new System.Drawing.Point(226, 83);
            this.decodedMessage.Multiline = true;
            this.decodedMessage.Name = "decodedMessage";
            this.decodedMessage.Size = new System.Drawing.Size(205, 171);
            this.decodedMessage.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Encoded Message";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Decoded Message";
            // 
            // clearMsgButton
            // 
            this.clearMsgButton.Location = new System.Drawing.Point(438, 260);
            this.clearMsgButton.Name = "clearMsgButton";
            this.clearMsgButton.Size = new System.Drawing.Size(205, 38);
            this.clearMsgButton.TabIndex = 6;
            this.clearMsgButton.Text = "Clear Messages";
            this.clearMsgButton.UseVisualStyleBackColor = true;
            this.clearMsgButton.Click += new System.EventHandler(this.clearMsgButton_Click);
            // 
            // _2ndDecodeMsgTextBox
            // 
            this._2ndDecodeMsgTextBox.BackColor = System.Drawing.SystemColors.Control;
            this._2ndDecodeMsgTextBox.Location = new System.Drawing.Point(439, 83);
            this._2ndDecodeMsgTextBox.Multiline = true;
            this._2ndDecodeMsgTextBox.Name = "_2ndDecodeMsgTextBox";
            this._2ndDecodeMsgTextBox.Size = new System.Drawing.Size(205, 171);
            this._2ndDecodeMsgTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Decoded Message #2";
            // 
            // CrashedRocketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(647, 307);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._2ndDecodeMsgTextBox);
            this.Controls.Add(this.clearMsgButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decodedMessage);
            this.Controls.Add(this.sendEmailButton);
            this.Controls.Add(this.requestMessageButton);
            this.Controls.Add(this.CrashedMessageBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        private System.Windows.Forms.TextBox _2ndDecodeMsgTextBox;
        private System.Windows.Forms.Label label3;
    }
}