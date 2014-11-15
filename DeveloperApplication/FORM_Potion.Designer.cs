namespace DeveloperApplication
{
    partial class FORM_Potion
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
            this.LBL_PID = new System.Windows.Forms.Label();
            this.TB_Nom = new System.Windows.Forms.TextBox();
            this.TB_Desc = new System.Windows.Forms.TextBox();
            this.TB_Duration = new System.Windows.Forms.TextBox();
            this.TB_Quantite = new System.Windows.Forms.TextBox();
            this.TB_WATK = new System.Windows.Forms.TextBox();
            this.TB_WDEF = new System.Windows.Forms.TextBox();
            this.TB_MATK = new System.Windows.Forms.TextBox();
            this.TB_MDEF = new System.Windows.Forms.TextBox();
            this.BTN_Annuler = new System.Windows.Forms.Button();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBL_PID
            // 
            this.LBL_PID.AutoSize = true;
            this.LBL_PID.Location = new System.Drawing.Point(12, 9);
            this.LBL_PID.Name = "LBL_PID";
            this.LBL_PID.Size = new System.Drawing.Size(25, 13);
            this.LBL_PID.TabIndex = 0;
            this.LBL_PID.Text = "PID";
            // 
            // TB_Nom
            // 
            this.TB_Nom.Location = new System.Drawing.Point(52, 6);
            this.TB_Nom.MaxLength = 40;
            this.TB_Nom.Name = "TB_Nom";
            this.TB_Nom.Size = new System.Drawing.Size(220, 20);
            this.TB_Nom.TabIndex = 1;
            // 
            // TB_Desc
            // 
            this.TB_Desc.Location = new System.Drawing.Point(52, 32);
            this.TB_Desc.MaxLength = 255;
            this.TB_Desc.Multiline = true;
            this.TB_Desc.Name = "TB_Desc";
            this.TB_Desc.Size = new System.Drawing.Size(220, 78);
            this.TB_Desc.TabIndex = 2;
            // 
            // TB_Duration
            // 
            this.TB_Duration.Location = new System.Drawing.Point(52, 116);
            this.TB_Duration.MaxLength = 1;
            this.TB_Duration.Name = "TB_Duration";
            this.TB_Duration.Size = new System.Drawing.Size(100, 20);
            this.TB_Duration.TabIndex = 3;
            // 
            // TB_Quantite
            // 
            this.TB_Quantite.Location = new System.Drawing.Point(174, 116);
            this.TB_Quantite.MaxLength = 2;
            this.TB_Quantite.Name = "TB_Quantite";
            this.TB_Quantite.Size = new System.Drawing.Size(100, 20);
            this.TB_Quantite.TabIndex = 4;
            // 
            // TB_WATK
            // 
            this.TB_WATK.Location = new System.Drawing.Point(52, 159);
            this.TB_WATK.MaxLength = 4;
            this.TB_WATK.Name = "TB_WATK";
            this.TB_WATK.Size = new System.Drawing.Size(100, 20);
            this.TB_WATK.TabIndex = 5;
            // 
            // TB_WDEF
            // 
            this.TB_WDEF.Location = new System.Drawing.Point(174, 159);
            this.TB_WDEF.MaxLength = 4;
            this.TB_WDEF.Name = "TB_WDEF";
            this.TB_WDEF.Size = new System.Drawing.Size(100, 20);
            this.TB_WDEF.TabIndex = 6;
            // 
            // TB_MATK
            // 
            this.TB_MATK.Location = new System.Drawing.Point(52, 186);
            this.TB_MATK.MaxLength = 4;
            this.TB_MATK.Name = "TB_MATK";
            this.TB_MATK.Size = new System.Drawing.Size(100, 20);
            this.TB_MATK.TabIndex = 7;
            // 
            // TB_MDEF
            // 
            this.TB_MDEF.Location = new System.Drawing.Point(174, 185);
            this.TB_MDEF.MaxLength = 4;
            this.TB_MDEF.Name = "TB_MDEF";
            this.TB_MDEF.Size = new System.Drawing.Size(100, 20);
            this.TB_MDEF.TabIndex = 8;
            // 
            // BTN_Annuler
            // 
            this.BTN_Annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Annuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Annuler.Location = new System.Drawing.Point(199, 225);
            this.BTN_Annuler.Name = "BTN_Annuler";
            this.BTN_Annuler.Size = new System.Drawing.Size(75, 23);
            this.BTN_Annuler.TabIndex = 10;
            this.BTN_Annuler.Text = "Annuler";
            this.BTN_Annuler.UseVisualStyleBackColor = true;
            // 
            // BTN_OK
            // 
            this.BTN_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_OK.Location = new System.Drawing.Point(118, 225);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(75, 23);
            this.BTN_OK.TabIndex = 9;
            this.BTN_OK.Text = "OK";
            this.BTN_OK.UseVisualStyleBackColor = true;
            // 
            // FORM_Potion
            // 
            this.AcceptButton = this.BTN_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTN_Annuler;
            this.ClientSize = new System.Drawing.Size(284, 257);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.BTN_Annuler);
            this.Controls.Add(this.TB_MDEF);
            this.Controls.Add(this.TB_MATK);
            this.Controls.Add(this.TB_WDEF);
            this.Controls.Add(this.TB_WATK);
            this.Controls.Add(this.TB_Quantite);
            this.Controls.Add(this.TB_Duration);
            this.Controls.Add(this.TB_Desc);
            this.Controls.Add(this.TB_Nom);
            this.Controls.Add(this.LBL_PID);
            this.Name = "FORM_Potion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_PID;
        private System.Windows.Forms.TextBox TB_Nom;
        private System.Windows.Forms.TextBox TB_Desc;
        private System.Windows.Forms.TextBox TB_Duration;
        private System.Windows.Forms.TextBox TB_Quantite;
        private System.Windows.Forms.TextBox TB_WATK;
        private System.Windows.Forms.TextBox TB_WDEF;
        private System.Windows.Forms.TextBox TB_MATK;
        private System.Windows.Forms.TextBox TB_MDEF;
        private System.Windows.Forms.Button BTN_Annuler;
        private System.Windows.Forms.Button BTN_OK;
    }
}