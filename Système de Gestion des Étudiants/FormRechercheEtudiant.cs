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
    }
}
