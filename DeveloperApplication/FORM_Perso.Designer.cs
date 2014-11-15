namespace DeveloperApplication
{
    partial class FORM_Perso
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
            this.components = new System.ComponentModel.Container();
            this.LBL_GUID = new System.Windows.Forms.Label();
            this.TB_Nom = new System.Windows.Forms.TextBox();
            this.TB_XP = new System.Windows.Forms.TextBox();
            this.TB_Level = new System.Windows.Forms.TextBox();
            this.CHECK_IsActive = new System.Windows.Forms.CheckBox();
            this.DGV_Inventaire = new System.Windows.Forms.DataGridView();
            this.BTN_Annuler = new System.Windows.Forms.Button();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.CB_Classe = new System.Windows.Forms.ComboBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.CHECK_AfficherTout = new System.Windows.Forms.CheckBox();
            this.BTN_Consulter = new System.Windows.Forms.Button();
            this.BTN_Supprimer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Inventaire)).BeginInit();
            this.SuspendLayout();
            // 
            // LBL_GUID
            // 
            this.LBL_GUID.AutoSize = true;
            this.LBL_GUID.Location = new System.Drawing.Point(12, 9);
            this.LBL_GUID.Name = "LBL_GUID";
            this.LBL_GUID.Size = new System.Drawing.Size(34, 13);
            this.LBL_GUID.TabIndex = 0;
            this.LBL_GUID.Text = "GUID";
            // 
            // TB_Nom
            // 
            this.TB_Nom.Location = new System.Drawing.Point(52, 6);
            this.TB_Nom.Name = "TB_Nom";
            this.TB_Nom.Size = new System.Drawing.Size(171, 20);
            this.TB_Nom.TabIndex = 1;
            this.TB_Nom.TextChanged += new System.EventHandler(this.UpdateControls);
            // 
            // TB_XP
            // 
            this.TB_XP.Location = new System.Drawing.Point(277, 6);
            this.TB_XP.Name = "TB_XP";
            this.TB_XP.ReadOnly = true;
            this.TB_XP.Size = new System.Drawing.Size(124, 20);
            this.TB_XP.TabIndex = 2;
            this.TB_XP.Text = "0";
            this.TB_XP.TextChanged += new System.EventHandler(this.UpdateControls);
            this.TB_XP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeyPress);
            // 
            // TB_Level
            // 
            this.TB_Level.Location = new System.Drawing.Point(229, 6);
            this.TB_Level.Name = "TB_Level";
            this.TB_Level.ReadOnly = true;
            this.TB_Level.Size = new System.Drawing.Size(42, 20);
            this.TB_Level.TabIndex = 3;
            this.TB_Level.Text = "1";
            this.TB_Level.TextChanged += new System.EventHandler(this.UpdateControls);
            this.TB_Level.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeyPress);
            // 
            // CHECK_IsActive
            // 
            this.CHECK_IsActive.AutoSize = true;
            this.CHECK_IsActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHECK_IsActive.Location = new System.Drawing.Point(15, 31);
            this.CHECK_IsActive.Name = "CHECK_IsActive";
            this.CHECK_IsActive.Size = new System.Drawing.Size(53, 17);
            this.CHECK_IsActive.TabIndex = 4;
            this.CHECK_IsActive.Text = "Activé";
            this.CHECK_IsActive.UseVisualStyleBackColor = true;
            // 
            // DGV_Inventaire
            // 
            this.DGV_Inventaire.AllowUserToAddRows = false;
            this.DGV_Inventaire.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Inventaire.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_Inventaire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Inventaire.Location = new System.Drawing.Point(15, 54);
            this.DGV_Inventaire.Name = "DGV_Inventaire";
            this.DGV_Inventaire.ReadOnly = true;
            this.DGV_Inventaire.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Inventaire.Size = new System.Drawing.Size(511, 207);
            this.DGV_Inventaire.TabIndex = 5;
            this.DGV_Inventaire.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Inventaire_CellDoubleClick);
            // 
            // BTN_Annuler
            // 
            this.BTN_Annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Annuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Annuler.Location = new System.Drawing.Point(451, 267);
            this.BTN_Annuler.Name = "BTN_Annuler";
            this.BTN_Annuler.Size = new System.Drawing.Size(75, 23);
            this.BTN_Annuler.TabIndex = 6;
            this.BTN_Annuler.Text = "Annuler";
            this.BTN_Annuler.UseVisualStyleBackColor = true;
            // 
            // BTN_OK
            // 
            this.BTN_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_OK.Location = new System.Drawing.Point(370, 267);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(75, 23);
            this.BTN_OK.TabIndex = 7;
            this.BTN_OK.Text = "OK";
            this.BTN_OK.UseVisualStyleBackColor = true;
            // 
            // CB_Classe
            // 
            this.CB_Classe.Enabled = false;
            this.CB_Classe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Classe.FormattingEnabled = true;
            this.CB_Classe.Location = new System.Drawing.Point(407, 6);
            this.CB_Classe.Name = "CB_Classe";
            this.CB_Classe.Size = new System.Drawing.Size(119, 21);
            this.CB_Classe.TabIndex = 8;
            this.CB_Classe.SelectedIndexChanged += new System.EventHandler(this.UpdateControls);
            // 
            // CHECK_AfficherTout
            // 
            this.CHECK_AfficherTout.AutoSize = true;
            this.CHECK_AfficherTout.Checked = true;
            this.CHECK_AfficherTout.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHECK_AfficherTout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHECK_AfficherTout.Location = new System.Drawing.Point(277, 270);
            this.CHECK_AfficherTout.Name = "CHECK_AfficherTout";
            this.CHECK_AfficherTout.Size = new System.Drawing.Size(80, 17);
            this.CHECK_AfficherTout.TabIndex = 9;
            this.CHECK_AfficherTout.Text = "Afficher tout";
            this.CHECK_AfficherTout.UseVisualStyleBackColor = true;
            // 
            // BTN_Consulter
            // 
            this.BTN_Consulter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Consulter.Location = new System.Drawing.Point(15, 267);
            this.BTN_Consulter.Name = "BTN_Consulter";
            this.BTN_Consulter.Size = new System.Drawing.Size(176, 23);
            this.BTN_Consulter.TabIndex = 10;
            this.BTN_Consulter.Text = "Consulter";
            this.BTN_Consulter.UseVisualStyleBackColor = true;
            this.BTN_Consulter.Click += new System.EventHandler(this.BTN_Consulter_Click);
            // 
            // BTN_Supprimer
            // 
            this.BTN_Supprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Supprimer.Location = new System.Drawing.Point(197, 267);
            this.BTN_Supprimer.Name = "BTN_Supprimer";
            this.BTN_Supprimer.Size = new System.Drawing.Size(74, 23);
            this.BTN_Supprimer.TabIndex = 11;
            this.BTN_Supprimer.Text = "Supprimer";
            this.BTN_Supprimer.UseVisualStyleBackColor = true;
            this.BTN_Supprimer.Click += new System.EventHandler(this.BTN_Supprimer_Click);
            // 
            // FORM_Perso
            // 
            this.AcceptButton = this.BTN_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTN_Annuler;
            this.ClientSize = new System.Drawing.Size(538, 303);
            this.Controls.Add(this.BTN_Supprimer);
            this.Controls.Add(this.BTN_Consulter);
            this.Controls.Add(this.CHECK_AfficherTout);
            this.Controls.Add(this.CB_Classe);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.BTN_Annuler);
            this.Controls.Add(this.DGV_Inventaire);
            this.Controls.Add(this.CHECK_IsActive);
            this.Controls.Add(this.TB_Level);
            this.Controls.Add(this.TB_XP);
            this.Controls.Add(this.TB_Nom);
            this.Controls.Add(this.LBL_GUID);
            this.Name = "FORM_Perso";
            this.Load += new System.EventHandler(this.FORM_Perso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Inventaire)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_GUID;
        private System.Windows.Forms.TextBox TB_Nom;
        private System.Windows.Forms.TextBox TB_XP;
        private System.Windows.Forms.TextBox TB_Level;
        private System.Windows.Forms.CheckBox CHECK_IsActive;
        private System.Windows.Forms.DataGridView DGV_Inventaire;
        private System.Windows.Forms.Button BTN_Annuler;
        private System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.ComboBox CB_Classe;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.CheckBox CHECK_AfficherTout;
        private System.Windows.Forms.Button BTN_Consulter;
        private System.Windows.Forms.Button BTN_Supprimer;
    }
}