namespace MethuselahRS_Client.UserControls.Forms
{
    partial class FullscreenClient
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.btnExitFullscreen = new System.Windows.Forms.Button();
            this.containerPanel = new System.Windows.Forms.Panel();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.headerPanel.Controls.Add(this.btnExitFullscreen);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(948, 32);
            this.headerPanel.TabIndex = 0;
            // 
            // btnExitFullscreen
            // 
            this.btnExitFullscreen.Location = new System.Drawing.Point(356, 4);
            this.btnExitFullscreen.Name = "btnExitFullscreen";
            this.btnExitFullscreen.Size = new System.Drawing.Size(200, 23);
            this.btnExitFullscreen.TabIndex = 0;
            this.btnExitFullscreen.Text = "Close Fullscreen Mode";
            this.btnExitFullscreen.UseVisualStyleBackColor = true;
            this.btnExitFullscreen.Click += new System.EventHandler(this.btnExitFullscreen_Click);
            // 
            // containerPanel
            // 
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(0, 32);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(948, 697);
            this.containerPanel.TabIndex = 1;
            // 
            // FullscreenClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "FullscreenClient";
            this.Size = new System.Drawing.Size(948, 729);
            this.headerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel headerPanel;
        public System.Windows.Forms.Panel containerPanel;
        private System.Windows.Forms.Button btnExitFullscreen;
    }
}
