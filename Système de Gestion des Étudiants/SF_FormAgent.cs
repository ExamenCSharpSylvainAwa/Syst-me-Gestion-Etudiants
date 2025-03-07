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
    }
}
