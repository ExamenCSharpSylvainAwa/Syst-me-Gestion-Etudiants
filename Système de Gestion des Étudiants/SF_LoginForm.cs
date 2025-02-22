using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetEnv;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Système_de_Gestion_des_Étudiants
{
    public partial class SF_LoginForm : Form
    {
        private string otpCode;
        private Utilisateurs currentUser;
        public SF_LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new GestionEtudiantsEntities())
                {
                    Utilisateurs utilisateurs = db.Utilisateurs.FirstOrDefault(c => c.NomUtilisateur == txtUsername.Text);


                    if (utilisateurs != null && BCrypt.Net.BCrypt.Verify(txtPassword.Text, utilisateurs.MotDePasse))
                    {
                        currentUser = utilisateurs;
                        SendOTPCode(utilisateurs.Telephone);
                        OTPVerificationForm otpForm = new OTPVerificationForm(this);
                        otpForm.ShowDialog();
                        OpenUserDashboard();


                    }
                    else
                    {
                        MessageBox.Show("Mot de passe incorrect.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
             private void SendOTPCode(string phoneNumber)
            {
                try
                {
               
                Env.Load(@"C:\SYLVAIN FAYE\Documents\Documents de Cheikh Sylvain FAYE\L3\C#\Syst-me-Gestion-Etudiants\Système de Gestion des Étudiants\.env");

                var accountSid = Env.GetString("ACCOUNT_ID");
                var authToken = Env.GetString("AUTH_TOKEN");
    
                MessageBox.Show($"Loaded Account SID: {accountSid}\nLoaded Auth Token: {authToken}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TwilioClient.Init(accountSid, authToken);

                string formattedPhoneNumber;

                if (phoneNumber.StartsWith("+221"))
                {
                    formattedPhoneNumber = phoneNumber;
                }
                else
                {
                    formattedPhoneNumber = $"+221{phoneNumber.TrimStart('0')}";
                }
                Random random = new Random();
                string otpCode = random.Next(100000, 999999).ToString();

                var message = MessageResource.Create(
                    to: new PhoneNumber(formattedPhoneNumber),
                    from: new PhoneNumber("+221 77 406 58 59"),
                    body: $"Ton code OTP est : {otpCode}"
                );


                using (var db = new GestionEtudiantsEntities())
                {
                    OTPCodes otp = new OTPCodes()
                    {
                        IdUtilisateur = currentUser.Id,
                        Code = otpCode,
                        DateExpiration = DateTime.Now.AddMinutes(5)
                    };
                    db.OTPCodes.Add(otp);
                    db.SaveChanges();
                }

                MessageBox.Show("Un code de vérification a été envoyé à votre téléphone.", "Vérification OTP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'envoi du SMS : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void VerifyOTP(string otp)
        {
            try
            {

                using (var db = new GestionEtudiantsEntities())
                {
                    var otpRecord = db.OTPCodes
                                      .Where(o => o.IdUtilisateur == currentUser.Id)
                                      .OrderByDescending(o => o.DateExpiration)
                                      .FirstOrDefault();

                    if (otpRecord != null)
                    {

                        if (otpRecord.Code == otp && otpRecord.DateExpiration > DateTime.Now)
                        {
                            MessageBox.Show("Authentification réussie !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            OpenUserDashboard();
                        }
                        else
                        {
                            MessageBox.Show("Code OTP incorrect ou expiré.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aucun code OTP trouvé pour cet utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la vérification du code OTP : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenUserDashboard()
        {
            switch (currentUser.Role)
            {
                case "Administrateur":
                    SF_FormManager.SF_HomeForm();
                    break;
                case "DE":
                    SF_FormManager.SF_FormDashboardDE();
                    break;
                case "Agent":
                    SF_FormManager.SF_FormAgent();
                    break;
                case "Professeur":
                    SF_FormManager.SF_FormProfesseur();
                    break;
                default:
                    MessageBox.Show("Rôle inconnu. Contactez l'administrateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void SF_LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

