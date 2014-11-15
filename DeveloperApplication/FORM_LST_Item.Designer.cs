namespace DeveloperApplication
{
    partial class FORM_LST_Item
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
            this.DGV_Items = new System.Windows.Forms.DataGridView();
            this.CHECK_AfficherTout = new System.Windows.Forms.CheckBox();
            this.BTN_Etat = new System.Windows.Forms.Button();
            this.BTN_Modifier = new System.Windows.Forms.Button();
            this.BTN_Fermer = new System.Windows.Forms.Button();
            this.BTN_Ajouter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Items)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Items
            // 
            this.DGV_Items.AllowUserToAddRows = false;
            this.DGV_Items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Items.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Items.Location = new System.Drawing.Point(12, 12);
            this.DGV_Items.Name = "DGV_Items";
            this.DGV_Items.ReadOnly = true;
            this.DGV_Items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Items.Size = new System.Drawing.Size(692, 287);
            this.DGV_Items.TabIndex = 0;
            this.DGV_Items.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Items_CellClick);
            this.DGV_Items.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Items_CellDoubleClick);
            // 
            // CHECK_AfficherTout
            // 
            this.CHECK_AfficherTout.AutoSize = true;
            this.CHECK_AfficherTout.Checked = true;
            this.CHECK_AfficherTout.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHECK_AfficherTout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHECK_AfficherTout.Location = new System.Drawing.Point(25, 308);
            this.CHECK_AfficherTout.Name = "CHECK_AfficherTout";
            this.CHECK_AfficherTout.Size = new System.Drawing.Size(80, 17);
            this.CHECK_AfficherTout.TabIndex = 1;
            this.CHECK_AfficherTout.Text = "Afficher tout";
            this.CHECK_AfficherTout.UseVisualStyleBackColor = true;
            this.CHECK_AfficherTout.CheckedChanged += new System.EventHandler(this.CHECK_AfficherTout_CheckedChanged);
            // 
            // BTN_Etat
            // 
            this.BTN_Etat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Etat.Location = new System.Drawing.Point(520, 305);
            this.BTN_Etat.Name = "BTN_Etat";
            this.BTN_Etat.Size = new System.Drawing.Size(184, 23);
            this.BTN_Etat.TabIndex = 2;
            this.BTN_Etat.Text = "Désactiver";
            this.BTN_Etat.UseVisualStyleBackColor = true;
            this.BTN_Etat.Click += new System.EventHandler(this.BTN_Etat_Click);
            // 
            // BTN_Modifier
            // 
            this.BTN_Modifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Modifier.Location = new System.Drawing.Point(330, 305);
            this.BTN_Modifier.Name = "BTN_Modifier";
            this.BTN_Modifier.Size = new System.Drawing.Size(184, 23);
            this.BTN_Modifier.TabIndex = 3;
            this.BTN_Modifier.Text = "Modifier";
            this.BTN_Modifier.UseVisualStyleBackColor = true;
            this.BTN_Modifier.Click += new System.EventHandler(this.BTN_Modifier_Click);
            // 
            // BTN_Fermer
            // 
            this.BTN_Fermer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_Fermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Fermer.Location = new System.Drawing.Point(629, 342);
            this.BTN_Fermer.Name = "BTN_Fermer";
            this.BTN_Fermer.Size = new System.Drawing.Size(75, 23);
            this.BTN_Fermer.TabIndex = 4;
            this.BTN_Fermer.Text = "Fermer";
            this.BTN_Fermer.UseVisualStyleBackColor = true;
            // 
            // BTN_Ajouter
            // 
            this.BTN_Ajouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Ajouter.Location = new System.Drawing.Point(140, 305);
            this.BTN_Ajouter.Name = "BTN_Ajouter";
            this.BTN_Ajouter.Size = new System.Drawing.Size(184, 23);
            this.BTN_Ajouter.TabIndex = 5;
            this.BTN_Ajouter.Text = "Ajouter";
            this.BTN_Ajouter.UseVisualStyleBackColor = true;
            this.BTN_Ajouter.Click += new System.EventHandler(this.BTN_Ajouter_Click);
            // 
            // FORM_LST_Item
            // 
            this.AcceptButton = this.BTN_Fermer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 377);
            this.Controls.Add(this.BTN_Ajouter);
            this.Controls.Add(this.BTN_Fermer);
            this.Controls.Add(this.BTN_Modifier);
            this.Controls.Add(this.BTN_Etat);
            this.Controls.Add(this.CHECK_AfficherTout);
            this.Controls.Add(this.DGV_Items);
            this.Name = "FORM_LST_Item";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FORM_LST_Item";
            this.Load += new System.EventHandler(this.FORM_LST_Item_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Items)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Items;
        private System.Windows.Forms.CheckBox CHECK_AfficherTout;
        private System.Windows.Forms.Button BTN_Etat;
        private System.Windows.Forms.Button BTN_Modifier;
        private System.Windows.Forms.Button BTN_Fermer;
        private System.Windows.Forms.Button BTN_Ajouter;
    }
}