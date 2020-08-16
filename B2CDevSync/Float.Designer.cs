namespace B2CDevSync
{
    partial class Float
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
            this.picFileIcon = new System.Windows.Forms.PictureBox();
            this.lblFileOperation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picFileIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picFileIcon
            // 
            this.picFileIcon.Location = new System.Drawing.Point(13, 13);
            this.picFileIcon.Name = "picFileIcon";
            this.picFileIcon.Size = new System.Drawing.Size(74, 74);
            this.picFileIcon.TabIndex = 0;
            this.picFileIcon.TabStop = false;
            // 
            // lblFileOperation
            // 
            this.lblFileOperation.Font = new System.Drawing.Font("Segoe UI Semibold", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileOperation.Location = new System.Drawing.Point(93, 13);
            this.lblFileOperation.Name = "lblFileOperation";
            this.lblFileOperation.Size = new System.Drawing.Size(458, 77);
            this.lblFileOperation.TabIndex = 1;
            // 
            // Float
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 99);
            this.Controls.Add(this.lblFileOperation);
            this.Controls.Add(this.picFileIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Float";
            this.Text = "Float";
            ((System.ComponentModel.ISupportInitialize)(this.picFileIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picFileIcon;
        private System.Windows.Forms.Label lblFileOperation;
    }
}