using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Système_de_Gestion_des_Étudiants
{
    public partial class SF_FormGestionProfesseur : Form
    {
        public SF_FormGestionProfesseur()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Seules les lettres et chiffres sont autorisés.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Seules les lettres et chiffres sont autorisés.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox3_Validating    (object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox3.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Veuillez entrer une adresse e-mail valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox2.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Seuls les chiffres sont autorisés.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
        private void ChargerMatieres()
        {         
            using (var db = new GestionEtudiantsEntities())
            {
                comboBoxMatiere.DataSource = db.Matieres.ToList();
                comboBoxMatiere.DisplayMember = "NomMatiere"; 
                comboBoxMatiere.ValueMember = "Id";             
            }
        }

        private void ChargerClasses()
        {
            using (var db = new GestionEtudiantsEntities())
            {
                comboBoxClasse.DataSource = db.Classes.ToList();
                comboBoxClasse.DisplayMember = "NomClasse"; 
                comboBoxClasse.ValueMember = "Id"; 

            }
        }




        private void SF_FormGestionProfesseur_Load(object sender, EventArgs e)
        {
            ChargerClasses();
            ChargerMatieres();
            RafraichirProfesseurs();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            using (var db = new GestionEtudiantsEntities())
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    comboBoxMatiere.SelectedItem == null ||
                    comboBoxClasse.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez remplir tous les champs et sélectionner au moins une matière et une classe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existingProf = db.Professeurs.FirstOrDefault(p => p.Email == textBox3.Text || p.Telephone == textBox2.Text);
                if (existingProf != null)
                {
                    MessageBox.Show("Un professeur avec cet e-mail ou ce numéro de téléphone existe déjà.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idMatiere;
                if (!int.TryParse(comboBoxMatiere.SelectedValue.ToString(), out idMatiere))
                {
                    MessageBox.Show("Veuillez sélectionner une matière valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Matieres matiere = db.Matieres.FirstOrDefault(m => m.Id == idMatiere);
                if (matiere == null)
                {
                    MessageBox.Show("La matière spécifiée n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idClasse;
                if (!int.TryParse(comboBoxClasse.SelectedValue.ToString(), out idClasse))
                {
                    MessageBox.Show("Veuillez sélectionner une classe valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Classes classe = db.Classes.FirstOrDefault(m => m.Id == idClasse);
                if (matiere == null)
                {
                    MessageBox.Show("La classe spécifiée n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                Professeurs professeur = new Professeurs()
                {
                    Nom = textBox1.Text,
                    Prenom = textBox4.Text,
                    Email = textBox3.Text,
                    Telephone = textBox2.Text,
                    
                };

                db.Professeurs.Add(professeur);
                db.SaveChanges();


                professeur.Matieres.Add(matiere);
                professeur.Classes.Add(classe);

                db.SaveChanges(); 

               

                MessageBox.Show($"Professeur ajouté avec succès",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RafraichirProfesseurs();
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;

                comboBoxMatiere.SelectedItem = null;
                comboBoxClasse.SelectedItem = null;

            }
        }
        private void RafraichirProfesseurs()
        {
            dataGridView1.DataSource = null;
            using (var db = new GestionEtudiantsEntities())
            {
                var professeurData = db.Professeurs

                   .ToList();

                var data = professeurData.Select(professeur => new
                {
                    professeur.Id,
                    professeur.Nom,
                    professeur.Prenom,
                    professeur.Email,
                    professeur.Telephone,
                    NomMatiere = string.Join(", ", professeur.Matieres.Select(m => m.NomMatiere)),
                    NomClasse=string.Join(", ", professeur.Classes.Select(m => m.NomClasse))
                }).ToList();

                dataGridView1.DataSource = data;
            }
        }



        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnAjouter.Enabled = false;
            if (e.RowIndex >= 0)
            {
                int IdProfesseur = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

                using (var db = new GestionEtudiantsEntities())
                {
                    Professeurs professeurs = db.Professeurs.Include("Classes").Include("Matieres")
                                                .FirstOrDefault(c => c.Id == IdProfesseur);
                    if (professeurs != null)
                    {
                        textBox1.Text = professeurs.Nom;
                        textBox4.Text= professeurs.Prenom;
                        textBox3.Text = professeurs.Email;
                        textBox2.Text = professeurs.Telephone;


                        var matiere = professeurs.Matieres.FirstOrDefault();
                        if (matiere != null)
                        {
                            comboBoxMatiere.SelectedValue = matiere.Id;
                        }
                        else
                        {
                            comboBoxMatiere.SelectedIndex = -1;
                        }
                        var classe = professeurs.Classes.FirstOrDefault();
                        if (classe != null)
                        {
                            comboBoxClasse.SelectedValue = classe.Id;
                        }
                        else
                        {
                            comboBoxClasse.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Professeur non trouvée.");
                    }
                }
            }

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un professeur à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProfesseur = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

            using (var db = new GestionEtudiantsEntities())
            {
                Professeurs professeur = db.Professeurs.Include("Classes").Include("Matieres")
                                          .FirstOrDefault(p => p.Id == idProfesseur);

                if (professeur == null)
                {
                    MessageBox.Show("Professeur non trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    comboBoxMatiere.SelectedItem == null ||
                    comboBoxClasse.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

              
                var existingProf = db.Professeurs.FirstOrDefault(p => (p.Email == textBox3.Text || p.Telephone == textBox2.Text) && p.Id != idProfesseur);
                if (existingProf != null)
                {
                    MessageBox.Show("Un autre professeur utilise déjà cet e-mail ou ce téléphone.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

              
                professeur.Nom = textBox1.Text;
                professeur.Prenom = textBox4.Text;
                professeur.Email = textBox3.Text;
                professeur.Telephone = textBox2.Text;

               
                int idMatiere = Convert.ToInt32(comboBoxMatiere.SelectedValue);
                int idClasse = Convert.ToInt32(comboBoxClasse.SelectedValue);

                professeur.Matieres.Clear();
                professeur.Classes.Clear();

                var matiere = db.Matieres.FirstOrDefault(m => m.Id == idMatiere);
                var classe = db.Classes.FirstOrDefault(c => c.Id == idClasse);

                if (matiere != null) professeur.Matieres.Add(matiere);
                if (classe != null) professeur.Classes.Add(classe);

                db.SaveChanges();

                MessageBox.Show("Professeur modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                RafraichirProfesseurs();

              
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBoxMatiere.SelectedItem = null;
                comboBoxClasse.SelectedItem = null;

                btnAjouter.Enabled = true; 
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un professeur à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProfesseur = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

            DialogResult confirmation = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce professeur ?",
                                                        "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.Yes)
            {
                using (var db = new GestionEtudiantsEntities())
                {
                    Professeurs professeur = db.Professeurs.Include("Classes").Include("Matieres")
                                              .FirstOrDefault(p => p.Id == idProfesseur);

                    if (professeur == null)
                    {
                        MessageBox.Show("Professeur non trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    professeur.Matieres.Clear();
                    professeur.Classes.Clear();
                    db.Professeurs.Remove(professeur);
                    db.SaveChanges();

                    MessageBox.Show("Professeur supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RafraichirProfesseurs();
                }
            }
        }

        private void btnAjouter_MouseEnter(object sender, EventArgs e)
        {
            btnAjouter.BackColor = Color.LimeGreen;
            btnAjouter.ForeColor = Color.White;
        }

        private void btnAjouter_MouseLeave(object sender, EventArgs e)
        {
            btnAjouter.BackColor = Color.LightGray;
            btnAjouter.ForeColor = Color.Black;
        }

        private void btnModifier_MouseEnter(object sender, EventArgs e)
        {
            btnModifier.BackColor = Color.DodgerBlue;
            btnModifier.ForeColor = Color.White;
        }

        private void btnModifier_MouseLeave(object sender, EventArgs e)
        {
            btnModifier.BackColor = Color.LightGray;
            btnModifier.ForeColor = Color.Black;
        }

        private void btnSupprimer_MouseEnter(object sender, EventArgs e)
        {
            btnSupprimer.BackColor = Color.IndianRed;
            btnSupprimer.ForeColor = Color.White;
        }

        private void btnSupprimer_MouseLeave(object sender, EventArgs e)
        {
            btnSupprimer.BackColor = Color.LightGray;
            btnSupprimer.ForeColor = Color.Black;
        }

        private void btnFermer_MouseEnter(object sender, EventArgs e)
        {
            btnFermer.BackColor = Color.Black;
            btnFermer.ForeColor = Color.White;
        }

        private void btnFermer_MouseLeave(object sender, EventArgs e)
        {
            btnFermer.BackColor = Color.LightGray;
            btnFermer.ForeColor = Color.Black;
        }

    }
}
