using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using NOVO_PROJETO;


namespace Sindicato
{
    public partial class Pessoal : Form
    {
        string linha_selecionada = string.Empty;

        string duplicitada = string.Empty;

        public Pessoal()
        {
            InitializeComponent();
        }
        private void Pessoal_Load(object sender, EventArgs e)
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
                    string strSql = "SELECT id AS Cod, CPF, Nome, Ocupacao FROM TBpessoal";

                    SqlDataAdapter da = new SqlDataAdapter(strSql, Nova_conn);

                    //cria um objeto datatable
                    DataTable pessoal = new DataTable();

                    //preenche o datatable via dataadapter
                    da.Fill(pessoal);

                    //atribui o datatable ao datagridview para exibir o resultado
                    dtgPessoal.DataSource = pessoal;

                    dtgPessoal.Refresh();

                    // Redimensionar as colunas mestre DataGridView para ajustar os dados recém-carregados.
                    //dtgFiltro_Vaga.AutoResizeColumns();

                    // Ajustar Coluna manualmente

                    DataGridViewColumn coluna0 = dtgPessoal.Columns[0];
                    coluna0.Width = 70;

                    DataGridViewColumn coluna1 = dtgPessoal.Columns[1];
                    coluna1.Width = 80;

                    DataGridViewColumn coluna2 = dtgPessoal.Columns[2];
                    coluna2.Width = 350;

                    DataGridViewColumn coluna3 = dtgPessoal.Columns[3];
                    coluna3.Width = 120;

                    Conexao.fecharConexao();
                }


                mkData_Cadastro.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

                // Validando Proximo Código

                SqlConnection conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {
                    SqlCommand retornobanco = new SqlCommand(("SELECT IDENT_CURRENT('TBpessoal') + 1 AS id"), conn);

                    SqlDataReader leitor = retornobanco.ExecuteReader();

                    while (leitor.Read())
                    {
                        txtCodigo.Text = leitor["id"].ToString();

                        //Passando Foco para campo CPF ao Carregar Tela

                        txtNome.Focus();

                        txtNome.Select();
                    }

                    //Fechar conexao 

                    Conexao.fecharConexao();
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void txtCodigo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtNome.Focus();

            txtNome.Select();
        }

        private void txtCodigo_MouseClick(object sender, MouseEventArgs e)
        {
            txtNome.Focus();

            txtNome.Select();
        }

        private void mkData_Cadastro_MouseClick(object sender, MouseEventArgs e)
        {
            txtNome.Focus();

            txtNome.Select();
        }

        private void mkData_Cadastro_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtNome.Focus();

            txtNome.Select();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            int id = 0;

            string Novo_id = string.Empty;

            string nome_duplicado = string.Empty;

            try
            {

                if (cmbRegiao.Text != string.Empty && txtNome.Text != string.Empty && txtRua.Text != string.Empty && txtBairro.Text != string.Empty && txtCidade.Text != string.Empty && txtNumero.Text != string.Empty)
                {
                    SqlConnection Nova_conn1 = Conexao.obterConexao();

                    // a conexão foi efetuada com sucesso?
                    if (Nova_conn1 == null)
                    {
                        MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                    }
                    else
                    {
                        SqlCommand retornobanco = new SqlCommand(("SELECT IDENT_CURRENT('TBpessoal') AS id"), Nova_conn1);

                        SqlDataReader leitor = retornobanco.ExecuteReader();

                        while (leitor.Read())
                        {
                            id = Convert.ToInt32(leitor["id"].ToString());
                        }

                        if (Convert.ToInt32(txtCodigo.Text) == id)
                        {
                            SqlConnection conn1 = Conexao.obterConexao();

                            // a conexão foi efetuada com sucesso?
                            if (conn1 == null)
                            {
                                MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                            }
                            else
                            {
                                SqlCommand retornobanco1 = new SqlCommand(("SELECT IDENT_CURRENT('TBpessoal') + 1 AS id"), conn1);

                                SqlDataReader leitor1 = retornobanco1.ExecuteReader();

                                while (leitor1.Read())
                                {
                                    Novo_id = leitor1["id"].ToString();
                                }


                                MessageBox.Show("Código do Registro já exite. \n Proximo número será" + " (" + Novo_id + ")");

                                txtCodigo.Text = Novo_id;
                            }
                        }
                    }

                    SqlConnection conn = Conexao.obterConexao();

                    // a conexão foi efetuada com sucesso?
                    if (conn == null)
                    {
                        MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                    }
                    else
                    {
                        string cpf = string.Empty;
                        string cep = string.Empty;
                        string Fone = string.Empty;
                        string Celular = string.Empty;
                        string Celular01 = string.Empty;
                        string Celular02 = string.Empty;
                        double pretensao = 0;

                        if (mkCpf.Text != string.Empty)
                        {
                            cpf = mkCpf.Text.Replace(".", "").Replace("-", "");
                        }
                        if (mkCep.Text != string.Empty)
                        {
                            cep = mkCep.Text.Replace(".", "").Replace("-", "");
                        }
                        if (mkFone.Text != string.Empty)
                        {
                            Fone = mkFone.Text.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "");
                        }
                        if (mkCelular.Text != string.Empty)
                        {
                            Celular = mkCelular.Text.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "");
                        }
                        if (mkCelular01.Text != string.Empty)
                        {
                            Celular01 = mkCelular01.Text.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "");
                        }
                        if (mkCelular02.Text != string.Empty)
                        {
                            Celular02 = mkCelular02.Text.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "");
                        }
                        if (txtPretensao.Text != string.Empty)
                        {
                            pretensao = Convert.ToDouble(txtPretensao.Text.Replace("R$", "".Replace(" ", "")));
                        }
                        // Atualizando os Campos

                        string ssql = "insert into TBpessoal(Data_Cadastro,Cpf,Nome,Rua,Numero,Bairro,Cidade,Cep,Uf"
                        + ",Regiao,Referencia,email,Fone,Celular,Recado_Telefone,Quem,Sexo,Estado_Civil,Filhos"
                        + ",Estuda,Horario_Estudo,Escolaridade,Disponibilidade_Horario,Cart_Trabalho,Serie,RG,Titulo_Eleitor"
                        + ",PIS,Habilitação,Categoria_Habilitacao,Naturalidade,Uf_Naturalidade,Possui_Moto,Possui_Carro,Possui_Moto_Carro,Nao_Possui"
                        + ",Fumante,Ocupacao,Obs,Cursos,Portador_Necessidade,Qual,Idade,Celular_01,Celular_02,Complemento)"
                        + " VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20"
                        + ",@21,@22,@23,@24,@25,@26,@27,@28,@29,@30,@31,@32,@33,@34,@35,@36,@37,@38,@39,@40,@41,@42,@43,@44,@45,@46)";

                        SqlCommand Comando = new SqlCommand(ssql, conn);

                        Comando.Parameters.AddWithValue("@1", Convert.ToDateTime(mkData_Cadastro.Text).ToString("yyyy-MM-dd"));
                        Comando.Parameters.AddWithValue("@2", cpf);
                        Comando.Parameters.AddWithValue("@3", txtNome.Text);
                        Comando.Parameters.AddWithValue("@4", txtRua.Text);
                        Comando.Parameters.AddWithValue("@5", txtNumero.Text);
                        Comando.Parameters.AddWithValue("@6", txtBairro.Text);
                        Comando.Parameters.AddWithValue("@7", txtCidade.Text);
                        Comando.Parameters.AddWithValue("@8", cep);
                        Comando.Parameters.AddWithValue("@9", Convert.ToString(cmUf.Text).ToUpper());
                        Comando.Parameters.AddWithValue("@10", Convert.ToString(cmbRegiao.Text).ToUpper());
                        Comando.Parameters.AddWithValue("@11", txtReferencia.Text);
                        Comando.Parameters.AddWithValue("@12", txtEmail.Text);
                        Comando.Parameters.AddWithValue("@13", Fone);
                        Comando.Parameters.AddWithValue("@14", Celular);
                        Comando.Parameters.AddWithValue("@15", txtRecado.Text);
                        Comando.Parameters.AddWithValue("@16", txtQuem.Text);
                        Comando.Parameters.AddWithValue("@17", Convert.ToString(cbSexo.Text).ToUpper());
                        Comando.Parameters.AddWithValue("@18", cbEstado_Civil.Text);
                        Comando.Parameters.AddWithValue("@19", txtFilhos.Text);
                        Comando.Parameters.AddWithValue("@20", (rdEstuda_Sim.Checked ? +1 : 0));
                        Comando.Parameters.AddWithValue("@21", txtHorario.Text);
                        Comando.Parameters.AddWithValue("@22", cbEscolaridade.Text);
                        Comando.Parameters.AddWithValue("@23", (cmbDisponibilidade_horario.Text));
                        Comando.Parameters.AddWithValue("@24", txtCarteira.Text);
                        Comando.Parameters.AddWithValue("@25", txtSerie.Text);
                        Comando.Parameters.AddWithValue("@26", txtRg.Text);
                        Comando.Parameters.AddWithValue("@27", txtTitulo.Text);
                        Comando.Parameters.AddWithValue("@28", txtPis.Text);
                        Comando.Parameters.AddWithValue("@29", (chcHabilitação.Checked ? +1 : 0));
                        Comando.Parameters.AddWithValue("@30", txtCategoria.Text);
                        Comando.Parameters.AddWithValue("@31", txtNatural.Text);
                        Comando.Parameters.AddWithValue("@32", Convert.ToString(cbUf.Text).ToUpper());
                        Comando.Parameters.AddWithValue("@33", (rdMoto.Checked ? +1 : 0));
                        Comando.Parameters.AddWithValue("@34", (rdCarro.Checked ? +1 : 0));
                        Comando.Parameters.AddWithValue("@35", (rdMoto_Carro.Checked ? +1 : 0));
                        Comando.Parameters.AddWithValue("@36", (rdNenhum.Checked ? +1 : 0));
                        Comando.Parameters.AddWithValue("@37", (rdFumante_Nao.Checked ? +1 : 0));
                        Comando.Parameters.AddWithValue("@38", cbOcupacao.Text);
                        Comando.Parameters.AddWithValue("@39", txtObs.Text);
                        Comando.Parameters.AddWithValue("@40", txtCursos.Text);
                        Comando.Parameters.AddWithValue("@41", (rdNao.Checked ? +0 : 1));
                        Comando.Parameters.AddWithValue("@42", txtQual.Text);
                        Comando.Parameters.AddWithValue("@43", mkIdade.Text);
                        Comando.Parameters.AddWithValue("@44", Celular01);
                        Comando.Parameters.AddWithValue("@45", Celular02);
                        Comando.Parameters.AddWithValue("@46", txtComplemento.Text);


                        Comando.ExecuteNonQuery();

                        Conexao.fecharConexao();

                        // Validando Estuda

                        if (rdEstuda_Sim.Checked != true)
                        {
                            rdEstuda_Nao.Checked = true;
                        }
                        // Validando Fuma
                        if (rdFumante_Nao.Checked != true)
                        {
                            rdFumante_Sim.Checked = true;
                        }
                        // Validando Necessidade Especial
                        if (rdNao.Checked != true)
                        {
                            rdSim.Checked = true;
                        }
                        else
                        {
                            rdSim.Checked = false;
                        }
                        if (mkNascimento.Text != string.Empty)
                        {
                            SqlConnection conn3 = Conexao.obterConexao();

                            // a conexão foi efetuada com sucesso?
                            if (conn3 == null)
                            {
                                MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                            }
                            else
                            {

                                string ssql1 = "update tbpessoal set nascimento = @Nascimento where id =" + txtCodigo.Text;

                                SqlCommand comando = new SqlCommand(ssql1, conn3);
                                comando.Parameters.AddWithValue("@Nascimento", Convert.ToDateTime(mkNascimento.Text).ToString("yyyy-MM-dd"));


                                comando.ExecuteNonQuery();
                            }

                            Conexao.fecharConexao();

                        }

                        if (txtPretensao.Text != string.Empty)
                        {
                            SqlConnection Nova_conn = Conexao.obterConexao();

                            // a conexão foi efetuada com sucesso?
                            if (Nova_conn == null)
                            {
                                MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                            }
                            else
                            {

                                string Nova_ssql = "update tbpessoal set Pretensao_Salarial = @Pretensao where id  =" + txtCodigo.Text;

                                SqlCommand Novo_Comando = new SqlCommand(Nova_ssql, Nova_conn);
                                Novo_Comando.Parameters.AddWithValue("@Pretensao", pretensao);

                                Novo_Comando.ExecuteNonQuery();
                            }

                            Conexao.fecharConexao();

                        }

                        //Validar Historio de Trabalho e inseri na base
                        if (dtgHistorico_Trabalho.Rows.Count != -1 && dtgHistorico_Trabalho.Rows.Count != 0)
                        {
                            SqlConnection N_Conn = Conexao.obterConexao();

                            // a conexão foi efetuada com sucesso?
                            if (N_Conn == null)
                            {
                                MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                            }
                            else
                            {
                                string N_ssql = "insert into tbhistorico_trabalho (Id_Curriculo,Empresa,Atividade,Salario_Inicial,Ultimo_Salario,Motivo_Saida, Admissao, Demissao)" +
                                "VALUES (@Id_Curriculo, @Empresa, @Atividade, @Salario_Inicial, @Ultimo_Salario, @Motivo_Saida, @admissao, @Demissao)";

                                SqlCommand N_Comando = new SqlCommand(N_ssql, N_Conn);

                                //percorro o DataGridView
                                for (int i = 0; i < dtgHistorico_Trabalho.Rows.Count; i++)
                                {
                                    //limpo os parâmetros
                                    N_Comando.Parameters.Clear();
                                    //crio os parâmetro do comando
                                    //e passo as linhas do dgvClientes para eles
                                    //onde a célula indica a coluna do dgv

                                    N_Comando.Parameters.AddWithValue("@Id_Curriculo", txtCodigo.Text);
                                    N_Comando.Parameters.AddWithValue("@Empresa", dtgHistorico_Trabalho.Rows[i].Cells[0].Value);
                                    N_Comando.Parameters.AddWithValue("@Atividade", dtgHistorico_Trabalho.Rows[i].Cells[1].Value);
                                    N_Comando.Parameters.AddWithValue("@Admissao", dtgHistorico_Trabalho.Rows[i].Cells[2].Value);
                                    N_Comando.Parameters.AddWithValue("@Demissao", dtgHistorico_Trabalho.Rows[i].Cells[3].Value);
                                    N_Comando.Parameters.AddWithValue("@Salario_Inicial", Convert.ToString(dtgHistorico_Trabalho.Rows[i].Cells[4].Value).Replace("R$ ", ""));
                                    N_Comando.Parameters.AddWithValue("@Ultimo_Salario", Convert.ToString(dtgHistorico_Trabalho.Rows[i].Cells[5].Value).Replace("R$ ", ""));
                                    N_Comando.Parameters.AddWithValue("@Motivo_Saida", dtgHistorico_Trabalho.Rows[i].Cells[6].Value);

                                    //executo o comando
                                    N_Comando.ExecuteNonQuery();
                                }
                            }

                            Conexao.fecharConexao();
                        }

                        //Fechar conexao

                        Conexao.fecharConexao();

                        MessageBox.Show("Registro Salvo no Sistema", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        Limpar_Dados.LimpaControles(this);

                        //Limpar datagrid

                        if (dtgHistorico_Trabalho.DataSource != null)
                        {

                            dtgHistorico_Trabalho.DataSource = null;
                        }
                        else
                        {
                            dtgHistorico_Trabalho.Rows.Clear();

                        }

                        //Desabilitar botão alterar historico trabalho

                        bntalterar1.Visible = false;

                        btnIncluir.Visible = true;

                        mkAdmissao.Focus();

                        mkDemissao.Focus();

                        // Voltando Foco para TABCADASTRO

                        tabPessoal.SelectedTab = tabPage1;

                        Pessoal_Load(this, new EventArgs());

                    }
                }
                else
                {
                    MessageBox.Show("Os campos destacados em vermelho são de preenchimento obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    // Voltando Foco para TABCADASTRO

                    tabPessoal.SelectedTab = tabPage1;


                    if (txtNome.Text == string.Empty)
                    {
                        txtNome.Focus();
                    }
                    else if (txtRua.Text == string.Empty)
                    {
                        txtRua.Focus();
                    }
                    else if (txtBairro.Text == string.Empty)
                    {
                        txtBairro.Focus();
                    }
                    else if (txtCidade.Text == string.Empty)
                    {
                        txtCidade.Focus();
                    }
                    else if (txtNumero.Text == string.Empty)
                    {
                        txtNumero.Focus();
                    }
                    else if (cmbRegiao.Text == string.Empty)
                    {
                        cmbRegiao.Focus();
                    }

                    Conexao.fecharConexao();
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void mkCpf_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            mkCpf.BackColor = System.Drawing.Color.Yellow;
            
            mkCpf.Mask = "000,000,000-00";

            mkCpf.Select(0, 0);

            mkCpf.Focus();

            mkCpf.SelectAll();

        }

        private void mkCpf_Leave(object sender, EventArgs e)
        {
            if (mkCpf.Text == "   .   .   -")
            {
                mkCpf.Mask = "";
            }
            if (mkCpf.Text.Replace("_", "").Replace(".", "").Replace("-", "").Length != 11 && mkCpf.Text != string.Empty)
            {
                MessageBox.Show("Valor informado inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                mkCpf.Focus();

                mkCpf.SelectAll();
            }
            else
            {
                // Mudando cor ao perder foco
                mkCpf.BackColor = System.Drawing.Color.White;
            }
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

        private void mkFone_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            mkFone.BackColor = System.Drawing.Color.Yellow;

            mkFone.Mask = "(99)0000-0000";

            mkFone.Select(0, 0);

            mkFone.Focus();

            mkFone.SelectAll();
        }

        private void mkFone_Leave(object sender, EventArgs e)
        {
            if (mkFone.Text == "(  )    -")

                mkFone.Mask = "";

            if (mkFone.Text == "NULL")
            {
                mkFone.Text = string.Empty;

                mkFone.Mask = "";
            }
            if (mkFone.Text.Replace("_", "").Replace("-", "").Replace("(", "").Replace(")", "").Length != 10 && mkFone.Text != string.Empty)
            {
                MessageBox.Show("Valor informado inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                mkFone.Focus();

                mkFone.SelectAll();
            }

            //Mudando cor ao perder foco
            mkFone.BackColor = System.Drawing.Color.White;
        }

        public void mkCelular_Enter(object sender, EventArgs e)
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

        private void mkNascimento_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            mkNascimento.BackColor = System.Drawing.Color.Yellow;
            
            mkNascimento.Mask = "00/00/0000";

            mkNascimento.Select(0, 0);

            mkNascimento.Focus();

            mkNascimento.SelectAll();
        }

        private void mkNascimento_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            mkNascimento.BackColor = System.Drawing.Color.White;

            DateTime data;


            if (mkNascimento.Text == "  /  /")
            {
                mkNascimento.Mask = "";
            }
            else
            {
                string data_nascimento = mkNascimento.Text.Replace("_", "");

                if (data_nascimento.Length != 10)
                {
                    MessageBox.Show("Data inválida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    mkNascimento.Focus();

                    mkNascimento.Select();
                }
                else
                {
                    if (DateTime.TryParse(mkNascimento.Text, out data))
                    {
                        // Atualizando Ano

                        int ano = DateTime.Now.Year;

                        // Pegando parte da data

                        string ano2 = Convert.ToDateTime(mkNascimento.Text).ToString("yyyy");

                        int ano_final = int.Parse(ano2);

                        mkIdade.Text = Convert.ToString(ano - ano_final).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Data inválida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        mkNascimento.Focus();

                        mkNascimento.Select();
                    }
                }
            }
        }

        private void mkAdmissao_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            mkAdmissao.BackColor = System.Drawing.Color.White;
        }

        private void mkAdmissao_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            mkAdmissao.BackColor = System.Drawing.Color.Yellow;
        }

        private void mkDemissao_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            mkDemissao.BackColor = System.Drawing.Color.White;
        }
        private void mkDemissao_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            mkDemissao.BackColor = System.Drawing.Color.Yellow;
        }

        private void chcHabilitação_CheckedChanged(object sender, EventArgs e)
        {
            if (chcHabilitação.Checked == true)
            {
                txtCategoria.ReadOnly = false;

                txtCategoria.Focus();

                txtCategoria.Select();
            }
            else
            {
                txtCategoria.ReadOnly = true;
            }

        }

        private void rdEstuda_Sim_CheckedChanged(object sender, EventArgs e)
        {
            if (rdEstuda_Sim.Checked == true)
            {
                txtHorario.ReadOnly = false;
            }
            else
            {
                txtHorario.ReadOnly = true;
            }
        }

        private void rdSim_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSim.Checked == true)
            {
                txtQual.ReadOnly = false;
            }
        }

        private void cmUf_Leave(object sender, EventArgs e)
        {
            cmUf.Text = Convert.ToString(cmUf.Text).ToUpper();

            //Mudando cor ao perder foco
            cmUf.BackColor = System.Drawing.Color.White;
        }

        private void cbUf_Leave(object sender, EventArgs e)
        {
            cbUf.Text = Convert.ToString(cbUf.Text).ToUpper();
        }

        private void cbSexo_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            cbSexo.BackColor = System.Drawing.Color.White;
            
            cbSexo.Text = Convert.ToString(cbSexo.Text).ToUpper();

            if (cbSexo.Text != "F" && cbSexo.Text != "M" && cbSexo.Text != string.Empty)
            {
                DialogResult atencao = MessageBox.Show("Valor informado não encontrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                cbSexo.Text = string.Empty;

                cbSexo.Focus();
            }
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

                    mkData_Cadastro.Text = (System.DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

                    txtNome.Focus();

                    txtNome.Select();

                    //Limpar datagrid

                    if (dtgHistorico_Trabalho.DataSource != null)
                    {

                        dtgHistorico_Trabalho.DataSource = null;
                    }
                    else
                    {
                        dtgHistorico_Trabalho.Rows.Clear();

                    }


                    // Desabilitar botão alterar historico trabalho
                    bntalterar1.Visible = false;

                    btnIncluir.Visible = true;

                    // Carregando Tabela de Preço

                    SqlConnection conn = Conexao.obterConexao();

                    // a conexão foi efetuada com sucesso?
                    if (conn == null)
                    {
                        MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                    }
                    else
                    {
                        SqlCommand retornobanco = new SqlCommand(("SELECT IDENT_CURRENT('TBpessoal') + 1 AS id"), conn);

                        SqlDataReader leitor = retornobanco.ExecuteReader();

                        while (leitor.Read())
                        {
                            txtCodigo.Text = leitor["id"].ToString();

                            //Passando Foco para campo CPF ao Carregar Tela

                            txtNome.Focus();

                            txtNome.Select();
                        }

                        // Desabilitando Botão Alterar

                        btnAlterar.Visible = false;

                        btnSalvar.Visible = true;

                        //Fechar conexao 

                        Conexao.fecharConexao();
                    }
                }

                // Voltando Foco para TABCADASTRO

                tabPessoal.SelectedTab = tabPage1;

                txtNome.Focus();

                mkCep.Focus();

                mkCelular01.Focus();

                mkCelular02.Focus();

                mkCelular.Focus();

                mkNascimento.Focus();

                mkFone.Focus();

                mkAdmissao.Focus();

                mkDemissao.Focus();

                txtSalario_Inicial.Focus();

                txtultimo_Salario.Focus();

                txtNome.Select();

            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void dtgPessoal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Pegando nome da coluna selecionada

                if (e.ColumnIndex == -1)
                {

                }
                else
                {

                    string coluna = (dtgPessoal.Columns[e.ColumnIndex].HeaderText);

                    lblPesquisa.Text = coluna;

                    //passando foco para txtbusca e limpando

                    txtBusca.Clear();

                    txtBusca.Focus();

                    txtBusca.SelectAll();
                }

            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void dtgPessoal_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                string coluna = dtgPessoal.CurrentRow.Cells[0].Value.ToString();

                SqlConnection conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {
                    DialogResult excluir = MessageBox.Show("Deseja Excluir o registro selecionar?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (excluir == DialogResult.Yes)
                    {
                        string ssql = "delete from tbpessoal where id =" + coluna;

                        SqlCommand Comando = new SqlCommand(ssql, conn);

                        Comando.ExecuteNonQuery();

                        Conexao.fecharConexao();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void dtgPessoal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string coluna = dtgPessoal.CurrentRow.Cells[0].Value.ToString();

                string nascimento;

                string salario;

                SqlConnection conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {

                    SqlCommand retornobanco = new SqlCommand(("select id,Data_Cadastro,Cpf,Nome,Rua,Numero,Bairro,Cidade,Cep,Uf,Referencia,email,Fone,Celular,Quem"
+ ",Nascimento,Sexo,Estado_Civil,Filhos,Estuda,Horario_Estudo,Escolaridade,Disponibilidade_Horario,Cart_Trabalho,Serie,RG,Titulo_Eleitor"
+ ",PIS,Habilitação,Categoria_Habilitacao,Naturalidade,Uf_Naturalidade,Possui_Moto,Possui_Carro,Possui_Moto_Carro,Nao_Possui,Fumante,Ocupacao"
+ ",Pretensao_Salarial,Obs,Cursos,Portador_Necessidade,Qual"
+ ",Idade,Regiao,Celular_01,Celular_02,Complemento from tbpessoal where id =" + coluna), conn);

                    SqlDataReader Comando = retornobanco.ExecuteReader();

                    while (Comando.Read())
                    {
                        txtCodigo.Text = Comando["id"].ToString();

                        mkData_Cadastro.Text = Convert.ToDateTime(Comando["Data_Cadastro"].ToString()).ToString("dd/MM/yyyy");

                        mkCpf.Text = Comando["Cpf"].ToString();

                        txtNome.Text = Comando["Nome"].ToString();

                        txtRua.Text = Comando["Rua"].ToString();

                        txtNumero.Text = Comando["Numero"].ToString();

                        txtBairro.Text = Comando["Bairro"].ToString();

                        txtCidade.Text = Comando["Cidade"].ToString();

                        mkCep.Text = Comando["Cep"].ToString();

                        cmUf.Text = Comando["Uf"].ToString();

                        cmbRegiao.Text = Comando["Regiao"].ToString();

                        txtReferencia.Text = Comando["Referencia"].ToString();

                        txtEmail.Text = Comando["email"].ToString();

                        mkFone.Text = Comando["Fone"].ToString();

                        mkCelular.Text = Comando["Celular"].ToString();

                        mkCelular01.Text = Comando["Celular_01"].ToString();

                        mkCelular02.Text = Comando["Celular_02"].ToString();

                        txtComplemento.Text = Comando["Complemento"].ToString();

                        txtQuem.Text = Comando["Quem"].ToString();

                        nascimento = Comando["Nascimento"].ToString();

                        if (nascimento != string.Empty)
                        {
                            mkNascimento.Text = Convert.ToDateTime(nascimento).ToString("dd/MM/yyyy");
                        }

                        cbSexo.Text = Comando["Sexo"].ToString();

                        cbEstado_Civil.Text = Comando["Estado_Civil"].ToString();

                        txtFilhos.Text = Comando["Filhos"].ToString();

                        rdEstuda_Sim.Checked = Convert.ToBoolean(Comando["Estuda"].ToString());

                        txtHorario.Text = Comando["Horario_Estudo"].ToString();

                        cbEscolaridade.Text = Comando["Escolaridade"].ToString();

                        cmbDisponibilidade_horario.Text = Comando["Disponibilidade_Horario"].ToString();

                        txtCarteira.Text = Comando["Cart_Trabalho"].ToString();

                        txtSerie.Text = Comando["Serie"].ToString();

                        txtRg.Text = Comando["RG"].ToString();

                        txtTitulo.Text = Comando["Titulo_Eleitor"].ToString();

                        txtPis.Text = Comando["PIS"].ToString();

                        chcHabilitação.Checked = Convert.ToBoolean(Comando["Habilitação"].ToString());

                        txtCategoria.Text = Comando["Categoria_Habilitacao"].ToString();

                        txtNatural.Text = Comando["Naturalidade"].ToString();

                        cbUf.Text = Comando["Uf_Naturalidade"].ToString();

                        rdMoto.Checked = Convert.ToBoolean(Comando["Possui_Moto"].ToString());

                        rdCarro.Checked = Convert.ToBoolean(Comando["Possui_Carro"].ToString());

                        rdMoto_Carro.Checked = Convert.ToBoolean(Comando["Possui_Moto_Carro"].ToString());

                        rdNao.Checked = Convert.ToBoolean(Comando["Nao_Possui"].ToString());

                        rdFumante_Nao.Checked = Convert.ToBoolean(Comando["Fumante"].ToString());

                        cbOcupacao.Text = Comando["Ocupacao"].ToString();

                        salario = Comando["Pretensao_Salarial"].ToString();

                        if (salario != string.Empty)
                        {
                            txtPretensao.Text = Convert.ToDouble(salario).ToString("C");
                        }

                        txtObs.Text = Comando["Obs"].ToString();

                        txtCursos.Text = Comando["Cursos"].ToString();

                        rdNao.Checked = Convert.ToBoolean(Comando["Portador_Necessidade"].ToString());

                        txtQual.Text = Comando["Qual"].ToString();

                        mkIdade.Text = Comando["Idade"].ToString();

                        // Validando Estuda

                        if (rdEstuda_Sim.Checked != true)
                        {
                            rdEstuda_Nao.Checked = true;
                        }
                        else
                        {
                            rdEstuda_Sim.Checked = true;
                        }
                        // Validando Fuma
                        if (rdFumante_Nao.Checked == false)
                        {
                            rdFumante_Nao.Checked = true;
                        }
                        else
                        {
                            rdFumante_Sim.Checked = true;
                        }
                        // Validando Necessidade Especial
                        if (rdNao.Checked != true)
                        {
                            rdNao.Checked = true;
                        }
                        else
                        {
                            rdSim.Checked = true;
                        }
                        // Limpado os campos Null

                        if (mkFone.Text == "NULL")
                        {
                            mkFone.Text = string.Empty;
                        }

                        if (mkCelular.Text == "NULL")
                        {
                            mkCelular.Text = string.Empty;
                        }
                        if (mkCelular01.Text == "NULL")
                        {
                            mkCelular01.Text = string.Empty;
                        }
                        if (mkCelular02.Text == "NULL")
                        {
                            mkCelular02.Text = string.Empty;
                        }

                        // Voltando Foco para TABCADASTRO

                        tabPessoal.SelectedTab = tabPage1;

                        mkCpf.Focus();

                        mkCep.Focus();

                        mkFone.Select();

                        mkCelular.Select();

                        mkCelular01.Select();

                        mkCelular02.Select();

                        mkCpf.Select();

                        txtNome.Focus();

                        txtNome.SelectAll();

                        // Desabilitar Botão Savlar e Habilitar Botão Atualizar

                        btnSalvar.Visible = false;

                        btnAlterar.Visible = true;

                        // Local onde botão Alterar vai aparecer

                        btnAlterar.Size = new Size(397, 38);

                        btnAlterar.Location = new Point(1, 591);
                    }
                    // Atualizando Data GRID Historico de Trabalho

                    SqlConnection n1_conn = Conexao.obterConexao();


                    if (n1_conn == null)
                    {
                        MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                    }
                    else
                    {
                        //Filtrar Dados pelo código

                        SqlCommand nova_script = new SqlCommand("select id, Empresa,Atividade,Admissao,Demissao,Salario_Inicial,Ultimo_Salario,Motivo_Saida from tbhistorico_trabalho where Id_Curriculo =" + coluna, n1_conn);

                        SqlDataReader script = nova_script.ExecuteReader();

                        while (script.Read())
                        {
                            dtgHistorico_Trabalho.Rows.Add(script["Empresa"].ToString(), script["Atividade"].ToString(), script["Admissao"].ToString(), script["Demissao"].ToString(), script["salario_inicial"].ToString(), script["Ultimo_Salario"].ToString(), script["Motivo_saida"].ToString(), script["Id"].ToString());
                        }

                        Conexao.fecharConexao();
                    }


                    Conexao.fecharConexao();
                }

                //mudando botão incluir para alterar habilitar botão alterar

                btnIncluir.Visible = false;

                bntalterar1.Visible = true;

                bntalterar1.Location = new Point(736, 145);
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void txtPretensao_Enter(object sender, EventArgs e)
        {
            if (txtPretensao.Text == "R$ 0,00" && txtPretensao.Text == string.Empty)
            {
                txtPretensao.Text = Convert.ToDouble(0.00).ToString("C");

                txtPretensao.SelectAll();
            }

            // Mudando cor ao receber foco
            txtPretensao.BackColor = System.Drawing.Color.Yellow;

            txtPretensao.Focus();

            txtPretensao.SelectAll();
        }

        private void txtPretensao_Leave(object sender, EventArgs e)
        {
            if (txtPretensao.Text == string.Empty || txtPretensao.Text == "R$ 0,00")
            {
                txtPretensao.Text = string.Empty;

                // Mudando cor ao perder foco
                txtPretensao.BackColor = System.Drawing.Color.White;
            }
            else
            {
                txtPretensao.Text = Convert.ToDouble(txtPretensao.Text).ToString("C");

                txtPretensao.BackColor = System.Drawing.Color.White;
            }
        }

        private void txtPretensao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')

                e.KeyChar = ',';
        }

        private void txtPretensao_MouseClick(object sender, MouseEventArgs e)
        {
            txtPretensao.SelectAll();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string cpf = string.Empty;
            string cep = string.Empty;
            string Fone = string.Empty;
            string Celular = string.Empty;
            string Celular01 = string.Empty;
            string Celular02 = string.Empty;
            string telefone_contato = string.Empty;
            double pretensao = 0;

            if (mkCpf.Text != string.Empty)
            {
                cpf = mkCpf.Text.Replace(".", "").Replace("-", "");
            }
            if (mkCep.Text != string.Empty)
            {
                cep = mkCep.Text.Replace(".", "").Replace("-", "");
            }
            if (mkFone.Text != string.Empty)
            {
                Fone = mkFone.Text.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "");
            }
            if (mkCelular.Text != string.Empty)
            {
                Celular = mkCelular.Text.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "");
            }
            if (mkCelular01.Text != string.Empty)
            {
                Celular01 = mkCelular01.Text.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "");
            }
            if (mkCelular02.Text != string.Empty)
            {
                Celular02 = mkCelular02.Text.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "");
            }
            if (txtRecado.Text != string.Empty)
            {
                telefone_contato = mkCelular.Text.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "");
            }
            if (txtPretensao.Text != string.Empty)
            {
                pretensao = Convert.ToDouble(txtPretensao.Text.Replace("R$", "".Replace(" ", "")));
            }
            try
            {
                if (cmbRegiao.Text != string.Empty && txtNome.Text != string.Empty && txtRua.Text != string.Empty && txtBairro.Text != string.Empty && txtCidade.Text != string.Empty && txtNumero.Text != string.Empty)
                {

                    SqlConnection conn = Conexao.obterConexao();

                    // a conexão foi efetuada com sucesso?
                    if (conn == null)
                    {
                        MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                    }
                    else
                    {
                        string ssql = "update tbpessoal set Cpf = @Cpf,Nome = @Nome,Rua = @Rua,Numero = @Numero,Complemento = @Complemento,Regiao = @Regiao,Bairro = @Bairro,Cidade = @Cidade,Cep = @Cep,Uf = @Uf"
    + ",Referencia = @Referencia,email = @email,Fone = @Fone,Celular = @Celular,Celular_01 = @Celular01,Celular_02 = @Celular02,Recado_Telefone = @Recado_Telefone"
    + ",Quem = @Quem,Sexo = @Sexo,Estado_Civil = @Estado_Civil,Filhos = @Filhos,Estuda = @Estuda,Horario_Estudo = @Horario_Estudo"
    + ",Escolaridade = @Escolaridade,Disponibilidade_Horario = @Disponibilidade_Horario,Cart_Trabalho = @Cart_Trabalho,Serie = @Serie,RG = @RG,Titulo_Eleitor = @Titulo_Eleitor,Pis = @Pis"
    + ",Habilitação = @Habilitação,Categoria_Habilitacao = @Categoria_Habilitacao,Naturalidade = @Naturalidade,Uf_Naturalidade = @Uf_Naturalidade,Possui_Moto = @Possui_Moto"
    + ",Possui_Carro = @Possui_Carro,Possui_Moto_Carro = @Possui_Moto_Carro,Nao_Possui = @Nao_Possui,Fumante = @Fumante,Ocupacao = @Ocupacao"
    + ",Obs = @Obs,Cursos = @Cursos,Portador_Necessidade = @Portador_Necessidade,Qual = @Qual,Idade = @Idade " + " where id  =" + txtCodigo.Text;

                        SqlCommand Comando = new SqlCommand(ssql, conn);

                        Comando.Parameters.AddWithValue("@Cpf", (cpf));
                        Comando.Parameters.AddWithValue("@Nome", (txtNome.Text));
                        Comando.Parameters.AddWithValue("@Rua", (txtRua.Text));
                        Comando.Parameters.AddWithValue("@Numero", (txtNumero.Text));
                        Comando.Parameters.AddWithValue("@Complemento", (txtComplemento.Text));
                        Comando.Parameters.AddWithValue("@Regiao", (cmbRegiao.Text));
                        Comando.Parameters.AddWithValue("@Bairro", (txtBairro.Text));
                        Comando.Parameters.AddWithValue("@Cidade", (txtCidade.Text));
                        Comando.Parameters.AddWithValue("@Cep", (cep));
                        Comando.Parameters.AddWithValue("@Uf", (cmUf.Text));
                        Comando.Parameters.AddWithValue("@Referencia", (txtReferencia.Text));
                        Comando.Parameters.AddWithValue("@email", (txtEmail.Text));
                        Comando.Parameters.AddWithValue("@Fone", (Fone));
                        Comando.Parameters.AddWithValue("@Celular", (Celular));
                        Comando.Parameters.AddWithValue("@Celular01", (Celular01));
                        Comando.Parameters.AddWithValue("@Celular02", (Celular02));
                        Comando.Parameters.AddWithValue("@Recado_Telefone", (telefone_contato));
                        Comando.Parameters.AddWithValue("@Quem", (txtQuem.Text));
                        Comando.Parameters.AddWithValue("@Sexo", (cbSexo.Text));
                        Comando.Parameters.AddWithValue("@Estado_Civil", (cbEstado_Civil.Text));
                        Comando.Parameters.AddWithValue("@Filhos", (txtFilhos.Text));
                        Comando.Parameters.AddWithValue("@Estuda", (rdEstuda_Nao.Checked ? +0 : 1));
                        Comando.Parameters.AddWithValue("@Horario_Estudo", (txtHorario.Text));
                        Comando.Parameters.AddWithValue("@Escolaridade", (cbEscolaridade.Text));
                        Comando.Parameters.AddWithValue("@Disponibilidade_Horario", (cmbDisponibilidade_horario.Text));
                        Comando.Parameters.AddWithValue("@Cart_Trabalho", (txtCarteira.Text));
                        Comando.Parameters.AddWithValue("@Serie", (txtSerie.Text));
                        Comando.Parameters.AddWithValue("@RG", (txtRg.Text));
                        Comando.Parameters.AddWithValue("@Titulo_Eleitor", (txtTitulo.Text));
                        Comando.Parameters.AddWithValue("@Pis", (txtPis.Text));
                        Comando.Parameters.AddWithValue("@Habilitação", (chcHabilitação.Checked ? +1 : 0));
                        Comando.Parameters.AddWithValue("@Categoria_Habilitacao", (txtCategoria.Text));
                        Comando.Parameters.AddWithValue("@Naturalidade", (txtNatural.Text));
                        Comando.Parameters.AddWithValue("@Uf_Naturalidade", (cbUf.Text));
                        Comando.Parameters.AddWithValue("@Possui_Moto", (rdMoto.Checked ? +1 : 0));
                        Comando.Parameters.AddWithValue("@Possui_Carro", (rdCarro.Checked ? +1 : 0));
                        Comando.Parameters.AddWithValue("@Possui_Moto_Carro", (rdMoto_Carro.Checked ? +1 : 0));
                        Comando.Parameters.AddWithValue("@Nao_Possui", (rdNenhum.Checked ? +1 : 0));
                        Comando.Parameters.AddWithValue("@Fumante", (rdFumante_Nao.Checked ? +0 : 1));
                        Comando.Parameters.AddWithValue("@Ocupacao", (cbOcupacao.Text));
                        Comando.Parameters.AddWithValue("@Obs", (txtObs.Text));
                        Comando.Parameters.AddWithValue("@Cursos", (txtCursos.Text));
                        Comando.Parameters.AddWithValue("@Portador_Necessidade", (rdNao.Checked ? +0 : 1));
                        Comando.Parameters.AddWithValue("@Qual", (txtQual.Text));
                        Comando.Parameters.AddWithValue("@Idade", (mkIdade.Text));


                        Comando.ExecuteNonQuery();

                        // Validando Necessidade Especial
                        if (rdNao.Checked != true)
                        {
                            rdSim.Checked = true;
                        }
                        else
                        {
                            rdNao.Checked = true;
                        }
                        // Validando Fuma
                        if (rdFumante_Nao.Checked != true)
                        {
                            rdFumante_Sim.Checked = true;
                        }
                        // Validando Estuda
                        if (rdEstuda_Nao.Checked != true)
                        {
                            rdEstuda_Sim.Checked = true;
                        }
                        else
                        {
                            rdEstuda_Nao.Checked = true;
                        }
                        if (mkNascimento.Text != string.Empty)
                        {
                            SqlConnection conn1 = Conexao.obterConexao();

                            // a conexão foi efetuada com sucesso?
                            if (conn1 == null)
                            {
                                MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                            }
                            else
                            {

                                string ssql1 = "update tbpessoal set nascimento = @Nascimento where id =" + txtCodigo.Text;

                                SqlCommand comando = new SqlCommand(ssql1, conn1);
                                comando.Parameters.AddWithValue("@Nascimento", Convert.ToDateTime(mkNascimento.Text).ToString("yyyy-MM-dd"));


                                comando.ExecuteNonQuery();
                            }

                            Conexao.fecharConexao();

                        }
                        if (txtPretensao.Text != string.Empty)
                        {
                            SqlConnection Nova_conn = Conexao.obterConexao();

                            // a conexão foi efetuada com sucesso?
                            if (Nova_conn == null)
                            {
                                MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                            }
                            else
                            {

                                string Nova_ssql = "update tbpessoal set Pretensao_Salarial = @Pretensao where id  =" + txtCodigo.Text;

                                SqlCommand Novo_Comando = new SqlCommand(Nova_ssql, Nova_conn);
                                Novo_Comando.Parameters.AddWithValue("@Pretensao", pretensao);

                                Novo_Comando.ExecuteNonQuery();
                            }

                            Conexao.fecharConexao();
                        }
                        
                        Conexao.fecharConexao();

                        MessageBox.Show("Alteração Efetuada com sucesso", "Atualização", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        Conexao.fecharConexao();

                        Limpar_Dados.LimpaControles(this);

                        //Limpar datagrid

                        if (dtgHistorico_Trabalho.DataSource != null)
                        {

                            dtgHistorico_Trabalho.DataSource = null;
                        }
                        else
                        {
                            dtgHistorico_Trabalho.Rows.Clear();
                        }

                        // Desabilitar Botão Atualizar e Atualizar Historico de trabalho e Habilitar Botão Savlar

                        bntalterar1.Visible = false;

                        btnIncluir.Visible = true;

                        btnSalvar.Visible = true;

                        btnAlterar.Visible = false;

                        // Voltando Foco para TABCADASTRO

                        tabPessoal.SelectedTab = tabPage1;

                        mkCpf.Focus();

                        mkCep.Focus();

                        mkCpf.Select();

                        // Chamando Evendo do LOAD

                        Pessoal_Load(this, new EventArgs());

                    }

                }
                else
                {
                    MessageBox.Show("Os campos destacados em vermelho são de preenchimento obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    // Voltando Foco para TABCADASTRO

                    tabPessoal.SelectedTab = tabPage1;


                    if (txtNome.Text == string.Empty)
                    {
                        txtNome.Focus();
                    }
                    else if (txtRua.Text == string.Empty)
                    {
                        txtRua.Focus();
                    }
                    else if (txtBairro.Text == string.Empty)
                    {
                        txtBairro.Focus();
                    }
                    else if (txtCidade.Text == string.Empty)
                    {
                        txtCidade.Focus();
                    }
                    else if (txtNumero.Text == string.Empty)
                    {
                        txtNumero.Focus();
                    }
                    else if (cmbRegiao.Text == string.Empty)
                    {
                        cmbRegiao.Focus();
                    }

                    Conexao.fecharConexao();
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void Pessoal_KeyUp(object sender, KeyEventArgs e)
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

        private void tabPessoal_KeyUp(object sender, KeyEventArgs e)
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

        private void Pessoal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtSalario_Inicial_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtSalario_Inicial.BackColor = System.Drawing.Color.Yellow;

            if (txtSalario_Inicial.Text == "R$ 0,00" && txtSalario_Inicial.Text == string.Empty)
            {
                txtSalario_Inicial.Text = Convert.ToDouble(0.00).ToString("C");

                txtSalario_Inicial.SelectAll();
            }

            txtSalario_Inicial.Focus();

            txtSalario_Inicial.SelectAll();
        }

        private void txtultimo_Salario_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtultimo_Salario.BackColor = System.Drawing.Color.Yellow;

            if (txtultimo_Salario.Text == "R$ 0,00" && txtultimo_Salario.Text == string.Empty)
            {
                txtultimo_Salario.Text = Convert.ToDouble(0.00).ToString("C");

                txtultimo_Salario.SelectAll();
            }

            txtultimo_Salario.Focus();

            txtultimo_Salario.SelectAll();
        }

        private void txtSalario_Inicial_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtultimo_Salario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')

                e.KeyChar = ',';
        }

        private void txtSalario_Inicial_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtSalario_Inicial.BackColor = System.Drawing.Color.White;

            if (txtSalario_Inicial.Text == string.Empty || txtSalario_Inicial.Text == "R$ 0,00")
            {
                txtSalario_Inicial.Text = string.Empty;
            }
            else
            {
                txtSalario_Inicial.Text = Convert.ToDouble(txtSalario_Inicial.Text).ToString("C");
            }
        }

        private void txtultimo_Salario_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtultimo_Salario.BackColor = System.Drawing.Color.White;

            if (txtultimo_Salario.Text == string.Empty || txtultimo_Salario.Text == "R$ 0,00")
            {
                txtultimo_Salario.Text = string.Empty;
            }
            else
            {
                txtultimo_Salario.Text = Convert.ToDouble(txtultimo_Salario.Text).ToString("C");
            }
        }

        private void txtSalario_Inicial_MouseClick(object sender, MouseEventArgs e)
        {
            txtSalario_Inicial.SelectAll();
        }

        private void txtultimo_Salario_MouseClick(object sender, MouseEventArgs e)
        {
            txtultimo_Salario.SelectAll();
        }

        private void Pessoal_FormClosing(object sender, FormClosingEventArgs e)
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

        private void tabPage3_Enter(object sender, EventArgs e)
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

                    string cpf = string.Empty;

                    if (mkCpf.Text != string.Empty)
                    {
                        cpf = mkCpf.Text.Replace(".", "").Replace("-", "");
                    }

                    if (cpf != string.Empty)
                    {
                        string strSql = "select Cpf, CONVERT(VARCHAR(10), Data, 103) AS Data, Empresa, Vaga, id from tbvaga_indicada where cpf ='" + cpf + "'";

                        SqlDataAdapter da = new SqlDataAdapter(strSql, Nova_conn);

                        //cria um objeto datatable
                        DataTable Vaga_Indicada = new DataTable();

                        //preenche o datatable via dataadapter
                        da.Fill(Vaga_Indicada);

                        //atribui o datatable ao datagridview para exibir o resultado
                        dtgHistorico_Vaga.DataSource = Vaga_Indicada;

                        dtgHistorico_Vaga.Refresh();

                        // Redimensionar as colunas mestre DataGridView para ajustar os dados recém-carregados.
                        //dtgFiltro_Vaga.AutoResizeColumns();

                        // Ajustar Coluna manualmente

                        DataGridViewColumn coluna0 = dtgHistorico_Vaga.Columns[0];
                        coluna0.Width = 90;

                        DataGridViewColumn coluna1 = dtgHistorico_Vaga.Columns[1];
                        coluna1.Width = 75;

                        DataGridViewColumn coluna2 = dtgHistorico_Vaga.Columns[2];
                        coluna2.Width = 310;

                        DataGridViewColumn coluna3 = dtgHistorico_Vaga.Columns[3];
                        coluna3.Width = 150;

                        DataGridViewColumn coluna4 = dtgHistorico_Vaga.Columns[4];
                        coluna3.Width = 150;
                        coluna4.Visible = false;

                    }

                    Conexao.fecharConexao();
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }

            Conexao.fecharConexao();
        }

        private void dtgHistorico_Vaga_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                string coluna = dtgHistorico_Vaga.CurrentRow.Cells[4].Value.ToString();

                SqlConnection conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {
                    DialogResult excluir = MessageBox.Show("Deseja Excluir o registro selecionar?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (excluir == DialogResult.Yes)
                    {
                        string ssql = "delete from TBVaga_Indicada where id =" + coluna;

                        SqlCommand Comando = new SqlCommand(ssql, conn);

                        Comando.ExecuteNonQuery();

                        Conexao.fecharConexao();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void mkNascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Aceita somente numero e backuspace

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 27 && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

                MessageBox.Show("Campo só aceita numero(s).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtFilhos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Aceita somente numero e backuspace

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 27 && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

                MessageBox.Show("Campo só aceita numero(s).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void tabPessoal_Selected(object sender, TabControlEventArgs e)
        {
            // Identificando Guia Selecionada

            if (tabPessoal.SelectedTab == tabListagem && txtNome.Text == string.Empty)
            {
                btnSalvar.Visible = false;

                btnCancelar.Visible = false;

                btnAlterar.Visible = false;

                tabPessoal.Size = new Size(810, 580);

                dtgPessoal.Size = new Size(800, 505);

                tabPessoal.Refresh();

                txtBusca.Focus();

                txtBusca.SelectAll();
            }
            else if (tabPessoal.SelectedTab == tabPage1)
            {
                btnSalvar.Visible = true;

                btnCancelar.Visible = true;

                tabPessoal.Size = new Size(810, 538);

                dtgPessoal.Size = new Size(800, 459);

                txtNome.Focus();

                txtNome.Select();
            }
            else if (tabPessoal.SelectedTab == tabPage2)
            {
                btnSalvar.Visible = true;

                btnCancelar.Visible = true;

                tabPessoal.Size = new Size(810, 538);

                dtgPessoal.Size = new Size(800, 459);

                txtCursos.Focus();

                txtCursos.Select();
            }
            else if (tabPessoal.SelectedTab == tabPage3)
            {
                btnSalvar.Visible = true;

                btnCancelar.Visible = true;

                tabPessoal.Size = new Size(810, 538);

                dtgPessoal.Size = new Size(800, 459);
            }

            else
            {
                tabPessoal.SelectedTab = tabPage1;

                MessageBox.Show("Favor limpar os campos ou clicar no botão CANCELAR\npara selecionar guia Listagem.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            try
            {

                //pegando coluna selecionada

                string colunapressionada = lblPesquisa.Text;

                //Efetuando pesquisa das informações dentro do banco e atualizando datagrid

                SqlConnection conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {
                    if (colunapressionada == "Cod")
                    {
                        if (txtBusca.Text != string.Empty)
                        {

                            //Filtrar Dados pelo código

                            SqlCommand script = new SqlCommand("select id AS Cod, Cpf, Nome, Celular, Ocupacao from tbpessoal where id like '" + txtBusca.Text + "%'", conn);

                            //Atualizando DataGrid

                            DataSet dts = new DataSet();

                            SqlDataAdapter da = new SqlDataAdapter(script);

                            da.Fill(dts, "tbpessoal");

                            dtgPessoal.DataSource = dts.Tables["tbpessoal"];

                            conn.Close();

                            Conexao.fecharConexao();
                        }
                        else
                        {
                            // Ao limpar txtBusca atualizar o DataGrid

                            //Filtrar Dados pelo código

                            SqlCommand script = new SqlCommand("select id AS Cod, Cpf, Nome, Celular, Ocupacao from tbpessoal", conn);

                            //Atualizando DataGrid

                            DataSet dts = new DataSet();

                            SqlDataAdapter da = new SqlDataAdapter(script);

                            da.Fill(dts, "tbpessoal");

                            dtgPessoal.DataSource = dts.Tables["tbpessoal"];

                        }
                    }
                    if (colunapressionada == "CPF")
                    {

                        //Filtrar Dados pelo CPF

                        SqlCommand script = new SqlCommand("select id AS Cod, Cpf, Nome, Celular, Ocupacao from tbpessoal where Cpf like '%" + txtBusca.Text + "%'", conn);

                        //Atualizando DataGrid

                        DataTable dt = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(script);

                        da.Fill(dt);

                        DataView dv = new DataView(dt);

                        dv.RowFilter = "Cpf like'" + txtBusca.Text + "%'";

                        dtgPessoal.DataSource = dv;

                        conn.Close();

                        Conexao.fecharConexao();
                    }

                    if (colunapressionada == "Nome")
                    {

                        //Filtrar Dados pela Descricao

                        SqlCommand script = new SqlCommand("select id AS Cod, Cpf, Nome, Celular, Ocupacao from tbpessoal where Nome like '%" + txtBusca.Text + "%'", conn);

                        //Atualizando DataGrid

                        DataTable dt = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(script);

                        da.Fill(dt);

                        DataView dv = new DataView(dt);

                        dv.RowFilter = "Nome like'" + txtBusca.Text + "%'";

                        dtgPessoal.DataSource = dv;

                        conn.Close();

                        Conexao.fecharConexao();
                    }

                    else if (colunapressionada == "Celular")
                    {
                        //Filtrar Dados pelo endereço

                        SqlCommand script = new SqlCommand("select id AS Cod, Cpf, Nome, Celular, Ocupacao from tbpessoal where Celular like '%" + txtBusca.Text + "%'", conn);

                        //Atualizando DataGrid

                        DataTable dt = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(script);

                        da.Fill(dt);

                        DataView dv = new DataView(dt);

                        dv.RowFilter = "Celular like'" + txtBusca.Text + "%'";

                        dtgPessoal.DataSource = dv;

                        conn.Close();

                        Conexao.fecharConexao();
                    }

                    else if (colunapressionada == "Ocupação")
                    {
                        //Filtrando dados pelo bairro

                        SqlCommand script = new SqlCommand("select id As Cod, Cpf, Nome, Celular, Ocupacao from tbpessoal where Ocupacao like '%" + txtBusca.Text + "%'", conn);

                        //Atualizando DataGrid

                        DataTable dt = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(script);

                        da.Fill(dt);

                        DataView dv = new DataView(dt);

                        dv.RowFilter = "Ocupacao like'" + txtBusca.Text + "%'";

                        dtgPessoal.DataSource = dv;

                        conn.Close();

                        Conexao.fecharConexao();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void mkCelular01_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            mkCelular01.BackColor = System.Drawing.Color.Yellow;

            mkCelular01.Mask = "(99)90000-0000";

            mkCelular01.Select(0, 0);

            mkCelular01.Focus();

            mkCelular01.SelectAll();
        }

        private void mkCelular01_Leave(object sender, EventArgs e)
        {
            if (mkCelular01.Text == "(  )     -")

                mkCelular01.Mask = "";

            if (mkCelular01.Text == "NULL")
            {
                mkCelular01.Text = string.Empty;

                mkCelular01.Mask = "";
            }
            if (mkCelular01.Text.Replace("_", "").Length != 14 && mkCelular01.Text != string.Empty)
            {
                MessageBox.Show("Valor informado inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                mkCelular01.Focus();

                mkCelular01.SelectAll();
            }

            // Mudando cor ao perder foco
            mkCelular01.BackColor = System.Drawing.Color.White;

        }

        private void mkCelular02_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            mkCelular02.BackColor = System.Drawing.Color.Yellow;

            mkCelular02.Mask = "(99)90000-0000";

            mkCelular02.Select(0, 0);

            mkCelular02.Focus();

            mkCelular02.SelectAll();
        }

        private void mkCelular02_Leave(object sender, EventArgs e)
        {
            if (mkCelular02.Text == "(  )     -")

                mkCelular02.Mask = "";

            if (mkCelular02.Text == "NULL")
            {
                mkCelular02.Text = string.Empty;

                mkCelular02.Mask = "";
            }
            if (mkCelular02.Text.Replace("_", "").Length != 14 && mkCelular02.Text != string.Empty)
            {
                MessageBox.Show("Valor informado inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                mkCelular02.Focus();

                mkCelular02.SelectAll();
            }

            // Mudando cor ao perder foco
            mkCelular02.BackColor = System.Drawing.Color.White;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtEmpresa.Text == string.Empty)
            {
                MessageBox.Show("Favor inserir histórico de trabalho.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtEmpresa.Focus();

                txtEmpresa.SelectAll();
            }
            else
            {
                dtgHistorico_Trabalho.Rows.Add(txtEmpresa.Text, txtAtividade.Text, mkAdmissao.Text, mkDemissao.Text, txtSalario_Inicial.Text, txtultimo_Salario.Text, txtMotivo.Text);
            }
            //Limpar os campos
            txtEmpresa.Text = string.Empty;
            txtAtividade.Text = string.Empty;
            mkAdmissao.Text = string.Empty;
            mkDemissao.Text = string.Empty;
            txtSalario_Inicial.Text = string.Empty;
            txtultimo_Salario.Text = string.Empty;
            txtMotivo.Text = string.Empty;
            mkAdmissao.Focus();
            mkDemissao.Focus();
            txtEmpresa.Focus();
            txtEmpresa.SelectAll();
        }
        private void txtNome_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtNome.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtNome.BackColor = System.Drawing.Color.White;
        }
        private void txtRua_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtRua.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtRua_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtRua.BackColor = System.Drawing.Color.White;
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

        private void txtComplemento_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtComplemento.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtComplemento_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtComplemento.BackColor = System.Drawing.Color.White;
        }

        private void cmbRegiao_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            cmbRegiao.BackColor = System.Drawing.Color.Yellow;

            //habilitar a abertura automatica da combo.
            cmbRegiao.DroppedDown = true;
        }

        private void cmbRegiao_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            cmbRegiao.BackColor = System.Drawing.Color.White;
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

        private void cmUf_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            cmUf.BackColor = System.Drawing.Color.Yellow;

            //habilitar a abertura automatica da combo.
            cmUf.DroppedDown = true;
        }

        private void txtReferencia_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtReferencia.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtReferencia_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtReferencia.BackColor = System.Drawing.Color.White;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtEmail.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtEmail.BackColor = System.Drawing.Color.White;
        }

        private void txtRecado_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtRecado.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtRecado_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtRecado.BackColor = System.Drawing.Color.White;
        }

        private void cmbRegiao_Click(object sender, EventArgs e)
        {
            //habilitar a abertura automatica da combo.
            cmbRegiao.DroppedDown = true;
        }

        private void dtgHistorico_Trabalho_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {

                //Pegando Linha selecionada Datagrid

                linha_selecionada = Convert.ToString(dtgHistorico_Trabalho.CurrentRow.Index);

                if (dtgHistorico_Trabalho.CurrentRow == null)
                {

                }
                else
                {
                    string coluna = dtgHistorico_Trabalho.CurrentRow.Cells[0].Value.ToString();

                    string coluna1 = dtgHistorico_Trabalho.CurrentRow.Cells[1].Value.ToString();

                    string coluna2 = dtgHistorico_Trabalho.CurrentRow.Cells[2].Value.ToString();

                    string coluna3 = dtgHistorico_Trabalho.CurrentRow.Cells[3].Value.ToString();

                    string coluna6 = dtgHistorico_Trabalho.CurrentRow.Cells[6].Value.ToString();

                    SqlConnection conn = Conexao.obterConexao();

                    // a conexão foi efetuada com sucesso?
                    if (conn == null)
                    {
                        MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                    }
                    else
                    {

                        SqlCommand retornobanco = new SqlCommand("select Empresa,Atividade,Admissao,Demissao,Salario_Inicial,Ultimo_Salario,Motivo_Saida from tbhistorico_trabalho where empresa = '" + coluna + "'" + " and atividade = '" + coluna1 + "'" + "and Admissao = '" + coluna2 + "'" + " and Demissao = '" + coluna3 + "'" + " and Motivo_saida = '" + coluna6 + "'", conn);                      

                        SqlDataReader Comando = retornobanco.ExecuteReader();

                        while (Comando.Read())
                        {
                            txtEmpresa.Text = Comando["Empresa"].ToString();

                            txtAtividade.Text = Comando["Atividade"].ToString();

                            mkAdmissao.Text = Comando["Admissao"].ToString();

                            mkDemissao.Text = Comando["Demissao"].ToString();

                            txtSalario_Inicial.Text = Comando["Salario_Inicial"].ToString();

                            txtultimo_Salario.Text = Comando["Ultimo_Salario"].ToString();

                            txtMotivo.Text = Comando["Motivo_Saida"].ToString();

                            //Passando foco para empresa

                            txtEmpresa.Focus();

                            txtEmpresa.SelectAll();
                        }

                        Conexao.fecharConexao();

                    }
                }
                dtgHistorico_Trabalho.Refresh();
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void bntalterar_Click(object sender, EventArgs e)
        {
            try
            {

                string s = linha_selecionada;

                int i;

                //Passando foco para empresa 

                txtEmpresa.Focus();

                txtEmpresa.SelectAll();

                //percorro o DataGridView
                for (i = 0; i < dtgHistorico_Trabalho.Rows.Count; i++)
                {
                    if (dtgHistorico_Trabalho.Rows[i].Cells[0].Value.ToString() == txtEmpresa.Text && dtgHistorico_Trabalho.Rows[i].Cells[1].Value.ToString() == txtAtividade.Text && dtgHistorico_Trabalho.Rows[i].Cells[2].Value.ToString() == mkAdmissao.Text && dtgHistorico_Trabalho.Rows[i].Cells[3].Value.ToString() == mkDemissao.Text && dtgHistorico_Trabalho.Rows[i].Cells[6].Value.ToString() == txtMotivo.Text)
                    {
                        DialogResult cancelar_datagrid = MessageBox.Show("Registro Duplicado.\nFavor verificar?", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                        if (cancelar_datagrid.ToString().ToUpper() == "OK")
                        {
                            //voltando foco para campo empresa

                            duplicitada = "OK";

                            txtEmpresa.Focus();

                            txtEmpresa.SelectAll();
                            break;
                        }
                    }

                    duplicitada = string.Empty;
                }
                if (duplicitada != "OK")
                {
                    if (txtEmpresa.Text == string.Empty)
                    {
                        MessageBox.Show("Registro Duplicado. Favor verificar");
                        {
                            txtEmpresa.Focus();
                            txtEmpresa.SelectAll();
                        }
                    }
                    else
                    {

                        // Inserindo valor no DATAGRID Historico de Trabalho

                        dtgHistorico_Trabalho.Rows.Add(txtEmpresa.Text, txtAtividade.Text, mkAdmissao.Text, mkDemissao.Text, txtSalario_Inicial.Text, txtultimo_Salario.Text, txtMotivo.Text);

                        //Limpar os campos
                        txtEmpresa.Text = string.Empty;
                        txtAtividade.Text = string.Empty;
                        mkAdmissao.Text = string.Empty;
                        mkDemissao.Text = string.Empty;
                        txtSalario_Inicial.Text = string.Empty;
                        txtultimo_Salario.Text = string.Empty;
                        txtMotivo.Text = string.Empty;
                        mkAdmissao.Focus();
                        mkDemissao.Focus();
                        txtEmpresa.Focus();
                        txtEmpresa.SelectAll();

                        // Atualizar Banco

                        SqlConnection N_Conn = Conexao.obterConexao();

                        // a conexão foi efetuada com sucesso?
                        if (N_Conn == null)
                        {
                            MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                        }
                        else
                        {
                            string N_ssql = "insert into tbhistorico_trabalho (Id_Curriculo,Empresa,Atividade,Salario_Inicial,Ultimo_Salario,Motivo_Saida, Admissao, Demissao)" +
                            "VALUES (@Id_Curriculo, @Empresa, @Atividade, @Salario_Inicial, @Ultimo_Salario, @Motivo_Saida, @admissao, @Demissao)";

                            SqlCommand N_Comando = new SqlCommand(N_ssql, N_Conn);

                            //limpo os parâmetros
                            N_Comando.Parameters.Clear();
                            //crio os parâmetro do comando
                            //e passo as linhas do dgvClientes para eles
                            //onde a célula indica a coluna do dgv

                            N_Comando.Parameters.AddWithValue("@Id_Curriculo", txtCodigo.Text);
                            N_Comando.Parameters.AddWithValue("@Empresa", dtgHistorico_Trabalho.Rows[i].Cells[0].Value);
                            N_Comando.Parameters.AddWithValue("@Atividade", dtgHistorico_Trabalho.Rows[i].Cells[1].Value);
                            N_Comando.Parameters.AddWithValue("@Admissao", dtgHistorico_Trabalho.Rows[i].Cells[2].Value);
                            N_Comando.Parameters.AddWithValue("@Demissao", dtgHistorico_Trabalho.Rows[i].Cells[3].Value);
                            N_Comando.Parameters.AddWithValue("@Salario_Inicial", Convert.ToString(dtgHistorico_Trabalho.Rows[i].Cells[4].Value).Replace("R$ ", ""));
                            N_Comando.Parameters.AddWithValue("@Ultimo_Salario", Convert.ToString(dtgHistorico_Trabalho.Rows[i].Cells[5].Value).Replace("R$ ", ""));
                            N_Comando.Parameters.AddWithValue("@Motivo_Saida", dtgHistorico_Trabalho.Rows[i].Cells[6].Value);

                            //executo o comando
                            N_Comando.ExecuteNonQuery();

                            // Remover linha selecionada

                            if (s != string.Empty)
                            {

                                int linha = Convert.ToInt32(s);

                                dtgHistorico_Trabalho.Rows.RemoveAt(linha);

                                string coluna = dtgHistorico_Trabalho.CurrentRow.Cells[0].Value.ToString();

                                string coluna1 = dtgHistorico_Trabalho.CurrentRow.Cells[1].Value.ToString();

                                string coluna2 = dtgHistorico_Trabalho.CurrentRow.Cells[2].Value.ToString();

                                string coluna3 = dtgHistorico_Trabalho.CurrentRow.Cells[3].Value.ToString();

                                string coluna6 = dtgHistorico_Trabalho.CurrentRow.Cells[6].Value.ToString();

                                SqlConnection conn1 = Conexao.obterConexao();

                                // a conexão foi efetuada com sucesso?
                                if (conn1 == null)
                                {
                                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                                }
                                else
                                {
                                    string delete = "delete from tbhistorico_trabalho where empresa = '" + coluna + "'" + " and atividade = '" + coluna1 + "'" + "and Admissao = '"  + coluna2 + "'" + " and Demissao = '" + coluna3 + "'" + " and Motivo_saida = '"+ coluna6 + "'" + "and Id_Curriculo = " + txtCodigo.Text;

                                    SqlCommand del = new SqlCommand(delete, conn1);

                                    del.ExecuteNonQuery();

                                    Conexao.fecharConexao();

                                    //Limpar memoria da linha selecionda
                                    linha_selecionada = string.Empty;
                                }
                                Conexao.fecharConexao();
                            }
                        }
                    }

                    Conexao.fecharConexao();

                    dtgHistorico_Trabalho.Refresh();
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void txtQuem_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtQuem.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtQuem_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtQuem.BackColor = System.Drawing.Color.White;
        }

        private void mkIdade_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            mkIdade.BackColor = System.Drawing.Color.Yellow;
        }

        private void mkIdade_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            mkIdade.BackColor = System.Drawing.Color.White;
        }

        private void cbSexo_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            cbSexo.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtFilhos_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtFilhos.BackColor = System.Drawing.Color.Yellow;
            
        }

        private void txtFilhos_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtFilhos.BackColor = System.Drawing.Color.White;
        }

        private void txtHorario_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtHorario.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtHorario_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtHorario.BackColor = System.Drawing.Color.White;
        }

        private void txtRg_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtRg.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtRg_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtRg.BackColor = System.Drawing.Color.White;
        }

        private void txtCarteira_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtCarteira.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtCarteira_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtCarteira.BackColor = System.Drawing.Color.White;
        }

        private void txtSerie_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtSerie.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtSerie_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtSerie.BackColor = System.Drawing.Color.White;
        }

        private void txtTitulo_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtTitulo.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtTitulo_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtTitulo.BackColor = System.Drawing.Color.White;
        }

        private void txtPis_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtPis.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtPis_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtPis.BackColor = System.Drawing.Color.White;
        }

        private void txtNatural_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtNatural.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtNatural_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtNatural.BackColor = System.Drawing.Color.White;
        }

        private void txtObs_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtObs.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtObs_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtObs.BackColor = System.Drawing.Color.White;
        }

        private void txtCategoria_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtCategoria.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtCategoria_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtCategoria.BackColor = System.Drawing.Color.White;
        }

        private void cbOcupacao_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            cbOcupacao.BackColor = System.Drawing.Color.Yellow;
        }

        private void cbOcupacao_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            cbOcupacao.BackColor = System.Drawing.Color.White;
        }

        private void txtCursos_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtCursos.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtCursos_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtCursos.BackColor = System.Drawing.Color.White;
        }

        private void txtQual_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtQual.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtQual_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtQual.BackColor = System.Drawing.Color.White;
        }

        private void txtEmpresa_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtEmpresa.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtEmpresa_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtEmpresa.BackColor = System.Drawing.Color.White;
        }

        private void txtAtividade_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtAtividade.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtAtividade_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtAtividade.BackColor = System.Drawing.Color.White;
        }

        private void txtMotivo_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtMotivo.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtMotivo_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtMotivo.BackColor = System.Drawing.Color.White;
        }

        private void dtgHistorico_Trabalho_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
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
                    string coluna = dtgHistorico_Trabalho.CurrentRow.Cells[7].Value.ToString();

                    DialogResult excluir = MessageBox.Show("Deseja Excluir o registro selecionar?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (excluir == DialogResult.Yes)
                    {
                        string ssql = "delete from TBHistorico_Trabalho where id =" + coluna;

                        SqlCommand Comando = new SqlCommand(ssql, conn);

                        Comando.ExecuteNonQuery();

                        Conexao.fecharConexao();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }

        }

        private void btnCadastro_Empresa_Click(object sender, EventArgs e)
        {
            Bairro_Regiao Bairro_Regiao = new Bairro_Regiao();

            Bairro_Regiao.ShowDialog();

        }
    }
}