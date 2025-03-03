using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Système_de_Gestion_des_Étudiants
{
    public partial class SF_AdminNotesForm : Form
    {
        public SF_AdminNotesForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"^[0-9]+([.,][0-9]+)?$"))
            {
                MessageBox.Show("Veuillez entrer un nombre valide (ex : 12.5 ou 12,5)", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                string valeur = textBox1.Text.Replace(',', '.');

                if (double.TryParse(valeur, NumberStyles.Float, CultureInfo.InvariantCulture, out double nombre))
                {
                    if (nombre < 0 || nombre > 20)
                    {
                        MessageBox.Show("Veuillez entrer un nombre entre 0 et 20.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez entrer un nombre valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void ChargerEtudiant()
        {
            using (var db = new GestionEtudiantsEntities())
            {
                var etudiants = db.Etudiants
                    .Select(et => new
                    {
                        et.Id,
                        NomComplet = et.Matricule + " - " + et.Prenom + " " + et.Nom
                    })
                    .ToList();

                comboBox1.DataSource = etudiants;
                comboBox1.DisplayMember = "NomComplet"; 
                comboBox1.ValueMember = "Id"; 
            }
        }

        private void ChargerMatiere()
        {
            using (var db = new GestionEtudiantsEntities())
            {
                comboBox2.DataSource = db.Matieres.ToList();
                comboBox2.DisplayMember = "NomMatiere";
                comboBox2.ValueMember = "Id";
            }
        }

        private void SF_AdminNotesForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            refresh();
            ChargerEtudiant();
            ChargerMatiere();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                comboBox1.SelectedIndex == -1 ||
                comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Tous les champs doivent être remplis.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEtudiant;
            if (!int.TryParse(comboBox1.SelectedValue.ToString(), out idEtudiant))
            {
                MessageBox.Show("Veuillez sélectionner un étudiant valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idMatiere;
            if (!int.TryParse(comboBox2.SelectedValue.ToString(), out idMatiere))
            {
                MessageBox.Show("Veuillez sélectionner une matière valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new GestionEtudiantsEntities())
            {
                bool EtudiantsExist = db.Etudiants.Any(et => et.Id == idEtudiant);
                if (!EtudiantsExist)
                {
                    MessageBox.Show("L'étudiant spécifié n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double note;
                if (!double.TryParse(textBox1.Text, out note))
                {
                    MessageBox.Show("Veuillez entrer une note valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Notes notes = new Notes()
                {
                    Note = note,
                    IdEtudiant = idEtudiant,
                    IdMatiere = idMatiere
                };

                db.Notes.Add(notes);
                db.SaveChanges();

                MessageBox.Show("Note ajoutée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refresh();

                textBox1.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
        }

        public void refresh()
        {
            dataGridView1.DataSource = null;

            using (var db = new GestionEtudiantsEntities())
            {
                var data = db.Notes
                    .Select(n => new
                    {
                        n.Id,  
                        Matricule = n.Etudiants.Matricule,  
                        NomPrenom = n.Etudiants.Prenom + " " + n.Etudiants.Nom,  
                        Matiere = n.Matieres.NomMatiere, 
                        n.Note  
                    })
                    .ToList();

                dataGridView1.DataSource = data;

                dataGridView1.Columns["Id"].HeaderText = "ID Note";
                dataGridView1.Columns["Matricule"].HeaderText = "Matricule Étudiant";
                dataGridView1.Columns["NomPrenom"].HeaderText = "Nom et Prénom";
                dataGridView1.Columns["Matiere"].HeaderText = "Matière";
                dataGridView1.Columns["Note"].HeaderText = "Note";
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                var selectedRow = dataGridView1.Rows[e.RowIndex];

                int IdNote = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                using (var db = new GestionEtudiantsEntities())
                {
                    var note = db.Notes.Include("Etudiants")
                                       .Include("Matieres")
                                       .FirstOrDefault(n => n.Id == IdNote); 

                    if (note != null)
                    {
                        textBox1.Text = note.Note.ToString();

                        if (note.Etudiants != null)
                        {
                            comboBox1.SelectedValue = note.Etudiants.Id;
                        }
                        else
                        {
                            comboBox1.SelectedIndex = -1;
                        }

                        if (note.Matieres != null)
                        {
                            comboBox2.SelectedValue = note.Matieres.Id;
                        }
                        else
                        {
                            comboBox2.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Note non trouvée.");
                    }
                }
            }
        }



        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) 
            {
                int IdNote = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                DialogResult dialogResult = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette note ?",
                                                            "Confirmation",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    using (var db = new GestionEtudiantsEntities())
                    {
                        Notes notes = db.Notes.FirstOrDefault(n => n.Id == IdNote);

                        if (notes != null)
                        {
                            try
                            {
                                db.Notes.Remove(notes);
                                db.SaveChanges();

                                MessageBox.Show("Note supprimée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                refresh(); 
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erreur lors de la suppression : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("La note spécifiée n'a pas été trouvée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) 
            {
                int IdNote = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                using (var db = new GestionEtudiantsEntities())
                {
                    Notes notes = db.Notes.Include("Etudiants")
                                          .Include("Matieres")
                                          .FirstOrDefault(n => n.Id == IdNote);

                    if (notes != null)
                    {
                        if (string.IsNullOrWhiteSpace(textBox1.Text) || comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
                        {
                            MessageBox.Show("Tous les champs doivent être remplis correctement.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        notes.Note = double.Parse(textBox1.Text);
                        notes.IdEtudiant = Convert.ToInt32(comboBox1.SelectedValue);
                        notes.IdMatiere = Convert.ToInt32(comboBox2.SelectedValue);

                        try
                        {
                            db.SaveChanges();
                            MessageBox.Show("Note modifiée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            refresh();
                            btnAjouter.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erreur lors de la modification : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La note spécifiée n'a pas été trouvée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMoyenne_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                int idEtudiant = Convert.ToInt32(comboBox1.SelectedValue);

                using (var db = new GestionEtudiantsEntities())
                {
                    var etudiant = db.Etudiants
                                     .Where(et => et.Id == idEtudiant)
                                     .Select(et => new
                                     {
                                         et.Matricule,
                                         NomPrenom = et.Prenom + " " + et.Nom
                                     })
                                     .FirstOrDefault();

                    if (etudiant != null)
                    {
                        var notes = db.Notes
                                      .Where(n => n.IdEtudiant == idEtudiant)
                                      .ToList();

                        if (notes.Any())
                        {
                            var moyenne = notes.Average(n => n.Note);

                            MessageBox.Show(
                                $"Étudiant : {etudiant.NomPrenom}\nMatricule : {etudiant.Matricule}\nMoyenne : {moyenne:0.00}",
                                "Moyenne", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Aucune note trouvée pour cet étudiant.",
                                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("L'étudiant sélectionné n'existe pas.",
                                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un étudiant.",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReleve_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                int idEtudiant = Convert.ToInt32(comboBox1.SelectedValue);

                using (var db = new GestionEtudiantsEntities())
                {
                    var etudiant = db.Etudiants
                                     .Where(et => et.Id == idEtudiant)
                                     .Select(et => new
                                     {
                                         et.Matricule,
                                         NomPrenom = et.Prenom + " " + et.Nom
                                     })
                                     .FirstOrDefault();

                    if (etudiant != null)
                    {
                        var notes = db.Notes
                                      .Where(n => n.IdEtudiant == idEtudiant)
                                      .GroupBy(n => n.IdMatiere)
                                      .Select(g => new
                                      {
                                          Matiere = g.FirstOrDefault().Matieres.NomMatiere,
                                          Moyenne = g.Average(n => n.Note)
                                      })
                                      .ToList();

                        if (notes.Any())
                        {
                            double moyenneGenerale = notes.Average(n => n.Moyenne);

                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine($"📌 Étudiant : {etudiant.NomPrenom}");
                            sb.AppendLine($"📌 Matricule : {etudiant.Matricule}\n");
                            sb.AppendLine("🔹 **Moyennes par matière** :");

                            foreach (var note in notes)
                            {
                                sb.AppendLine($"- {note.Matiere} : {note.Moyenne:0.00}");
                            }

                            sb.AppendLine($"\n📊 **Moyenne Générale** : {moyenneGenerale:0.00}");

                            MessageBox.Show(sb.ToString(), "Relevé de Notes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Aucune note trouvée pour cet étudiant.",
                                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("L'étudiant sélectionné n'existe pas.",
                                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un étudiant.",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
