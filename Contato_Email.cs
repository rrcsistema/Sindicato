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
    public partial class Contato_Email : Form
    {
        // Passando valor para outro form part 1
        Enviar_Email Enviar_Email;

        //Pegando as colunas selecionadas e pasando para o relatorio

        string registros = string.Empty;

        string registro_conc = string.Empty;

        // Passando valor para outro form part 2
        public Contato_Email(Enviar_Email enviar_email)
        {
            InitializeComponent();

            Enviar_Email = enviar_email;
        }
        private void Contato_Email_Load(object sender, EventArgs e)
        {

            try
            {

                // Atualizando Data Grid com base no select

                SqlConnection conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {
                    string strSql = "select Nome, Email from tbempresa where email is not null";

                    SqlDataAdapter da = new SqlDataAdapter(strSql, conn);

                    //cria um objeto datatable
                    DataTable Email = new DataTable();

                    //preenche o datatable via dataadapter
                    da.Fill(Email);

                    //atribui o datatable ao datagridview para exibir o resultado
                    dtgEmail.DataSource = Email;

                    dtgEmail.Refresh();

                    // Redimensionar as colunas mestre DataGridView para ajustar os dados recém-carregados.
                    //dtgFiltro_Vaga.AutoResizeColumns();

                    // Ajustar Coluna manualmente

                    DataGridViewColumn coluna1 = dtgEmail.Columns[0];
                    coluna1.Width = 245;

                    DataGridViewColumn coluna2 = dtgEmail.Columns[1];
                    coluna2.Width = 260;

                    Conexao.fecharConexao();
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
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

                    if (colunapressionada == "Nome")
                    {
                        if (txtBusca.Text != string.Empty)
                        {

                            //Filtrar Dados pelo Nome

                            SqlCommand script = new SqlCommand("select Nome, Email from TBempresa where Nome like '%" + txtBusca.Text + "%'" + "and Email is not null", conn);

                            //Atualizando DataGrid

                            DataTable dt = new DataTable();

                            SqlDataAdapter da = new SqlDataAdapter(script);

                            da.Fill(dt);

                            DataView dv = new DataView(dt);

                            dv.RowFilter = "Nome like'" + txtBusca.Text + "%'";

                            dtgEmail.DataSource = dv;

                            conn.Close();

                            Conexao.fecharConexao();
                        }
                        else
                        {
                            // Ao limpar txtBusca atualizar o DataGrid

                            SqlCommand script = new SqlCommand("select Nome, Email from TBempresa where Email is not null", conn);

                            //Atualizando DataGrid

                            DataSet dts = new DataSet();

                            SqlDataAdapter da = new SqlDataAdapter(script);

                            da.Fill(dts, "TBempresa");

                            dtgEmail.DataSource = dts.Tables["TBempresa"];

                        }
                    }
                    if (colunapressionada == "Email")
                    {

                        //Filtrar Dados pelo email

                        SqlCommand script = new SqlCommand("select Nome, Email from TBempresa where Nome Email '%" + txtBusca.Text + "%'" + "and Email is not null", conn);

                        //Atualizando DataGrid

                        DataTable dt = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(script);

                        da.Fill(dt);

                        DataView dv = new DataView(dt);

                        dv.RowFilter = "Email like'" + txtBusca.Text + "%'";

                        dtgEmail.DataSource = dv;

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

        private void dtgEmail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dtgEmail.SelectedRows)
                {

                    if (dtgEmail.SelectedRows.Count == 1)
                    {
                        if (Enviar_Email.txtDestinatario.Text == string.Empty)
                        {
                            registros = row.Cells[1].Value.ToString();

                            registro_conc = string.Concat(string.Concat(registro_conc, registros));

                            // Passando valor para outro form part 3

                            Enviar_Email.txtDestinatario.Text = registro_conc;

                            Enviar_Email.txtDestinatario.Refresh();
                        }
                        else
                        {
                            DialogResult resultado = MessageBox.Show("Já existe uma contato informado\n Deseja alterar o mesmo?", "Atenção",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                            registro_conc = string.Empty;

                            if (resultado == DialogResult.Yes)
                            {
                                if (dtgEmail.SelectedRows.Count == 1)
                                {
                                    registros = row.Cells[1].Value.ToString();

                                    registro_conc = string.Concat(string.Concat(registro_conc, registros));

                                    // Passando valor para outro form part 3

                                    Enviar_Email.txtDestinatario.Text = registro_conc;

                                    Enviar_Email.txtDestinatario.Refresh();

                                    Enviar_Email.txtDestinatario.Text = string.Empty;

                                    Enviar_Email.txtDestinatario.Text = registro_conc;

                                    Enviar_Email.txtDestinatario.Refresh();
                                }
                            }
                        }
                    }
                }
                //Pegando nome da coluna selecionada

                if (e.ColumnIndex == -1)
                {

                }
                else
                {

                    string coluna = (dtgEmail.Columns[e.ColumnIndex].HeaderText);

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
        private void Contato_Email_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}