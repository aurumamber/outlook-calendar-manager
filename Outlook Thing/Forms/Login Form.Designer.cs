namespace Outlook_Calendar_Manager
{
    partial class LoginForm
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
            this.client_id_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // client_id_label
            // 
            this.client_id_label.AutoSize = true;
            this.client_id_label.Location = new System.Drawing.Point(107, 125);
            this.client_id_label.Name = "client_id_label";
            this.client_id_label.Size = new System.Drawing.Size(17, 16);
            this.client_id_label.TabIndex = 0;
            this.client_id_label.Text = "\"\"";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 566);
            this.Controls.Add(this.client_id_label);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label client_id_label;
    }
}

