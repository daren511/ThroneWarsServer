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
            this.label2 = new System.Windows.Forms.Label();
            this.CB_Niveau = new System.Windows.Forms.ComboBox();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.BTN_Insert = new System.Windows.Forms.Button();
            this.BTN_Supprimer = new System.Windows.Forms.Button();
            this.TB_Nom = new System.Windows.Forms.TextBox();
            this.BTN_Modifier = new System.Windows.Forms.Button();
            this.LBL_Total = new System.Windows.Forms.Label();
            this.BTN_Instructions = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LB_Noms
            // 
            this.LB_Noms.FormattingEnabled = true;
            this.LB_Noms.Location = new System.Drawing.Point(12, 71);
            this.LB_Noms.Name = "LB_Noms";
            this.LB_Noms.Size = new System.Drawing.Size(305, 199);
            this.LB_Noms.TabIndex = 0;
            this.LB_Noms.SelectedIndexChanged += new System.EventHandler(this.LB_Noms_SelectedIndexChanged);
            // 
            // TB_Path
            // 
            this.TB_Path.Location = new System.Drawing.Point(12, 32);
            this.TB_Path.Name = "TB_Path";
            this.TB_Path.Size = new System.Drawing.Size(305, 20);
            this.TB_Path.TabIndex = 1;
            this.TB_Path.TextChanged += new System.EventHandler(this.TB_Path_TextChanged);
            // 
            // BTN_OuvrirFichier
            // 
            this.BTN_OuvrirFichier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_OuvrirFichier.Location = new System.Drawing.Point(323, 30);
            this.BTN_OuvrirFichier.Name = "BTN_OuvrirFichier";
            this.BTN_OuvrirFichier.Size = new System.Drawing.Size(75, 23);
            this.BTN_OuvrirFichier.TabIndex = 2;
            this.BTN_OuvrirFichier.Text = "Ouvrir";
            this.BTN_OuvrirFichier.UseVisualStyleBackColor = true;
            this.BTN_OuvrirFichier.Click += new System.EventHandler(this.BTN_OuvrirFichier_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Niveau";
            // 
            // CB_Niveau
            // 
            this.CB_Niveau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Niveau.FormattingEnabled = true;
            this.CB_Niveau.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.CB_Niveau.Location = new System.Drawing.Point(329, 87);
            this.CB_Niveau.Name = "CB_Niveau";
            this.CB_Niveau.Size = new System.Drawing.Size(72, 21);
            this.CB_Niveau.TabIndex = 6;
            // 
            // fileDialog
            // 
            this.fileDialog.Filter = "Fichiers texte (*.txt)|*.txt";
            // 
            // BTN_OK
            // 
            this.BTN_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_OK.Location = new System.Drawing.Point(326, 304);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(75, 23);
            this.BTN_OK.TabIndex = 7;
            this.BTN_OK.Text = "OK";
            this.BTN_OK.UseVisualStyleBackColor = true;
            // 
            // BTN_Insert
            // 
            this.BTN_Insert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Insert.Location = new System.Drawing.Point(161, 275);
            this.BTN_Insert.Name = "BTN_Insert";
            this.BTN_Insert.Size = new System.Drawing.Size(156, 23);
            this.BTN_Insert.TabIndex = 8;
            this.BTN_Insert.Text = "Insérer les items";
            this.BTN_Insert.UseVisualStyleBackColor = true;
            this.BTN_Insert.Click += new System.EventHandler(this.BTN_Insert_Click);
            // 
            // BTN_Supprimer
            // 
            this.BTN_Supprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Supprimer.Location = new System.Drawing.Point(242, 304);
            this.BTN_Supprimer.Name = "BTN_Supprimer";
            this.BTN_Supprimer.Size = new System.Drawing.Size(75, 23);
            this.BTN_Supprimer.TabIndex = 9;
            this.BTN_Supprimer.Text = "Supprimer";
            this.BTN_Supprimer.UseVisualStyleBackColor = true;
            this.BTN_Supprimer.Click += new System.EventHandler(this.BTN_Supprimer_Click);
            // 
            // TB_Nom
            // 
            this.TB_Nom.Location = new System.Drawing.Point(12, 306);
            this.TB_Nom.Name = "TB_Nom";
            this.TB_Nom.Size = new System.Drawing.Size(134, 20);
            this.TB_Nom.TabIndex = 10;
            // 
            // BTN_Modifier
            // 
            this.BTN_Modifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Modifier.Location = new System.Drawing.Point(161, 304);
            this.BTN_Modifier.Name = "BTN_Modifier";
            this.BTN_Modifier.Size = new System.Drawing.Size(75, 23);
            this.BTN_Modifier.TabIndex = 11;
            this.BTN_Modifier.Text = "Modifier";
            this.BTN_Modifier.UseVisualStyleBackColor = true;
            this.BTN_Modifier.Click += new System.EventHandler(this.BTN_Modifier_Click);
            // 
            // LBL_Total
            // 
            this.LBL_Total.AutoSize = true;
            this.LBL_Total.Location = new System.Drawing.Point(323, 280);
            this.LBL_Total.Name = "LBL_Total";
            this.LBL_Total.Size = new System.Drawing.Size(0, 13);
            this.LBL_Total.TabIndex = 12;
            // 
            // BTN_Instructions
            // 
            this.BTN_Instructions.BackColor = System.Drawing.Color.Green;
            this.BTN_Instructions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Instructions.ForeColor = System.Drawing.Color.White;
            this.BTN_Instructions.Location = new System.Drawing.Point(12, 3);
            this.BTN_Instructions.Name = "BTN_Instructions";
            this.BTN_Instructions.Size = new System.Drawing.Size(386, 23);
            this.BTN_Instructions.TabIndex = 13;
            this.BTN_Instructions.Text = "INSTRUCTIONS";
            this.BTN_Instructions.UseVisualStyleBackColor = false;
            this.BTN_Instructions.Click += new System.EventHandler(this.BTN_Instructions_Click);
            // 
            // FORM_FichierTxt
            // 
            this.AcceptButton = this.BTN_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 339);
            this.Controls.Add(this.BTN_Instructions);
            this.Controls.Add(this.LBL_Total);
            this.Controls.Add(this.BTN_Modifier);
            this.Controls.Add(this.TB_Nom);
            this.Controls.Add(this.BTN_Supprimer);
            this.Controls.Add(this.BTN_Insert);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.CB_Niveau);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_Niveau;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.Button BTN_Insert;
        private System.Windows.Forms.Button BTN_Supprimer;
        private System.Windows.Forms.TextBox TB_Nom;
        private System.Windows.Forms.Button BTN_Modifier;
        private System.Windows.Forms.Label LBL_Total;
        private System.Windows.Forms.Button BTN_Instructions;
    }
}