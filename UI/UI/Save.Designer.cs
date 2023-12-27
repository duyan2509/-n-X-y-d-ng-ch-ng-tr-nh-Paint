namespace UI
{
    partial class Save
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
            this.components = new System.ComponentModel.Container();
            this.btYes = new Guna.UI2.WinForms.Guna2Button();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.btNo = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btYes
            // 
            this.btYes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btYes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btYes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btYes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btYes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btYes.ForeColor = System.Drawing.Color.White;
            this.btYes.Location = new System.Drawing.Point(119, 206);
            this.btYes.Name = "btYes";
            this.btYes.Size = new System.Drawing.Size(180, 45);
            this.btYes.TabIndex = 0;
            this.btYes.Text = "Yes";
            this.btYes.Click += new System.EventHandler(this.btYes_Click);
            // 
            // btNo
            // 
            this.btNo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btNo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btNo.ForeColor = System.Drawing.Color.White;
            this.btNo.Location = new System.Drawing.Point(359, 206);
            this.btNo.Name = "btNo";
            this.btNo.Size = new System.Drawing.Size(180, 45);
            this.btNo.TabIndex = 1;
            this.btNo.Text = "No";
            this.btNo.Click += new System.EventHandler(this.btNo_Click);
            // 
            // Save
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btNo);
            this.Controls.Add(this.btYes);
            this.Name = "Save";
            this.Text = "Save";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btYes;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2Button btNo;
    }
}