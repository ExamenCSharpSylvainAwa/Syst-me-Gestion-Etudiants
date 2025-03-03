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
    public partial class SF_FormDashboardDE : Form
    {
        public SF_FormDashboardDE()
        {
            InitializeComponent();
        }

        private void btnClasse_Click(object sender, EventArgs e)
        {
            SF_FormClasseDE formClasseDE = new SF_FormClasseDE();
            formClasseDE.Show();
        }

        private void btnCours_Click(object sender, EventArgs e)
        {
            SF_FormCoursDE formCoursDE = new SF_FormCoursDE();
            formCoursDE.Show();
        }

        private void btnMatiere_Click(object sender, EventArgs e)
        {
            SF_FormMatieresDE formMatieresDE = new SF_FormMatieresDE();
            formMatieresDE.Show();
            
        }

        private void btnProfesseur_Click(object sender, EventArgs e)
        {
            SF_FormProfesseurDE formProfesseurDE = new SF_FormProfesseurDE();
            formProfesseurDE.Show();
        }

        private void btnResultat_Click(object sender, EventArgs e)
        {
            SF_FormResulatsDE formResulatsDE = new SF_FormResulatsDE();
            formResulatsDE.Show();
        }
    }
}
