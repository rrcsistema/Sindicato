namespace NOVO_PROJETO
{
    partial class Bairro_Regiao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bairro_Regiao));
            this.cmbRegiao = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblregiao = new System.Windows.Forms.Label();
            this.lblBairro = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.tabBairro_Regiao = new System.Windows.Forms.TabControl();
            this.tabpCadastro = new System.Windows.Forms.TabPage();
            this.tabpListagem = new System.Windows.Forms.TabPage();
            this.tabBairro_Regiao.SuspendLayout();
            this.tabpCadastro.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbRegiao
            // 
            this.cmbRegiao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRegiao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRegiao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegiao.FormattingEnabled = true;
            this.cmbRegiao.Items.AddRange(new object[] {
            "",
            "Central",
            "Leste",
            "Nordeste",
            "Norte",
            "Oeste",
            "Sudeste",
            "Sul",
            "Outros"});
            this.cmbRegiao.Location = new System.Drawing.Point(7, 20);
            this.cmbRegiao.Name = "cmbRegiao";
            this.cmbRegiao.Size = new System.Drawing.Size(185, 21);
            this.cmbRegiao.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(7, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(663, 20);
            this.textBox1.TabIndex = 1;
            // 
            // lblregiao
            // 
            this.lblregiao.AutoSize = true;
            this.lblregiao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblregiao.Location = new System.Drawing.Point(4, 4);
            this.lblregiao.Name = "lblregiao";
            this.lblregiao.Size = new System.Drawing.Size(47, 13);
            this.lblregiao.TabIndex = 27;
            this.lblregiao.Text = "Região";
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBairro.Location = new System.Drawing.Point(4, 45);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(40, 13);
            this.lblBairro.TabIndex = 28;
            this.lblBairro.Text = "Bairro";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.Green;
            this.btnSalvar.Location = new System.Drawing.Point(2, 129);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(684, 38);
            this.btnSalvar.TabIndex = 29;
            this.btnSalvar.Text = "Salvar (F5)";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // tabBairro_Regiao
            // 
            this.tabBairro_Regiao.Controls.Add(this.tabpCadastro);
            this.tabBairro_Regiao.Controls.Add(this.tabpListagem);
            this.tabBairro_Regiao.Location = new System.Drawing.Point(2, 2);
            this.tabBairro_Regiao.Name = "tabBairro_Regiao";
            this.tabBairro_Regiao.SelectedIndex = 0;
            this.tabBairro_Regiao.Size = new System.Drawing.Size(688, 121);
            this.tabBairro_Regiao.TabIndex = 30;
            // 
            // tabpCadastro
            // 
            this.tabpCadastro.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tabpCadastro.Controls.Add(this.cmbRegiao);
            this.tabpCadastro.Controls.Add(this.textBox1);
            this.tabpCadastro.Controls.Add(this.lblBairro);
            this.tabpCadastro.Controls.Add(this.lblregiao);
            this.tabpCadastro.Location = new System.Drawing.Point(4, 22);
            this.tabpCadastro.Name = "tabpCadastro";
            this.tabpCadastro.Padding = new System.Windows.Forms.Padding(3);
            this.tabpCadastro.Size = new System.Drawing.Size(680, 95);
            this.tabpCadastro.TabIndex = 0;
            this.tabpCadastro.Text = "Cadastro";
            // 
            // tabpListagem
            // 
            this.tabpListagem.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tabpListagem.Location = new System.Drawing.Point(4, 22);
            this.tabpListagem.Name = "tabpListagem";
            this.tabpListagem.Padding = new System.Windows.Forms.Padding(3);
            this.tabpListagem.Size = new System.Drawing.Size(680, 95);
            this.tabpListagem.TabIndex = 1;
            this.tabpListagem.Text = "Listagem";
            // 
            // Bairro_Regiao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 170);
            this.Controls.Add(this.tabBairro_Regiao);
            this.Controls.Add(this.btnSalvar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Bairro_Regiao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Bairro por Região";
            this.tabBairro_Regiao.ResumeLayout(false);
            this.tabpCadastro.ResumeLayout(false);
            this.tabpCadastro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRegiao;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblregiao;
        private System.Windows.Forms.Label lblBairro;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TabControl tabBairro_Regiao;
        private System.Windows.Forms.TabPage tabpCadastro;
        private System.Windows.Forms.TabPage tabpListagem;

        public System.EventHandler cmbRegiao_Enter { get; set; }
    }
}