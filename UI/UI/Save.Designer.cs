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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btYes
            // 
            this.btYes.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btYes.BorderRadius = 10;
            this.btYes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btYes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btYes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btYes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btYes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btYes.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btYes.ForeColor = System.Drawing.Color.White;
            this.btYes.Location = new System.Drawing.Point(57, 112);
            this.btYes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btYes.Name = "btYes";
            this.btYes.Size = new System.Drawing.Size(180, 46);
            this.btYes.TabIndex = 0;
            this.btYes.Text = "Yes";
            this.btYes.Click += new System.EventHandler(this.btYes_Click);
            // 
            // btNo
            // 
            this.btNo.BorderRadius = 10;
            this.btNo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btNo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btNo.FillColor = System.Drawing.Color.White;
            this.btNo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btNo.Location = new System.Drawing.Point(280, 31);
            this.btNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btNo.Name = "btNo";
            this.btNo.Size = new System.Drawing.Size(180, 46);
            this.btNo.TabIndex = 1;
            this.btNo.Text = "No";
            this.btNo.Click += new System.EventHandler(this.btNo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btNo);
            this.panel1.Location = new System.Drawing.Point(-1, 81);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 105);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(67, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Do you want to save changes to Untitled ";
            // 
            // Save
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 181);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btYes);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Save";
            this.Text = "Save";
            this.Load += new System.EventHandler(this.Save_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btYes;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2Button btNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}