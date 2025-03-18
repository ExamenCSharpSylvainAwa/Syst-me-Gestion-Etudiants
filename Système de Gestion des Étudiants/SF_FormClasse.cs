using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Système_de_Gestion_des_Étudiants;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Système_de_Gestion_des_Étudiants
{
    public partial class SF_FormClasse : Form
    {
        public SF_FormClasse()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          

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

        private void ChargerCours()
        {
            using (var db = new GestionEtudiantsEntities())
            {
                var cours = db.Cours
                    .Select(c => new
                    {
                        c.Id,
                        NomCours = c.NomCours 
                    })
                    .ToList();

                comboBox3.DataSource = cours;
                comboBox3.DisplayMember = "NomCours";
                comboBox3.ValueMember = "Id";
            }
        }



        private void btnAjouter_Click(object sender, EventArgs e)
        {
            using (var db = new GestionEtudiantsEntities())
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text)  || comboBox3.SelectedIndex == -1)
                {
                    MessageBox.Show("Tous les champs doivent être remplis.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idProfesseur;
                if (!int.TryParse(comboBox1.SelectedValue.ToString(), out idProfesseur))
                {
                    MessageBox.Show("Veuillez sélectionner un professeur valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idCours;
                if (!int.TryParse(comboBox3.SelectedValue.ToString(), out idCours))
                {
                    MessageBox.Show("Veuillez sélectionner un cours valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Professeurs professeurs = db.Professeurs.FirstOrDefault(m => m.Id == idProfesseur);
                if (professeurs == null)
                {
                    MessageBox.Show("Le professeur spécifié n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            
                Cours cours = db.Cours.FirstOrDefault(c => c.Id == idCours);
                if (cours == null)
                {
                    MessageBox.Show("Le cours spécifié n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool classExists = db.Classes.Any(c => c.NomClasse.Equals(textBox1.Text, StringComparison.OrdinalIgnoreCase));
                if (classExists)
                {
                    MessageBox.Show("Cette classe existe déjà. Veuillez saisir un nom différent.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Classes classe = new Classes()
                {
                    NomClasse = textBox1.Text,
                              
                };

                db.Classes.Add(classe);
                db.SaveChanges();

                classe.Professeurs.Add(professeurs);
                classe.Cours.Add(cours);

                db.SaveChanges();

                MessageBox.Show("Classe ajoutée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refresh();

                textBox1.Text = string.Empty;
                comboBox1.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int IdClasse = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                using (var db = new GestionEtudiantsEntities())
                {
                    Classes classe = db.Classes.FirstOrDefault(c => c.Id == IdClasse);

                    bool classExists = db.Classes.Any(c => c.NomClasse.Equals(textBox1.Text, StringComparison.OrdinalIgnoreCase) && c.Id != IdClasse);

                    if (classExists)
                    {
                        MessageBox.Show("Cette classe existe déjà. Veuillez saisir un nom différent.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (classe != null)
                    {
                        classe.NomClasse = textBox1.Text;

                        classe.Cours.Clear();
                        classe.Professeurs.Clear();

                        int IdCours;
                        if (comboBox3.SelectedValue != null && int.TryParse(comboBox3.SelectedValue.ToString(), out IdCours))
                        {
                            Cours cours = db.Cours.FirstOrDefault(c => c.Id == IdCours);
                            if (cours != null)
                            {
                                classe.Cours.Add(cours);
                            }
                            else
                            {
                                MessageBox.Show("Le cours sélectionnée n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Veuillez sélectionner un cours valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        int IdProfesseur;
                        if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out IdProfesseur))
                        {
                            Professeurs professeurs = db.Professeurs.FirstOrDefault(p => p.Id == IdProfesseur);
                            if (professeurs != null)
                            {
                                classe.Professeurs.Add(professeurs);
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

                        MessageBox.Show("Classe, cours et professeur modifiés avec succès !");
                        refresh();
                        btnAjouter.Enabled = true;

                        textBox1.Text = string.Empty;
                        comboBox3.SelectedIndex = -1;
                        comboBox1.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Classe non trouvée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void refresh()
        {
            dataGridView1.DataSource = null;
            using (var db = new GestionEtudiantsEntities())
            {
                var classeData = db.Classes.ToList();

                var data = classeData.Select(classes => new
                {
                    classes.Id,
                    classes.NomClasse,
                    NomProfesseur = string.Join(", ", classes.Professeurs.Select(p => $"{p.Nom} {p.Prenom} ({p.Telephone})")),
                    NomCours = string.Join(", ", classes.Cours.Select(c => $"{c.NomCours} "))

                }).ToList();

                dataGridView1.DataSource = data;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
       

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int IdClasse = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                DialogResult confirmation = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer cette classe ?",
                    "Confirmation de suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmation == DialogResult.Yes)
                {
                    using (var db = new GestionEtudiantsEntities())
                    {
                        Classes classes = db.Classes.FirstOrDefault(c => c.Id == IdClasse);

                        if (classes != null)
                        {
                            db.Classes.Remove(classes);
                            db.SaveChanges();

                            MessageBox.Show("Classe supprimée avec succès !");
                            refresh();
                        }
                        else
                        {
                            MessageBox.Show("Classe non trouvée.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne.");
            }
        }

        private void SF_FormClasse_Load(object sender, EventArgs e)
        {
            ChargerProfesseur();
            ChargerCours();
         
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            refresh();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnAjouter.Enabled = false;
            if (e.RowIndex >= 0)
            {
                int IdClasse = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

                using (var db = new GestionEtudiantsEntities())
                {
                    Classes classes = db.Classes.Include("Professeurs").Include("Cours")
                                                .FirstOrDefault(c => c.Id == IdClasse);
                    if (classes != null)
                    {
                        textBox1.Text = classes.NomClasse;

                        var professeur = classes.Professeurs.FirstOrDefault();
                        if (professeur != null)
                        {
                            comboBox1.SelectedValue = professeur.Id;
                        }
                        else
                        {
                            comboBox1.SelectedIndex = -1;
                        }

                        var cours = classes.Cours.FirstOrDefault();
                        if (cours != null)
                        {
                            comboBox3.SelectedValue = cours.Id;
                        }
                        else
                        {
                            comboBox3.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Classe non trouvée.");
                    }
                }
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Seules les lettres et chiffres sont autorisés.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;            }
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

        private void btnFermer_MouseEnter(object sender, EventArgs e)
        {
            btnFermer.BackColor = Color.DimGray;       
            btnFermer.ForeColor = Color.White;        
        }

        private void btnFermer_MouseLeave(object sender, EventArgs e)
        {
            btnFermer.BackColor = Color.LightGray;    
            btnFermer.ForeColor = Color.Black;       
        }

    }
}
