using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Système_de_Gestion_des_Étudiants
{
    public partial class SF_FormEtudiant : Form
    {
        public SF_FormEtudiant()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNom_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtNom.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Seules les lettres sont autorisées.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; 
            }
        }

        private void txtPrenom_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtPrenom.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Seules les lettres sont autorisées.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void txtAdresse_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtAdresse.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Seules les lettres et chiffres sont autorisés.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void txtTelephone_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtTelephone.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Seuls les chiffres sont autorisés.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }


        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Veuillez entrer une adresse e-mail valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; 
            }
        }


        private void btnAjouter_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtNom.Text) ||
                string.IsNullOrWhiteSpace(txtPrenom.Text) ||
                !rdHomme.Checked && !rdFemme.Checked ||  
                string.IsNullOrWhiteSpace(txtAdresse.Text) ||
                string.IsNullOrWhiteSpace(txtTelephone.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                comboBox1.SelectedIndex == -1) 
            {
                MessageBox.Show("Tous les champs doivent être remplis.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string sexe = rdHomme.Checked ? "Homme" : "Femme";

        
            int idClasse;
            if (!int.TryParse(comboBox1.SelectedValue.ToString(), out idClasse))
            {
                MessageBox.Show("Veuillez sélectionner une classe valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new GestionEtudiantsEntities())
            {
               
                bool classeExiste = db.Classes.Any(c => c.Id == idClasse);
                if (!classeExiste)
                {
                    MessageBox.Show("La classe spécifiée n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string nomPart = txtNom.Text.Substring(0, 2).ToUpper(); 
                string prenomPart = txtPrenom.Text.Substring(0, 2).ToUpper(); 
                string telephonePart = txtTelephone.Text.Substring(txtTelephone.Text.Length - 2); 
                string adressePart = txtAdresse.Text.Substring(0, 2).ToUpper(); 

               
                string matricule = $"{nomPart}{prenomPart}{telephonePart}{adressePart}";

                Etudiants etudiant = new Etudiants()
                {
                    Nom = txtNom.Text,
                    Prenom = txtPrenom.Text,
                    Matricule= matricule,
                    DateNaissance = dateTimePicker1.Value,
                    Sexe = sexe, 
                    Adresse = txtAdresse.Text,
                    Telephone = txtTelephone.Text,
                    Email = txtEmail.Text,
                    IdClasse = idClasse
                };

                db.Etudiants.Add(etudiant);
                db.SaveChanges();

                MessageBox.Show("Étudiant ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refresh();


                txtNom.Clear();
                txtPrenom.Clear();
                dateTimePicker1.Value = DateTime.Now;
                rdHomme.Checked = false;
                rdFemme.Checked = false;
                txtAdresse.Clear();
                txtTelephone.Clear();
                txtEmail.Clear();
                comboBox1.SelectedIndex = -1;
            }
        }

        private void ChargerClasses()
        {
            using (var db = new GestionEtudiantsEntities())
            {
                comboBox1.DataSource = db.Classes.ToList();
                comboBox1.DisplayMember = "NomClasse";  
                comboBox1.ValueMember = "Id";     
            }
        }

        private void SF_FormEtudiant_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ChargerClasses();

            refresh();
        }
        public void refresh()
        {
            dataGridView1.DataSource = null;
            using (var db = new GestionEtudiantsEntities())
            {
                var data = db.Etudiants
                    .Select(e => new
                    {
                        e.Id,
                        e.Matricule,
                        e.Prenom,
                        e.Nom,
                        e.DateNaissance,
                        e.Email,
                        e.Telephone,
                        e.Adresse,
                        NomClasse = e.Classes.NomClasse 
                    })
                    .ToList();

                dataGridView1.DataSource = data;
            }

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int idEtudiant = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                DialogResult confirmation = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer cet étudiant ?",
                    "Confirmation de suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmation == DialogResult.Yes)
                {
                    using (var db = new GestionEtudiantsEntities())
                    {
                        Etudiants etudiant = db.Etudiants.FirstOrDefault(et => et.Id == idEtudiant);

                        if (etudiant != null)
                        {
                            db.Etudiants.Remove(etudiant);
                            db.SaveChanges();

                            MessageBox.Show("Étudiant supprimé avec succès !");
                            refresh();
                        }
                        else
                        {
                            MessageBox.Show("Étudiant non trouvé.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne.");
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int idEtudiant = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                using (var db = new GestionEtudiantsEntities())
                {
                    Etudiants etudiant = db.Etudiants.FirstOrDefault(et => et.Id == idEtudiant);

                    if (etudiant != null)
                    {
                        
                        bool telephoneExists = db.Etudiants.Any(et => et.Telephone.Equals(txtTelephone.Text, StringComparison.OrdinalIgnoreCase) && et.Id != idEtudiant);
                        if (telephoneExists)
                        {
                            MessageBox.Show("Le numéro de téléphone existe déjà. Veuillez saisir un numéro différent.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        
                        bool emailExists = db.Etudiants.Any(et => et.Email.Equals(txtEmail.Text, StringComparison.OrdinalIgnoreCase) && et.Id != idEtudiant);
                        if (emailExists)
                        {
                            MessageBox.Show("L'email existe déjà. Veuillez saisir un email différent.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        
                        string nomPart = txtNom.Text.Length >= 2 ? txtNom.Text.Substring(0, 2).ToUpper() : txtNom.Text.ToUpper();
                        string prenomPart = txtPrenom.Text.Length >= 2 ? txtPrenom.Text.Substring(0, 2).ToUpper() : txtPrenom.Text.ToUpper();
                        string telephonePart = txtTelephone.Text.Length >= 2 ? txtTelephone.Text.Substring(txtTelephone.Text.Length - 2) : txtTelephone.Text;
                        string adressePart = txtAdresse.Text.Length >= 2 ? txtAdresse.Text.Substring(0, 2).ToUpper() : txtAdresse.Text.ToUpper();

                        string matricule = $"{nomPart}{prenomPart}{telephonePart}{adressePart}";

                        
                        etudiant.Nom = txtNom.Text;
                        etudiant.Prenom = txtPrenom.Text;
                        etudiant.DateNaissance = dateTimePicker1.Value;
                        etudiant.Matricule = matricule;

                        
                        if (rdHomme.Checked)
                        {
                            etudiant.Sexe = "Homme";
                        }
                        else if (rdFemme.Checked)
                        {
                            etudiant.Sexe = "Femme";
                        }

                       
                        etudiant.Adresse = txtAdresse.Text;
                        etudiant.Telephone = txtTelephone.Text;
                        etudiant.Email = txtEmail.Text;
                        etudiant.IdClasse = Convert.ToInt32(comboBox1.SelectedValue);

                        
                        db.SaveChanges();

                        MessageBox.Show("Étudiant modifié avec succès !");
                        refresh(); 
                    }
                    else
                    {
                        MessageBox.Show("Étudiant non trouvé.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne.");
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            using (FormRechercheEtudiant formRecherche = new FormRechercheEtudiant())
            {
                DialogResult result = formRecherche.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string recherche = formRecherche.Recherche;

                    using (var db = new GestionEtudiantsEntities())
                    {
                        var query = db.Etudiants.AsQueryable();

                       
                        if (!string.IsNullOrEmpty(recherche) && !recherche.Contains("@"))
                        {
                            query = query.Where(et => et.Nom.Contains(recherche));
                        }
                        
                        else if (!string.IsNullOrEmpty(recherche) && recherche.Contains("@"))
                        {
                            query = query.Where(et => et.Matricule.Contains(recherche));
                        }
                        
                        else if (!string.IsNullOrEmpty(recherche))
                        {
                           
                            var classe = db.Classes.FirstOrDefault(c => c.NomClasse.Contains(recherche));

                            if (classe != null)
                            {
                                query = query.Where(et => et.IdClasse == classe.Id); 
                            }
                            else
                            {
                                MessageBox.Show("Nom de classe non trouvé.");
                                return;
                            }
                        }

                        var data = query
                            .Select(et => new
                            {
                                et.Id,
                                et.Matricule,
                                et.Prenom,
                                et.Nom,
                                et.DateNaissance,
                                et.Email,
                                et.Telephone,
                                et.Adresse,
                                NomClasse = et.Classes.NomClasse
                            })
                            .ToList();

             
                        dataGridView1.DataSource = data;
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (comboBox1.SelectedValue != null)
                {
                    int idClasse = Convert.ToInt32(comboBox1.SelectedValue);

                    using (var db = new GestionEtudiantsEntities())
                    {
                        var etudiants = db.Etudiants
                            .Where(et => et.IdClasse == idClasse)
                            .Select(et => new
                            {
                                et.Id,
                                et.Matricule,
                                et.Prenom,
                                et.Nom,
                                et.DateNaissance,
                                et.Email,
                                et.Telephone,
                                et.Adresse,
                                NomClasse = et.Classes.NomClasse
                            })
                            .ToList();

                        dataGridView1.DataSource = etudiants;
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner une classe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                refresh(); 
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            using (var db = new GestionEtudiantsEntities())
            {
                var query = db.Etudiants.Select(et => new
                {
                    et.Id,
                    et.Matricule,
                    et.Prenom,
                    et.Nom,
                    et.DateNaissance,
                    et.Email,
                    et.Telephone,
                    et.Adresse,
                    NomClasse = et.Classes.NomClasse
                });

                if (checkBox4.Checked)
                {
                 
                    query = query.OrderBy(et => et.Nom);
                }

                dataGridView1.DataSource = query.ToList();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            using (var db = new GestionEtudiantsEntities())
            {
                var query = db.Etudiants.Select(et => new
                {
                    et.Id,
                    et.Matricule,
                    et.Prenom,
                    et.Nom,
                    et.DateNaissance,
                    et.Email,
                    et.Telephone,
                    et.Adresse,
                    NomClasse = et.Classes.NomClasse
                });

                if (checkBox3.Checked)
                {
                    query = query.OrderBy(et => et.Matricule);
                }

                dataGridView1.DataSource = query.ToList();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
           /* using (var db = new GestionEtudiantsEntities())
            {
                var query = db.Etudiants.Select(et => new
                {
                    et.Id,
                    et.Matricule,
                    et.Prenom,
                    et.Nom,
                    et.DateNaissance,
                    et.Email,
                    et.Telephone,
                    et.Adresse,
                    et.Resultat, 
                    NomClasse = et.Classes.NomClasse
                });

                if (checkBox2.Checked)
                {
                    query = query.OrderByDescending(et => et.Resultat);
                }

                dataGridView1.DataSource = query.ToList();
            }
           */
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnAjouter.Enabled = false;

            if (e.RowIndex >= 0)
            {
                int IdEtudiant = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

                using (var db = new GestionEtudiantsEntities())
                {
                   
                    Etudiants etudiant = db.Etudiants.Include("Classes") 
                                                     .FirstOrDefault(c => c.Id == IdEtudiant);

                    if (etudiant != null)
                    {
                        txtNom.Text = etudiant.Nom;
                        txtPrenom.Text = etudiant.Prenom;
                        dateTimePicker1.Value = etudiant.DateNaissance;
                        txtAdresse.Text = etudiant.Adresse;
                        txtTelephone.Text = etudiant.Telephone;
                        txtEmail.Text = etudiant.Email;

                        
                        if (etudiant.Sexe == "Homme")
                        {
                            rdHomme.Checked = true;
                        }
                        else if (etudiant.Sexe == "Femme")
                        {
                            rdFemme.Checked = true;
                        }
                        else
                        {
                            rdHomme.Checked = false;
                            rdFemme.Checked = false;
                        }

                        if (etudiant.Classes != null) 
                        {
                            comboBox1.SelectedValue = etudiant.Classes.Id;
                        }
                        else
                        {
                            comboBox1.SelectedIndex = -1; 
                        }
                    }
                    else
                    {
                        MessageBox.Show("Étudiant non trouvé.");
                    }
                }
            }
        }

    }
}
