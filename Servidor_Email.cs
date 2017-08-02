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
    public partial class Servidor_Email : Form
    {
        private Filtrar_Vaga filtrar_Vaga;

        public Servidor_Email()
        {
            InitializeComponent();
        }

        public Servidor_Email(Filtrar_Vaga filtrar_Vaga)
        {
            // TODO: Complete member initialization
            this.filtrar_Vaga = filtrar_Vaga;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {

                bool seguranca = true;

                if (cmbSeguranca.Text == "SSL/TLS")
                {
                    seguranca = true;
                }
                else
                {
                    seguranca = false;
                }

                SqlConnection conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {
                    string ssql = "update tbconta_email set Nome = @nome, smtp = @smtp, porta = @porta, seguranca = @seguranca, email = @email, senha = @senha where id = 1";

                    SqlCommand Novo_Comando = new SqlCommand(ssql, conn);

                    Novo_Comando.Parameters.AddWithValue("@nome", txtNome.Text);
                    Novo_Comando.Parameters.AddWithValue("@smtp", txtSmtp.Text);
                    Novo_Comando.Parameters.AddWithValue("@porta", txtPorta.Text);
                    Novo_Comando.Parameters.AddWithValue("@seguranca", seguranca);
                    Novo_Comando.Parameters.AddWithValue("@email", txtEmail.Text);
                    Novo_Comando.Parameters.AddWithValue("@senha", txtSenha.Text);

                    Novo_Comando.ExecuteNonQuery();

                    MessageBox.Show("Registro Atualizado com Sucesso", "Alteração de Dados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }



                Conexao.fecharConexao();

                this.Close();
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }

        private void Servidor_Email_Load(object sender, EventArgs e)
        {
            try
            {

                string seguranca1 = "";

                // Validando Proximo Código

                SqlConnection conn = Conexao.obterConexao();

                // a conexão foi efetuada com sucesso?
                if (conn == null)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                }
                else
                {
                    SqlCommand retornobanco = new SqlCommand(("select Nome, Smtp,Porta,Seguranca,Email,Senha from tbconta_email where id = 1"), conn);

                    SqlDataReader leitor = retornobanco.ExecuteReader();

                    while (leitor.Read())
                    {
                        txtNome.Text = leitor["Nome"].ToString();
                        txtSmtp.Text = leitor["Smtp"].ToString();
                        txtPorta.Text = leitor["Porta"].ToString();
                        seguranca1 = leitor["Seguranca"].ToString();
                        txtEmail.Text = leitor["Email"].ToString();
                        txtSenha.Text = leitor["Senha"].ToString();
                    }

                    if (seguranca1 == "1")
                    {
                        cmbSeguranca.Text = "SSL/TLS";
                    }
                    else
                    {
                        cmbSeguranca.Text = "STARTTLS";
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

        private void Servidor_Email_KeyDown(object sender, KeyEventArgs e)
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