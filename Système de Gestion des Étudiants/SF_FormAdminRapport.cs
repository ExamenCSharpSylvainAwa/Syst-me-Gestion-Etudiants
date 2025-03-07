using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Système_de_Gestion_des_Étudiants
{
    public partial class SF_FormAdminRapport : Form
    {
        public SF_FormAdminRapport()
        {
            InitializeComponent();
        }

        private void SF_FormAdminRapport_Load(object sender, EventArgs e)
        {
            ChargerEtudiant();
            ChargerClasses();
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
        private void ChargerClasses()
        {
            using (var db = new GestionEtudiantsEntities())
            {
                comboBox2.DataSource = db.Classes.ToList();
                comboBox2.DisplayMember = "NomClasse";
                comboBox2.ValueMember = "Id";

            }
        }

        private void btnRelever_Click(object sender, EventArgs e)
        {
            ReportDocument report = new ReportDocument();

            report.Load(@"C:\SYLVAIN FAYE\Documents\Documents de Cheikh Sylvain FAYE\L3\C#\Syst-me-Gestion-Etudiants\Système de Gestion des Étudiants\ReleveDeNotesReport.rpt");

            int idEtudiant = (int)comboBox1.SelectedValue; 

          
            using (var db = new GestionEtudiantsEntities())
            {
                var data = db.Etudiants
                             .Where(et => et.Id == idEtudiant)
                             .Select(et => new
                             {
                                 et.Matricule,
                                 et.Nom,
                                 et.Prenom,
                                 et.Notes
                             }).ToList();

                report.SetDataSource(data);
            }

            crystalReportViewer1.ReportSource = report;

            crystalReportViewer1.RefreshReport();
        }
    }
}
