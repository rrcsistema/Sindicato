using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sindicato
{
    public partial class Cadastro_de_Empresa : Form
    {
        public Cadastro_de_Empresa()
        {
            InitializeComponent();
        }

        private void Cadastro_de_Empresa_Load(object sender, EventArgs e)
        {
            try
            {
                // Atualizando Data Grid com base no select

                SqlConnection Nova_conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (Nova_conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {



                    string strSql = "select Id as Cod, CNPJ,Nome from TBempresa";

                    SqlDataAdapter da = new SqlDataAdapter(strSql, Nova_conn);

                    //cria um objeto datatable
                    DataTable empresa = new DataTable();

                    //preenche o datatable via dataadapter
                    da.Fill(empresa);

                    //atribui o datatable ao datagridview para exibir o resultado
                    dtgCadastro_Empresa.DataSource = empresa;

                    dtgCadastro_Empresa.Refresh();

                    // Redimensionar as colunas mestre DataGridView para ajustar os dados recém-carregados.
                    //dtgFiltro_Vaga.AutoResizeColumns();

                    // Ajustar Coluna manualmente

                    DataGridViewColumn coluna0 = dtgCadastro_Empresa.Columns[0];
                    coluna0.Width = 35;

                    DataGridViewColumn coluna1 = dtgCadastro_Empresa.Columns[1];
                    coluna1.Width = 110;

                    DataGridViewColumn coluna2 = dtgCadastro_Empresa.Columns[2];
                    coluna2.Width = 220;

                    Conexao.fecharConexao();
                }


                SqlConnection conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {
                    SqlCommand retornobanco = new SqlCommand(("SELECT IDENT_CURRENT('TBempresa') + 1 AS id"), conn);

                    SqlDataReader leitor = retornobanco.ExecuteReader();

                    while (leitor.Read())
                    {
                        txtCodigo.Text = leitor["id"].ToString();

                        txtCodigo.Focus();
                    }

                    //Fechar conexao 

                    Conexao.fecharConexao();

                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }

            // Passando foco para Empresa

            txtEmpresa.Focus();

            txtEmpresa.SelectAll();
        }

        private void mkCnpj_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            mkCnpj.BackColor = System.Drawing.Color.Yellow;
            
            mkCnpj.Mask = "00,000,000/0000-00";

            mkCnpj.Select(0, 0);

            mkCnpj.Focus();

            mkCnpj.SelectAll();
        }

        private void mkCnpj_Leave(object sender, EventArgs e)
        {
            if (mkCnpj.Text == "  .   .   /    -")
            {
                mkCnpj.Mask = "";
            }

            if (mkCnpj.Text.Replace("_", "").Replace("/", "").Replace("-", "").Replace(".", "").Length != 14 && mkCnpj.Text != string.Empty)
            {
                MessageBox.Show("Valor informado inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                mkCnpj.Focus();

                mkCnpj.SelectAll();
            }

            //Mudando cor ao perder foco
            mkCnpj.BackColor = System.Drawing.Color.White;
        }

        private void mkCep_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            mkCep.BackColor = System.Drawing.Color.Yellow;
            
            mkCep.Mask = "00000-999";

            mkCep.Select(0, 0);

            mkCep.Focus();

            mkCep.SelectAll();
        }

        private void mkCep_Leave(object sender, EventArgs e)
        {
            if (mkCep.Text == "     -")
            {
                mkCep.Mask = "";
            }
            if (mkCep.Text.Replace("_", "").Length != 9 && mkCep.Text != string.Empty)
            {
                MessageBox.Show("Valor informado inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                mkCep.Focus();

                mkCep.SelectAll();
            }

            //Mudando cor ao perder foco
            mkCep.BackColor = System.Drawing.Color.White;
        }

        private void mkTelefone_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            mkTelefone.BackColor = System.Drawing.Color.Yellow;

            mkTelefone.Mask = "(99)0000-0000";

            mkTelefone.Select(0, 0);

            mkTelefone.Focus();

            mkTelefone.SelectAll();
        }

        private void mkTelefone_Leave(object sender, EventArgs e)
        {
            if (mkTelefone.Text == "(  )    -")

                mkTelefone.Mask = "";

            if (mkTelefone.Text == "NULL")
            {
                mkTelefone.Text = string.Empty;

                mkTelefone.Mask = "";
            }
            if (mkTelefone.Text.Replace("_", "").Replace("-", "").Replace("(", "").Replace(")", "").Length != 10 && mkTelefone.Text != string.Empty)
            {
                MessageBox.Show("Valor informado inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                mkTelefone.Focus();

                mkTelefone.SelectAll();
            }

            //Mudando cor ao perder foco
            mkTelefone.BackColor = System.Drawing.Color.White;
        }

        private void mkCelular_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            mkCelular.BackColor = System.Drawing.Color.Yellow;
            
            mkCelular.Mask = "(99)90000-0000";

            mkCelular.Select(0, 0);

            mkCelular.Focus();

            mkCelular.SelectAll();
        }
        private void mkCelular_Leave(object sender, EventArgs e)
        {
            if (mkCelular.Text == "(  )     -")

                mkCelular.Mask = "";

            if (mkCelular.Text == "NULL")
            {
                mkCelular.Text = string.Empty;

                mkCelular.Mask = "";
            }
            if (mkCelular.Text.Replace("_", "").Length != 14 && mkCelular.Text != string.Empty)
            {
                MessageBox.Show("Valor informado inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                mkCelular.Focus();

                mkCelular.SelectAll();
            }
            //Mudando cor ao perder foco
            mkCelular.BackColor = System.Drawing.Color.White;

        }
        private void txtCodigo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtEmpresa.Focus();

            txtEmpresa.Select();
        }

        private void txtCodigo_MouseClick(object sender, MouseEventArgs e)
        {
            txtEmpresa.Focus();

            txtEmpresa.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cancelar = MessageBox.Show("Deseja cancelar os dados na Tela?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (cancelar.ToString().ToUpper() == "YES")
                {
                    Limpar_Dados.LimpaControles(this);

                    Conexao.fecharConexao();

                    Cadastro_de_Empresa_Load(this, new EventArgs());

                    mkCnpj.Focus();

                    mkCep.Focus();

                    mkTelefone.Focus();

                    mkCelular.Focus();

                    txtEmpresa.Focus();

                    txtEmpresa.Select();
                }
                else
                {
                    // Voltando Foco para TABCADASTRO

                    tbEmpresa.SelectedTab = tbpCadastro;

                    txtEmpresa.Focus();

                    txtEmpresa.Select();
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {

                    string cnpj = string.Empty;
                    string cep = string.Empty;
                    string Fone = string.Empty;
                    string Celular = string.Empty;

                    if (mkCnpj.Text != string.Empty)
                    {
                        cnpj = mkCnpj.Text.Replace(".", "").Replace("/", "").Replace("-", "");
                    }
                    if (mkCep.Text != string.Empty)
                    {
                        cep = mkCep.Text.Replace(".", "").Replace("-", "");
                    }
                    if (mkTelefone.Text != string.Empty)
                    {
                        Fone = mkTelefone.Text.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "");
                    }
                    if (mkCelular.Text != string.Empty)
                    {
                        Celular = mkCelular.Text.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "");
                    }

                    if (txtEmpresa.Text != string.Empty && mkCnpj.Text != string.Empty)
                    {



                        string ssql = "insert into TBempresa(Nome,Cnpj,Cep,Telefone,Celular,Endereco,Numero,Cidade,Bairro,Email) " + " VALUES (@Nome, @Cnpj, @Cep, @Telefone,@Celular,@Endereco,@Numero,@Cidade,@Bairro,@Email)";

                        SqlCommand Comando = new SqlCommand(ssql, conn);

                        Comando.Parameters.AddWithValue("@Nome", txtEmpresa.Text);
                        Comando.Parameters.AddWithValue("@Cnpj", cnpj);
                        Comando.Parameters.AddWithValue("@Cep", cep);
                        Comando.Parameters.AddWithValue("@Telefone", Fone);
                        Comando.Parameters.AddWithValue("@Celular", Celular);
                        Comando.Parameters.AddWithValue("@Endereco", txtEndereco.Text);
                        Comando.Parameters.AddWithValue("@Numero", txtNumero.Text);
                        Comando.Parameters.AddWithValue("@Cidade", txtCidade.Text);
                        Comando.Parameters.AddWithValue("@Bairro", txtBairro.Text);
                        Comando.Parameters.AddWithValue("@Email", txtEmail.Text);

                        Comando.ExecuteNonQuery();

                        //Fechar conexao 

                        Conexao.fecharConexao();

                        MessageBox.Show("Registro Salvo no Sistema", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        Limpar_Dados.LimpaControles(this);

                        Cadastro_de_Empresa_Load(this, new EventArgs());

                        mkCnpj.Mask = "";
                        mkCep.Mask = "";
                        mkTelefone.Mask = "";
                        mkCelular.Mask = "";
                    }
                    else
                    {
                        MessageBox.Show("Para Salvar Registro é Necessario informar Descrição/CNPJ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        // Voltando Foco para Nome da Empresa

                        txtEmpresa.Focus();

                        txtEmpresa.Select();
                    }
                }
            }

            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void Cadastro_de_Empresa_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //Validando tecla F5 e chamando evento do botão salvar.

                if (btnSalvar.Visible == true)
                {

                    if (e.KeyCode == Keys.F5)
                    {
                        btnSalvar_Click(this, new EventArgs());
                    }
                }
                //Validando tecla F8 e chamando evento do botão Atualizar.
                if (btnAlterar.Visible == true)
                {
                    if (e.KeyCode == Keys.F8)
                    {
                        btnAlterar_Click(this, new EventArgs());
                    }
                }
                // Validando tecla F7
                if (e.KeyCode == Keys.F7)
                {
                    btnCancelar_Click(this, new EventArgs());
                }


            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void tbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbEmpresa.SelectedTab == tbpListagem)
                {
                    // Desabilitar os Botões

                    btnAlterar.Visible = false;

                    btnCancelar.Visible = false;

                    btnSalvar.Visible = false;

                    tbEmpresa.Size = new Size(424, 242);

                }
                else if (tbEmpresa.SelectedTab == tbpCadastro)
                {
                    // Habilitando os Botões Salva

                    btnCancelar.Visible = true;

                    btnSalvar.Visible = true;

                    tbEmpresa.Size = new Size(424, 206);

                    txtEmpresa.Focus();

                    txtEmpresa.Select();
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string cnpj = string.Empty;
            string cep = string.Empty;
            string Fone = string.Empty;
            string Celular = string.Empty;


            if (mkCnpj.Text != string.Empty)
            {
                cnpj = mkCnpj.Text.Replace(".", "").Replace("/", "").Replace("-", "");
            }
            if (mkCep.Text != string.Empty)
            {
                cep = mkCep.Text.Replace(".", "").Replace("-", "");
            }
            if (mkTelefone.Text != string.Empty)
            {
                Fone = mkTelefone.Text.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "");
            }
            if (mkCelular.Text != string.Empty)
            {
                Celular = mkCelular.Text.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "");
            }

            try
            {
                SqlConnection conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {
                    string ssql = "update tbempresa set Nome = @Nome,Cnpj = @Cnpj,Cep = @Cep,Telefone = @Telefone,Celular = @Celular,Endereco = @Endereco,Numero = @Numero,Cidade = @Cidade,Bairro = @Bairro,Email = @Email from tbempresa" + " where id  =" + txtCodigo.Text;

                    SqlCommand Comando = new SqlCommand(ssql, conn);

                    Comando.Parameters.AddWithValue("@Nome", (txtEmpresa.Text));
                    Comando.Parameters.AddWithValue("@Cnpj", (cnpj));
                    Comando.Parameters.AddWithValue("@Cep", (cep));
                    Comando.Parameters.AddWithValue("@Telefone", (Fone));
                    Comando.Parameters.AddWithValue("@Celular", (Celular));
                    Comando.Parameters.AddWithValue("@Endereco", (txtEndereco.Text));
                    Comando.Parameters.AddWithValue("@Numero", (txtNumero.Text));
                    Comando.Parameters.AddWithValue("@Cidade", (txtCidade.Text));
                    Comando.Parameters.AddWithValue("@Bairro", (txtBairro.Text));
                    Comando.Parameters.AddWithValue("@Email", (txtEmail.Text));

                    Comando.ExecuteNonQuery();

                    Conexao.fecharConexao();

                }

                Conexao.fecharConexao();

                MessageBox.Show("Alteração Efetuada com sucesso", "Atualização", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Conexao.fecharConexao();

                Limpar_Dados.LimpaControles(this);

                // Desabilitar Botão Atualizar e Habilitar Botão Savlar

                btnSalvar.Visible = true;

                btnAlterar.Visible = false;

                // Voltando Foco para TABCADASTRO

                tbEmpresa.SelectedTab = tbpCadastro;

                mkCnpj.Focus();

                mkCep.Focus();

                mkTelefone.Focus();

                mkCelular.Focus();

                txtEmpresa.Focus();

                txtEmpresa.Select();

                // Chamando Evendo do LOAD

                Cadastro_de_Empresa_Load(this, new EventArgs());
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void dtgCadastro_Empresa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string coluna = dtgCadastro_Empresa.CurrentRow.Cells[0].Value.ToString();

                SqlConnection conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {

                    SqlCommand retornobanco = new SqlCommand(("select Id,Nome,Cnpj,Cep,Telefone,Celular,Endereco,Numero,Cidade,Bairro,Email from tbempresa where id =" + coluna), conn);

                    SqlDataReader Comando = retornobanco.ExecuteReader();

                    while (Comando.Read())
                    {
                        txtCodigo.Text = Comando["id"].ToString();

                        txtEmpresa.Text = Comando["Nome"].ToString();

                        mkCnpj.Text = Comando["Cnpj"].ToString();

                        mkCep.Text = Comando["Cep"].ToString();

                        mkTelefone.Text = Comando["Telefone"].ToString();

                        mkCelular.Text = Comando["Celular"].ToString();

                        txtEndereco.Text = Comando["Endereco"].ToString();

                        txtNumero.Text = Comando["Numero"].ToString();

                        txtCidade.Text = Comando["Cidade"].ToString();

                        txtBairro.Text = Comando["Bairro"].ToString();

                        txtEmail.Text = Comando["Email"].ToString();

                        // Limpado os campos Null

                        if (mkTelefone.Text == "NULL")
                        {
                            mkTelefone.Text = string.Empty;
                        }

                        if (mkCelular.Text == "NULL")
                        {
                            mkCelular.Text = string.Empty;
                        }

                        // Voltando Foco para TABCADASTRO

                        tbEmpresa.SelectedTab = tbpCadastro;

                        mkCnpj.Focus();

                        mkCep.Focus();

                        mkTelefone.Focus();

                        mkCelular.Focus();

                        txtEmpresa.Focus();

                        txtEmpresa.Select();

                        // Desabilitar Botão Savlar e Habilitar Botão Atualizar

                        btnSalvar.Visible = false;

                        btnAlterar.Visible = true;

                        // Local onde botão Alterar vai aparecer

                        btnAlterar.Location = new Point(0, 201);
                    }

                    Conexao.fecharConexao();
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void Cadastro_de_Empresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Parando o som e mudando foco com Enter

                e.SuppressKeyPress = true;

                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Cadastro_de_Empresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult fechar = MessageBox.Show("Deseja Fechar Tela?", "Fechar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (fechar.ToString().ToUpper() == "YES")
                {
                    Limpar_Dados.LimpaControles(this);

                    Conexao.fecharConexao();

                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void mkCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Aceita somente numero e backuspace

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 27 && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

                MessageBox.Show("Campo só aceita numero(s).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtEmpresa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmpresa_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtEmpresa.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtEmpresa_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtEmpresa.BackColor = System.Drawing.Color.White;
        }

        private void txtEndereco_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtEndereco.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtEndereco_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtEndereco.BackColor = System.Drawing.Color.White;
        }

        private void txtNumero_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtNumero.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtNumero.BackColor = System.Drawing.Color.White;
        }

        private void txtCidade_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtCidade.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtCidade_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtCidade.BackColor = System.Drawing.Color.White;
        }

        private void txtBairro_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtBairro.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtBairro_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtBairro.BackColor = System.Drawing.Color.White;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtEmail.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtEmail.BackColor = System.Drawing.Color.White;
        }
    }
}
