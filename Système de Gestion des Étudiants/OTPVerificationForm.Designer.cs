namespace Système_de_Gestion_des_Étudiants
{
    partial class OTPVerificationForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxOTP;
        private System.Windows.Forms.Button btnVerify;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBoxOTP = new System.Windows.Forms.TextBox();
            btnVerify = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // textBoxOTP
            // 
            textBoxOTP.Location = new System.Drawing.Point(83, 58);
            textBoxOTP.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            textBoxOTP.Name = "textBoxOTP";
            textBoxOTP.Size = new System.Drawing.Size(331, 31);
            textBoxOTP.TabIndex = 0;
            // 
            // btnVerify
            // 
            btnVerify.Location = new System.Drawing.Point(83, 115);
            btnVerify.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new System.Drawing.Size(333, 58);
            btnVerify.TabIndex = 1;
            btnVerify.Text = "Vérifier";
            btnVerify.UseVisualStyleBackColor = true;
            btnVerify.Click += btnVerify_Click;
            // 
            // OTPVerificationForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(500, 231);
            Controls.Add(textBoxOTP);
            Controls.Add(btnVerify);
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "OTPVerificationForm";
            Text = "Vérification OTP";
            Load += OTPVerificationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
