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
            this.CHECK_SHOW_Activated = new System.Windows.Forms.CheckBox();
            this.TAB_Control = new System.Windows.Forms.TabControl();
            this.PAGE_Inventaire = new System.Windows.Forms.TabPage();
            this.PAGE_Potions = new System.Windows.Forms.TabPage();
            this.DGV_Potions = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Inventaire)).BeginInit();
            this.TAB_Control.SuspendLayout();
            this.PAGE_Inventaire.SuspendLayout();
            this.PAGE_Potions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Potions)).BeginInit();
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
            this.DGV_Inventaire.AllowUserToAddRows = false;
            this.DGV_Inventaire.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Inventaire.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_Inventaire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Inventaire.Location = new System.Drawing.Point(6, 6);
            this.DGV_Inventaire.Name = "DGV_Inventaire";
            this.DGV_Inventaire.ReadOnly = true;
            this.DGV_Inventaire.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Inventaire.Size = new System.Drawing.Size(487, 175);
            this.DGV_Inventaire.TabIndex = 8;
            this.DGV_Inventaire.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Inventaire_CellDoubleClick);
            // 
            // BTN_OK
            // 
            this.BTN_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
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
            this.BTN_Consulter.Location = new System.Drawing.Point(12, 281);
            this.BTN_Consulter.Name = "BTN_Consulter";
            this.BTN_Consulter.Size = new System.Drawing.Size(176, 23);
            this.BTN_Consulter.TabIndex = 10;
            this.BTN_Consulter.Text = "Consulter";
            this.BTN_Consulter.UseVisualStyleBackColor = true;
            this.BTN_Consulter.Click += new System.EventHandler(this.BTN_Consulter_Click);
            // 
            // BTN_Annuler
            // 
            this.BTN_Annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            this.TB_Username.Size = new System.Drawing.Size(170, 20);
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
            this.TB_PWD.Location = new System.Drawing.Point(239, 10);
            this.TB_PWD.Name = "TB_PWD";
            this.TB_PWD.ReadOnly = true;
            this.TB_PWD.Size = new System.Drawing.Size(190, 20);
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
            this.TB_Argent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Argent_KeyPress);
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
            // CHECK_SHOW_Activated
            // 
            this.CHECK_SHOW_Activated.AutoSize = true;
            this.CHECK_SHOW_Activated.Checked = true;
            this.CHECK_SHOW_Activated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHECK_SHOW_Activated.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHECK_SHOW_Activated.Location = new System.Drawing.Point(204, 285);
            this.CHECK_SHOW_Activated.Name = "CHECK_SHOW_Activated";
            this.CHECK_SHOW_Activated.Size = new System.Drawing.Size(80, 17);
            this.CHECK_SHOW_Activated.TabIndex = 18;
            this.CHECK_SHOW_Activated.Text = "Afficher tout";
            this.CHECK_SHOW_Activated.UseVisualStyleBackColor = true;
            // 
            // TAB_Control
            // 
            this.TAB_Control.Controls.Add(this.PAGE_Inventaire);
            this.TAB_Control.Controls.Add(this.PAGE_Potions);
            this.TAB_Control.HotTrack = true;
            this.TAB_Control.Location = new System.Drawing.Point(12, 62);
            this.TAB_Control.Name = "TAB_Control";
            this.TAB_Control.SelectedIndex = 0;
            this.TAB_Control.Size = new System.Drawing.Size(507, 213);
            this.TAB_Control.TabIndex = 19;
            this.TAB_Control.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TAB_Control_Selecting);
            // 
            // PAGE_Inventaire
            // 
            this.PAGE_Inventaire.Controls.Add(this.DGV_Inventaire);
            this.PAGE_Inventaire.Location = new System.Drawing.Point(4, 22);
            this.PAGE_Inventaire.Name = "PAGE_Inventaire";
            this.PAGE_Inventaire.Padding = new System.Windows.Forms.Padding(3);
            this.PAGE_Inventaire.Size = new System.Drawing.Size(499, 187);
            this.PAGE_Inventaire.TabIndex = 0;
            this.PAGE_Inventaire.Text = "Inventaire";
            this.PAGE_Inventaire.UseVisualStyleBackColor = true;
            // 
            // PAGE_Potions
            // 
            this.PAGE_Potions.Controls.Add(this.DGV_Potions);
            this.PAGE_Potions.Location = new System.Drawing.Point(4, 22);
            this.PAGE_Potions.Name = "PAGE_Potions";
            this.PAGE_Potions.Padding = new System.Windows.Forms.Padding(3);
            this.PAGE_Potions.Size = new System.Drawing.Size(499, 187);
            this.PAGE_Potions.TabIndex = 1;
            this.PAGE_Potions.Text = "Potions";
            this.PAGE_Potions.UseVisualStyleBackColor = true;
            // 
            // DGV_Potions
            // 
            this.DGV_Potions.AllowUserToAddRows = false;
            this.DGV_Potions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Potions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_Potions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Potions.Location = new System.Drawing.Point(6, 6);
            this.DGV_Potions.Name = "DGV_Potions";
            this.DGV_Potions.ReadOnly = true;
            this.DGV_Potions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Potions.Size = new System.Drawing.Size(487, 175);
            this.DGV_Potions.TabIndex = 0;
            this.DGV_Potions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Potions_CellDoubleClick);
            // 
            // FORM_Joueur
            // 
            this.AcceptButton = this.BTN_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTN_Annuler;
            this.ClientSize = new System.Drawing.Size(531, 317);
            this.Controls.Add(this.TAB_Control);
            this.Controls.Add(this.CHECK_SHOW_Activated);
            this.Controls.Add(this.CHECK_Confirmed);
            this.Controls.Add(this.TB_Argent);
            this.Controls.Add(this.DTP_JoinDate);
            this.Controls.Add(this.TB_PWD);
            this.Controls.Add(this.TB_Email);
            this.Controls.Add(this.TB_Username);
            this.Controls.Add(this.BTN_Annuler);
            this.Controls.Add(this.BTN_Consulter);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.LBL_JID);
            this.Name = "FORM_Joueur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FORM_Joueur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Inventaire)).EndInit();
            this.TAB_Control.ResumeLayout(false);
            this.PAGE_Inventaire.ResumeLayout(false);
            this.PAGE_Potions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Potions)).EndInit();
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
        private System.Windows.Forms.CheckBox CHECK_SHOW_Activated;
        private System.Windows.Forms.TabControl TAB_Control;
        private System.Windows.Forms.TabPage PAGE_Inventaire;
        private System.Windows.Forms.TabPage PAGE_Potions;
        private System.Windows.Forms.DataGridView DGV_Potions;
    }
}