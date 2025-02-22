using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Système_de_Gestion_des_Étudiants
{
    internal class SF_FormManager
    {
        public static SF_LoginForm loginForm { get; set; }
        public static Form1 form1 { get; set; }
        public static SF_FormDashboardDE FormDashboardDE { get; set; }
        public static SF_FormAgent FormAgent { get; set; }
        public static SF_FormProfesseur FormProfesseur { get; set; }

        public static void SF_showLoginForm()
        {
            if (loginForm == null || loginForm.IsDisposed)
            {
                loginForm = new SF_LoginForm();
            }
            form1?.Hide();
            FormDashboardDE?.Hide();
            FormAgent?.Hide();
            FormProfesseur?.Hide();
            loginForm.Show();

        }
        public static void SF_HomeForm()
        {
            if (form1 == null || form1.IsDisposed)
            {
                form1 = new Form1();
            }
            loginForm?.Hide();
            FormDashboardDE?.Hide();
            FormAgent?.Hide();
            FormProfesseur?.Hide();
            form1.Show();

        }
        public static void SF_FormDashboardDE()
        {
            if (FormDashboardDE == null || FormDashboardDE.IsDisposed)
            {
                FormDashboardDE = new SF_FormDashboardDE();
            }
            loginForm?.Hide();
            form1?.Hide();
            FormAgent?.Hide();
            FormProfesseur?.Hide();
            FormDashboardDE.Show();

        }
        public static void SF_FormAgent()
        {
            if (FormAgent == null || FormAgent.IsDisposed)
            {
                FormAgent = new SF_FormAgent();
            }
            loginForm?.Hide();
            form1?.Hide();
            FormDashboardDE?.Hide();
            FormProfesseur?.Hide();
            FormAgent.Show();

        }
        public static void SF_FormProfesseur()
        {
            if (FormProfesseur == null || FormProfesseur.IsDisposed)
            {
                FormProfesseur = new SF_FormProfesseur();
            }
            loginForm?.Hide();
            form1?.Hide();
            FormDashboardDE?.Hide();
            FormAgent?.Hide();
            FormProfesseur.Show();

        }
    }
}
