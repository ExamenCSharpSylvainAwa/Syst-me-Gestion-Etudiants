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
    public partial class SF_FormProfesseur : Form
    {
        public SF_FormProfesseur()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
 

        private void btnNote_Click(object sender, EventArgs e)
        {
            SF_FormProfesseurNotes formProfesseurNotes = new SF_FormProfesseurNotes();
            formProfesseurNotes.Show();
        }

        private void btnEtudiant_Click(object sender, EventArgs e)
        {
            SF_FormProfesseurEtudiants formProfesseurEtudiants =  new SF_FormProfesseurEtudiants();
            formProfesseurEtudiants.Show();
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

        private void btnNote_MouseEnter(object sender, EventArgs e)
        {
            btnNote.BackColor = Color.SkyBlue;
            btnNote.ForeColor = Color.White;
        }

        private void btnNote_MouseLeave(object sender, EventArgs e)
        {
            btnNote.BackColor = Color.LightGray;
            btnNote.ForeColor = Color.Black;
        }

        private void btnEtudiant_MouseEnter(object sender, EventArgs e)
        {
            btnEtudiant.BackColor = Color.LightGreen;
            btnEtudiant.ForeColor = Color.White;
        }

        private void btnEtudiant_MouseLeave(object sender, EventArgs e)
        {
            btnEtudiant.BackColor = Color.LightGray;
            btnEtudiant.ForeColor = Color.Black;
        }

    }
}
