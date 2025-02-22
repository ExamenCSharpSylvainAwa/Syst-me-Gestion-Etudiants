using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Système_de_Gestion_des_Étudiants
{
    public partial class OTPVerificationForm : Form
    {
        private SF_LoginForm loginForm;

        public OTPVerificationForm(SF_LoginForm form)
        {
            InitializeComponent();
            loginForm = form;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string enteredOTP = textBoxOTP.Text.Trim();
            if (!string.IsNullOrEmpty(enteredOTP))
            {
                loginForm.VerifyOTP(enteredOTP);
                this.Close();
            }
            else
            {
                MessageBox.Show("Veuillez entrer le code OTP.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OTPVerificationForm_Load(object sender, EventArgs e)
        {

        }

        private void btnVerify_Click_1(object sender, EventArgs e)
        {

        }
    }
}
