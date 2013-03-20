namespace WIFIGUIDemo
{
    partial class EObjectsForm
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
            this.deliveredObjects = new System.Windows.Forms.Label();
            this.deliveredButton = new System.Windows.Forms.Button();
            this.missDeliveredButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deliveredObjects
            // 
            this.deliveredObjects.AutoSize = true;
            this.deliveredObjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deliveredObjects.Location = new System.Drawing.Point(12, 15);
            this.deliveredObjects.Name = "deliveredObjects";
            this.deliveredObjects.Size = new System.Drawing.Size(245, 31);
            this.deliveredObjects.TabIndex = 0;
            this.deliveredObjects.Text = "Object Delivered: 0";
            // 
            // deliveredButton
            // 
            this.deliveredButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deliveredButton.Location = new System.Drawing.Point(18, 66);
            this.deliveredButton.Name = "deliveredButton";
            this.deliveredButton.Size = new System.Drawing.Size(239, 46);
            this.deliveredButton.TabIndex = 1;
            this.deliveredButton.Text = "Delivered an Object";
            this.deliveredButton.UseVisualStyleBackColor = true;
            this.deliveredButton.Click += new System.EventHandler(this.deliveredButton_Click);
            // 
            // missDeliveredButton
            // 
            this.missDeliveredButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missDeliveredButton.Location = new System.Drawing.Point(18, 118);
            this.missDeliveredButton.Name = "missDeliveredButton";
            this.missDeliveredButton.Size = new System.Drawing.Size(239, 46);
            this.missDeliveredButton.TabIndex = 2;
            this.missDeliveredButton.Text = "Miss-delivered an Object";
            this.missDeliveredButton.UseVisualStyleBackColor = true;
            this.missDeliveredButton.Click += new System.EventHandler(this.missDeliveredButton_Click);
            // 
            // EObjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 178);
            this.Controls.Add(this.missDeliveredButton);
            this.Controls.Add(this.deliveredButton);
            this.Controls.Add(this.deliveredObjects);
            this.Name = "EObjectsForm";
            this.Text = "EObjects";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label deliveredObjects;
        private System.Windows.Forms.Button deliveredButton;
        private System.Windows.Forms.Button missDeliveredButton;

    }
}