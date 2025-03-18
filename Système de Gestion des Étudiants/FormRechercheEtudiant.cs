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
    public partial class FormRechercheEtudiant : Form
    {
        public string Recherche { get; set; }
        public FormRechercheEtudiant()
        {
            InitializeComponent();
        }

        private void FormRechercheEtudiant_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recherche = textBox1.Text.Trim();
            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(33, 150, 243); // Changer la couleur de fond au survol
            button1.ForeColor = Color.White; // Changer la couleur du texte au survol
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White; // Revenir à la couleur d'origine
            button1.ForeColor = Color.Black; // Revenir à la couleur du texte d'origine
        }

    }
}
