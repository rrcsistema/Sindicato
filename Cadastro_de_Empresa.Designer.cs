namespace Sindicato
{
    partial class Cadastro_de_Empresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cadastro_de_Empresa));
            this.tbEmpresa = new System.Windows.Forms.TabControl();
            this.tbpCadastro = new System.Windows.Forms.TabPage();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblBairro = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.mkCelular = new System.Windows.Forms.MaskedTextBox();
            this.mkTelefone = new System.Windows.Forms.MaskedTextBox();
            this.mkCep = new System.Windows.Forms.MaskedTextBox();
            this.mkCnpj = new System.Windows.Forms.MaskedTextBox();
            this.lblCidade = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.lblCelular = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblFone = new System.Windows.Forms.Label();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.lblCep = new System.Windows.Forms.Label();
            this.lblCnpj = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.tbpListagem = new System.Windows.Forms.TabPage();
            this.dtgCadastro_Empresa = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.tbEmpresa.SuspendLayout();
            this.tbpCadastro.SuspendLayout();
            this.tbpListagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCadastro_Empresa)).BeginInit();
            this.SuspendLayout();
            // 
            // tbEmpresa
            // 
            this.tbEmpresa.Controls.Add(this.tbpCadastro);
            this.tbEmpresa.Controls.Add(this.tbpListagem);
            this.tbEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmpresa.Location = new System.Drawing.Point(-4, -1);
            this.tbEmpresa.Name = "tbEmpresa";
            this.tbEmpresa.SelectedIndex = 0;
            this.tbEmpresa.Size = new System.Drawing.Size(424, 206);
            this.tbEmpresa.TabIndex = 0;
            this.tbEmpresa.TabStop = false;
            this.tbEmpresa.SelectedIndexChanged += new System.EventHandler(this.tbEmpresa_SelectedIndexChanged);
            // 
            // tbpCadastro
            // 
            this.tbpCadastro.BackColor = System.Drawing.SystemColors.Menu;
            this.tbpCadastro.Controls.Add(this.lblEmail);
            this.tbpCadastro.Controls.Add(this.txtEmail);
            this.tbpCadastro.Controls.Add(this.lblBairro);
            this.tbpCadastro.Controls.Add(this.txtBairro);
            this.tbpCadastro.Controls.Add(this.mkCelular);
            this.tbpCadastro.Controls.Add(this.mkTelefone);
            this.tbpCadastro.Controls.Add(this.mkCep);
            this.tbpCadastro.Controls.Add(this.mkCnpj);
            this.tbpCadastro.Controls.Add(this.lblCidade);
            this.tbpCadastro.Controls.Add(this.txtCidade);
            this.tbpCadastro.Controls.Add(this.lblCelular);
            this.tbpCadastro.Controls.Add(this.lblNumero);
            this.tbpCadastro.Controls.Add(this.txtNumero);
            this.tbpCadastro.Controls.Add(this.lblFone);
            this.tbpCadastro.Controls.Add(this.lblEndereco);
            this.tbpCadastro.Controls.Add(this.txtEndereco);
            this.tbpCadastro.Controls.Add(this.lblCep);
            this.tbpCadastro.Controls.Add(this.lblCnpj);
            this.tbpCadastro.Controls.Add(this.txtEmpresa);
            this.tbpCadastro.Controls.Add(this.lblEmpresa);
            this.tbpCadastro.Controls.Add(this.txtCodigo);
            this.tbpCadastro.Location = new System.Drawing.Point(4, 22);
            this.tbpCadastro.Name = "tbpCadastro";
            this.tbpCadastro.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCadastro.Size = new System.Drawing.Size(416, 180);
            this.tbpCadastro.TabIndex = 0;
            this.tbpCadastro.Text = "Cadastro";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(3, 143);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(41, 13);
            this.lblEmail.TabIndex = 19;
            this.lblEmail.Text = "E-mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(6, 156);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(406, 20);
            this.txtEmail.TabIndex = 20;
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Location = new System.Drawing.Point(230, 108);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(40, 13);
            this.lblBairro.TabIndex = 17;
            this.lblBairro.Text = "Bairro";
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(233, 121);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(179, 20);
            this.txtBairro.TabIndex = 18;
            this.txtBairro.Enter += new System.EventHandler(this.txtBairro_Enter);
            this.txtBairro.Leave += new System.EventHandler(this.txtBairro_Leave);
            // 
            // mkCelular
            // 
            this.mkCelular.Location = new System.Drawing.Point(310, 51);
            this.mkCelular.Name = "mkCelular";
            this.mkCelular.Size = new System.Drawing.Size(102, 20);
            this.mkCelular.TabIndex = 10;
            this.mkCelular.Enter += new System.EventHandler(this.mkCelular_Enter);
            this.mkCelular.Leave += new System.EventHandler(this.mkCelular_Leave);
            // 
            // mkTelefone
            // 
            this.mkTelefone.Location = new System.Drawing.Point(211, 51);
            this.mkTelefone.Name = "mkTelefone";
            this.mkTelefone.Size = new System.Drawing.Size(95, 20);
            this.mkTelefone.TabIndex = 8;
            this.mkTelefone.Enter += new System.EventHandler(this.mkTelefone_Enter);
            this.mkTelefone.Leave += new System.EventHandler(this.mkTelefone_Leave);
            // 
            // mkCep
            // 
            this.mkCep.Location = new System.Drawing.Point(136, 51);
            this.mkCep.Name = "mkCep";
            this.mkCep.Size = new System.Drawing.Size(71, 20);
            this.mkCep.TabIndex = 6;
            this.mkCep.Enter += new System.EventHandler(this.mkCep_Enter);
            this.mkCep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mkCep_KeyPress);
            this.mkCep.Leave += new System.EventHandler(this.mkCep_Leave);
            // 
            // mkCnpj
            // 
            this.mkCnpj.Location = new System.Drawing.Point(6, 51);
            this.mkCnpj.Name = "mkCnpj";
            this.mkCnpj.Size = new System.Drawing.Size(126, 20);
            this.mkCnpj.TabIndex = 4;
            this.mkCnpj.Enter += new System.EventHandler(this.mkCnpj_Enter);
            this.mkCnpj.Leave += new System.EventHandler(this.mkCnpj_Leave);
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(3, 108);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(46, 13);
            this.lblCidade.TabIndex = 15;
            this.lblCidade.Text = "Cidade";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(6, 121);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(223, 20);
            this.txtCidade.TabIndex = 16;
            this.txtCidade.Enter += new System.EventHandler(this.txtCidade_Enter);
            this.txtCidade.Leave += new System.EventHandler(this.txtCidade_Leave);
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Location = new System.Drawing.Point(307, 38);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(46, 13);
            this.lblCelular.TabIndex = 9;
            this.lblCelular.Text = "Celular";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(342, 73);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(50, 13);
            this.lblNumero.TabIndex = 13;
            this.lblNumero.Text = "Número";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(345, 86);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(67, 20);
            this.txtNumero.TabIndex = 14;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumero.Enter += new System.EventHandler(this.txtNumero_Enter);
            this.txtNumero.Leave += new System.EventHandler(this.txtNumero_Leave);
            // 
            // lblFone
            // 
            this.lblFone.AutoSize = true;
            this.lblFone.Location = new System.Drawing.Point(208, 38);
            this.lblFone.Name = "lblFone";
            this.lblFone.Size = new System.Drawing.Size(57, 13);
            this.lblFone.TabIndex = 7;
            this.lblFone.Text = "Telefone";
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Location = new System.Drawing.Point(3, 73);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(61, 13);
            this.lblEndereco.TabIndex = 11;
            this.lblEndereco.Text = "Endereço";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(6, 86);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(333, 20);
            this.txtEndereco.TabIndex = 12;
            this.txtEndereco.Enter += new System.EventHandler(this.txtEndereco_Enter);
            this.txtEndereco.Leave += new System.EventHandler(this.txtEndereco_Leave);
            // 
            // lblCep
            // 
            this.lblCep.AutoSize = true;
            this.lblCep.Location = new System.Drawing.Point(134, 38);
            this.lblCep.Name = "lblCep";
            this.lblCep.Size = new System.Drawing.Size(31, 13);
            this.lblCep.TabIndex = 5;
            this.lblCep.Text = "CEP";
            // 
            // lblCnpj
            // 
            this.lblCnpj.AutoSize = true;
            this.lblCnpj.Location = new System.Drawing.Point(3, 38);
            this.lblCnpj.Name = "lblCnpj";
            this.lblCnpj.Size = new System.Drawing.Size(38, 13);
            this.lblCnpj.TabIndex = 3;
            this.lblCnpj.Text = "CNPJ";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Location = new System.Drawing.Point(75, 16);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(337, 20);
            this.txtEmpresa.TabIndex = 0;
            this.txtEmpresa.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this.txtEmpresa.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this.txtEmpresa.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(3, 3);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(55, 13);
            this.lblEmpresa.TabIndex = 0;
            this.lblEmpresa.Text = "Empresa";
            // 
            // txtCodigo
            // 
            this.txtCodigo.ForeColor = System.Drawing.Color.Red;
            this.txtCodigo.Location = new System.Drawing.Point(6, 16);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(65, 20);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TabStop = false;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCodigo_MouseClick);
            this.txtCodigo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCodigo_MouseDoubleClick);
            // 
            // tbpListagem
            // 
            this.tbpListagem.BackColor = System.Drawing.SystemColors.Menu;
            this.tbpListagem.Controls.Add(this.dtgCadastro_Empresa);
            this.tbpListagem.Location = new System.Drawing.Point(4, 22);
            this.tbpListagem.Name = "tbpListagem";
            this.tbpListagem.Padding = new System.Windows.Forms.Padding(3);
            this.tbpListagem.Size = new System.Drawing.Size(416, 180);
            this.tbpListagem.TabIndex = 1;
            this.tbpListagem.Text = "Listagem";
            // 
            // dtgCadastro_Empresa
            // 
            this.dtgCadastro_Empresa.AllowUserToAddRows = false;
            this.dtgCadastro_Empresa.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dtgCadastro_Empresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCadastro_Empresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCadastro_Empresa.Location = new System.Drawing.Point(3, 3);
            this.dtgCadastro_Empresa.Name = "dtgCadastro_Empresa";
            this.dtgCadastro_Empresa.ReadOnly = true;
            this.dtgCadastro_Empresa.Size = new System.Drawing.Size(410, 174);
            this.dtgCadastro_Empresa.TabIndex = 0;
            this.dtgCadastro_Empresa.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dtgCadastro_Empresa_MouseDoubleClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Red;
            this.btnCancelar.Location = new System.Drawing.Point(213, 201);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(203, 40);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar (F7)";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.Green;
            this.btnSalvar.Location = new System.Drawing.Point(0, 201);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(203, 40);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Salvar (F5)";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.ForeColor = System.Drawing.Color.Blue;
            this.btnAlterar.Location = new System.Drawing.Point(104, 201);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(203, 40);
            this.btnAlterar.TabIndex = 2;
            this.btnAlterar.Text = "Alterar (F8)";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Visible = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // Cadastro_de_Empresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 241);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.tbEmpresa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cadastro_de_Empresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Empresa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cadastro_de_Empresa_FormClosing);
            this.Load += new System.EventHandler(this.Cadastro_de_Empresa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cadastro_de_Empresa_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Cadastro_de_Empresa_KeyUp);
            this.tbEmpresa.ResumeLayout(false);
            this.tbpCadastro.ResumeLayout(false);
            this.tbpCadastro.PerformLayout();
            this.tbpListagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCadastro_Empresa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbEmpresa;
        private System.Windows.Forms.TabPage tbpCadastro;
        private System.Windows.Forms.TabPage tbpListagem;
        private System.Windows.Forms.MaskedTextBox mkCelular;
        private System.Windows.Forms.MaskedTextBox mkTelefone;
        private System.Windows.Forms.MaskedTextBox mkCep;
        private System.Windows.Forms.MaskedTextBox mkCnpj;
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblFone;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label lblCep;
        private System.Windows.Forms.Label lblCnpj;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblBairro;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.DataGridView dtgCadastro_Empresa;
        private System.Windows.Forms.Button btnAlterar;
    }
}