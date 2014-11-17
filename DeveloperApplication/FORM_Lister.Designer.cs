namespace DeveloperApplication
{
    partial class FORM_Lister
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
            this.DGV_Liste = new System.Windows.Forms.DataGridView();
            this.CHECK_AfficherTout = new System.Windows.Forms.CheckBox();
            this.BTN_Etat = new System.Windows.Forms.Button();
            this.BTN_Modifier = new System.Windows.Forms.Button();
            this.BTN_Fermer = new System.Windows.Forms.Button();
            this.BTN_Ajouter = new System.Windows.Forms.Button();
            this.LBL_Ajouter = new System.Windows.Forms.Label();
            this.CB_Joueurs = new System.Windows.Forms.ComboBox();
            this.TB_Qte = new System.Windows.Forms.TextBox();
            this.BTN_Ajouter_Potion = new System.Windows.Forms.Button();
            this.LBL_Qte = new System.Windows.Forms.Label();
            this.LBL_Envoyer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Liste)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Liste
            // 
            this.DGV_Liste.AllowUserToAddRows = false;
            this.DGV_Liste.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Liste.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_Liste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Liste.Location = new System.Drawing.Point(12, 12);
            this.DGV_Liste.Name = "DGV_Liste";
            this.DGV_Liste.ReadOnly = true;
            this.DGV_Liste.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Liste.Size = new System.Drawing.Size(692, 287);
            this.DGV_Liste.TabIndex = 0;
            this.DGV_Liste.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Liste_CellClick);
            this.DGV_Liste.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Liste_CellDoubleClick);
            // 
            // CHECK_AfficherTout
            // 
            this.CHECK_AfficherTout.AutoSize = true;
            this.CHECK_AfficherTout.Checked = true;
            this.CHECK_AfficherTout.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHECK_AfficherTout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHECK_AfficherTout.Location = new System.Drawing.Point(25, 308);
            this.CHECK_AfficherTout.Name = "CHECK_AfficherTout";
            this.CHECK_AfficherTout.Size = new System.Drawing.Size(80, 17);
            this.CHECK_AfficherTout.TabIndex = 1;
            this.CHECK_AfficherTout.Text = "Afficher tout";
            this.CHECK_AfficherTout.UseVisualStyleBackColor = true;
            this.CHECK_AfficherTout.CheckedChanged += new System.EventHandler(this.CHECK_AfficherTout_CheckedChanged);
            // 
            // BTN_Etat
            // 
            this.BTN_Etat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Etat.Location = new System.Drawing.Point(140, 305);
            this.BTN_Etat.Name = "BTN_Etat";
            this.BTN_Etat.Size = new System.Drawing.Size(184, 23);
            this.BTN_Etat.TabIndex = 2;
            this.BTN_Etat.Text = "Désactiver";
            this.BTN_Etat.UseVisualStyleBackColor = true;
            this.BTN_Etat.Click += new System.EventHandler(this.BTN_Etat_Click);
            // 
            // BTN_Modifier
            // 
            this.BTN_Modifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Modifier.Location = new System.Drawing.Point(520, 305);
            this.BTN_Modifier.Name = "BTN_Modifier";
            this.BTN_Modifier.Size = new System.Drawing.Size(184, 23);
            this.BTN_Modifier.TabIndex = 3;
            this.BTN_Modifier.Text = "Modifier";
            this.BTN_Modifier.UseVisualStyleBackColor = true;
            this.BTN_Modifier.Click += new System.EventHandler(this.BTN_Modifier_Click);
            // 
            // BTN_Fermer
            // 
            this.BTN_Fermer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_Fermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Fermer.Location = new System.Drawing.Point(629, 342);
            this.BTN_Fermer.Name = "BTN_Fermer";
            this.BTN_Fermer.Size = new System.Drawing.Size(75, 23);
            this.BTN_Fermer.TabIndex = 4;
            this.BTN_Fermer.Text = "Fermer";
            this.BTN_Fermer.UseVisualStyleBackColor = true;
            // 
            // BTN_Ajouter
            // 
            this.BTN_Ajouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Ajouter.Location = new System.Drawing.Point(330, 305);
            this.BTN_Ajouter.Name = "BTN_Ajouter";
            this.BTN_Ajouter.Size = new System.Drawing.Size(184, 23);
            this.BTN_Ajouter.TabIndex = 5;
            this.BTN_Ajouter.Text = "Ajouter";
            this.BTN_Ajouter.UseVisualStyleBackColor = true;
            this.BTN_Ajouter.Click += new System.EventHandler(this.BTN_Ajouter_Click);
            // 
            // LBL_Ajouter
            // 
            this.LBL_Ajouter.AutoSize = true;
            this.LBL_Ajouter.Location = new System.Drawing.Point(9, 337);
            this.LBL_Ajouter.Name = "LBL_Ajouter";
            this.LBL_Ajouter.Size = new System.Drawing.Size(117, 13);
            this.LBL_Ajouter.TabIndex = 6;
            this.LBL_Ajouter.Text = "Ajouter cette potion à : ";
            // 
            // CB_Joueurs
            // 
            this.CB_Joueurs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Joueurs.FormattingEnabled = true;
            this.CB_Joueurs.Location = new System.Drawing.Point(132, 334);
            this.CB_Joueurs.Name = "CB_Joueurs";
            this.CB_Joueurs.Size = new System.Drawing.Size(99, 21);
            this.CB_Joueurs.TabIndex = 7;
            this.CB_Joueurs.SelectedIndexChanged += new System.EventHandler(this.UpdateControls);
            // 
            // TB_Qte
            // 
            this.TB_Qte.Location = new System.Drawing.Point(132, 361);
            this.TB_Qte.MaxLength = 2;
            this.TB_Qte.Name = "TB_Qte";
            this.TB_Qte.Size = new System.Drawing.Size(48, 20);
            this.TB_Qte.TabIndex = 8;
            this.TB_Qte.TextChanged += new System.EventHandler(this.UpdateControls);
            this.TB_Qte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Check_KeyPress);
            // 
            // BTN_Ajouter_Potion
            // 
            this.BTN_Ajouter_Potion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Ajouter_Potion.Location = new System.Drawing.Point(249, 332);
            this.BTN_Ajouter_Potion.Name = "BTN_Ajouter_Potion";
            this.BTN_Ajouter_Potion.Size = new System.Drawing.Size(75, 23);
            this.BTN_Ajouter_Potion.TabIndex = 9;
            this.BTN_Ajouter_Potion.Text = "Ajouter";
            this.BTN_Ajouter_Potion.UseVisualStyleBackColor = true;
            this.BTN_Ajouter_Potion.Click += new System.EventHandler(this.BTN_Ajouter_Potion_Click);
            // 
            // LBL_Qte
            // 
            this.LBL_Qte.AutoSize = true;
            this.LBL_Qte.Location = new System.Drawing.Point(70, 364);
            this.LBL_Qte.Name = "LBL_Qte";
            this.LBL_Qte.Size = new System.Drawing.Size(56, 13);
            this.LBL_Qte.TabIndex = 10;
            this.LBL_Qte.Text = "Quantité : ";
            // 
            // LBL_Envoyer
            // 
            this.LBL_Envoyer.AutoSize = true;
            this.LBL_Envoyer.ForeColor = System.Drawing.Color.Green;
            this.LBL_Envoyer.Location = new System.Drawing.Point(246, 364);
            this.LBL_Envoyer.Name = "LBL_Envoyer";
            this.LBL_Envoyer.Size = new System.Drawing.Size(76, 13);
            this.LBL_Envoyer.TabIndex = 11;
            this.LBL_Envoyer.Text = "Envoi effectué";
            // 
            // FORM_Lister
            // 
            this.AcceptButton = this.BTN_Fermer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 377);
            this.Controls.Add(this.LBL_Envoyer);
            this.Controls.Add(this.LBL_Qte);
            this.Controls.Add(this.BTN_Ajouter_Potion);
            this.Controls.Add(this.TB_Qte);
            this.Controls.Add(this.CB_Joueurs);
            this.Controls.Add(this.LBL_Ajouter);
            this.Controls.Add(this.BTN_Ajouter);
            this.Controls.Add(this.BTN_Fermer);
            this.Controls.Add(this.BTN_Modifier);
            this.Controls.Add(this.BTN_Etat);
            this.Controls.Add(this.CHECK_AfficherTout);
            this.Controls.Add(this.DGV_Liste);
            this.Name = "FORM_Lister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FORM_Lister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Liste)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Liste;
        private System.Windows.Forms.CheckBox CHECK_AfficherTout;
        private System.Windows.Forms.Button BTN_Etat;
        private System.Windows.Forms.Button BTN_Modifier;
        private System.Windows.Forms.Button BTN_Fermer;
        private System.Windows.Forms.Button BTN_Ajouter;
        private System.Windows.Forms.Label LBL_Ajouter;
        private System.Windows.Forms.ComboBox CB_Joueurs;
        private System.Windows.Forms.TextBox TB_Qte;
        private System.Windows.Forms.Button BTN_Ajouter_Potion;
        private System.Windows.Forms.Label LBL_Qte;
        private System.Windows.Forms.Label LBL_Envoyer;
    }
}