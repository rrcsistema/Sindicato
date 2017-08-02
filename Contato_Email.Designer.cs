namespace Sindicato
{
    partial class Contato_Email
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contato_Email));
            this.lblPesquisa = new System.Windows.Forms.Label();
            this.lblBusca = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.dtgEmail = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPesquisa
            // 
            this.lblPesquisa.AutoSize = true;
            this.lblPesquisa.ForeColor = System.Drawing.Color.Red;
            this.lblPesquisa.Location = new System.Drawing.Point(94, 2);
            this.lblPesquisa.Name = "lblPesquisa";
            this.lblPesquisa.Size = new System.Drawing.Size(71, 13);
            this.lblPesquisa.TabIndex = 8;
            this.lblPesquisa.Text = "                ";
            // 
            // lblBusca
            // 
            this.lblBusca.AutoSize = true;
            this.lblBusca.Location = new System.Drawing.Point(1, 2);
            this.lblBusca.Name = "lblBusca";
            this.lblBusca.Size = new System.Drawing.Size(89, 13);
            this.lblBusca.TabIndex = 7;
            this.lblBusca.Text = "Busca pelo(a):";
            // 
            // txtBusca
            // 
            this.txtBusca.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusca.Location = new System.Drawing.Point(1, 16);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(633, 22);
            this.txtBusca.TabIndex = 6;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // dtgEmail
            // 
            this.dtgEmail.AllowUserToAddRows = false;
            this.dtgEmail.AllowUserToDeleteRows = false;
            this.dtgEmail.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.dtgEmail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEmail.Location = new System.Drawing.Point(0, 41);
            this.dtgEmail.Name = "dtgEmail";
            this.dtgEmail.ReadOnly = true;
            this.dtgEmail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEmail.Size = new System.Drawing.Size(635, 242);
            this.dtgEmail.TabIndex = 5;
            this.dtgEmail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEmail_CellClick);
            // 
            // Contato_Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 285);
            this.Controls.Add(this.lblPesquisa);
            this.Controls.Add(this.lblBusca);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.dtgEmail);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Contato_Email";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contato_Email";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Contato_Email_FormClosing);
            this.Load += new System.EventHandler(this.Contato_Email_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPesquisa;
        private System.Windows.Forms.Label lblBusca;
        public System.Windows.Forms.TextBox txtBusca;
        public System.Windows.Forms.DataGridView dtgEmail;
    }
}