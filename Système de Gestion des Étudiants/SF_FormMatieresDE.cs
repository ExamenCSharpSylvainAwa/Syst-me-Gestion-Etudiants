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

namespace Système_de_Gestion_des_Étudiants
{
    public partial class SF_FormMatieresDE : Form
    {
        public SF_FormMatieresDE()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
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

                comboBox1.DataSource = professeurs;
                comboBox1.DisplayMember = "Affichage";
                comboBox1.ValueMember = "Id";
            }
        }




        public void rafresh()
        {
            dataGridView1.DataSource = null;
            using (var db = new GestionEtudiantsEntities())
            {
                var matiereData = db.Matieres.ToList();

                var data = matiereData.Select(matiere => new
                {
                    matiere.Id,
                    matiere.NomMatiere,
                    NomProfesseur = string.Join(", ", matiere.Professeurs.Select(p => $"{p.Nom} {p.Prenom} ({p.Telephone})"))
                }).ToList();

                dataGridView1.DataSource = data;
            }
        }

        private void SF_FormMatieresDE_Load(object sender, EventArgs e)
        {
            rafresh();
            ChargerProfesseur();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            using (var db = new GestionEtudiantsEntities())
            {

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("La nom de la matiere ne peut pas être vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int idProfesseur;
                    if (!int.TryParse(comboBox1.SelectedValue.ToString(), out idProfesseur))
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
                            NomMatiere = textBox1.Text,
                        };

                        db.Matieres.Add(matieres);
                        db.SaveChanges();

                        matieres.Professeurs.Add(professeurs);
                        db.SaveChanges();

                        MessageBox.Show("Matière ajoutée avec succès.");


                        rafresh();


                        textBox1.Text = string.Empty;
                        comboBox1.SelectedItem = null;

                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Seules les lettres  sont autorisés.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int IdMatiere = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                using (var db = new GestionEtudiantsEntities())
                {

                    Matieres matiere = db.Matieres.FirstOrDefault(m => m.Id == IdMatiere);

                    if (matiere == null)
                    {
                        MessageBox.Show("Matière non trouvée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    bool matiereExists = db.Matieres.Any(m => m.NomMatiere.Equals(textBox1.Text, StringComparison.OrdinalIgnoreCase));
                    if (matiereExists)
                    {
                        MessageBox.Show("Cette matière existe déjà. Veuillez saisir un nom différent.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    matiere.NomMatiere = textBox1.Text;
                    matiere.Professeurs.Clear();

                    int idProfesseur;
                    if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out idProfesseur))
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
                    btnAjouter.Enabled = true;

                    textBox1.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une matière à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int IdMatiere = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value); 


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

            btnAjouter.Enabled = false;
            if (e.RowIndex >= 0)
            {
                int IdMatiere = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

                using (var db = new GestionEtudiantsEntities())
                {
                    Matieres matieres = db.Matieres.Include("Professeurs")
                                                .FirstOrDefault(c => c.Id == IdMatiere);
                    if (matieres != null)
                    {
                        textBox1.Text = matieres.NomMatiere;


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
