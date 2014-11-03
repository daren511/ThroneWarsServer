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
            // 
            // TB_XP
            // 
            this.TB_XP.Location = new System.Drawing.Point(277, 6);
            this.TB_XP.Name = "TB_XP";
            this.TB_XP.Size = new System.Drawing.Size(124, 20);
            this.TB_XP.TabIndex = 2;
            // 
            // TB_Level
            // 
            this.TB_Level.Location = new System.Drawing.Point(229, 6);
            this.TB_Level.Name = "TB_Level";
            this.TB_Level.Size = new System.Drawing.Size(42, 20);
            this.TB_Level.TabIndex = 3;
            // 
            // CHECK_IsActive
            // 
            this.CHECK_IsActive.AutoSize = true;
            this.CHECK_IsActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHECK_IsActive.Location = new System.Drawing.Point(52, 283);
            this.CHECK_IsActive.Name = "CHECK_IsActive";
            this.CHECK_IsActive.Size = new System.Drawing.Size(53, 17);
            this.CHECK_IsActive.TabIndex = 4;
            this.CHECK_IsActive.Text = "Activé";
            this.CHECK_IsActive.UseVisualStyleBackColor = true;
            // 
            // DGV_Inventaire
            // 
            this.DGV_Inventaire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Inventaire.Location = new System.Drawing.Point(15, 44);
            this.DGV_Inventaire.Name = "DGV_Inventaire";
            this.DGV_Inventaire.Size = new System.Drawing.Size(511, 220);
            this.DGV_Inventaire.TabIndex = 5;
            // 
            // BTN_Annuler
            // 
            this.BTN_Annuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Annuler.Location = new System.Drawing.Point(451, 280);
            this.BTN_Annuler.Name = "BTN_Annuler";
            this.BTN_Annuler.Size = new System.Drawing.Size(75, 23);
            this.BTN_Annuler.TabIndex = 6;
            this.BTN_Annuler.Text = "Annuler";
            this.BTN_Annuler.UseVisualStyleBackColor = true;
            // 
            // BTN_OK
            // 
            this.BTN_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_OK.Location = new System.Drawing.Point(370, 280);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(75, 23);
            this.BTN_OK.TabIndex = 7;
            this.BTN_OK.Text = "OK";
            this.BTN_OK.UseVisualStyleBackColor = true;
            // 
            // CB_Classe
            // 
            this.CB_Classe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Classe.FormattingEnabled = true;
            this.CB_Classe.Location = new System.Drawing.Point(407, 6);
            this.CB_Classe.Name = "CB_Classe";
            this.CB_Classe.Size = new System.Drawing.Size(119, 21);
            this.CB_Classe.TabIndex = 8;
            // 
            // FORM_Perso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 317);
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
    }
}