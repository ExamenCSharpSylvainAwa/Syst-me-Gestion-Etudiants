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

namespace Système_de_Gestion_des_Étudiants
{
    public partial class SF_FormCoursMatieres : Form
    {
        public SF_FormCoursMatieres()
        {
            InitializeComponent();
        }


        private void ChargerMatieres()
        {
            using (var db = new GestionEtudiantsEntities())
            {
                comboBox1.DataSource = db.Matieres.ToList();
                comboBox1.DisplayMember = "NomMatiere";
                comboBox1.ValueMember = "Id";
            }
        }
        public void refresh()
        {
            dataGridView1.DataSource = null;
            using (var db = new GestionEtudiantsEntities())
            {
                
                var coursData = db.Cours
                    
                    .ToList();

                
                var data = coursData.Select(cours => new
                {
                    cours.Id,
                    cours.NomCours,
                    cours.Description,
                    NomMatiere = string.Join(", ", cours.Matieres.Select(m => m.NomMatiere)) 
                }).ToList();

               
                dataGridView1.DataSource = data;
            }
        }
        private void ChargerProfesseur()
        {
            using (var db = new GestionEtudiantsEntities())
            {
                var professeurs = db.Professeurs
                    .ToList() 
                    .Select(p => new
                    {
                        p.Id,
                        Affichage = $"{p.Nom} {p.Prenom} - {p.Telephone}"
                    })
                    .ToList();

                comboBox3.DataSource = professeurs;
                comboBox3.DisplayMember = "Affichage"; 
                comboBox3.ValueMember = "Id"; 
            }
        }




        public void rafresh()
        {
            dataGridView2.DataSource = null;
            using (var db = new GestionEtudiantsEntities())
            {
                var matiereData = db.Matieres.ToList();

                var data = matiereData.Select(matiere => new
                {
                    matiere.Id,
                    matiere.NomMatiere,
                    NomProfesseur = string.Join(", ", matiere.Professeurs.Select(p => $"{p.Nom} {p.Prenom} ({p.Telephone})"))
                }).ToList();

                dataGridView2.DataSource = data;
            }
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFermer_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAjouterCours_Click_1(object sender, EventArgs e)
        {
            using (var db = new GestionEtudiantsEntities())
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Le nom du cours ne peut pas être vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("La description du cours ne peut pas être vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idMatiere;
                if (!int.TryParse(comboBox1.SelectedValue.ToString(), out idMatiere))
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
              
                bool coursExists = db.Cours.Any(c => c.NomCours.Equals(textBox1.Text, StringComparison.OrdinalIgnoreCase));
                if (coursExists)
                {
                    MessageBox.Show("Ce cours existe déjà. Veuillez saisir un nom différent.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Cours cours = new Cours()
                {
                    NomCours = textBox1.Text,
                    Description = textBox2.Text
                };

                db.Cours.Add(cours);
                db.SaveChanges();

                cours.Matieres.Add(matiere);
                


                db.SaveChanges();

                MessageBox.Show("Cours ajouté et associé avec succès à la matière.");

                refresh();

                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
            }
        }

        private void btnAjouterMatieres_Click(object sender, EventArgs e)
        {
            using (var db = new GestionEtudiantsEntities())
            {

                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("La nom de la matiere ne peut pas être vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int idProfesseur;
                    if (!int.TryParse(comboBox3.SelectedValue.ToString(), out idProfesseur))
                    {
                        MessageBox.Show("Veuillez sélectionner un professeur valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Professeurs professeurs = db.Professeurs.FirstOrDefault(m => m.Id == idProfesseur);
                    if (professeurs == null)
                    {
                        MessageBox.Show("Le professeur spécifiée n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    bool matiereExists = db.Matieres.Any(c => c.NomMatiere.Equals(textBox1.Text, StringComparison.OrdinalIgnoreCase));

                    if (matiereExists)
                    {
                        MessageBox.Show("Cette matière existe déjà. Veuillez saisir un nom différent.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        Matieres matieres = new Matieres()
                        {
                            NomMatiere = textBox3.Text,
                        };

                        db.Matieres.Add(matieres);
                        db.SaveChanges();

                        matieres.Professeurs.Add(professeurs);
                        db.SaveChanges();

                        MessageBox.Show("Matière ajoutée avec succès.");


                        rafresh();


                        textBox3.Text = string.Empty;
                        comboBox3.SelectedItem = null;

                    }
                }
            }
           }

        private void SF_FormCoursMatieres_Load(object sender, EventArgs e)
        {
            refresh();
            rafresh();
            ChargerMatieres();
            ChargerProfesseur();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Seules les lettres  sont autorisés.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Seules les lettres  sont autorisés.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnModifierCours_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int IdCours = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                using (var db = new GestionEtudiantsEntities())
                {
                    
                    Cours cours = db.Cours.FirstOrDefault(c => c.Id == IdCours);

                    if (cours == null)
                    {
                        MessageBox.Show("Cours non trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    bool coursExists = db.Cours.Any(c => c.NomCours.Equals(textBox1.Text, StringComparison.OrdinalIgnoreCase) && c.Id != IdCours);

                    if (coursExists)
                    {
                        MessageBox.Show("Ce cours existe déjà. Veuillez saisir un nom différent.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        cours.NomCours = textBox1.Text;
                        cours.Description = textBox2.Text;

                        
                        cours.Matieres.Clear();

                        int idMatiere;
                        if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out idMatiere))
                        {
                            Matieres matiere = db.Matieres.FirstOrDefault(m => m.Id == idMatiere);
                            if (matiere != null)
                            {
                                cours.Matieres.Add(matiere);
                            }
                            else
                            {
                                MessageBox.Show("La matière sélectionnée n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Veuillez sélectionner une matière valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                       
                        db.SaveChanges();

                        MessageBox.Show("Cours et matières associés modifiés avec succès !");
                        refresh(); 

                        textBox1.Text = string.Empty;
                        textBox2.Text = string.Empty;
                        comboBox1.SelectedIndex = -1;
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSupprimerCours_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int IdCours = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                DialogResult dialogResult = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce cours ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    using (var db = new GestionEtudiantsEntities())
                    {
                        Cours cours = db.Cours.FirstOrDefault(c => c.Id == IdCours);

                        if (cours == null)
                        {
                            MessageBox.Show("Cours non trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        foreach (var matiere in cours.Matieres.ToList())
                        {
                            cours.Matieres.Remove(matiere); 
                        }

                        
                        db.Cours.Remove(cours);
                        db.SaveChanges();

                        MessageBox.Show("Cours supprimé avec succès !");
                        refresh(); 
                    }
                }
                else
                {
                    
                    MessageBox.Show("Suppression annulée.", "Annulé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un cours à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModifierMatiere_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                int IdMatiere = Convert.ToInt32(dataGridView2.CurrentRow.Cells["Id"].Value); 

                using (var db = new GestionEtudiantsEntities())
                {
                   
                    Matieres matiere = db.Matieres.FirstOrDefault(m => m.Id == IdMatiere);

                    if (matiere == null)
                    {
                        MessageBox.Show("Matière non trouvée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    
                    bool matiereExists = db.Matieres.Any(m => m.NomMatiere.Equals(textBox3.Text, StringComparison.OrdinalIgnoreCase));
                    if (matiereExists)
                    {
                        MessageBox.Show("Cette matière existe déjà. Veuillez saisir un nom différent.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                   
                    matiere.NomMatiere = textBox3.Text;
                    matiere.Professeurs.Clear();

                    int idProfesseur;
                    if (comboBox3.SelectedValue != null && int.TryParse(comboBox3.SelectedValue.ToString(), out idProfesseur))
                    {
                        Professeurs professeurs = db.Professeurs.FirstOrDefault(m => m.Id == idProfesseur);
                        if (professeurs != null)
                        {
                            matiere.Professeurs.Add(professeurs);
                        }
                        else
                        {
                            MessageBox.Show("Le professeur sélectionnée n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez sélectionner un professeur valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    db.SaveChanges();

                    MessageBox.Show("Matière modifiée avec succès !");
                    rafresh(); 

                    textBox3.Text = string.Empty; 
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une matière à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSupprimerMatiere_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                int IdMatiere = Convert.ToInt32(dataGridView2.CurrentRow.Cells["Id"].Value); // Récupérer l'ID de la matière sélectionnée

              
                var confirmation = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette matière ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    using (var db = new GestionEtudiantsEntities())
                    {
                       
                        Matieres matiere = db.Matieres.FirstOrDefault(m => m.Id == IdMatiere);

                        if (matiere != null)
                        {
                            foreach (var professeur in matiere.Professeurs.ToList())
                            {
                                matiere.Professeurs.Remove(professeur);
                            }
                            db.Matieres.Remove(matiere);
                            db.SaveChanges();

                            MessageBox.Show("Matière supprimée avec succès !");
                            rafresh();
                        }
                        else
                        {
                            MessageBox.Show("La matière sélectionnée n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une matière à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnAjouterCours.Enabled = false;
            if (e.RowIndex >= 0)
            {
                int IdCours = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

                using (var db = new GestionEtudiantsEntities())
                {
                    Cours cours = db.Cours.Include("Matieres")
                                                .FirstOrDefault(c => c.Id == IdCours);
                    if (cours != null)
                    {
                        textBox1.Text = cours.NomCours;
                        textBox2.Text=cours.Description;

                        var matiere = cours.Matieres.FirstOrDefault();
                        if (matiere != null)
                        {
                            comboBox1.SelectedValue = matiere.Id;
                        }
                        else
                        {
                            comboBox1.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cours non trouvée.");
                    }
                }
            }
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnAjouterMatieres.Enabled = false;
            if (e.RowIndex >= 0)
            {
                int IdMatiere = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

                using (var db = new GestionEtudiantsEntities())
                {
                    Matieres matieres = db.Matieres.Include("Professeurs")
                                                .FirstOrDefault(c => c.Id == IdMatiere);
                    if (matieres != null)
                    {
                        textBox3.Text = matieres.NomMatiere;


                        var professeur = matieres.Professeurs.FirstOrDefault();
                        if (professeur != null)
                        {
                            comboBox1.SelectedValue = professeur.Id;
                        }
                        else
                        {
                            comboBox1.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Matiere non trouvée.");
                    }
                }
                }
            }
    }
}
