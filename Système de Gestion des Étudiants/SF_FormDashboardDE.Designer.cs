namespace Système_de_Gestion_des_Étudiants
{
    partial class SF_FormDashboardDE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SF_FormDashboardDE));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClasse = new System.Windows.Forms.Button();
            this.btnResultat = new System.Windows.Forms.Button();
            this.btnRapport = new System.Windows.Forms.Button();
            this.btnProfesseur = new System.Windows.Forms.Button();
            this.btnMatiere = new System.Windows.Forms.Button();
            this.btnCours = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCours);
            this.splitContainer1.Panel2.Controls.Add(this.btnMatiere);
            this.splitContainer1.Panel2.Controls.Add(this.btnProfesseur);
            this.splitContainer1.Panel2.Controls.Add(this.btnRapport);
            this.splitContainer1.Panel2.Controls.Add(this.btnResultat);
            this.splitContainer1.Panel2.Controls.Add(this.btnClasse);
            this.splitContainer1.Size = new System.Drawing.Size(1710, 787);
            this.splitContainer1.SplitterDistance = 340;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directeur d\'étude";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 191);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(334, 419);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnClasse
            // 
            this.btnClasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClasse.Location = new System.Drawing.Point(100, 191);
            this.btnClasse.Name = "btnClasse";
            this.btnClasse.Size = new System.Drawing.Size(283, 92);
            this.btnClasse.TabIndex = 0;
            this.btnClasse.Text = "Classes";
            this.btnClasse.UseVisualStyleBackColor = true;
            // 
            // btnResultat
            // 
            this.btnResultat.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResultat.Location = new System.Drawing.Point(542, 518);
            this.btnResultat.Name = "btnResultat";
            this.btnResultat.Size = new System.Drawing.Size(283, 92);
            this.btnResultat.TabIndex = 1;
            this.btnResultat.Text = "Résultats";
            this.btnResultat.UseVisualStyleBackColor = true;
            // 
            // btnRapport
            // 
            this.btnRapport.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRapport.Location = new System.Drawing.Point(1007, 518);
            this.btnRapport.Name = "btnRapport";
            this.btnRapport.Size = new System.Drawing.Size(283, 92);
            this.btnRapport.TabIndex = 2;
            this.btnRapport.Text = "Rapports";
            this.btnRapport.UseVisualStyleBackColor = true;
            // 
            // btnProfesseur
            // 
            this.btnProfesseur.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfesseur.Location = new System.Drawing.Point(100, 518);
            this.btnProfesseur.Name = "btnProfesseur";
            this.btnProfesseur.Size = new System.Drawing.Size(283, 92);
            this.btnProfesseur.TabIndex = 3;
            this.btnProfesseur.Text = "Professeurs";
            this.btnProfesseur.UseVisualStyleBackColor = true;
            // 
            // btnMatiere
            // 
            this.btnMatiere.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatiere.Location = new System.Drawing.Point(1007, 191);
            this.btnMatiere.Name = "btnMatiere";
            this.btnMatiere.Size = new System.Drawing.Size(283, 92);
            this.btnMatiere.TabIndex = 4;
            this.btnMatiere.Text = "Matières";
            this.btnMatiere.UseVisualStyleBackColor = true;
            // 
            // btnCours
            // 
            this.btnCours.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCours.Location = new System.Drawing.Point(542, 191);
            this.btnCours.Name = "btnCours";
            this.btnCours.Size = new System.Drawing.Size(283, 92);
            this.btnCours.TabIndex = 5;
            this.btnCours.Text = "Cours";
            this.btnCours.UseVisualStyleBackColor = true;
            // 
            // SF_FormDashboardDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1710, 787);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SF_FormDashboardDE";
            this.Text = "SF_FormDashboardDE";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClasse;
        private System.Windows.Forms.Button btnCours;
        private System.Windows.Forms.Button btnMatiere;
        private System.Windows.Forms.Button btnProfesseur;
        private System.Windows.Forms.Button btnRapport;
        private System.Windows.Forms.Button btnResultat;
    }
}