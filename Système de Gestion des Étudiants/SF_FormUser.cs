using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio.Types;
using Twilio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Twilio.Rest.Api.V2010.Account;
using DotNetEnv;

namespace Système_de_Gestion_des_Étudiants
{
    public partial class SF_FormUser : Form
    {
        public SF_FormUser()
        {
            InitializeComponent();
        }

        private void SF_FormUser_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            using (var db = new GestionEtudiantsEntities())
            {
                Utilisateurs utilisateurs = new Utilisateurs()
                {
                    NomUtilisateur = txtUsername.Text,
                    MotDePasse = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text),
                    Telephone = txtTelephone.Text,
                    Role = comboBox1.SelectedItem.ToString()
                };
                db.Utilisateurs.Add(utilisateurs);
                db.SaveChanges();


                SendVerificationCode(utilisateurs.Telephone, utilisateurs.Id);

                MessageBox.Show("Utilisateur ajouté avec succès et OTP envoyé.");
                refresh();
            }
        }
        private void SendVerificationCode(string phoneNumber, int userId)
        {
            try
            {
                Env.Load(@"C:\SYLVAIN FAYE\Documents\Documents de Cheikh Sylvain FAYE\L3\C#\Syst-me-Gestion-Etudiants\Système de Gestion des Étudiants\.env");

                var accountSid = Env.GetString("ACCOUNT_ID");
                var authToken = Env.GetString("AUTH_TOKEN");


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
                        IdUtilisateur = userId,
                        Code = otpCode,
                        DateExpiration = DateTime.Now.AddMinutes(5)
                    };
                    db.OTPCodes.Add(otp);
                    db.SaveChanges();
                }

                MessageBox.Show("OTP envoyé avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'envoi du SMS : " + ex.Message);
            }
        }
        public void refresh()
        {
            using (var db = new GestionEtudiantsEntities())
            {
                var data = db.Utilisateurs
                    .Select(u => new
                    {
                        u.Id,
                        u.NomUtilisateur,
                        u.Role,
                        u.Telephone
                    })
                    .ToList();

                dataGridView1.DataSource = data;
            }
        }
    }
}
