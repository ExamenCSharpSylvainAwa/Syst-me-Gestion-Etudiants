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
                txtUsername.Text =string.Empty;
                txtPassword.Text =string.Empty;
                txtTelephone.Text =string.Empty;
                comboBox1.SelectedIndex = -1;

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
                    from: new PhoneNumber("+221 774065859"),
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

        private void btnSupprimer_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int idUtilisateur = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                using (var db = new GestionEtudiantsEntities())
                {
                    Utilisateurs utilisateur = db.Utilisateurs.FirstOrDefault(u => u.Id == idUtilisateur);

                    if (utilisateur != null)
                    {
                        string roleUtilisateurConnecte = GetRoleUtilisateurConnecte();

                        if (roleUtilisateurConnecte == "Administrateur" && utilisateur.Role == "Administrateur")
                        {
                            MessageBox.Show("Vous ne pouvez pas supprimer un autre administrateur.");
                            return;
                        }

                        db.Utilisateurs.Remove(utilisateur);
                        db.SaveChanges();

                        refresh();
                        MessageBox.Show("Utilisateur supprimé avec succès.");
                    }
                    else
                    {
                        MessageBox.Show("Utilisateur non trouvé.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur à supprimer.");
            }
        }


        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idUtilisateur = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                using (var db = new GestionEtudiantsEntities())
                {
                    Utilisateurs utilisateur = db.Utilisateurs.FirstOrDefault(u => u.Id == idUtilisateur);

                    if (utilisateur != null)
                    {
                        utilisateur.NomUtilisateur = txtUsername.Text;
                        utilisateur.MotDePasse = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);
                        utilisateur.Telephone = txtTelephone.Text;
                        utilisateur.Role = comboBox1.SelectedItem.ToString();

                        db.SaveChanges();

                        MessageBox.Show("Utilisateur modifié avec succès.");

                        refresh();

                        txtUsername.Text = string.Empty;
                        txtPassword.Text = string.Empty;
                        txtTelephone.Text = string.Empty;
                        comboBox1.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Utilisateur non trouvé.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur à modifier.");
            }
        }
        private string GetRoleUtilisateurConnecte()
        {
            int idUtilisateurConnecte = 1;
            using (var db = new GestionEtudiantsEntities())
            {
                var utilisateur = db.Utilisateurs.FirstOrDefault(u => u.Id == idUtilisateurConnecte);
                return utilisateur?.Role ?? string.Empty; 
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnAjouter.Enabled = false;
            if (e.RowIndex >= 0)
            {
                int idUtilisateur = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

                using (var db = new GestionEtudiantsEntities())
                {
                    Utilisateurs utilisateur = db.Utilisateurs.FirstOrDefault(u => u.Id == idUtilisateur);

                    if (utilisateur != null)
                    {
                        txtUsername.Text = utilisateur.NomUtilisateur;
                        txtPassword.Text = ""; 
                        txtTelephone.Text = utilisateur.Telephone;
                        comboBox1.SelectedItem = utilisateur.Role; 
                    }
                    else
                    {
                        MessageBox.Show("Utilisateur non trouvé.");
                    }
                }
            }
        }
    }
}
