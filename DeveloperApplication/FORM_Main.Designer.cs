﻿namespace DeveloperApplication
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
            this.DGV_Joueurs = new System.Windows.Forms.DataGridView();
            this.DGV_Personnages = new System.Windows.Forms.DataGridView();
            this.BTN_CONS_Joueur = new System.Windows.Forms.Button();
            this.BTN_DESAC_Joueur = new System.Windows.Forms.Button();
            this.BTN_AJT_Perso = new System.Windows.Forms.Button();
            this.BTN_CONS_Perso = new System.Windows.Forms.Button();
            this.BTN_DESAC_Perso = new System.Windows.Forms.Button();
            this.CHECK_CFM_Joueur = new System.Windows.Forms.CheckBox();
            this.CHECK_CFM_Perso = new System.Windows.Forms.CheckBox();
            this.STRIP_Menu = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Quitter = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Items = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Potions = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Joueurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Personnages)).BeginInit();
            this.STRIP_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV_Joueurs
            // 
            this.DGV_Joueurs.AllowUserToAddRows = false;
            this.DGV_Joueurs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Joueurs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_Joueurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Joueurs.Location = new System.Drawing.Point(13, 27);
            this.DGV_Joueurs.MultiSelect = false;
            this.DGV_Joueurs.Name = "DGV_Joueurs";
            this.DGV_Joueurs.ReadOnly = true;
            this.DGV_Joueurs.RowHeadersVisible = false;
            this.DGV_Joueurs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Joueurs.Size = new System.Drawing.Size(300, 168);
            this.DGV_Joueurs.TabIndex = 1;
            this.DGV_Joueurs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Joueurs_CellClick);
            this.DGV_Joueurs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Joueurs_CellDoubleClick);
            // 
            // DGV_Personnages
            // 
            this.DGV_Personnages.AllowUserToAddRows = false;
            this.DGV_Personnages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Personnages.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_Personnages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Personnages.Location = new System.Drawing.Point(350, 27);
            this.DGV_Personnages.MultiSelect = false;
            this.DGV_Personnages.Name = "DGV_Personnages";
            this.DGV_Personnages.ReadOnly = true;
            this.DGV_Personnages.RowHeadersVisible = false;
            this.DGV_Personnages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Personnages.Size = new System.Drawing.Size(434, 168);
            this.DGV_Personnages.TabIndex = 2;
            this.DGV_Personnages.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Personnages_CellClick);
            this.DGV_Personnages.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Personnages_CellDoubleClick);
            // 
            // BTN_CONS_Joueur
            // 
            this.BTN_CONS_Joueur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CONS_Joueur.Location = new System.Drawing.Point(13, 201);
            this.BTN_CONS_Joueur.Name = "BTN_CONS_Joueur";
            this.BTN_CONS_Joueur.Size = new System.Drawing.Size(100, 23);
            this.BTN_CONS_Joueur.TabIndex = 4;
            this.BTN_CONS_Joueur.Text = "Consulter";
            this.BTN_CONS_Joueur.UseVisualStyleBackColor = true;
            this.BTN_CONS_Joueur.Click += new System.EventHandler(this.BTN_CONS_Joueur_Click);
            // 
            // BTN_DESAC_Joueur
            // 
            this.BTN_DESAC_Joueur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DESAC_Joueur.Location = new System.Drawing.Point(119, 201);
            this.BTN_DESAC_Joueur.Name = "BTN_DESAC_Joueur";
            this.BTN_DESAC_Joueur.Size = new System.Drawing.Size(100, 23);
            this.BTN_DESAC_Joueur.TabIndex = 5;
            this.BTN_DESAC_Joueur.Text = "Désactiver";
            this.BTN_DESAC_Joueur.UseVisualStyleBackColor = true;
            this.BTN_DESAC_Joueur.Click += new System.EventHandler(this.BTN_DESAC_Joueur_Click);
            // 
            // BTN_AJT_Perso
            // 
            this.BTN_AJT_Perso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_AJT_Perso.Location = new System.Drawing.Point(350, 201);
            this.BTN_AJT_Perso.Name = "BTN_AJT_Perso";
            this.BTN_AJT_Perso.Size = new System.Drawing.Size(110, 23);
            this.BTN_AJT_Perso.TabIndex = 6;
            this.BTN_AJT_Perso.Text = "Ajouter";
            this.BTN_AJT_Perso.UseVisualStyleBackColor = true;
            this.BTN_AJT_Perso.Click += new System.EventHandler(this.BTN_AJT_Perso_Click);
            // 
            // BTN_CONS_Perso
            // 
            this.BTN_CONS_Perso.Enabled = false;
            this.BTN_CONS_Perso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CONS_Perso.Location = new System.Drawing.Point(466, 201);
            this.BTN_CONS_Perso.Name = "BTN_CONS_Perso";
            this.BTN_CONS_Perso.Size = new System.Drawing.Size(110, 23);
            this.BTN_CONS_Perso.TabIndex = 7;
            this.BTN_CONS_Perso.Text = "Consulter";
            this.BTN_CONS_Perso.UseVisualStyleBackColor = true;
            this.BTN_CONS_Perso.Click += new System.EventHandler(this.BTN_CONS_Perso_Click);
            // 
            // BTN_DESAC_Perso
            // 
            this.BTN_DESAC_Perso.Enabled = false;
            this.BTN_DESAC_Perso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DESAC_Perso.Location = new System.Drawing.Point(582, 201);
            this.BTN_DESAC_Perso.Name = "BTN_DESAC_Perso";
            this.BTN_DESAC_Perso.Size = new System.Drawing.Size(110, 23);
            this.BTN_DESAC_Perso.TabIndex = 8;
            this.BTN_DESAC_Perso.Text = "Désactiver";
            this.BTN_DESAC_Perso.UseVisualStyleBackColor = true;
            this.BTN_DESAC_Perso.Click += new System.EventHandler(this.BTN_DESAC_Perso_Click);
            // 
            // CHECK_CFM_Joueur
            // 
            this.CHECK_CFM_Joueur.AutoSize = true;
            this.CHECK_CFM_Joueur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHECK_CFM_Joueur.Location = new System.Drawing.Point(233, 204);
            this.CHECK_CFM_Joueur.Name = "CHECK_CFM_Joueur";
            this.CHECK_CFM_Joueur.Size = new System.Drawing.Size(80, 17);
            this.CHECK_CFM_Joueur.TabIndex = 9;
            this.CHECK_CFM_Joueur.Text = "Afficher tout";
            this.CHECK_CFM_Joueur.UseVisualStyleBackColor = true;
            this.CHECK_CFM_Joueur.CheckedChanged += new System.EventHandler(this.CHECK_CFM_Joueur_CheckedChanged);
            // 
            // CHECK_CFM_Perso
            // 
            this.CHECK_CFM_Perso.AutoSize = true;
            this.CHECK_CFM_Perso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHECK_CFM_Perso.Location = new System.Drawing.Point(704, 204);
            this.CHECK_CFM_Perso.Name = "CHECK_CFM_Perso";
            this.CHECK_CFM_Perso.Size = new System.Drawing.Size(80, 17);
            this.CHECK_CFM_Perso.TabIndex = 10;
            this.CHECK_CFM_Perso.Text = "Afficher tout";
            this.CHECK_CFM_Perso.UseVisualStyleBackColor = true;
            this.CHECK_CFM_Perso.CheckedChanged += new System.EventHandler(this.CHECK_CFM_Perso_CheckedChanged);
            // 
            // STRIP_Menu
            // 
            this.STRIP_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.TSMI_Items,
            this.TSMI_Potions});
            this.STRIP_Menu.Location = new System.Drawing.Point(0, 0);
            this.STRIP_Menu.Name = "STRIP_Menu";
            this.STRIP_Menu.Size = new System.Drawing.Size(800, 24);
            this.STRIP_Menu.TabIndex = 11;
            this.STRIP_Menu.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Quitter});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // TSMI_Quitter
            // 
            this.TSMI_Quitter.Name = "TSMI_Quitter";
            this.TSMI_Quitter.Size = new System.Drawing.Size(111, 22);
            this.TSMI_Quitter.Text = "Quitter";
            this.TSMI_Quitter.Click += new System.EventHandler(this.TSMI_Quitter_Click);
            // 
            // TSMI_Items
            // 
            this.TSMI_Items.Name = "TSMI_Items";
            this.TSMI_Items.Size = new System.Drawing.Size(48, 20);
            this.TSMI_Items.Text = "Items";
            this.TSMI_Items.Click += new System.EventHandler(this.TSMI_Items_Click);
            // 
            // TSMI_Potions
            // 
            this.TSMI_Potions.Name = "TSMI_Potions";
            this.TSMI_Potions.Size = new System.Drawing.Size(59, 20);
            this.TSMI_Potions.Text = "Potions";
            this.TSMI_Potions.Click += new System.EventHandler(this.TSMI_Potions_Click);
            // 
            // FORM_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 237);
            this.Controls.Add(this.CHECK_CFM_Perso);
            this.Controls.Add(this.CHECK_CFM_Joueur);
            this.Controls.Add(this.BTN_DESAC_Perso);
            this.Controls.Add(this.BTN_CONS_Perso);
            this.Controls.Add(this.BTN_AJT_Perso);
            this.Controls.Add(this.BTN_DESAC_Joueur);
            this.Controls.Add(this.BTN_CONS_Joueur);
            this.Controls.Add(this.DGV_Personnages);
            this.Controls.Add(this.DGV_Joueurs);
            this.Controls.Add(this.STRIP_Menu);
            this.MainMenuStrip = this.STRIP_Menu;
            this.Name = "FORM_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Throne Wars";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FORM_Main_FormClosed);
            this.Load += new System.EventHandler(this.FORM_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Joueurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Personnages)).EndInit();
            this.STRIP_Menu.ResumeLayout(false);
            this.STRIP_Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Joueurs;
        private System.Windows.Forms.DataGridView DGV_Personnages;
        private System.Windows.Forms.Button BTN_CONS_Joueur;
        private System.Windows.Forms.Button BTN_DESAC_Joueur;
        private System.Windows.Forms.Button BTN_AJT_Perso;
        private System.Windows.Forms.Button BTN_CONS_Perso;
        private System.Windows.Forms.Button BTN_DESAC_Perso;
        private System.Windows.Forms.CheckBox CHECK_CFM_Joueur;
        private System.Windows.Forms.CheckBox CHECK_CFM_Perso;
        private System.Windows.Forms.MenuStrip STRIP_Menu;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Quitter;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Items;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Potions;
    }
}

