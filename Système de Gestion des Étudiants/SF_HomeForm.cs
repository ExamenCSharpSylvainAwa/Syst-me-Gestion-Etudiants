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

        private void btnRapport_Click(object sender, EventArgs e)
        {
            SF_FormAdminRapport formAdminRapport = new SF_FormAdminRapport();
            formAdminRapport.Show();
        }

        private void btnUser_MouseEnter(object sender, EventArgs e)
        {
            btnUser.BackColor = Color.RoyalBlue; 
            btnUser.ForeColor = Color.White; 
        }

        private void btnUser_MouseLeave(object sender, EventArgs e)
        {
            btnUser.BackColor = Color.LightGray; 
            btnUser.ForeColor = Color.Black; 
        }

        private void btnEtudiant_MouseEnter(object sender, EventArgs e)
        {
            btnEtudiant.BackColor = Color.RoyalBlue;
            btnEtudiant.ForeColor = Color.White;
        }

        private void btnEtudiant_MouseLeave(object sender, EventArgs e)
        {
            btnEtudiant.BackColor = Color.LightGray;
            btnEtudiant.ForeColor = Color.Black;
        }

        private void btnClasse_MouseEnter(object sender, EventArgs e)
        {
            btnClasse.BackColor = Color.RoyalBlue;
            btnClasse.ForeColor = Color.White;

        }

        private void btnClasse_MouseLeave(object sender, EventArgs e)
        {
            btnClasse.BackColor = Color.LightGray;
            btnClasse.ForeColor = Color.Black;

        }

        private void btnCoursMatiere_MouseEnter(object sender, EventArgs e)
        {
            btnCoursMatiere.BackColor = Color.RoyalBlue;
            btnCoursMatiere.ForeColor = Color.White;
        }

        private void btnCoursMatiere_MouseLeave(object sender, EventArgs e)
        {
            btnCoursMatiere.BackColor = Color.LightGray;
            btnCoursMatiere.ForeColor = Color.Black;
        }

        private void btnProfesseur_MouseEnter(object sender, EventArgs e)
        {
            btnProfesseur.BackColor = Color.RoyalBlue;
            btnProfesseur.ForeColor = Color.White;
        }

        private void btnProfesseur_MouseLeave(object sender, EventArgs e)
        {
            btnProfesseur.BackColor = Color.LightGray;
            btnProfesseur.ForeColor = Color.Black;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.RoyalBlue;
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGray;
            button1.ForeColor = Color.Black;
        }

        private void btnRapport_MouseEnter(object sender, EventArgs e)
        {
            btnRapport.BackColor = Color.RoyalBlue;
            btnRapport.ForeColor = Color.White;
        }

        private void btnRapport_MouseLeave(object sender, EventArgs e)
        {
            btnRapport.BackColor = Color.LightGray;
            btnRapport.ForeColor = Color.Black;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Red;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {

            button2.BackColor = Color.Red;
            button2.ForeColor = Color.White;
        }
    }
}
