namespace Système_de_Gestion_des_Étudiants
{
    partial class SF_FormCoursMatieres
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnAjouterCours = new System.Windows.Forms.Button();
            this.btnFermer = new System.Windows.Forms.Button();
            this.btnSupprimerCours = new System.Windows.Forms.Button();
            this.btnModifierCours = new System.Windows.Forms.Button();
            this.btnModifierMatiere = new System.Windows.Forms.Button();
            this.btnAjouterMatieres = new System.Windows.Forms.Button();
            this.btnSupprimerMatiere = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(243, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestion Cours";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1117, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gestion Matères";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nom";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(809, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nom";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(551, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 29);
            this.label6.TabIndex = 5;
            this.label6.Text = "Matières";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(244, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 29);
            this.label7.TabIndex = 6;
            this.label7.Text = "Description";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 85);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 41);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(814, 85);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(206, 53);
            this.textBox3.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(249, 85);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(153, 41);
            this.textBox2.TabIndex = 10;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(775, 525);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(814, 144);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(798, 525);
            this.dataGridView2.TabIndex = 12;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick_1);
            this.dataGridView2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDoubleClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(556, 98);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(231, 28);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnAjouterCours
            // 
            this.btnAjouterCours.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouterCours.Location = new System.Drawing.Point(17, 722);
            this.btnAjouterCours.Name = "btnAjouterCours";
            this.btnAjouterCours.Size = new System.Drawing.Size(153, 43);
            this.btnAjouterCours.TabIndex = 14;
            this.btnAjouterCours.Text = "Ajouter";
            this.btnAjouterCours.UseVisualStyleBackColor = true;
            this.btnAjouterCours.Click += new System.EventHandler(this.btnAjouterCours_Click_1);
            // 
            // btnFermer
            // 
            this.btnFermer.BackColor = System.Drawing.Color.Red;
            this.btnFermer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFermer.ForeColor = System.Drawing.Color.White;
            this.btnFermer.Location = new System.Drawing.Point(1459, 722);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(153, 43);
            this.btnFermer.TabIndex = 15;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = false;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click_1);
            // 
            // btnSupprimerCours
            // 
            this.btnSupprimerCours.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimerCours.Location = new System.Drawing.Point(488, 722);
            this.btnSupprimerCours.Name = "btnSupprimerCours";
            this.btnSupprimerCours.Size = new System.Drawing.Size(202, 43);
            this.btnSupprimerCours.TabIndex = 16;
            this.btnSupprimerCours.Text = "Supprimer";
            this.btnSupprimerCours.UseVisualStyleBackColor = true;
            this.btnSupprimerCours.Click += new System.EventHandler(this.btnSupprimerCours_Click);
            // 
            // btnModifierCours
            // 
            this.btnModifierCours.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifierCours.Location = new System.Drawing.Point(249, 722);
            this.btnModifierCours.Name = "btnModifierCours";
            this.btnModifierCours.Size = new System.Drawing.Size(153, 43);
            this.btnModifierCours.TabIndex = 17;
            this.btnModifierCours.Text = "Modifier";
            this.btnModifierCours.UseVisualStyleBackColor = true;
            this.btnModifierCours.Click += new System.EventHandler(this.btnModifierCours_Click);
            // 
            // btnModifierMatiere
            // 
            this.btnModifierMatiere.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifierMatiere.Location = new System.Drawing.Point(1042, 722);
            this.btnModifierMatiere.Name = "btnModifierMatiere";
            this.btnModifierMatiere.Size = new System.Drawing.Size(153, 43);
            this.btnModifierMatiere.TabIndex = 18;
            this.btnModifierMatiere.Text = "Modifier";
            this.btnModifierMatiere.UseVisualStyleBackColor = true;
            this.btnModifierMatiere.Click += new System.EventHandler(this.btnModifierMatiere_Click);
            // 
            // btnAjouterMatieres
            // 
            this.btnAjouterMatieres.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouterMatieres.Location = new System.Drawing.Point(814, 722);
            this.btnAjouterMatieres.Name = "btnAjouterMatieres";
            this.btnAjouterMatieres.Size = new System.Drawing.Size(153, 43);
            this.btnAjouterMatieres.TabIndex = 19;
            this.btnAjouterMatieres.Text = "Ajouter";
            this.btnAjouterMatieres.UseVisualStyleBackColor = true;
            this.btnAjouterMatieres.Click += new System.EventHandler(this.btnAjouterMatieres_Click);
            // 
            // btnSupprimerMatiere
            // 
            this.btnSupprimerMatiere.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimerMatiere.Location = new System.Drawing.Point(1257, 722);
            this.btnSupprimerMatiere.Name = "btnSupprimerMatiere";
            this.btnSupprimerMatiere.Size = new System.Drawing.Size(173, 43);
            this.btnSupprimerMatiere.TabIndex = 20;
            this.btnSupprimerMatiere.Text = "Supprimer";
            this.btnSupprimerMatiere.UseVisualStyleBackColor = true;
            this.btnSupprimerMatiere.Click += new System.EventHandler(this.btnSupprimerMatiere_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(1123, 110);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(206, 28);
            this.comboBox3.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1118, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 29);
            this.label4.TabIndex = 23;
            this.label4.Text = "Professeur";
            // 
            // SF_FormCoursMatieres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1633, 803);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.btnSupprimerMatiere);
            this.Controls.Add(this.btnAjouterMatieres);
            this.Controls.Add(this.btnModifierMatiere);
            this.Controls.Add(this.btnModifierCours);
            this.Controls.Add(this.btnSupprimerCours);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.btnAjouterCours);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SF_FormCoursMatieres";
            this.Text = "SF_FormCoursMatieres";
            this.Load += new System.EventHandler(this.SF_FormCoursMatieres_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnAjouterCours;
        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Button btnSupprimerCours;
        private System.Windows.Forms.Button btnModifierCours;
        private System.Windows.Forms.Button btnModifierMatiere;
        private System.Windows.Forms.Button btnAjouterMatieres;
        private System.Windows.Forms.Button btnSupprimerMatiere;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label4;
    }
}