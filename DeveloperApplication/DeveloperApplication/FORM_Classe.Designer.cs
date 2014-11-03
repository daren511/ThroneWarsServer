namespace DeveloperApplication
{
    partial class FORM_Classe
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
            this.LBL_CID = new System.Windows.Forms.Label();
            this.TB_Level = new System.Windows.Forms.TextBox();
            this.TB_Nom = new System.Windows.Forms.TextBox();
            this.TB_Life = new System.Windows.Forms.TextBox();
            this.TB_WATK = new System.Windows.Forms.TextBox();
            this.TB_WDEF = new System.Windows.Forms.TextBox();
            this.TB_MATK = new System.Windows.Forms.TextBox();
            this.TB_MDEF = new System.Windows.Forms.TextBox();
            this.BTN_Annuler = new System.Windows.Forms.Button();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // LBL_CID
            // 
            this.LBL_CID.AutoSize = true;
            this.LBL_CID.Location = new System.Drawing.Point(13, 13);
            this.LBL_CID.Name = "LBL_CID";
            this.LBL_CID.Size = new System.Drawing.Size(25, 13);
            this.LBL_CID.TabIndex = 0;
            this.LBL_CID.Text = "CID";
            // 
            // TB_Level
            // 
            this.TB_Level.Location = new System.Drawing.Point(220, 10);
            this.TB_Level.Name = "TB_Level";
            this.TB_Level.Size = new System.Drawing.Size(52, 20);
            this.TB_Level.TabIndex = 1;
            // 
            // TB_Nom
            // 
            this.TB_Nom.Location = new System.Drawing.Point(52, 10);
            this.TB_Nom.Name = "TB_Nom";
            this.TB_Nom.Size = new System.Drawing.Size(162, 20);
            this.TB_Nom.TabIndex = 2;
            // 
            // TB_Life
            // 
            this.TB_Life.Location = new System.Drawing.Point(52, 36);
            this.TB_Life.Name = "TB_Life";
            this.TB_Life.Size = new System.Drawing.Size(122, 20);
            this.TB_Life.TabIndex = 3;
            // 
            // TB_WATK
            // 
            this.TB_WATK.Location = new System.Drawing.Point(52, 77);
            this.TB_WATK.Name = "TB_WATK";
            this.TB_WATK.Size = new System.Drawing.Size(100, 20);
            this.TB_WATK.TabIndex = 4;
            // 
            // TB_WDEF
            // 
            this.TB_WDEF.Location = new System.Drawing.Point(172, 77);
            this.TB_WDEF.Name = "TB_WDEF";
            this.TB_WDEF.Size = new System.Drawing.Size(100, 20);
            this.TB_WDEF.TabIndex = 5;
            // 
            // TB_MATK
            // 
            this.TB_MATK.Location = new System.Drawing.Point(52, 103);
            this.TB_MATK.Name = "TB_MATK";
            this.TB_MATK.Size = new System.Drawing.Size(100, 20);
            this.TB_MATK.TabIndex = 6;
            // 
            // TB_MDEF
            // 
            this.TB_MDEF.Location = new System.Drawing.Point(172, 103);
            this.TB_MDEF.Name = "TB_MDEF";
            this.TB_MDEF.Size = new System.Drawing.Size(100, 20);
            this.TB_MDEF.TabIndex = 7;
            // 
            // BTN_Annuler
            // 
            this.BTN_Annuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Annuler.Location = new System.Drawing.Point(197, 147);
            this.BTN_Annuler.Name = "BTN_Annuler";
            this.BTN_Annuler.Size = new System.Drawing.Size(75, 23);
            this.BTN_Annuler.TabIndex = 8;
            this.BTN_Annuler.Text = "Annuler";
            this.BTN_Annuler.UseVisualStyleBackColor = true;
            // 
            // BTN_OK
            // 
            this.BTN_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_OK.Location = new System.Drawing.Point(116, 147);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(75, 23);
            this.BTN_OK.TabIndex = 9;
            this.BTN_OK.Text = "OK";
            this.BTN_OK.UseVisualStyleBackColor = true;
            // 
            // FORM_Classe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 183);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.BTN_Annuler);
            this.Controls.Add(this.TB_MDEF);
            this.Controls.Add(this.TB_MATK);
            this.Controls.Add(this.TB_WDEF);
            this.Controls.Add(this.TB_WATK);
            this.Controls.Add(this.TB_Life);
            this.Controls.Add(this.TB_Nom);
            this.Controls.Add(this.TB_Level);
            this.Controls.Add(this.LBL_CID);
            this.Name = "FORM_Classe";
            this.Load += new System.EventHandler(this.FORM_Classe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_CID;
        private System.Windows.Forms.TextBox TB_Level;
        private System.Windows.Forms.TextBox TB_Nom;
        private System.Windows.Forms.TextBox TB_Life;
        private System.Windows.Forms.TextBox TB_WATK;
        private System.Windows.Forms.TextBox TB_WDEF;
        private System.Windows.Forms.TextBox TB_MATK;
        private System.Windows.Forms.TextBox TB_MDEF;
        private System.Windows.Forms.Button BTN_Annuler;
        private System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}