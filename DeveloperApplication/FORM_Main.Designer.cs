namespace DeveloperApplication
{
    partial class FORM_Main
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
            this.MS_Menu = new System.Windows.Forms.MenuStrip();
            this.TSMI_Fichier = new System.Windows.Forms.ToolStripMenuItem();
            this.DGV_Joueurs = new System.Windows.Forms.DataGridView();
            this.DGV_Personnages = new System.Windows.Forms.DataGridView();
            this.BTN_CONS_Joueur = new System.Windows.Forms.Button();
            this.BTN_SUPP_Joueur = new System.Windows.Forms.Button();
            this.BTN_AJT_Perso = new System.Windows.Forms.Button();
            this.BTN_CONS_Perso = new System.Windows.Forms.Button();
            this.BTN_SUPP_Perso = new System.Windows.Forms.Button();
            this.MS_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Joueurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Personnages)).BeginInit();
            this.SuspendLayout();
            // 
            // MS_Menu
            // 
            this.MS_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Fichier});
            this.MS_Menu.Location = new System.Drawing.Point(0, 0);
            this.MS_Menu.Name = "MS_Menu";
            this.MS_Menu.Size = new System.Drawing.Size(800, 24);
            this.MS_Menu.TabIndex = 0;
            this.MS_Menu.Text = "menuStrip1";
            // 
            // TSMI_Fichier
            // 
            this.TSMI_Fichier.Name = "TSMI_Fichier";
            this.TSMI_Fichier.Size = new System.Drawing.Size(54, 20);
            this.TSMI_Fichier.Text = "Fichier";
            // 
            // DGV_Joueurs
            // 
            this.DGV_Joueurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Joueurs.Location = new System.Drawing.Point(13, 28);
            this.DGV_Joueurs.Name = "DGV_Joueurs";
            this.DGV_Joueurs.Size = new System.Drawing.Size(300, 233);
            this.DGV_Joueurs.TabIndex = 1;
            // 
            // DGV_Personnages
            // 
            this.DGV_Personnages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Personnages.Location = new System.Drawing.Point(350, 28);
            this.DGV_Personnages.Name = "DGV_Personnages";
            this.DGV_Personnages.Size = new System.Drawing.Size(434, 233);
            this.DGV_Personnages.TabIndex = 2;
            // 
            // BTN_CONS_Joueur
            // 
            this.BTN_CONS_Joueur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CONS_Joueur.Location = new System.Drawing.Point(13, 267);
            this.BTN_CONS_Joueur.Name = "BTN_CONS_Joueur";
            this.BTN_CONS_Joueur.Size = new System.Drawing.Size(148, 23);
            this.BTN_CONS_Joueur.TabIndex = 4;
            this.BTN_CONS_Joueur.Text = "Consulter";
            this.BTN_CONS_Joueur.UseVisualStyleBackColor = true;
            // 
            // BTN_SUPP_Joueur
            // 
            this.BTN_SUPP_Joueur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SUPP_Joueur.Location = new System.Drawing.Point(165, 267);
            this.BTN_SUPP_Joueur.Name = "BTN_SUPP_Joueur";
            this.BTN_SUPP_Joueur.Size = new System.Drawing.Size(148, 23);
            this.BTN_SUPP_Joueur.TabIndex = 5;
            this.BTN_SUPP_Joueur.Text = "Supprimer";
            this.BTN_SUPP_Joueur.UseVisualStyleBackColor = true;
            // 
            // BTN_AJT_Perso
            // 
            this.BTN_AJT_Perso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_AJT_Perso.Location = new System.Drawing.Point(350, 267);
            this.BTN_AJT_Perso.Name = "BTN_AJT_Perso";
            this.BTN_AJT_Perso.Size = new System.Drawing.Size(141, 23);
            this.BTN_AJT_Perso.TabIndex = 6;
            this.BTN_AJT_Perso.Text = "Ajouter";
            this.BTN_AJT_Perso.UseVisualStyleBackColor = true;
            // 
            // BTN_CONS_Perso
            // 
            this.BTN_CONS_Perso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CONS_Perso.Location = new System.Drawing.Point(497, 267);
            this.BTN_CONS_Perso.Name = "BTN_CONS_Perso";
            this.BTN_CONS_Perso.Size = new System.Drawing.Size(141, 23);
            this.BTN_CONS_Perso.TabIndex = 7;
            this.BTN_CONS_Perso.Text = "Consulter";
            this.BTN_CONS_Perso.UseVisualStyleBackColor = true;
            // 
            // BTN_SUPP_Perso
            // 
            this.BTN_SUPP_Perso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SUPP_Perso.Location = new System.Drawing.Point(643, 267);
            this.BTN_SUPP_Perso.Name = "BTN_SUPP_Perso";
            this.BTN_SUPP_Perso.Size = new System.Drawing.Size(141, 23);
            this.BTN_SUPP_Perso.TabIndex = 8;
            this.BTN_SUPP_Perso.Text = "Supprimer";
            this.BTN_SUPP_Perso.UseVisualStyleBackColor = true;
            // 
            // FORM_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 305);
            this.Controls.Add(this.BTN_SUPP_Perso);
            this.Controls.Add(this.BTN_CONS_Perso);
            this.Controls.Add(this.BTN_AJT_Perso);
            this.Controls.Add(this.BTN_SUPP_Joueur);
            this.Controls.Add(this.BTN_CONS_Joueur);
            this.Controls.Add(this.DGV_Personnages);
            this.Controls.Add(this.DGV_Joueurs);
            this.Controls.Add(this.MS_Menu);
            this.MainMenuStrip = this.MS_Menu;
            this.Name = "FORM_Main";
            this.Load += new System.EventHandler(this.FORM_Main_Load);
            this.MS_Menu.ResumeLayout(false);
            this.MS_Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Joueurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Personnages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MS_Menu;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Fichier;
        private System.Windows.Forms.DataGridView DGV_Joueurs;
        private System.Windows.Forms.DataGridView DGV_Personnages;
        private System.Windows.Forms.Button BTN_CONS_Joueur;
        private System.Windows.Forms.Button BTN_SUPP_Joueur;
        private System.Windows.Forms.Button BTN_AJT_Perso;
        private System.Windows.Forms.Button BTN_CONS_Perso;
        private System.Windows.Forms.Button BTN_SUPP_Perso;
    }
}

