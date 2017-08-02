namespace Sindicato
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.btnConfigurar_smtp = new System.Windows.Forms.Button();
            this.btnCadastro_Vaga = new System.Windows.Forms.Button();
            this.btnPessoal = new System.Windows.Forms.Button();
            this.btnFiltrar_Vaga = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConfigurar_smtp
            // 
            this.btnConfigurar_smtp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigurar_smtp.ForeColor = System.Drawing.Color.Black;
            this.btnConfigurar_smtp.Location = new System.Drawing.Point(5, 136);
            this.btnConfigurar_smtp.Name = "btnConfigurar_smtp";
            this.btnConfigurar_smtp.Size = new System.Drawing.Size(153, 33);
            this.btnConfigurar_smtp.TabIndex = 7;
            this.btnConfigurar_smtp.Text = "Conta de E-mail";
            this.btnConfigurar_smtp.UseVisualStyleBackColor = true;
            this.btnConfigurar_smtp.Visible = false;
            this.btnConfigurar_smtp.Click += new System.EventHandler(this.btnConfigurar_smtp_Click);
            // 
            // btnCadastro_Vaga
            // 
            this.btnCadastro_Vaga.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastro_Vaga.ForeColor = System.Drawing.Color.Black;
            this.btnCadastro_Vaga.Location = new System.Drawing.Point(5, 6);
            this.btnCadastro_Vaga.Name = "btnCadastro_Vaga";
            this.btnCadastro_Vaga.Size = new System.Drawing.Size(153, 33);
            this.btnCadastro_Vaga.TabIndex = 4;
            this.btnCadastro_Vaga.Text = "Cad. Vaga";
            this.btnCadastro_Vaga.UseVisualStyleBackColor = true;
            this.btnCadastro_Vaga.Click += new System.EventHandler(this.btnCadastro_Vaga_Click);
            // 
            // btnPessoal
            // 
            this.btnPessoal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPessoal.ForeColor = System.Drawing.Color.Black;
            this.btnPessoal.Location = new System.Drawing.Point(5, 49);
            this.btnPessoal.Name = "btnPessoal";
            this.btnPessoal.Size = new System.Drawing.Size(153, 33);
            this.btnPessoal.TabIndex = 5;
            this.btnPessoal.Text = "Cad. Currículo";
            this.btnPessoal.UseVisualStyleBackColor = true;
            this.btnPessoal.Click += new System.EventHandler(this.btnPessoal_Click);
            // 
            // btnFiltrar_Vaga
            // 
            this.btnFiltrar_Vaga.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar_Vaga.ForeColor = System.Drawing.Color.Black;
            this.btnFiltrar_Vaga.Location = new System.Drawing.Point(5, 93);
            this.btnFiltrar_Vaga.Name = "btnFiltrar_Vaga";
            this.btnFiltrar_Vaga.Size = new System.Drawing.Size(153, 33);
            this.btnFiltrar_Vaga.TabIndex = 6;
            this.btnFiltrar_Vaga.Text = "Filtrar Vaga";
            this.btnFiltrar_Vaga.UseVisualStyleBackColor = true;
            this.btnFiltrar_Vaga.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.ForeColor = System.Drawing.Color.Black;
            this.btnBackup.Location = new System.Drawing.Point(5, 179);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(153, 33);
            this.btnBackup.TabIndex = 8;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Visible = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(960, 580);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnConfigurar_smtp);
            this.Controls.Add(this.btnCadastro_Vaga);
            this.Controls.Add(this.btnPessoal);
            this.Controls.Add(this.btnFiltrar_Vaga);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Principal";
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Principal_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfigurar_smtp;
        private System.Windows.Forms.Button btnCadastro_Vaga;
        private System.Windows.Forms.Button btnPessoal;
        private System.Windows.Forms.Button btnFiltrar_Vaga;
        private System.Windows.Forms.Button btnBackup;

    }
}