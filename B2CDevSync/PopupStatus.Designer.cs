namespace B2CDevSync
{
    partial class PopupStatus
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
            this.txtOperationsLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStatusClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOperationsLog
            // 
            this.txtOperationsLog.Location = new System.Drawing.Point(12, 78);
            this.txtOperationsLog.Multiline = true;
            this.txtOperationsLog.Name = "txtOperationsLog";
            this.txtOperationsLog.ReadOnly = true;
            this.txtOperationsLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOperationsLog.Size = new System.Drawing.Size(573, 682);
            this.txtOperationsLog.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(14);
            this.label1.Size = new System.Drawing.Size(594, 74);
            this.label1.TabIndex = 1;
            this.label1.Text = "B2C Dev Sync Log";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStatusClose
            // 
            this.btnStatusClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatusClose.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnStatusClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStatusClose.Location = new System.Drawing.Point(536, 12);
            this.btnStatusClose.Name = "btnStatusClose";
            this.btnStatusClose.Size = new System.Drawing.Size(48, 36);
            this.btnStatusClose.TabIndex = 2;
            this.btnStatusClose.Text = "X";
            this.btnStatusClose.UseVisualStyleBackColor = false;
            this.btnStatusClose.Click += new System.EventHandler(this.btnStatusClose_Click);
            // 
            // PopupStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(596, 772);
            this.ControlBox = false;
            this.Controls.Add(this.btnStatusClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOperationsLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopupStatus";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PopupStatus";
            this.VisibleChanged += new System.EventHandler(this.PopupStatus_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOperationsLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStatusClose;
    }
}