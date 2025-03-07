namespace Système_de_Gestion_des_Étudiants
{
    partial class SF_FormAdminRapport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnRelever = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.releveDeNotesReport1 = new Système_de_Gestion_des_Étudiants.ReleveDeNotesReport();
            this.releveDeNotesReport2 = new Système_de_Gestion_des_Étudiants.ReleveDeNotesReport();
            this.ReleveDeNotesReport3 = new Système_de_Gestion_des_Étudiants.ReleveDeNotesReport();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ReleveDeNotesReport4 = new Système_de_Gestion_des_Étudiants.ReleveDeNotesReport();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(631, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rapports";
            // 
            // btnRelever
            // 
            this.btnRelever.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelever.Location = new System.Drawing.Point(63, 522);
            this.btnRelever.Name = "btnRelever";
            this.btnRelever.Size = new System.Drawing.Size(402, 84);
            this.btnRelever.TabIndex = 1;
            this.btnRelever.Text = "Relevés Etudiant";
            this.btnRelever.UseVisualStyleBackColor = true;
            this.btnRelever.Click += new System.EventHandler(this.btnRelever_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1078, 522);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(516, 84);
            this.button1.TabIndex = 2;
            this.button1.Text = "Liste Best Etudiant par Classe";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(557, 522);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(467, 84);
            this.button2.TabIndex = 3;
            this.button2.Text = "Liste Etudiant par Classe";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(63, 248);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(402, 28);
            this.comboBox1.TabIndex = 4;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(557, 248);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(1037, 28);
            this.comboBox2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 37);
            this.label2.TabIndex = 7;
            this.label2.Text = "Etudiant";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(550, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 37);
            this.label3.TabIndex = 8;
            this.label3.Text = "Classe";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.DisplayToolbar = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(333, 532);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.ReleveDeNotesReport4;
            this.crystalReportViewer1.Size = new System.Drawing.Size(10, 10);
            this.crystalReportViewer1.TabIndex = 9;
            // 
            // SF_FormAdminRapport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1633, 813);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRelever);
            this.Controls.Add(this.label1);
            this.Name = "SF_FormAdminRapport";
            this.Text = "SF_FormAdminRapport";
            this.Load += new System.EventHandler(this.SF_FormAdminRapport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRelever;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ReleveDeNotesReport releveDeNotesReport1;
        private ReleveDeNotesReport releveDeNotesReport2;
        private ReleveDeNotesReport ReleveDeNotesReport3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private ReleveDeNotesReport ReleveDeNotesReport4;
    }
}