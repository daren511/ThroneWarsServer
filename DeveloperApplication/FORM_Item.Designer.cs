namespace DeveloperApplication
{
    partial class FORM_Item
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
            this.LBL_IID = new System.Windows.Forms.Label();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.TB_Nom = new System.Windows.Forms.TextBox();
            this.TB_Level = new System.Windows.Forms.TextBox();
            this.TB_WATK = new System.Windows.Forms.TextBox();
            this.TB_WDEF = new System.Windows.Forms.TextBox();
            this.TB_MATK = new System.Windows.Forms.TextBox();
            this.TB_MDEF = new System.Windows.Forms.TextBox();
            this.CHECK_IsActive = new System.Windows.Forms.CheckBox();
            this.BTN_Annuler = new System.Windows.Forms.Button();
            this.CB_Classe = new System.Windows.Forms.ComboBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TB_Quantite = new System.Windows.Forms.TextBox();
            this.TB_Prix = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LBL_IID
            // 
            this.LBL_IID.AutoSize = true;
            this.LBL_IID.Location = new System.Drawing.Point(12, 9);
            this.LBL_IID.Name = "LBL_IID";
            this.LBL_IID.Size = new System.Drawing.Size(21, 13);
            this.LBL_IID.TabIndex = 0;
            this.LBL_IID.Text = "IID";
            // 
            // BTN_OK
            // 
            this.BTN_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_OK.Location = new System.Drawing.Point(152, 137);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(75, 23);
            this.BTN_OK.TabIndex = 9;
            this.BTN_OK.Text = "OK";
            this.BTN_OK.UseVisualStyleBackColor = true;
            // 
            // TB_Nom
            // 
            this.TB_Nom.Location = new System.Drawing.Point(80, 6);
            this.TB_Nom.MaxLength = 40;
            this.TB_Nom.Name = "TB_Nom";
            this.TB_Nom.ReadOnly = true;
            this.TB_Nom.Size = new System.Drawing.Size(145, 20);
            this.TB_Nom.TabIndex = 10;
            this.TB_Nom.TextChanged += new System.EventHandler(this.UpdateControls);
            // 
            // TB_Level
            // 
            this.TB_Level.Location = new System.Drawing.Point(231, 6);
            this.TB_Level.MaxLength = 2;
            this.TB_Level.Name = "TB_Level";
            this.TB_Level.ReadOnly = true;
            this.TB_Level.Size = new System.Drawing.Size(30, 20);
            this.TB_Level.TabIndex = 11;
            this.TB_Level.TextChanged += new System.EventHandler(this.UpdateControls);
            this.TB_Level.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeyPress);
            // 
            // TB_WATK
            // 
            this.TB_WATK.Location = new System.Drawing.Point(80, 41);
            this.TB_WATK.MaxLength = 4;
            this.TB_WATK.Name = "TB_WATK";
            this.TB_WATK.ReadOnly = true;
            this.TB_WATK.Size = new System.Drawing.Size(100, 20);
            this.TB_WATK.TabIndex = 12;
            this.TB_WATK.TextChanged += new System.EventHandler(this.UpdateControls);
            this.TB_WATK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeyPress);
            // 
            // TB_WDEF
            // 
            this.TB_WDEF.Location = new System.Drawing.Point(208, 41);
            this.TB_WDEF.MaxLength = 4;
            this.TB_WDEF.Name = "TB_WDEF";
            this.TB_WDEF.ReadOnly = true;
            this.TB_WDEF.Size = new System.Drawing.Size(100, 20);
            this.TB_WDEF.TabIndex = 13;
            this.TB_WDEF.TextChanged += new System.EventHandler(this.UpdateControls);
            this.TB_WDEF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeyPress);
            // 
            // TB_MATK
            // 
            this.TB_MATK.Location = new System.Drawing.Point(80, 67);
            this.TB_MATK.MaxLength = 4;
            this.TB_MATK.Name = "TB_MATK";
            this.TB_MATK.ReadOnly = true;
            this.TB_MATK.Size = new System.Drawing.Size(100, 20);
            this.TB_MATK.TabIndex = 14;
            this.TB_MATK.TextChanged += new System.EventHandler(this.UpdateControls);
            this.TB_MATK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeyPress);
            // 
            // TB_MDEF
            // 
            this.TB_MDEF.Location = new System.Drawing.Point(208, 67);
            this.TB_MDEF.MaxLength = 4;
            this.TB_MDEF.Name = "TB_MDEF";
            this.TB_MDEF.ReadOnly = true;
            this.TB_MDEF.Size = new System.Drawing.Size(100, 20);
            this.TB_MDEF.TabIndex = 15;
            this.TB_MDEF.TextChanged += new System.EventHandler(this.UpdateControls);
            this.TB_MDEF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeyPress);
            // 
            // CHECK_IsActive
            // 
            this.CHECK_IsActive.AutoSize = true;
            this.CHECK_IsActive.Checked = true;
            this.CHECK_IsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHECK_IsActive.Enabled = false;
            this.CHECK_IsActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHECK_IsActive.Location = new System.Drawing.Point(12, 41);
            this.CHECK_IsActive.Name = "CHECK_IsActive";
            this.CHECK_IsActive.Size = new System.Drawing.Size(53, 17);
            this.CHECK_IsActive.TabIndex = 16;
            this.CHECK_IsActive.Text = "Activé";
            this.CHECK_IsActive.UseVisualStyleBackColor = true;
            // 
            // BTN_Annuler
            // 
            this.BTN_Annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Annuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Annuler.Location = new System.Drawing.Point(233, 137);
            this.BTN_Annuler.Name = "BTN_Annuler";
            this.BTN_Annuler.Size = new System.Drawing.Size(75, 23);
            this.BTN_Annuler.TabIndex = 17;
            this.BTN_Annuler.Text = "Annuler";
            this.BTN_Annuler.UseVisualStyleBackColor = true;
            // 
            // CB_Classe
            // 
            this.CB_Classe.Enabled = false;
            this.CB_Classe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Classe.FormattingEnabled = true;
            this.CB_Classe.Location = new System.Drawing.Point(80, 97);
            this.CB_Classe.Name = "CB_Classe";
            this.CB_Classe.Size = new System.Drawing.Size(100, 21);
            this.CB_Classe.TabIndex = 18;
            this.CB_Classe.SelectedIndexChanged += new System.EventHandler(this.UpdateControls);
            // 
            // TB_Quantite
            // 
            this.TB_Quantite.Location = new System.Drawing.Point(208, 98);
            this.TB_Quantite.MaxLength = 2;
            this.TB_Quantite.Name = "TB_Quantite";
            this.TB_Quantite.Size = new System.Drawing.Size(100, 20);
            this.TB_Quantite.TabIndex = 19;
            this.TB_Quantite.TextChanged += new System.EventHandler(this.UpdateControls);
            this.TB_Quantite.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeyPress);
            // 
            // TB_Prix
            // 
            this.TB_Prix.Location = new System.Drawing.Point(267, 6);
            this.TB_Prix.MaxLength = 4;
            this.TB_Prix.Name = "TB_Prix";
            this.TB_Prix.ReadOnly = true;
            this.TB_Prix.Size = new System.Drawing.Size(41, 20);
            this.TB_Prix.TabIndex = 20;
            this.TB_Prix.TextChanged += new System.EventHandler(this.UpdateControls);
            this.TB_Prix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeyPress);
            // 
            // FORM_Item
            // 
            this.AcceptButton = this.BTN_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTN_Annuler;
            this.ClientSize = new System.Drawing.Size(320, 171);
            this.Controls.Add(this.TB_Prix);
            this.Controls.Add(this.TB_Quantite);
            this.Controls.Add(this.CB_Classe);
            this.Controls.Add(this.BTN_Annuler);
            this.Controls.Add(this.CHECK_IsActive);
            this.Controls.Add(this.TB_MDEF);
            this.Controls.Add(this.TB_MATK);
            this.Controls.Add(this.TB_WDEF);
            this.Controls.Add(this.TB_WATK);
            this.Controls.Add(this.TB_Level);
            this.Controls.Add(this.TB_Nom);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.LBL_IID);
            this.Name = "FORM_Item";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FORM_Item_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_IID;
        private System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.TextBox TB_Nom;
        private System.Windows.Forms.TextBox TB_Level;
        private System.Windows.Forms.TextBox TB_WATK;
        private System.Windows.Forms.TextBox TB_WDEF;
        private System.Windows.Forms.TextBox TB_MATK;
        private System.Windows.Forms.TextBox TB_MDEF;
        private System.Windows.Forms.CheckBox CHECK_IsActive;
        private System.Windows.Forms.Button BTN_Annuler;
        private System.Windows.Forms.ComboBox CB_Classe;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.TextBox TB_Quantite;
        private System.Windows.Forms.TextBox TB_Prix;
    }
}