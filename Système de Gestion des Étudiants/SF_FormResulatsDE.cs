using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Système_de_Gestion_des_Étudiants
{
    public partial class SF_FormResulatsDE : Form
    {
        public SF_FormResulatsDE()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ChargerResultatsEtudiants()
        {
            using (var db = new GestionEtudiantsEntities())
            {
                var resultats = db.Etudiants
                    .Select(etudiant => new
                    {
                        etudiant.Id,
                        etudiant.Nom,
                        etudiant.Prenom,
                        etudiant.Email,
                        Moyenne = db.Notes
                            .Where(n => n.IdEtudiant == etudiant.Id)
                            .Average(n => (double?)n.Note) ?? 0 
                    })
                    .OrderByDescending(e => e.Moyenne) 
                    .ToList();

                dataGridView1.DataSource = resultats;
            }

            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SF_FormResulatsDE_Load(object sender, EventArgs e)
        {
            ChargerResultatsEtudiants();
        }
    }
}
