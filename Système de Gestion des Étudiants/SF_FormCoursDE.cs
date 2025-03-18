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
    public partial class SF_FormCoursDE : Form
    {
        public SF_FormCoursDE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnAjouter_Click(object sender, EventArgs e)
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

        private void SF_FormCoursDE_Load(object sender, EventArgs e)
        {
            refresh();
            ChargerMatieres();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Seules les lettres  sont autorisés.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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
                        btnAjouter.Enabled = true;

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

        private void btnSupprimer_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnAjouter.Enabled = false;
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
                        textBox2.Text = cours.Description;

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAjouter_MouseEnter(object sender, EventArgs e)
        {
            btnAjouter.BackColor = Color.LightSkyBlue; 
            btnAjouter.ForeColor = Color.White;
        }

        private void btnAjouter_MouseLeave(object sender, EventArgs e)
        {
            btnAjouter.BackColor = Color.LightGray; 
            btnAjouter.ForeColor = Color.Black;
        }

        private void btnModifier_MouseEnter(object sender, EventArgs e)
        {
            btnModifier.BackColor = Color.LightGreen;
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

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Yellow;
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGray;
            button1.ForeColor = Color.Black;
        }

    }
}
