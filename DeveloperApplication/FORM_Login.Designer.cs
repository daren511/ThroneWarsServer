namespace DeveloperApplication
{
    partial class FORM_Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_Login = new System.Windows.Forms.Button();
            this.TB_MDP = new System.Windows.Forms.TextBox();
            this.LBL_Erreur = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mot de passe";
            // 
            // BTN_Login
            // 
            this.BTN_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Login.Location = new System.Drawing.Point(175, 62);
            this.BTN_Login.Name = "BTN_Login";
            this.BTN_Login.Size = new System.Drawing.Size(78, 25);
            this.BTN_Login.TabIndex = 2;
            this.BTN_Login.Text = "Connexion";
            this.BTN_Login.UseVisualStyleBackColor = true;
            this.BTN_Login.Click += new System.EventHandler(this.BTN_Login_Click);
            // 
            // TB_MDP
            // 
            this.TB_MDP.Location = new System.Drawing.Point(44, 36);
            this.TB_MDP.MaxLength = 75;
            this.TB_MDP.Name = "TB_MDP";
            this.TB_MDP.PasswordChar = '*';
            this.TB_MDP.Size = new System.Drawing.Size(209, 20);
            this.TB_MDP.TabIndex = 1;
            this.TB_MDP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_MDP_KeyPress);
            // 
            // LBL_Erreur
            // 
            this.LBL_Erreur.AutoSize = true;
            this.LBL_Erreur.ForeColor = System.Drawing.Color.Red;
            this.LBL_Erreur.Location = new System.Drawing.Point(41, 68);
            this.LBL_Erreur.Name = "LBL_Erreur";
            this.LBL_Erreur.Size = new System.Drawing.Size(113, 13);
            this.LBL_Erreur.TabIndex = 3;
            this.LBL_Erreur.Text = "Mauvais mot de passe";
            this.LBL_Erreur.Visible = false;
            // 
            // FORM_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 106);
            this.Controls.Add(this.LBL_Erreur);
            this.Controls.Add(this.BTN_Login);
            this.Controls.Add(this.TB_MDP);
            this.Controls.Add(this.label1);
            this.Name = "FORM_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connexion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_Login;
        private System.Windows.Forms.TextBox TB_MDP;
        private System.Windows.Forms.Label LBL_Erreur;
    }
}