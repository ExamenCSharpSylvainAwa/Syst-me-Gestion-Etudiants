namespace Système_de_Gestion_des_Étudiants
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnUser = new System.Windows.Forms.Button();
            this.btnEtudiant = new System.Windows.Forms.Button();
            this.btnProfesseur = new System.Windows.Forms.Button();
            this.btnClasse = new System.Windows.Forms.Button();
            this.btnCoursMatiere = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRapport = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUser
            // 
            this.btnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.Location = new System.Drawing.Point(411, 168);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(343, 94);
            this.btnUser.TabIndex = 0;
            this.btnUser.Text = "Utilisateurs";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnEtudiant
            // 
            this.btnEtudiant.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEtudiant.Location = new System.Drawing.Point(821, 168);
            this.btnEtudiant.Name = "btnEtudiant";
            this.btnEtudiant.Size = new System.Drawing.Size(352, 94);
            this.btnEtudiant.TabIndex = 1;
            this.btnEtudiant.Text = "Etudiants";
            this.btnEtudiant.UseVisualStyleBackColor = true;
            this.btnEtudiant.Click += new System.EventHandler(this.btnEtudiant_Click);
            // 
            // btnProfesseur
            // 
            this.btnProfesseur.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfesseur.Location = new System.Drawing.Point(821, 410);
            this.btnProfesseur.Name = "btnProfesseur";
            this.btnProfesseur.Size = new System.Drawing.Size(352, 94);
            this.btnProfesseur.TabIndex = 2;
            this.btnProfesseur.Text = "Professeurs";
            this.btnProfesseur.UseVisualStyleBackColor = true;
            this.btnProfesseur.Click += new System.EventHandler(this.btnProffesseur_Click);
            // 
            // btnClasse
            // 
            this.btnClasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClasse.Location = new System.Drawing.Point(1261, 168);
            this.btnClasse.Name = "btnClasse";
            this.btnClasse.Size = new System.Drawing.Size(343, 94);
            this.btnClasse.TabIndex = 3;
            this.btnClasse.Text = "Classes";
            this.btnClasse.UseVisualStyleBackColor = true;
            this.btnClasse.Click += new System.EventHandler(this.btnClasse_Click);
            // 
            // btnCoursMatiere
            // 
            this.btnCoursMatiere.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCoursMatiere.Location = new System.Drawing.Point(411, 410);
            this.btnCoursMatiere.Name = "btnCoursMatiere";
            this.btnCoursMatiere.Size = new System.Drawing.Size(343, 94);
            this.btnCoursMatiere.TabIndex = 4;
            this.btnCoursMatiere.Text = "Cours et Matières";
            this.btnCoursMatiere.UseVisualStyleBackColor = true;
            this.btnCoursMatiere.Click += new System.EventHandler(this.btnCoursMatiere_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1261, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(343, 94);
            this.button1.TabIndex = 5;
            this.button1.Text = "Notes";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 168);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(324, 484);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 46);
            this.label1.TabIndex = 7;
            this.label1.Text = "Administrateur";
            // 
            // btnRapport
            // 
            this.btnRapport.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRapport.Location = new System.Drawing.Point(744, 604);
            this.btnRapport.Name = "btnRapport";
            this.btnRapport.Size = new System.Drawing.Size(520, 94);
            this.btnRapport.TabIndex = 8;
            this.btnRapport.Text = "Rapports";
            this.btnRapport.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(12, 726);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(303, 47);
            this.button2.TabIndex = 9;
            this.button2.Text = "Déconnexion";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1687, 830);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRapport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCoursMatiere);
            this.Controls.Add(this.btnClasse);
            this.Controls.Add(this.btnProfesseur);
            this.Controls.Add(this.btnEtudiant);
            this.Controls.Add(this.btnUser);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion Etudiants";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnEtudiant;
        private System.Windows.Forms.Button btnProfesseur;
        private System.Windows.Forms.Button btnClasse;
        private System.Windows.Forms.Button btnCoursMatiere;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRapport;
        private System.Windows.Forms.Button button2;
    }
}

