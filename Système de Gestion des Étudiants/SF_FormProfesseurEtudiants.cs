using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;

namespace Système_de_Gestion_des_Étudiants
{
    public partial class SF_FormProfesseurEtudiants : Form
    {
        public SF_FormProfesseurEtudiants()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SF_FormProfesseurEtudiants_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            refresh();
        }
        public void refresh()
        {
            dataGridView1.DataSource = null;

            using (var db = new GestionEtudiantsEntities())
            {
                var data = db.Etudiants
                    .Include(e => e.Classes) 
                    .Select(e => new
                    {
                      
                        e.Matricule,
                        e.Prenom,
                        e.Nom,
                        e.DateNaissance,
                        e.Email,
                        e.Telephone,
                        e.Adresse,
                        NomClasse = e.Classes != null ? e.Classes.NomClasse : "Aucune classe" 
                    })
                    .ToList();

                dataGridView1.DataSource = data;
            }
        }


    }
}
