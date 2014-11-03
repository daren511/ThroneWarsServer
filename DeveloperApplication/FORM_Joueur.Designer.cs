namespace DeveloperApplication
{
    partial class FORM_Joueur
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
            this.LBL_JID = new System.Windows.Forms.Label();
            this.DGV_Inventaire = new System.Windows.Forms.DataGridView();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.BTN_Consulter = new System.Windows.Forms.Button();
            this.BTN_Annuler = new System.Windows.Forms.Button();
            this.TB_Username = new System.Windows.Forms.TextBox();
            this.TB_Email = new System.Windows.Forms.TextBox();
            this.TB_PWD = new System.Windows.Forms.TextBox();
            this.DTP_JoinDate = new System.Windows.Forms.DateTimePicker();
            this.TB_Argent = new System.Windows.Forms.TextBox();
            this.CHECK_Confirmed = new System.Windows.Forms.CheckBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Inventaire)).BeginInit();
            this.SuspendLayout();
            // 
            // LBL_JID
            // 
            this.LBL_JID.AutoSize = true;
            this.LBL_JID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LBL_JID.Location = new System.Drawing.Point(13, 13);
            this.LBL_JID.Name = "LBL_JID";
            this.LBL_JID.Size = new System.Drawing.Size(23, 13);
            this.LBL_JID.TabIndex = 0;
            this.LBL_JID.Text = "JID";
            // 
            // DGV_Inventaire
            // 
            this.DGV_Inventaire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Inventaire.Location = new System.Drawing.Point(12, 63);
            this.DGV_Inventaire.Name = "DGV_Inventaire";
            this.DGV_Inventaire.Size = new System.Drawing.Size(507, 213);
            this.DGV_Inventaire.TabIndex = 8;
            // 
            // BTN_OK
            // 
            this.BTN_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_OK.Location = new System.Drawing.Point(363, 281);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(75, 23);
            this.BTN_OK.TabIndex = 9;
            this.BTN_OK.Text = "OK";
            this.BTN_OK.UseVisualStyleBackColor = true;
            // 
            // BTN_Consulter
            // 
            this.BTN_Consulter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Consulter.Location = new System.Drawing.Point(12, 282);
            this.BTN_Consulter.Name = "BTN_Consulter";
            this.BTN_Consulter.Size = new System.Drawing.Size(176, 23);
            this.BTN_Consulter.TabIndex = 10;
            this.BTN_Consulter.Text = "Consulter";
            this.BTN_Consulter.UseVisualStyleBackColor = true;
            // 
            // BTN_Annuler
            // 
            this.BTN_Annuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Annuler.Location = new System.Drawing.Point(444, 281);
            this.BTN_Annuler.Name = "BTN_Annuler";
            this.BTN_Annuler.Size = new System.Drawing.Size(75, 23);
            this.BTN_Annuler.TabIndex = 11;
            this.BTN_Annuler.Text = "Annuler";
            this.BTN_Annuler.UseVisualStyleBackColor = true;
            // 
            // TB_Username
            // 
            this.TB_Username.Location = new System.Drawing.Point(63, 10);
            this.TB_Username.Name = "TB_Username";
            this.TB_Username.Size = new System.Drawing.Size(201, 20);
            this.TB_Username.TabIndex = 12;
            // 
            // TB_Email
            // 
            this.TB_Email.Location = new System.Drawing.Point(63, 36);
            this.TB_Email.Name = "TB_Email";
            this.TB_Email.Size = new System.Drawing.Size(170, 20);
            this.TB_Email.TabIndex = 13;
            // 
            // TB_PWD
            // 
            this.TB_PWD.Location = new System.Drawing.Point(270, 11);
            this.TB_PWD.Name = "TB_PWD";
            this.TB_PWD.Size = new System.Drawing.Size(159, 20);
            this.TB_PWD.TabIndex = 14;
            // 
            // DTP_JoinDate
            // 
            this.DTP_JoinDate.Location = new System.Drawing.Point(403, 37);
            this.DTP_JoinDate.Name = "DTP_JoinDate";
            this.DTP_JoinDate.Size = new System.Drawing.Size(116, 20);
            this.DTP_JoinDate.TabIndex = 15;
            // 
            // TB_Argent
            // 
            this.TB_Argent.Location = new System.Drawing.Point(239, 37);
            this.TB_Argent.Name = "TB_Argent";
            this.TB_Argent.Size = new System.Drawing.Size(158, 20);
            this.TB_Argent.TabIndex = 16;
            // 
            // CHECK_Confirmed
            // 
            this.CHECK_Confirmed.AutoSize = true;
            this.CHECK_Confirmed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHECK_Confirmed.Location = new System.Drawing.Point(455, 11);
            this.CHECK_Confirmed.Name = "CHECK_Confirmed";
            this.CHECK_Confirmed.Size = new System.Drawing.Size(64, 17);
            this.CHECK_Confirmed.TabIndex = 17;
            this.CHECK_Confirmed.Text = "Confirmé";
            this.CHECK_Confirmed.UseVisualStyleBackColor = true;
            // 
            // FORM_Joueur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 317);
            this.Controls.Add(this.CHECK_Confirmed);
            this.Controls.Add(this.TB_Argent);
            this.Controls.Add(this.DTP_JoinDate);
            this.Controls.Add(this.TB_PWD);
            this.Controls.Add(this.TB_Email);
            this.Controls.Add(this.TB_Username);
            this.Controls.Add(this.BTN_Annuler);
            this.Controls.Add(this.BTN_Consulter);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.DGV_Inventaire);
            this.Controls.Add(this.LBL_JID);
            this.Name = "FORM_Joueur";
            this.Load += new System.EventHandler(this.FORM_Joueur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Inventaire)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_JID;
        private System.Windows.Forms.DataGridView DGV_Inventaire;
        private System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.Button BTN_Consulter;
        private System.Windows.Forms.Button BTN_Annuler;
        private System.Windows.Forms.TextBox TB_Username;
        private System.Windows.Forms.TextBox TB_Email;
        private System.Windows.Forms.TextBox TB_PWD;
        private System.Windows.Forms.DateTimePicker DTP_JoinDate;
        private System.Windows.Forms.TextBox TB_Argent;
        private System.Windows.Forms.CheckBox CHECK_Confirmed;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}