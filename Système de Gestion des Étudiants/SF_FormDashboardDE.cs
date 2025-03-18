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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            SF_LoginForm loginForm = new SF_LoginForm();
            loginForm.Show();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
            button2.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Red;
        }

        private void btnClasse_MouseEnter(object sender, EventArgs e)
        {
            btnClasse.BackColor = Color.Turquoise;
            btnClasse.ForeColor = Color.White;
        }

        private void btnClasse_MouseLeave(object sender, EventArgs e)
        {
            btnClasse.BackColor = Color.LightGray;
            btnClasse.ForeColor = Color.Black;
        }

        private void btnCours_MouseEnter(object sender, EventArgs e)
        {
            btnCours.BackColor = Color.Orange;
            btnCours.ForeColor = Color.White;
        }

        private void btnCours_MouseLeave(object sender, EventArgs e)
        {
            btnCours.BackColor = Color.LightGray;
            btnCours.ForeColor = Color.Black;
        }

        private void btnMatiere_MouseEnter(object sender, EventArgs e)
        {
            btnMatiere.BackColor = Color.Cyan;
            btnMatiere.ForeColor = Color.White;
        }

        private void btnMatiere_MouseLeave(object sender, EventArgs e)
        {
            btnMatiere.BackColor = Color.LightGray;
            btnMatiere.ForeColor = Color.Black;
        }

        private void btnProfesseur_MouseEnter(object sender, EventArgs e)
        {
            btnProfesseur.BackColor = Color.Salmon;
            btnProfesseur.ForeColor = Color.White;
        }

        private void btnProfesseur_MouseLeave(object sender, EventArgs e)
        {
            btnProfesseur.BackColor = Color.LightGray;
            btnProfesseur.ForeColor = Color.Black;
        }

        private void btnResultat_MouseEnter(object sender, EventArgs e)
        {
            btnResultat.BackColor = Color.Olive;
            btnResultat.ForeColor = Color.White;
        }

        private void btnResultat_MouseLeave(object sender, EventArgs e)
        {
            btnResultat.BackColor = Color.LightGray;
            btnResultat.ForeColor = Color.Black;
        }

        private void btnRapport_MouseEnter(object sender, EventArgs e)
        {
            btnRapport.BackColor = Color.HotPink;
            btnRapport.ForeColor = Color.White;
        }

        private void btnRapport_MouseLeave(object sender, EventArgs e)
        {
            btnRapport.BackColor = Color.LightGray;
            btnRapport.ForeColor = Color.Black;
        }

    }
}
