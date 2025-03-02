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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProffesseur_Click(object sender, EventArgs e)
        {
            SF_FormGestionProfesseur formGestionProfesseur = new SF_FormGestionProfesseur();
            formGestionProfesseur.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            SF_FormUser formUser = new SF_FormUser();
            formUser.Show();
        }

        private void btnClasse_Click(object sender, EventArgs e)
        {
            SF_FormClasse formClasse = new SF_FormClasse();
            formClasse.Show();
        }

        private void btnEtudiant_Click(object sender, EventArgs e)
        {
            SF_FormEtudiant formEtudiant = new SF_FormEtudiant();
            formEtudiant.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            SF_LoginForm loginForm = new SF_LoginForm();
            loginForm.Show();
        }

        private void btnCoursMatiere_Click(object sender, EventArgs e)
        {
            SF_FormCoursMatieres formCoursMatieres  = new SF_FormCoursMatieres();
            formCoursMatieres.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SF_AdminNotesForm adminNotesForm = new SF_AdminNotesForm();
            adminNotesForm.Show();
        }
    }
}
