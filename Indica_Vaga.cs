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
    public partial class Indicar_Vaga : Form
    {
        public static string Cpf;

        public static string Nome;

        public Indicar_Vaga()
        {
            InitializeComponent();
        }

        private void Indicar_Vaga_Load(object sender, EventArgs e)
        {
            try
            {
                // Preencher combobox ao carregar tela

                SqlConnection conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {

                    string sql = "select distinct Cargo, Empresa from TBvaga where Cargo <> ''";

                    // criando um data adapter
                    SqlDataAdapter cargo_empresa = new SqlDataAdapter(sql, conn);

                    // criando um data table para guardar os dados  
                    DataTable dtResultado = new DataTable();

                    // preenchendo o data table usando o metodo Fill do adapter
                    cargo_empresa.Fill(dtResultado);

                    // agora que voce já tem um DataTable populado, é só atribui-lo ao datasource do combobox
                    cmbCargo.DataSource = dtResultado;

                    cmbEmpresa.DataSource = dtResultado;

                    //DisplayMember = recebe o nome que está no banco de dados
                    cmbCargo.DisplayMember = "Cargo";
                    //ValueMember = recebe o código e guarda internamente em cada item do combobox.
                    cmbCargo.ValueMember = "Cargo";


                    //DisplayMember = recebe o nome que está no banco de dados
                    cmbEmpresa.DisplayMember = "Empresa";
                    //ValueMember = recebe o código e guarda internamente em cada item do combobox.
                    cmbEmpresa.ValueMember = "Empresa";

                    cmbCargo.Text = "";

                    cmbEmpresa.Text = "";

                    Conexao.fecharConexao();

                    // Pegando valor da coluna selecionada e atualizando os dados

                    mkCpf.Text = Cpf;

                    txtNome.Text = Nome;

                    // Atualizando mascara CPF

                    if (mkCpf.Text != "")
                    {

                        mkCpf.Mask = "000,000,000-00";

                        mkCpf.Select(0, 0);
                    }

                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void mkCpf_Enter(object sender, EventArgs e)
        {
            cmbCargo.Focus();

            cmbCargo.SelectAll();
        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            cmbCargo.Focus();

            cmbCargo.SelectAll();
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

                    if (cmbCargo.Text != "" && cmbEmpresa.Text != "")
                    {

                        string cpf = string.Empty;

                        string data_atual = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm");


                        if (mkCpf.Text != string.Empty)
                        {
                            cpf = mkCpf.Text.Replace(".", "").Replace("-", "");
                        }

                        // Atualizando os Campos

                        string ssql = "insert into tbvaga_indicada(Cpf, Data, Empresa, Vaga, Vaga_Indicada)"
                        + " VALUES (@1,@2,@3,@4,@5)";

                        SqlCommand Comando = new SqlCommand(ssql, conn);

                        Comando.Parameters.AddWithValue("@1", cpf);
                        Comando.Parameters.AddWithValue("@2", Convert.ToDateTime(data_atual).ToString("yyyy-MM-dd"));
                        Comando.Parameters.AddWithValue("@3", cmbEmpresa.Text);
                        Comando.Parameters.AddWithValue("@4", cmbCargo.Text);
                        Comando.Parameters.AddWithValue("@5", 1);


                        Comando.ExecuteNonQuery();

                        Conexao.fecharConexao();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Favor Informar Cargo e Empresa para continuar.");

                        cmbCargo.Focus();

                        cmbCargo.Select();
                    }
                }

                Conexao.fecharConexao();
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void Indicar_Vaga_KeyDown(object sender, KeyEventArgs e)
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
    }
}