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
    public partial class Empresa_Solicitante : Form
    {
        public Empresa_Solicitante()
        {
            InitializeComponent();
        }

        private void Empresa_Solicitante_Load(object sender, EventArgs e)
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

                    string strSql = "select Id As Cod, Empresa, Cargo from tbvaga";

                    SqlDataAdapter da = new SqlDataAdapter(strSql, Nova_conn);

                    //cria um objeto datatable
                    DataTable Vaga = new DataTable();

                    //preenche o datatable via dataadapter
                    da.Fill(Vaga);

                    //atribui o datatable ao datagridview para exibir o resultado
                    dtgVaga.DataSource = Vaga;

                    dtgVaga.Refresh();

                    // Redimensionar as colunas mestre DataGridView para ajustar os dados recém-carregados.
                    //dtgFiltro_Vaga.AutoResizeColumns();

                    // Ajustar Coluna manualmente

                    DataGridViewColumn coluna0 = dtgVaga.Columns[0];
                    coluna0.Width = 80;

                    DataGridViewColumn coluna1 = dtgVaga.Columns[1];
                    coluna1.Width = 450;

                    DataGridViewColumn coluna2 = dtgVaga.Columns[2];
                    coluna2.Width = 155;

                    Conexao.fecharConexao();

                }

                toolTip1.SetToolTip(this.btnCadastro_Empresa, "Cadastro de Empresa.\r Atalho (F2)");

                // Validando Proximo Código

                SqlConnection conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {
                    SqlCommand retornobanco = new SqlCommand(("SELECT IDENT_CURRENT('TBvaga') + 1 AS id"), conn);

                    SqlDataReader leitor = retornobanco.ExecuteReader();

                    while (leitor.Read())
                    {
                        txtId.Text = leitor["id"].ToString();

                        //Passando Foco para campo Empresa ao Carregar Tela

                        txtCodigo.Focus();

                        txtCodigo.Select();
                    }

                    // Limpando Combox Empresa

                    cbEmpresa.Text = "";

                    //Fechar conexao 

                    Conexao.fecharConexao();
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void btnCadastro_Empresa_Click(object sender, EventArgs e)
        {
            Cadastro_de_Empresa Cadastro_de_Empresa = new Cadastro_de_Empresa();

            Cadastro_de_Empresa.ShowDialog();
        }

        private void tbVaga_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Identificando Guia Selecionada

            if (tbVaga.SelectedTab == tbpListagem)
            {
                btnSalvar.Visible = false;

                btnAlterar.Visible = false;

                btnCancelar.Visible = false;

                tbVaga.Size = new Size(744, 480);

                dtgVaga.Size = new Size(730, 414);

                dtgVaga.Refresh();
            }
            else
            {
                btnSalvar.Visible = true;

                btnCancelar.Visible = true;

                tbVaga.Size = new Size(744, 441);

                dtgVaga.Size = new Size(730, 371);
            }
        }

        private void Empresa_Solicitante_KeyDown(object sender, KeyEventArgs e)
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

        private void txtEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCodigo.Select(0, 0);
            }
        }

        private void txtEmpresa_Leave(object sender, EventArgs e)
        {
            // Mudando cor ao perder foco
            txtCodigo.BackColor = System.Drawing.Color.White;
            
            try
            {
                if (txtCodigo.Text == string.Empty || txtCodigo.Text == "\r\n\r\n" || txtCodigo.Text == "\r\n")
                {
                    txtCodigo.Text = "";

                    cbEmpresa.Text = "";
                }
                else
                {
                    // Guardar Valor da Empresa e retirar função do ENTER 

                    string id = Convert.ToUInt64(txtCodigo.Text.Replace("\r\n", "")).ToString();

                    if (id != string.Empty)
                    {
                        SqlConnection conn = Conexao.obterConexao();

                        // a conexão foi efetuada com sucesso?
                        if (conn == null)
                        {
                            MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                        }

                        else
                        {

                            SqlCommand retornobanco = new SqlCommand(("select nome from TBempresa where id='" + id + "'"), conn);

                            string nome_fornecedor = System.Convert.ToString(retornobanco.ExecuteScalar());

                            // Validar Descricao caso não tenha limpar os campos

                            if (nome_fornecedor == string.Empty && nome_fornecedor == "")
                            {
                                txtCodigo.Text = "";

                                cbEmpresa.Text = "";

                                Conexao.fecharConexao();
                            }
                            else
                            {
                                cbEmpresa.Text = System.Convert.ToString(nome_fornecedor);

                                txtCodigo.Text = id;

                                Conexao.fecharConexao();

                            }
                        }
                    }
                    else
                    {
                        cbEmpresa.Text = "";

                        txtCodigo.Text = "";

                        txtCodigo.Focus();

                        txtCodigo.Select();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void txtSalario_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtSalario.BackColor = System.Drawing.Color.Yellow;
            
            if (txtSalario.Text == "R$ 0,00" && txtSalario.Text == string.Empty)
            {
                txtSalario.Text = Convert.ToDouble(0.00).ToString("C");

                txtSalario.SelectAll();
            }

            txtSalario.Focus();

            txtSalario.SelectAll();
        }

        private void txtSalario_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtSalario.BackColor = System.Drawing.Color.White;
            
            if (txtSalario.Text == string.Empty || txtSalario.Text == "R$ 0,00")
            {
                txtSalario.Text = string.Empty;
            }
            else
            {
                txtSalario.Text = Convert.ToDouble(txtSalario.Text).ToString("C");
            }
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            // Aceita somente numero e backuspace

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 27 && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

                MessageBox.Show("Campo só aceita numero(s).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSalario_MouseClick(object sender, MouseEventArgs e)
        {
            txtSalario.SelectAll();
        }

        private void btnCadastro_Empresa_Click_1(object sender, EventArgs e)
        {
            Cadastro_de_Empresa Cadastro_de_Empresa = new Cadastro_de_Empresa();

            Cadastro_de_Empresa.ShowDialog();
        }

        private void Empresa_Solicitante_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //Validando tecla F5 e chamando evento do botão salvar.

                if (btnSalvar.Visible == true)
                {

                    if (e.KeyCode == Keys.F5)
                    {
                        // btnSalvar_Click(this, new EventArgs());
                    }
                }
                //Validando tecla F8 e chamando evento do botão Atualizar.
                if (btnAlterar.Visible == true)
                {
                    if (e.KeyCode == Keys.F8)
                    {
                        // btnAlterar_Click(this, new EventArgs());
                    }
                }
                // Validando tecla F7
                if (e.KeyCode == Keys.F7)
                {
                    //btnCancelar_Click(this, new EventArgs());
                }
                // Chamando Cadastro de Cliente
                if (e.KeyCode == Keys.F2)
                {
                    Cadastro_de_Empresa Cadastro_de_Empresa = new Cadastro_de_Empresa();

                    Cadastro_de_Empresa.ShowDialog();
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
                string Proximo_numero;

                // Validando Proximo Código

                SqlConnection conn1 = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (conn1 == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {

                    SqlCommand retornobanco1 = new SqlCommand(("SELECT IDENT_CURRENT('TBvaga') + 1 AS id"), conn1);

                    SqlDataReader leitor1 = retornobanco1.ExecuteReader();

                    leitor1.Read();

                    Proximo_numero = leitor1["id"].ToString();

                    if (txtCodigo.Text != Proximo_numero)
                    {
                        txtCodigo.Text = Proximo_numero;
                    }

                    if (txtCodigo.Text == string.Empty)
                    {
                        //Fechar conexao 

                        Conexao.fecharConexao();

                        MessageBox.Show("Para Salvar Registro é Necessário Informar uma Empresa", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        txtCodigo.Focus();

                        txtCodigo.Select();
                    }
                    else
                    {
                        string id = Convert.ToUInt64(txtCodigo.Text.Replace("\r\n", "")).ToString();

                        SqlConnection conn = Conexao.obterConexao();

                        // a conexão foi efetuada com sucesso?
                        if (conn == null)
                        {
                            MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                        }
                        else
                        {

                            double salario = 0;

                            if (txtSalario.Text != string.Empty)
                            {
                                salario = Convert.ToDouble(txtSalario.Text.Replace("R$", "".Replace(" ", "")));
                            }

                            // Atualizando os Campos

                            string ssql = "insert into TBvaga(Emprego,Id_Empresa,Empresa,Solicitante,Cargo,Vaga,Carga_Horaria,Folga,Idade_de,Idade_ate,Funcoes"
                            + ",Escolaridade,Conhecimentos,Experiencia,Trabalha_Sabado,Trabalha_Domingo,Sexo,Possuir_Veiculo"
                            + ",Moradia,Psicologicas,Aparencia,Alimentacao,Obs_Alimentacao,Saude,Obs_Saude,Transporte"
                            + ",Obs_Transporte,Outros,Obs_Outros,Motivado,Disponivel_Horario,Decisao,Sem_Experiencia,Dinamico,Hora_Extra"
                            + ",Conhecimento_Funcao,Disponivel_Domingo,Salario)"
                            + " VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19"
                            + ",@20,@21,@22,@23,@24,@25,@26,@27,@28,@29,@30,@31,@32,@33,@34,@35,@36,@37,@38)";

                            SqlCommand Comando = new SqlCommand(ssql, conn);

                            Comando.Parameters.AddWithValue("@1", (rdEmprego.Checked ? +1 : 0));
                            Comando.Parameters.AddWithValue("@2", id);
                            Comando.Parameters.AddWithValue("@3", cbEmpresa.Text);
                            Comando.Parameters.AddWithValue("@4", txtSolicitante.Text);
                            Comando.Parameters.AddWithValue("@5", cbCargo.Text);
                            Comando.Parameters.AddWithValue("@6", txtVaga.Text);
                            Comando.Parameters.AddWithValue("@7", txtCarga.Text);
                            Comando.Parameters.AddWithValue("@8", txtFolga.Text);
                            Comando.Parameters.AddWithValue("@9", txtIdadede.Text);
                            Comando.Parameters.AddWithValue("@10", txtIdadeate.Text);
                            Comando.Parameters.AddWithValue("@11", txtFuncoes.Text);
                            Comando.Parameters.AddWithValue("@12", cmbEscolaridade.Text);
                            Comando.Parameters.AddWithValue("@13", txtConhecimento.Text);
                            Comando.Parameters.AddWithValue("@14", txtExperiencia.Text);
                            Comando.Parameters.AddWithValue("@15", (cbSabado.Checked ? +1 : 0));
                            Comando.Parameters.AddWithValue("@16", (cbDomingo.Checked ? +1 : 0));
                            Comando.Parameters.AddWithValue("@17", (cmbSexo.Text));
                            Comando.Parameters.AddWithValue("@18", (cbVeiculo.Checked ? +1 : 0));
                            Comando.Parameters.AddWithValue("@19", txtMoradia.Text);
                            Comando.Parameters.AddWithValue("@20", txtCaracteristicas.Text);
                            Comando.Parameters.AddWithValue("@21", txtAparencia.Text);
                            Comando.Parameters.AddWithValue("@22", (chbAlimentacao.Checked ? +1 : 0));
                            Comando.Parameters.AddWithValue("@23", txtAlimentacao.Text);
                            Comando.Parameters.AddWithValue("@24", (chbSaude.Checked ? +1 : 0));
                            Comando.Parameters.AddWithValue("@25", txtSaude.Text);
                            Comando.Parameters.AddWithValue("@26", (chbTransporte.Checked ? +1 : 0));
                            Comando.Parameters.AddWithValue("@27", txtTransporte.Text);
                            Comando.Parameters.AddWithValue("@28", (chbOutros.Checked ? +1 : 0));
                            Comando.Parameters.AddWithValue("@29", txtOutros.Text);
                            Comando.Parameters.AddWithValue("@30", (chbMotivado.Checked ? +1 : 0));
                            Comando.Parameters.AddWithValue("@31", (chbDisp_Hora.Checked ? +1 : 0));
                            Comando.Parameters.AddWithValue("@32", (chbDecisao.Checked ? +1 : 0));
                            Comando.Parameters.AddWithValue("@33", (chbExperiencia.Checked ? +1 : 0));
                            Comando.Parameters.AddWithValue("@34", (chbDinamico.Checked ? +1 : 0));
                            Comando.Parameters.AddWithValue("@35", (chbHora_Extra.Checked ? +1 : 0));
                            Comando.Parameters.AddWithValue("@36", (chbConhecimento.Checked ? +1 : 0));
                            Comando.Parameters.AddWithValue("@37", (chbTrab_Domingo.Checked ? +1 : 0));
                            if (txtSalario.Text != string.Empty)
                            {
                                Comando.Parameters.AddWithValue("@38", salario);
                            }
                            else
                            {
                                Comando.Parameters.AddWithValue("@38", salario);
                            }

                            Comando.ExecuteNonQuery();

                            Conexao.fecharConexao();

                            //Fechar conexao 

                            MessageBox.Show("Registro Salvo no Sistema", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            Limpar_Dados.LimpaControles(this);

                            Empresa_Solicitante_Load(this, new EventArgs());

                            txtCodigo.Text = "";
                        }
                    }
                }
            }

            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }
        private void txtId_MouseClick(object sender, MouseEventArgs e)
        {
            txtCodigo.Focus();

            txtCodigo.Select();
        }

        private void txtId_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtCodigo.Focus();

            txtCodigo.Select();
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

                            SqlCommand script = new SqlCommand("select id AS Cod, Empresa, Cargo from tbvaga where id like '" + txtBusca.Text + "%'", conn);

                            //Atualizando DataGrid

                            DataSet dts = new DataSet();

                            SqlDataAdapter da = new SqlDataAdapter(script);

                            da.Fill(dts, "tbvaga");

                            dtgVaga.DataSource = dts.Tables["tbvaga"];

                            conn.Close();

                            Conexao.fecharConexao();
                        }
                        else
                        {
                            // Ao limpar txtBusca atualizar o DataGrid

                            //Filtrar Dados pelo código

                            SqlCommand script = new SqlCommand("select id AS Cod, Empresa, Cargo from tbvaga where Vaga_Finalizada = 0", conn);

                            //Atualizando DataGrid

                            DataSet dts = new DataSet();

                            SqlDataAdapter da = new SqlDataAdapter(script);

                            da.Fill(dts, "tbvaga");

                            dtgVaga.DataSource = dts.Tables["tbvaga"];

                        }
                    }
                }

                if (colunapressionada == "Empresa")
                {

                    //Filtrar Dados pela Descricao

                    SqlCommand script = new SqlCommand("select id AS Cod, Empresa, Cargo from tbvaga where Empresa like '%" + txtBusca.Text + "%'", conn);

                    //Atualizando DataGrid

                    DataTable dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(script);

                    da.Fill(dt);

                    DataView dv = new DataView(dt);

                    dv.RowFilter = "Empresa like'" + txtBusca.Text + "%'";

                    dtgVaga.DataSource = dv;

                    conn.Close();

                    Conexao.fecharConexao();
                }

                else if (colunapressionada == "Cargo")
                {
                    //Filtrar Dados pelo endereço

                    SqlCommand script = new SqlCommand("select id as Cod, Empresa, Cargo from tbvaga where Cargo like '%" + txtBusca.Text + "%'", conn);

                    //Atualizando DataGrid

                    DataTable dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(script);

                    da.Fill(dt);

                    DataView dv = new DataView(dt);

                    dv.RowFilter = "Cargo like'" + txtBusca.Text + "%'";

                    dtgVaga.DataSource = dv;

                    conn.Close();

                    Conexao.fecharConexao();
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void dtgVaga_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Pegando nome da coluna selecionada

                if (e.ColumnIndex == -1)
                {

                }
                else
                {

                    string coluna = (dtgVaga.Columns[e.ColumnIndex].HeaderText);

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

        private void tbVaga_KeyUp(object sender, KeyEventArgs e)
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
                        //  btnAlterar_Click(this, new EventArgs());
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cancelar = MessageBox.Show("Deseja cancelar os dados na Tela?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (cancelar.ToString().ToUpper() == "YES")
                {
                    Limpar_Dados.LimpaControles(this);

                    Conexao.fecharConexao();

                    txtCodigo.Focus();

                    txtCodigo.Select();


                    // Carregando ID 

                    SqlConnection conn = Conexao.obterConexao();

                    // a conexão foi efetuada com sucesso?
                    if (conn == null)
                    {
                        MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                    }
                    else
                    {
                        SqlCommand retornobanco = new SqlCommand(("SELECT IDENT_CURRENT('TBvaga') + 1 AS id"), conn);

                        SqlDataReader leitor = retornobanco.ExecuteReader();

                        while (leitor.Read())
                        {
                            txtId.Text = leitor["id"].ToString();

                            txtCodigo.Focus();

                            txtCodigo.Select();
                        }

                        // Desabilitando Botão Alterar

                        btnAlterar.Visible = false;

                        btnSalvar.Visible = true;

                        //Fechar conexao 

                        Conexao.fecharConexao();
                    }
                }

                txtCodigo.Focus();

                txtCodigo.Select();

            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void dtgVaga_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                string coluna = dtgVaga.CurrentRow.Cells[0].Value.ToString();

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
                        string ssql = "delete from Tbvaga where id =" + coluna;

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

        private void dtgVaga_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string coluna = dtgVaga.CurrentRow.Cells[0].Value.ToString();

                string salario;

                SqlConnection conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {

                    SqlCommand retornobanco = new SqlCommand(("select Id,Emprego,Id_Empresa,Empresa,Solicitante,Cargo,Vaga,Carga_Horaria,Folga,Idade_de,Idade_ate"
                    + ",Funcoes,Escolaridade,Conhecimentos,Experiencia,Trabalha_Sabado,Trabalha_Domingo,Sexo"
                    + ",Possuir_Veiculo,Moradia,Psicologicas,Aparencia,Salario,Alimentacao,Obs_Alimentacao,Saude,Obs_Saude"
                    + ",Transporte,Obs_Transporte,Outros,Obs_Outros,Motivado,Disponivel_Horario"
                    + ",Decisao,Sem_Experiencia,Dinamico,Hora_Extra,Conhecimento_Funcao,Disponivel_Domingo,Vaga_Indicada from TBvaga where id =" + coluna), conn);

                    SqlDataReader Comando = retornobanco.ExecuteReader();

                    while (Comando.Read())
                    {
                        txtCodigo.Text = Comando["id"].ToString();

                        rdEmprego.Checked = Convert.ToBoolean(Comando["Emprego"].ToString());

                        if (rdEmprego.Checked == false)
                        {
                            rdEstagio.Checked = true;
                        }
                        txtCodigo.Text = Comando["Id_Empresa"].ToString();

                        cbEmpresa.Text = Comando["Empresa"].ToString();

                        txtSolicitante.Text = Comando["Solicitante"].ToString();

                        cbCargo.Text = Comando["Cargo"].ToString();

                        txtVaga.Text = Comando["Vaga"].ToString();

                        txtCarga.Text = Comando["Carga_Horaria"].ToString();

                        txtFolga.Text = Comando["Folga"].ToString();

                        txtIdadede.Text = Comando["Idade_de"].ToString();

                        txtIdadeate.Text = Comando["Idade_ate"].ToString();

                        txtFuncoes.Text = Comando["Funcoes"].ToString();

                        cmbEscolaridade.Text = Comando["Escolaridade"].ToString();

                        txtConhecimento.Text = Comando["Conhecimentos"].ToString();

                        txtExperiencia.Text = Comando["Experiencia"].ToString();

                        cbSabado.Checked = Convert.ToBoolean(Comando["Trabalha_Sabado"].ToString());

                        cbDomingo.Checked = Convert.ToBoolean(Comando["Trabalha_Domingo"].ToString());

                        cmbSexo.Text = Comando["Sexo"].ToString();

                        cbVeiculo.Checked = Convert.ToBoolean(Comando["Possuir_Veiculo"].ToString());

                        txtMoradia.Text = Comando["Moradia"].ToString();

                        txtCaracteristicas.Text = Comando["Psicologicas"].ToString();

                        txtAparencia.Text = Comando["Aparencia"].ToString();

                        salario = Comando["Salario"].ToString();

                        if (salario != string.Empty)
                        {
                            txtSalario.Text = Convert.ToDouble(salario).ToString("C");
                        }

                        chbAlimentacao.Checked = Convert.ToBoolean(Comando["Alimentacao"].ToString());

                        txtAlimentacao.Text = Comando["Obs_Alimentacao"].ToString();

                        chbSaude.Checked = Convert.ToBoolean(Comando["Saude"].ToString());

                        txtSaude.Text = Comando["Obs_Saude"].ToString();

                        chbTransporte.Checked = Convert.ToBoolean(Comando["Transporte"].ToString());

                        txtTransporte.Text = Comando["Obs_Transporte"].ToString();

                        chbOutros.Checked = Convert.ToBoolean(Comando["Outros"].ToString());

                        txtOutros.Text = Comando["Obs_Outros"].ToString();

                        chbMotivado.Checked = Convert.ToBoolean(Comando["Motivado"].ToString());

                        chbDisp_Hora.Checked = Convert.ToBoolean(Comando["Disponivel_Horario"].ToString());

                        chbDecisao.Checked = Convert.ToBoolean(Comando["Decisao"].ToString());

                        chbExperiencia.Checked = Convert.ToBoolean(Comando["Sem_Experiencia"].ToString());

                        chbDinamico.Checked = Convert.ToBoolean(Comando["Dinamico"].ToString());

                        chbHora_Extra.Checked = Convert.ToBoolean(Comando["Hora_Extra"].ToString());

                        chbConhecimento.Checked = Convert.ToBoolean(Comando["Conhecimento_Funcao"].ToString());

                        chbTrab_Domingo.Checked = Convert.ToBoolean(Comando["Disponivel_Domingo"].ToString());
                        

                        // Voltando Foco para TABCADASTRO

                        tbVaga.SelectedTab = tbpCadastro1;

                        txtCodigo.Focus();

                        txtCodigo.Select();

                        // Desabilitar Botão Salvar e Habilitar Botão Atualizar

                        btnSalvar.Visible = false;

                        btnAlterar.Visible = true;

                        // Local onde botão Alterar vai aparecer

                        btnAlterar.Location = new Point(0, 483);

                        // Limpando os campos

                        if (txtVaga.Text == "0")
                        {
                            txtVaga.Text = "";
                        }
                        if (txtIdadede.Text == "0")
                        {
                            txtIdadede.Text = "";
                        }
                        if (txtIdadeate.Text == "0")
                        {
                            txtIdadeate.Text = "";
                        }


                    }

                    Conexao.fecharConexao();
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            double salario = 0;

            if (txtSalario.Text != string.Empty)
            {
                salario = Convert.ToDouble(txtSalario.Text.Replace("R$", "".Replace(" ", "")));

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
                    string ssql = "update TBvaga set Emprego = @1, Id_Empresa = @2,Empresa = @3,Solicitante = @4,Cargo = @5,Vaga = @6,Carga_Horaria = @7"
                                    + ",Folga = @8,Idade_de = @9,Idade_ate = @10,Funcoes = @11,Escolaridade = @12,Conhecimentos = @13,Experiencia = @14"
                                    + ",Trabalha_Sabado = @15,Trabalha_Domingo = @16,Sexo = @17,Possuir_Veiculo = @18,Moradia = @19"
                                    + ",Psicologicas = @20,Aparencia = @21,Alimentacao = @22,Obs_Alimentacao = @23,Saude = @24,Obs_Saude = @25"
                                    + ",Transporte = @26,Obs_Transporte = @27,Outros = @28,Obs_Outros = @29"
                                    + ",Motivado = @30,Disponivel_Horario = @31,Decisao = @32,Sem_Experiencia = @33,Dinamico = @34,Hora_Extra = @35,Conhecimento_Funcao = @36"
                                    + ",Disponivel_Domingo = @37, Salario = @38 " + " where id  =" + txtCodigo.Text;

                    SqlCommand Comando = new SqlCommand(ssql, conn);


                    Comando.Parameters.AddWithValue("@1", (rdEmprego.Checked ? +1 : 0));
                    Comando.Parameters.AddWithValue("@2", txtCodigo.Text);
                    Comando.Parameters.AddWithValue("@3", cbEmpresa.Text);
                    Comando.Parameters.AddWithValue("@4", txtSolicitante.Text);
                    Comando.Parameters.AddWithValue("@5", cbCargo.Text);
                    Comando.Parameters.AddWithValue("@6", txtVaga.Text);
                    Comando.Parameters.AddWithValue("@7", txtCarga.Text);
                    Comando.Parameters.AddWithValue("@8", txtFolga.Text);
                    Comando.Parameters.AddWithValue("@9", txtIdadede.Text);
                    Comando.Parameters.AddWithValue("@10", txtIdadeate.Text);
                    Comando.Parameters.AddWithValue("@11", txtFuncoes.Text);
                    Comando.Parameters.AddWithValue("@12", cmbEscolaridade.Text);
                    Comando.Parameters.AddWithValue("@13", txtConhecimento.Text);
                    Comando.Parameters.AddWithValue("@14", txtExperiencia.Text);
                    Comando.Parameters.AddWithValue("@15", (cbSabado.Checked ? +1 : 0));
                    Comando.Parameters.AddWithValue("@16", (cbDomingo.Checked ? +1 : 0));
                    Comando.Parameters.AddWithValue("@17", cmbSexo.Text);                   
                    Comando.Parameters.AddWithValue("@18", (cbVeiculo.Checked ? +1 : 0));
                    Comando.Parameters.AddWithValue("@19", txtMoradia.Text);
                    Comando.Parameters.AddWithValue("@20", txtCaracteristicas.Text);
                    Comando.Parameters.AddWithValue("@21", txtAparencia.Text);
                    Comando.Parameters.AddWithValue("@22", (chbAlimentacao.Checked ? +1 : 0));
                    Comando.Parameters.AddWithValue("@23", txtAlimentacao.Text);
                    Comando.Parameters.AddWithValue("@24", (chbSaude.Checked ? +1 : 0));
                    Comando.Parameters.AddWithValue("@25", txtSaude.Text);
                    Comando.Parameters.AddWithValue("@26", (chbTransporte.Checked ? +1 : 0));
                    Comando.Parameters.AddWithValue("@27", txtTransporte.Text);
                    Comando.Parameters.AddWithValue("@28", (chbOutros.Checked ? +1 : 0));
                    Comando.Parameters.AddWithValue("@29", txtOutros.Text);
                    Comando.Parameters.AddWithValue("@30", (chbMotivado.Checked ? +1 : 0));
                    Comando.Parameters.AddWithValue("@31", (chbDisp_Hora.Checked ? +1 : 0));
                    Comando.Parameters.AddWithValue("@32", (chbDecisao.Checked ? +1 : 0));
                    Comando.Parameters.AddWithValue("@33", (chbExperiencia.Checked ? +1 : 0));
                    Comando.Parameters.AddWithValue("@34", (chbDinamico.Checked ? +1 : 0));
                    Comando.Parameters.AddWithValue("@35", (chbHora_Extra.Checked ? +1 : 0));
                    Comando.Parameters.AddWithValue("@36", (chbConhecimento.Checked ? +1 : 0));
                    Comando.Parameters.AddWithValue("@37", (chbTrab_Domingo.Checked ? +1 : 0));

                    if (txtSalario.Text != string.Empty)
                    {
                        Comando.Parameters.AddWithValue("@38", salario);
                    }
                    else
                    {
                        Comando.Parameters.AddWithValue("@45", salario);
                    }

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

                tbVaga.SelectedTab = tbpCadastro1;

                txtCodigo.Focus();

                txtCodigo.Select();

                // Chamando Evendo do LOAD

                Empresa_Solicitante_Load(this, new EventArgs());

            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void cbEmpresa_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            cbEmpresa.BackColor = System.Drawing.Color.Yellow;

            //habilitar a abertura automatica da combo.
            cbEmpresa.DroppedDown = true;


           // Atualizando o COMBOBOX de acordo com o cadastro de empresa

            SqlConnection Nova_conn = Conexao.obterConexao();

            // a conexão foi efetuada com sucesso?
            if (Nova_conn == null)
            {
                MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
            }
            else
            {

                string nome_empresa = cbEmpresa.Text;

                String scom = "select Nome from tbempresa";

                SqlDataAdapter da = new SqlDataAdapter(scom, Nova_conn);

                DataTable dtResultado = new DataTable();
                dtResultado.Clear();//o ponto mais importante (limpa a table antes de preenche-la)
                cbEmpresa.DataSource = null;
                da.Fill(dtResultado);
                cbEmpresa.DataSource = dtResultado;
                cbEmpresa.ValueMember = "Nome";
                cbEmpresa.DisplayMember = "Nome";
                cbEmpresa.Refresh(); //faz uma nova busca no BD para preencher os valores da cb de departamentos.

                cbEmpresa.Text = nome_empresa;

                if (cbEmpresa.Text == string.Empty)
                {
                    txtCodigo.Text = "";
                }

                Conexao.fecharConexao();
            }

            Conexao.fecharConexao();
        }

        private void Empresa_Solicitante_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Aceita somente numero e backuspace

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 27 && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

                MessageBox.Show("Campo só aceita numero(s).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void chbAlimentacao_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAlimentacao.Checked == true)
            {
                txtAlimentacao.ReadOnly = false;

                txtAlimentacao.Focus();

                txtAlimentacao.SelectAll();

            }
            else
            {
                txtAlimentacao.Clear();

                txtAlimentacao.ReadOnly = true;
            }
        }

        private void chbSaude_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSaude.Checked == true)
            {
                txtSaude.ReadOnly = false;

                txtSaude.Focus();

                txtSaude.SelectAll();
            }
            else
            {
                txtSaude.Clear();

                txtSaude.ReadOnly = true;
            }
        }

        private void chbTransporte_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTransporte.Checked == true)
            {
                txtTransporte.ReadOnly = false;

                txtTransporte.Focus();

                txtTransporte.SelectAll();
            }
            else
            {
                txtTransporte.Clear();

                txtTransporte.ReadOnly = true;
            }
        }

        private void chbOutros_CheckedChanged(object sender, EventArgs e)
        {
            if (chbOutros.Checked == true)
            {
                txtOutros.ReadOnly = false;

                txtOutros.Focus();

                txtOutros.SelectAll();
            }
            else
            {
                txtOutros.Clear();

                txtOutros.ReadOnly = true;
            }
        }

        private void cbCargo_Click(object sender, EventArgs e)
        {
            try
            {

                // Atualizando o COMBOBOX de acordo com o cadastro de empresa

                SqlConnection Nova_conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (Nova_conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {

                    string cargo = cbCargo.Text;

                    String scom = "select distinct cargo from tbvaga where cargo is not null and cargo <> ''";

                    SqlDataAdapter da = new SqlDataAdapter(scom, Nova_conn);

                    DataTable dtResultado = new DataTable();
                    dtResultado.Clear();//o ponto mais importante (limpa a table antes de preenche-la)
                    cbCargo.DataSource = null;
                    da.Fill(dtResultado);
                    cbCargo.DataSource = dtResultado;
                    cbCargo.ValueMember = "Cargo";
                    cbCargo.DisplayMember = "Cargo";
                    cbCargo.Refresh(); //faz uma nova busca no BD para preencher os valores da cb de cargo.

                    cbCargo.Text = cargo;

                    Conexao.fecharConexao();
                }

                Conexao.fecharConexao();
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void cbCargo_Leave(object sender, EventArgs e)
        {
            cbCargo.Text = cbCargo.Text.ToUpper();

            //Mudando cor ao perder foco
            cbCargo.BackColor = System.Drawing.Color.White;
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
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

                    SqlCommand retornobanco = new SqlCommand(("select id from TBempresa where nome='" + cbEmpresa.Text + "'"), conn);

                    Int64 codigo = System.Convert.ToInt64(retornobanco.ExecuteScalar());

                    if (codigo != 0)
                    {
                        txtCodigo.Text = System.Convert.ToString(codigo);
                    }
                    else
                    {
                        txtCodigo.Text = "";
                    }
                    Conexao.fecharConexao();
                }

                Conexao.fecharConexao();
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void cbCargo_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            cbCargo.BackColor = System.Drawing.Color.Yellow;

            //habilitar a abertura automatica da combo.
            cbCargo.DroppedDown = true;
        }

        private void cmbSexo_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            cmbSexo.BackColor = System.Drawing.Color.Yellow;

            //habilitar a abertura automatica da combo.
            cmbSexo.DroppedDown = true;
        }

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtCodigo.BackColor = System.Drawing.Color.Yellow;
        }

        private void cbEmpresa_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            cbEmpresa.BackColor = System.Drawing.Color.White;
        }

        private void txtSolicitante_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtSolicitante.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtSolicitante_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtSolicitante.BackColor = System.Drawing.Color.White;
        }

        private void txtVaga_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtVaga.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtVaga_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtVaga.BackColor = System.Drawing.Color.White;
        }

        private void txtCarga_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtCarga.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtCarga_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtCarga.BackColor = System.Drawing.Color.White;
        }

        private void txtFolga_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtFolga.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtFolga_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtFolga.BackColor = System.Drawing.Color.White;
        }

        private void txtIdadede_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtIdadede.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtIdadede_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtIdadede.BackColor = System.Drawing.Color.White;
        }

        private void txtIdadeate_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtIdadeate.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtIdadeate_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtIdadeate.BackColor = System.Drawing.Color.White;
        }

        private void txtFuncoes_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtFuncoes.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtFuncoes_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtFuncoes.BackColor = System.Drawing.Color.White;
        }

        private void cmbEscolaridade_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            cmbEscolaridade.BackColor = System.Drawing.Color.Yellow;
        }

        private void cmbEscolaridade_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            cmbEscolaridade.BackColor = System.Drawing.Color.White;
        }

        private void txtConhecimento_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtConhecimento.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtConhecimento_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtConhecimento.BackColor = System.Drawing.Color.White;
        }

        private void txtExperiencia_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtExperiencia.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtExperiencia_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtExperiencia.BackColor = System.Drawing.Color.White;
        }

        private void cmbSexo_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            cmbSexo.BackColor = System.Drawing.Color.White;
        }

        private void txtMoradia_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtMoradia.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtMoradia_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtMoradia.BackColor = System.Drawing.Color.White;
        }

        private void txtCaracteristicas_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtCaracteristicas.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtCaracteristicas_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtCaracteristicas.BackColor = System.Drawing.Color.White;
        }

        private void txtAparencia_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtAparencia.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtAparencia_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtAparencia.BackColor = System.Drawing.Color.White;
        }

        private void txtBusca_Enter(object sender, EventArgs e)
        {
            // Mudando cor ao receber foco
            txtBusca.BackColor = System.Drawing.Color.Yellow;
        }

        private void txtBusca_Leave(object sender, EventArgs e)
        {
            //Mudando cor ao perder foco
            txtBusca.BackColor = System.Drawing.Color.White;
        }
    }
}
