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
            this.btnUser = new System.Windows.Forms.Button();
            this.btnEtudiant = new System.Windows.Forms.Button();
            this.btnProffesseur = new System.Windows.Forms.Button();
            this.btnClasse = new System.Windows.Forms.Button();
            this.btnCoursMatiere = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUser
            // 
            this.btnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.Location = new System.Drawing.Point(358, 240);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(343, 94);
            this.btnUser.TabIndex = 0;
            this.btnUser.Text = "Utilisateurs";
            this.btnUser.UseVisualStyleBackColor = true;
            // 
            // btnEtudiant
            // 
            this.btnEtudiant.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEtudiant.Location = new System.Drawing.Point(808, 240);
            this.btnEtudiant.Name = "btnEtudiant";
            this.btnEtudiant.Size = new System.Drawing.Size(308, 94);
            this.btnEtudiant.TabIndex = 1;
            this.btnEtudiant.Text = "Etudiants";
            this.btnEtudiant.UseVisualStyleBackColor = true;
            // 
            // btnProffesseur
            // 
            this.btnProffesseur.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProffesseur.Location = new System.Drawing.Point(808, 392);
            this.btnProffesseur.Name = "btnProffesseur";
            this.btnProffesseur.Size = new System.Drawing.Size(308, 94);
            this.btnProffesseur.TabIndex = 2;
            this.btnProffesseur.Text = "Professeurs";
            this.btnProffesseur.UseVisualStyleBackColor = true;
            // 
            // btnClasse
            // 
            this.btnClasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClasse.Location = new System.Drawing.Point(1273, 240);
            this.btnClasse.Name = "btnClasse";
            this.btnClasse.Size = new System.Drawing.Size(308, 94);
            this.btnClasse.TabIndex = 3;
            this.btnClasse.Text = "Classes";
            this.btnClasse.UseVisualStyleBackColor = true;
            // 
            // btnCoursMatiere
            // 
            this.btnCoursMatiere.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCoursMatiere.Location = new System.Drawing.Point(358, 392);
            this.btnCoursMatiere.Name = "btnCoursMatiere";
            this.btnCoursMatiere.Size = new System.Drawing.Size(343, 94);
            this.btnCoursMatiere.TabIndex = 4;
            this.btnCoursMatiere.Text = "Cours et Matières";
            this.btnCoursMatiere.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1273, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(308, 94);
            this.button1.TabIndex = 5;
            this.button1.Text = "Notes";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1687, 830);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCoursMatiere);
            this.Controls.Add(this.btnClasse);
            this.Controls.Add(this.btnProffesseur);
            this.Controls.Add(this.btnEtudiant);
            this.Controls.Add(this.btnUser);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion Etudiants";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnEtudiant;
        private System.Windows.Forms.Button btnProffesseur;
        private System.Windows.Forms.Button btnClasse;
        private System.Windows.Forms.Button btnCoursMatiere;
        private System.Windows.Forms.Button button1;
    }
}

