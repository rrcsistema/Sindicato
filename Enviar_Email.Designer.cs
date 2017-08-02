namespace Sindicato
{
    partial class Enviar_Email
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Enviar_Email));
            this.btnEmail = new System.Windows.Forms.Button();
            this.btnEnviar_Email = new System.Windows.Forms.Button();
            this.txtAssunto = new System.Windows.Forms.TextBox();
            this.txtCc = new System.Windows.Forms.TextBox();
            this.txtCorpo_Email = new System.Windows.Forms.TextBox();
            this.txtDestinatario = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAssunto = new System.Windows.Forms.Label();
            this.lblCc = new System.Windows.Forms.Label();
            this.lblDestinatario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEmail
            // 
            this.btnEmail.Location = new System.Drawing.Point(839, 16);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(63, 20);
            this.btnEmail.TabIndex = 19;
            this.btnEmail.Text = "E-mail";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // btnEnviar_Email
            // 
            this.btnEnviar_Email.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar_Email.ForeColor = System.Drawing.Color.Green;
            this.btnEnviar_Email.Location = new System.Drawing.Point(7, 412);
            this.btnEnviar_Email.Name = "btnEnviar_Email";
            this.btnEnviar_Email.Size = new System.Drawing.Size(897, 41);
            this.btnEnviar_Email.TabIndex = 18;
            this.btnEnviar_Email.Text = "Enviar Email";
            this.btnEnviar_Email.UseVisualStyleBackColor = true;
            this.btnEnviar_Email.Click += new System.EventHandler(this.btnEnviar_Email_Click);
            // 
            // txtAssunto
            // 
            this.txtAssunto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtAssunto.Location = new System.Drawing.Point(8, 96);
            this.txtAssunto.MaxLength = 200;
            this.txtAssunto.Name = "txtAssunto";
            this.txtAssunto.Size = new System.Drawing.Size(893, 20);
            this.txtAssunto.TabIndex = 15;
            // 
            // txtCc
            // 
            this.txtCc.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCc.Location = new System.Drawing.Point(8, 56);
            this.txtCc.MaxLength = 2000;
            this.txtCc.Name = "txtCc";
            this.txtCc.Size = new System.Drawing.Size(893, 20);
            this.txtCc.TabIndex = 13;
            // 
            // txtCorpo_Email
            // 
            this.txtCorpo_Email.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCorpo_Email.Location = new System.Drawing.Point(8, 136);
            this.txtCorpo_Email.Multiline = true;
            this.txtCorpo_Email.Name = "txtCorpo_Email";
            this.txtCorpo_Email.Size = new System.Drawing.Size(893, 271);
            this.txtCorpo_Email.TabIndex = 17;
            // 
            // txtDestinatario
            // 
            this.txtDestinatario.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDestinatario.Location = new System.Drawing.Point(8, 16);
            this.txtDestinatario.MaxLength = 100;
            this.txtDestinatario.Name = "txtDestinatario";
            this.txtDestinatario.Size = new System.Drawing.Size(823, 20);
            this.txtDestinatario.TabIndex = 11;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(3, 123);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(41, 13);
            this.lblEmail.TabIndex = 16;
            this.lblEmail.Text = "E-mail";
            // 
            // lblAssunto
            // 
            this.lblAssunto.AutoSize = true;
            this.lblAssunto.Location = new System.Drawing.Point(3, 83);
            this.lblAssunto.Name = "lblAssunto";
            this.lblAssunto.Size = new System.Drawing.Size(60, 13);
            this.lblAssunto.TabIndex = 14;
            this.lblAssunto.Text = "Assunto.:";
            // 
            // lblCc
            // 
            this.lblCc.AutoSize = true;
            this.lblCc.Location = new System.Drawing.Point(3, 43);
            this.lblCc.Name = "lblCc";
            this.lblCc.Size = new System.Drawing.Size(30, 13);
            this.lblCc.TabIndex = 12;
            this.lblCc.Text = "Cc.:";
            // 
            // lblDestinatario
            // 
            this.lblDestinatario.AutoSize = true;
            this.lblDestinatario.Location = new System.Drawing.Point(3, 3);
            this.lblDestinatario.Name = "lblDestinatario";
            this.lblDestinatario.Size = new System.Drawing.Size(83, 13);
            this.lblDestinatario.TabIndex = 10;
            this.lblDestinatario.Text = "Destinatário.:";
            // 
            // Enviar_Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 457);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.btnEnviar_Email);
            this.Controls.Add(this.txtAssunto);
            this.Controls.Add(this.txtCc);
            this.Controls.Add(this.txtCorpo_Email);
            this.Controls.Add(this.txtDestinatario);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblAssunto);
            this.Controls.Add(this.lblCc);
            this.Controls.Add(this.lblDestinatario);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Enviar_Email";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar_Email";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enviar_Email_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Button btnEnviar_Email;
        private System.Windows.Forms.TextBox txtAssunto;
        public System.Windows.Forms.TextBox txtCc;
        private System.Windows.Forms.TextBox txtCorpo_Email;
        public System.Windows.Forms.TextBox txtDestinatario;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAssunto;
        private System.Windows.Forms.Label lblCc;
        private System.Windows.Forms.Label lblDestinatario;

        public System.EventHandler Enviar_Email_Load { get; set; }
    }
}