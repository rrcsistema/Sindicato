using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using System.Net.Mail;
using System.Net;
using CrystalDecisions.Shared;
using System.IO;


namespace Sindicato
{
    public partial class Filtrar_Vaga : Form
    {

        public Filtrar_Vaga()
        {
            InitializeComponent();
        }

        private void cmbBairro_Click(object sender, EventArgs e)
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

                    string bairro = cmbBairro.Text;

                    String scom = "select distinct bairro from tbpessoal where Bairro is not null and Bairro <> ''";

                    SqlDataAdapter da = new SqlDataAdapter(scom, Nova_conn);

                    DataTable dtResultado = new DataTable();
                    dtResultado.Clear();//o ponto mais importante (limpa a table antes de preenche-la)
                    cmbBairro.DataSource = null;
                    da.Fill(dtResultado);
                    cmbBairro.DataSource = dtResultado;
                    cmbBairro.ValueMember = "Bairro";
                    cmbBairro.DisplayMember = "Bairro";
                    cmbBairro.Refresh(); //faz uma nova busca no BD para preencher os valores da cb de departamentos.

                    cmbBairro.Text = bairro;

                    Conexao.fecharConexao();
                }

                Conexao.fecharConexao();
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void cmbBairro_Leave(object sender, EventArgs e)
        {
            if (cmbBairro.Text == string.Empty)
            {
                cmbBairro.Text = "";
            }
        }

        private void cmbCidade_Click(object sender, EventArgs e)
        {
            try
            {

                // Atualizando o COMBOBOX de acordo com o cadastro de Cidade

                SqlConnection Nova_conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (Nova_conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {

                    string cidade = cmbCidade.Text;

                    String scom = "select distinct Cidade from tbpessoal where Cidade is not null and Cidade <> ''";

                    SqlDataAdapter da = new SqlDataAdapter(scom, Nova_conn);

                    DataTable dtResultado = new DataTable();
                    dtResultado.Clear();//o ponto mais importante (limpa a table antes de preenche-la)
                    cmbCidade.DataSource = null;
                    da.Fill(dtResultado);
                    cmbCidade.DataSource = dtResultado;
                    cmbCidade.ValueMember = "Cidade";
                    cmbCidade.DisplayMember = "Cidade";
                    cmbCidade.Refresh(); //faz uma nova busca no BD para preencher os valores da cb de departamentos.

                    cmbCidade.Text = cidade;

                    Conexao.fecharConexao();
                }

                Conexao.fecharConexao();
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void cmbCidade_Leave(object sender, EventArgs e)
        {
            if (cmbCidade.Text == string.Empty)
            {
                cmbCidade.Text = "";
            }
        }

        private void cmbBairro_Enter(object sender, EventArgs e)
        {
            // Chamando o Evento da Combbox CLICK onde o mesmo atualiza os dados da COMBOBOX

            cmbBairro_Click(this, new EventArgs());
        }

        private void cmbCidade_Enter(object sender, EventArgs e)
        {
            // Chamando o Evento da Combbox CLICK onde o mesmo atualiza os dados da COMBOBOX

            cmbCidade_Click(this, new EventArgs());
        }

        private void btnBusca_Click(object sender, EventArgs e)
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
                    //Validando Filtros Necessidade Especial

                    string necessidade;

                    string estuda;

                    string sexo;

                    string fuma;

                    string idade_de = "";

                    string idade_ate = "99";

                    if (rdNecessidade_Todos.Checked == true)
                    {
                        necessidade = "(0,1)";
                    }
                    else if (rdNecessidade_Sim.Checked == true)
                    {
                        necessidade = "('1')";
                    }
                    else
                    {
                        necessidade = "('0')";
                    }

                    // Validando Filtros Estuda

                    if (rdTodos.Checked == true)
                    {
                        estuda = "('0','1')";
                    }
                    else if (rdEstuda_Sim.Checked == true)
                    {
                        estuda = "('1')";
                    }
                    else
                    {
                        estuda = "('0')";
                    }
                    // Validando Sexo

                    if (rdSexo_Todos.Checked == true)
                    {
                        sexo = "('F','M','')";
                    }
                    else if (rdSexo_Masculino.Checked == true)
                    {
                        sexo = "('M')";
                    }
                    else
                    {
                        sexo = "('F')";
                    }

                    // Validando Fuma

                    if (rdFumante_Todos.Checked == true)
                    {
                        fuma = "('0','1')";
                    }
                    else if (rdFumante_Sim.Checked == true)
                    {
                        fuma = "('1')";
                    }
                    else
                    {
                        fuma = "('0')";
                    }

                    if (txtIdadede.Text != "" && txtIdadede.Text != "99" && txtIdadede.Text != "")
                    {
                        idade_de = txtIdadede.Text.Replace("\r\n1", "");
                    }
                    if (txtIdadeate.Text != "" && txtIdadeate.Text != "99" && txtIdadeate.Text != "")
                    {
                        idade_ate = txtIdadeate.Text.Replace("\r\n1", "");
                    }

                    if (txtBusca_Atividade.Text != string.Empty)
                    {

                        string strSql = "SELECT id AS Cod, CPF, Nome, Rua AS Endereço, Numero, Bairro, Cidade FROM TBpessoal Where id in" + "(select distinct Id_Curriculo from TBHistorico_Trabalho where Atividade like '%" + txtBusca_Atividade.Text + "%')"
                        + " and Escolaridade Like '%" + cbEscolaridade.Text + "%' and Bairro Like '%" + cmbBairro.Text + "%' and Cidade like '%" + cmbCidade.Text + "%' and Regiao like '%" + cmbRegiao.Text + "%' and Estado_Civil like '%" + cmbEstado_Civil.Text + "%'"
                        + " and Portador_Necessidade in" + necessidade + " and Estuda in " + estuda + " and Disponibilidade_Horario like '%" + cmbDisponibilidade_horario.Text + "%' and Sexo in " + sexo + " and Fumante in " + fuma + " and Categoria_Habilitacao like '%" + txtHabilitacao.Text + "%' and Idade >='" + idade_de + "' and Idade <='" + idade_ate + "'";

                        SqlDataAdapter da = new SqlDataAdapter(strSql, Nova_conn);

                        //cria um objeto datatable
                        DataTable clientes = new DataTable();

                        //preenche o datatable via dataadapter
                        da.Fill(clientes);

                        //atribui o datatable ao datagridview para exibir o resultado
                        dtgFiltro_Vaga.DataSource = clientes;

                        dtgFiltro_Vaga.Refresh();
                    }
                    else
                    {
                        string strSql = "SELECT id AS Cod, CPF, Nome, Rua AS Endereço, Numero, Bairro, Cidade FROM TBpessoal Where Escolaridade Like '%" + cbEscolaridade.Text + "%' and Bairro Like '%" + cmbBairro.Text + "%' and Cidade like '%" + cmbCidade.Text + "%' and Regiao like '%" + cmbRegiao.Text + "%' and Estado_Civil like '%" + cmbEstado_Civil.Text + "%'"
                        + " and Portador_Necessidade in" + necessidade + " and Estuda in " + estuda + " and Disponibilidade_Horario like '%" + cmbDisponibilidade_horario.Text + "%' and Sexo in " + sexo + " and Fumante in " + fuma + " and Categoria_Habilitacao like '%" + txtHabilitacao.Text + "%' and Idade >='" + idade_de + "' and Idade <='" + idade_ate + "'";

                        SqlDataAdapter da = new SqlDataAdapter(strSql, Nova_conn);

                        //cria um objeto datatable
                        DataTable clientes = new DataTable();

                        //preenche o datatable via dataadapter
                        da.Fill(clientes);

                        //atribui o datatable ao datagridview para exibir o resultado
                        dtgFiltro_Vaga.DataSource = clientes;

                        dtgFiltro_Vaga.Refresh();
                    }

                    // Redimensionar as colunas mestre DataGridView para ajustar os dados recém-carregados.
                    //dtgFiltro_Vaga.AutoResizeColumns();

                    // Ajustar Coluna manualmente

                    DataGridViewColumn coluna0 = dtgFiltro_Vaga.Columns[0];
                    coluna0.Width = 50;

                    DataGridViewColumn coluna1 = dtgFiltro_Vaga.Columns[1];
                    coluna1.Width = 75;

                    DataGridViewColumn coluna2 = dtgFiltro_Vaga.Columns[2];
                    coluna2.Width = 280;

                    DataGridViewColumn coluna3 = dtgFiltro_Vaga.Columns[3];
                    coluna3.Width = 240;

                    DataGridViewColumn coluna4 = dtgFiltro_Vaga.Columns[4];
                    coluna4.Width = 60;

                    DataGridViewColumn coluna5 = dtgFiltro_Vaga.Columns[5];
                    coluna5.Width = 150;

                    DataGridViewColumn coluna6 = dtgFiltro_Vaga.Columns[6];
                    coluna6.Width = 150;

                    if (dtgFiltro_Vaga.RowCount > 0)
                    {

                        // Selecionando primeira linha do datagrid

                        dtgFiltro_Vaga.Rows[0].Selected = true;

                        // Habilitar Enviar Email e Indica Vaga

                        btnEnviar_Email.Enabled = true;

                        btnIndicar.Enabled = true;

                        btnImprimir.Enabled = true;
                    }
                    else
                    {
                        string message = "Não existe dados para consulta";
                        string caption = "Infromações";
                        var result = MessageBox.Show(message, caption,
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Question);

                        // Desabilitar Enviar Email e Indica Vaga

                        btnEnviar_Email.Enabled = false;

                        btnIndicar.Enabled = false;

                        btnImprimir.Enabled = false;

                    }
                }

                Conexao.fecharConexao();
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }

            Conexao.fecharConexao();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Relatorio_Pessoal Relatorio_Pessoal = new Relatorio_Pessoal();

            Relatorio_Pessoal.Show();

        }
        private void btnIndicar_Click(object sender, EventArgs e)
        {
            Indicar_Vaga Indicar_Vaga = new Indicar_Vaga();

            Indicar_Vaga.Show();
        }

        private void Filtrar_Vaga_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnEnviar_Email_Click(object sender, EventArgs e)
        {
            Enviar_Email Enviar_Email = new Enviar_Email();

            Enviar_Email.ShowDialog();
        }

        private void dtgFiltro_Vaga_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Pegando as colunas selecionadas e pasando para o relatorio

                string registros = string.Empty;

                string registro_conc = string.Empty;


                foreach (DataGridViewRow row in dtgFiltro_Vaga.SelectedRows)
                {

                    if (dtgFiltro_Vaga.SelectedRows.Count > 1)
                    {

                        registros = row.Cells[0].Value.ToString() + ",";

                        registro_conc = string.Concat(string.Concat(registro_conc, registros));

                    }
                    else
                    {
                        // Passando registro quando marcadodo somente uma linha
                        registro_conc = row.Cells[0].Value.ToString();

                    }
                }

                Relatorio_Pessoal.linha = registro_conc;

                Enviar_Email.selecionar_pdf = registro_conc;

                // Validando os Dados

                if (e.RowIndex == -1)
                {

                }
                else
                {
                    // Pegando valor da primeira coluna e passando para o form indica_vaga

                    string cpf = dtgFiltro_Vaga.Rows[e.RowIndex].Cells["CPF"].Value.ToString();

                    string nome = dtgFiltro_Vaga.Rows[e.RowIndex].Cells["Nome"].Value.ToString();

                    Enviar_Email.selecionar_pdf = dtgFiltro_Vaga.Rows[e.RowIndex].Cells[0].Value.ToString();


                    Indicar_Vaga.Cpf = cpf;

                    Indicar_Vaga.Nome = nome;
                }

            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void Filtrar_Vaga_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbRegiao_Click(object sender, EventArgs e)
        {
            try
            {

                // Atualizando o COMBOBOX de acordo com o cadastro de Regiao

                SqlConnection Nova_conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (Nova_conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {

                    string Regiao = cmbRegiao.Text;

                    String scom = "select distinct Regiao from tbpessoal where Regiao is not null and Regiao <> ''";

                    SqlDataAdapter da = new SqlDataAdapter(scom, Nova_conn);

                    DataTable dtResultado = new DataTable();
                    dtResultado.Clear();//o ponto mais importante (limpa a table antes de preenche-la)
                    cmbRegiao.DataSource = null;
                    da.Fill(dtResultado);
                    cmbRegiao.DataSource = dtResultado;
                    cmbRegiao.ValueMember = "Regiao";
                    cmbRegiao.DisplayMember = "Regiao";
                    cmbRegiao.Refresh(); //faz uma nova busca no BD para preencher os valores da base no combobox.

                    cmbRegiao.Text = Regiao;

                    Conexao.fecharConexao();
                }

                Conexao.fecharConexao();
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void cmbRegiao_Enter(object sender, EventArgs e)
        {
            // Chamando o Evento da Combbox CLICK onde o mesmo atualiza os dados da COMBOBOX

            cmbRegiao_Click(this, new EventArgs());
        }

        private void cmbRegiao_Leave(object sender, EventArgs e)
        {
            if (cmbRegiao.Text == string.Empty)
            {
                cmbRegiao.Text = "";
            }
        }

        private void cmbDisponibilidade_horario_Enter(object sender, EventArgs e)
        {
            try
            {

                // Atualizando o COMBOBOX de acordo com o cadastro de Regiao

                SqlConnection Nova_conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (Nova_conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {

                    string Regiao = cmbRegiao.Text;

                    String scom = "select distinct Disponibilidade_Horario from tbpessoal where Disponibilidade_Horario is not null and Disponibilidade_Horario <> ''";

                    SqlDataAdapter da = new SqlDataAdapter(scom, Nova_conn);

                    DataTable dtResultado = new DataTable();
                    dtResultado.Clear();//o ponto mais importante (limpa a table antes de preenche-la)
                    cmbDisponibilidade_horario.DataSource = null;
                    da.Fill(dtResultado);
                    cmbDisponibilidade_horario.DataSource = dtResultado;
                    cmbDisponibilidade_horario.ValueMember = "Disponibilidade_Horario";
                    cmbDisponibilidade_horario.DisplayMember = "Disponibilidade_Horario";
                    cmbDisponibilidade_horario.Refresh(); //faz uma nova busca no BD para preencher os valores da base no combobox.

                    cmbDisponibilidade_horario.Text = Regiao;

                    Conexao.fecharConexao();
                }

                Conexao.fecharConexao();
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void btnLimparDados_Click(object sender, EventArgs e)
        {
            cmbBairro.Text = string.Empty;
            cmbCidade.Text = string.Empty;
            cmbRegiao.Text = string.Empty;
            cmbDisponibilidade_horario.Text = string.Empty;
            cmbEstado_Civil.Text = string.Empty;
            txtIdadede.Text = string.Empty;
            txtIdadeate.Text = string.Empty;
            txtHabilitacao.Text = string.Empty;
            cbEscolaridade.Text = string.Empty;
            txtBusca_Atividade.Text = string.Empty;
            rdNecessidade_Todos.Checked = true;
            rdTodos.Checked = true;
            rdFumante_Todos.Checked = true;
            rdSexo_Todos.Checked = true;
            txtBusca_Atividade.Text = string.Empty;
            dtgFiltro_Vaga.DataSource = null;

            


        }
    }
}