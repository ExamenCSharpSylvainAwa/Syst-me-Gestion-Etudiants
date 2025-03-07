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
    }
}
