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
    public partial class SF_FormAgent : Form
    {
        public SF_FormAgent()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            SF_LoginForm loginForm = new SF_LoginForm();
            loginForm.Show();
        }

        private void btnEtudiant_Click(object sender, EventArgs e)
        {
            SF_FormAgentEtudiants formAgentEtudiants = new SF_FormAgentEtudiants();
            formAgentEtudiants.Show();
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            SF_FormAgentNotes formAgentNotes = new SF_FormAgentNotes();
            formAgentNotes.Show();
        }

        private void btnEtudiant_MouseEnter(object sender, EventArgs e)
        {
            btnEtudiant.BackColor = Color.FromArgb(0, 188, 212); // Couleur au survol du bouton Etudiant
            btnEtudiant.ForeColor = Color.White; // Couleur du texte
        }

        private void btnEtudiant_MouseLeave(object sender, EventArgs e)
        {
            btnEtudiant.BackColor = Color.White; // Couleur d'origine
            btnEtudiant.ForeColor = Color.Black; // Couleur du texte d'origine
        }

        private void btnNotes_MouseEnter(object sender, EventArgs e)
        {
            btnNotes.BackColor = Color.FromArgb(233, 30, 99); // Couleur au survol du bouton Notes
            btnNotes.ForeColor = Color.White; // Couleur du texte
        }

        private void btnNotes_MouseLeave(object sender, EventArgs e)
        {
            btnNotes.BackColor = Color.White; // Couleur d'origine
            btnNotes.ForeColor = Color.Black; // Couleur du texte d'origine
        }

    }
}
