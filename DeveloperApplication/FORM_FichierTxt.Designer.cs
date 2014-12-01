namespace DeveloperApplication
{
    partial class FORM_FichierTxt
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
            this.LB_Noms = new System.Windows.Forms.ListBox();
            this.TB_Path = new System.Windows.Forms.TextBox();
            this.BTN_OuvrirFichier = new System.Windows.Forms.Button();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.BTN_Insert = new System.Windows.Forms.Button();
            this.BTN_Supprimer = new System.Windows.Forms.Button();
            this.BTN_Instructions = new System.Windows.Forms.Button();
            this.LBL_Total_Inserer = new System.Windows.Forms.Label();
            this.LBL_NonInserer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LB_Noms
            // 
            this.LB_Noms.FormattingEnabled = true;
            this.LB_Noms.Location = new System.Drawing.Point(12, 71);
            this.LB_Noms.Name = "LB_Noms";
            this.LB_Noms.Size = new System.Drawing.Size(338, 199);
            this.LB_Noms.TabIndex = 0;
            this.LB_Noms.SelectedIndexChanged += new System.EventHandler(this.LB_Noms_SelectedIndexChanged);
            // 
            // TB_Path
            // 
            this.TB_Path.Location = new System.Drawing.Point(12, 32);
            this.TB_Path.Name = "TB_Path";
            this.TB_Path.Size = new System.Drawing.Size(257, 20);
            this.TB_Path.TabIndex = 1;
            this.TB_Path.TextChanged += new System.EventHandler(this.TB_Path_TextChanged);
            // 
            // BTN_OuvrirFichier
            // 
            this.BTN_OuvrirFichier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_OuvrirFichier.Location = new System.Drawing.Point(275, 30);
            this.BTN_OuvrirFichier.Name = "BTN_OuvrirFichier";
            this.BTN_OuvrirFichier.Size = new System.Drawing.Size(75, 23);
            this.BTN_OuvrirFichier.TabIndex = 2;
            this.BTN_OuvrirFichier.Text = "Ouvrir";
            this.BTN_OuvrirFichier.UseVisualStyleBackColor = true;
            this.BTN_OuvrirFichier.Click += new System.EventHandler(this.BTN_OuvrirFichier_Click);
            // 
            // fileDialog
            // 
            this.fileDialog.Filter = "Fichiers texte (*.txt)|*.txt";
            // 
            // BTN_OK
            // 
            this.BTN_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_OK.Location = new System.Drawing.Point(275, 305);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(75, 23);
            this.BTN_OK.TabIndex = 7;
            this.BTN_OK.Text = "OK";
            this.BTN_OK.UseVisualStyleBackColor = true;
            // 
            // BTN_Insert
            // 
            this.BTN_Insert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Insert.Location = new System.Drawing.Point(147, 276);
            this.BTN_Insert.Name = "BTN_Insert";
            this.BTN_Insert.Size = new System.Drawing.Size(203, 23);
            this.BTN_Insert.TabIndex = 8;
            this.BTN_Insert.Text = "Insérer les items";
            this.BTN_Insert.UseVisualStyleBackColor = true;
            this.BTN_Insert.Click += new System.EventHandler(this.BTN_Insert_Click);
            // 
            // BTN_Supprimer
            // 
            this.BTN_Supprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Supprimer.Location = new System.Drawing.Point(12, 276);
            this.BTN_Supprimer.Name = "BTN_Supprimer";
            this.BTN_Supprimer.Size = new System.Drawing.Size(129, 23);
            this.BTN_Supprimer.TabIndex = 9;
            this.BTN_Supprimer.Text = "Supprimer";
            this.BTN_Supprimer.UseVisualStyleBackColor = true;
            this.BTN_Supprimer.Click += new System.EventHandler(this.BTN_Supprimer_Click);
            // 
            // BTN_Instructions
            // 
            this.BTN_Instructions.BackColor = System.Drawing.Color.Green;
            this.BTN_Instructions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Instructions.ForeColor = System.Drawing.Color.White;
            this.BTN_Instructions.Location = new System.Drawing.Point(12, 3);
            this.BTN_Instructions.Name = "BTN_Instructions";
            this.BTN_Instructions.Size = new System.Drawing.Size(338, 23);
            this.BTN_Instructions.TabIndex = 13;
            this.BTN_Instructions.Text = "INSTRUCTIONS";
            this.BTN_Instructions.UseVisualStyleBackColor = false;
            this.BTN_Instructions.Click += new System.EventHandler(this.BTN_Instructions_Click);
            // 
            // LBL_Total_Inserer
            // 
            this.LBL_Total_Inserer.AutoSize = true;
            this.LBL_Total_Inserer.ForeColor = System.Drawing.Color.Green;
            this.LBL_Total_Inserer.Location = new System.Drawing.Point(9, 310);
            this.LBL_Total_Inserer.Name = "LBL_Total_Inserer";
            this.LBL_Total_Inserer.Size = new System.Drawing.Size(103, 13);
            this.LBL_Total_Inserer.TabIndex = 14;
            this.LBL_Total_Inserer.Text = "LIGNES INSÉRÉES";
            // 
            // LBL_NonInserer
            // 
            this.LBL_NonInserer.AutoSize = true;
            this.LBL_NonInserer.ForeColor = System.Drawing.Color.Red;
            this.LBL_NonInserer.Location = new System.Drawing.Point(139, 310);
            this.LBL_NonInserer.Name = "LBL_NonInserer";
            this.LBL_NonInserer.Size = new System.Drawing.Size(130, 13);
            this.LBL_NonInserer.TabIndex = 15;
            this.LBL_NonInserer.Text = "LIGNES NON INSÉRÉES";
            // 
            // FORM_FichierTxt
            // 
            this.AcceptButton = this.BTN_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 339);
            this.Controls.Add(this.LBL_NonInserer);
            this.Controls.Add(this.LBL_Total_Inserer);
            this.Controls.Add(this.BTN_Instructions);
            this.Controls.Add(this.BTN_Supprimer);
            this.Controls.Add(this.BTN_Insert);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.BTN_OuvrirFichier);
            this.Controls.Add(this.TB_Path);
            this.Controls.Add(this.LB_Noms);
            this.Name = "FORM_FichierTxt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajouter item avec fichier texte";
            this.Load += new System.EventHandler(this.FORM_FichierTxt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LB_Noms;
        private System.Windows.Forms.TextBox TB_Path;
        private System.Windows.Forms.Button BTN_OuvrirFichier;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.Button BTN_Insert;
        private System.Windows.Forms.Button BTN_Supprimer;
        private System.Windows.Forms.Button BTN_Instructions;
        private System.Windows.Forms.Label LBL_Total_Inserer;
        private System.Windows.Forms.Label LBL_NonInserer;
    }
}