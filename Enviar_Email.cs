using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using CrystalDecisions.Shared;
using System.Data.OleDb;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using System.Net;
using NOVO_PROJETO;


namespace Sindicato
{
    public partial class Enviar_Email : Form
    {
        public static string selecionar_pdf;

        public static string Destinatario;

        public Enviar_Email()
        {
            InitializeComponent();
        }

        private void btnEnviar_Email_Click(object sender, EventArgs e)
        {
            try
            {

                string smtp = "";

                int porta = 0;

                bool seguranca = true;

                string email = "";

                string senha = "";

                string nome_exibicao = "";

                SqlConnection conn = Conexao.obterConexao();

                if (txtDestinatario.Text == "")
                {
                    MessageBox.Show("Favor informar e-mail destino");

                    txtDestinatario.Focus();

                    txtDestinatario.SelectAll();
                }
                else
                {

                    // a conexão foi efetuada com sucesso?
                    if (conn == null)
                    {
                        MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                    }
                    else
                    {
                        // Pegando dados do servidor de email

                        SqlConnection Nova_conn = Conexao.obterConexao();

                        // a conexão foi efetuada com sucesso?
                        if (Nova_conn == null)
                        {
                            MessageBox.Show("Não foi possível estabelecer uma conexão com servidor.Aconselhamos entrar em contato com administrador da rede.");
                        }
                        else
                        {
                            SqlCommand retornobanco = new SqlCommand(("select Nome, Smtp, Porta,Case when Seguranca = 1 then 'true' else 'false' end as Seguranca, Email, Senha from TBconta_email where id = 1"), Nova_conn);

                            SqlDataReader leitor = retornobanco.ExecuteReader();

                            while (leitor.Read())
                            {
                                nome_exibicao = leitor["Nome"].ToString();

                                smtp = leitor["Smtp"].ToString();

                                porta = Convert.ToInt32(leitor["Porta"].ToString());

                                seguranca = Convert.ToBoolean(leitor["Seguranca"].ToString());

                                email = leitor["Email"].ToString();

                                senha = leitor["Senha"].ToString();

                            }

                            if (selecionar_pdf.EndsWith(","))
                            {
                                selecionar_pdf = selecionar_pdf.Remove(selecionar_pdf.Length - 1);
                            }
                            string sql = "select id, nome, Rua, bairro, cidade, Numero, case when Fone = '' then '' else    '(' + SUBSTRING(Fone, 1, 2) + ') ' + SUBSTRING(Fone, 3, 4) + ' - ' + SUBSTRING(Fone, 7, 4) end as Fone"
                           + ",case when recado_telefone = '' then ''"
                           + "when len (recado_telefone) = 11 then '(' + SUBSTRING(recado_telefone, 1, 2) + ') ' + SUBSTRING(recado_telefone, 3, 5) + ' - ' + SUBSTRING(recado_telefone, 8, 4)"
                           + "else '(' + SUBSTRING(recado_telefone, 1, 2) + ') ' + SUBSTRING(recado_telefone, 3, 4) + ' - ' + SUBSTRING(recado_telefone, 7, 4) end as recado_telefone"
                           + ", Quem, Nascimento,Filhos, CASE WHEN Fumante = '1' THEN 'S' ELSE 'N' END AS Fumante"
                           + ",case when Celular = '' then '' else    '(' + SUBSTRING(Celular, 1, 2) + ') ' + SUBSTRING(Celular, 3, 5) + ' - ' + SUBSTRING(Celular, 8, 4) end as Celular"
                           + ", Estado_Civil,Sexo, Cpf, RG, Categoria_Habilitacao,Cart_Trabalho,Serie,CASE WHEN Possui_Moto_Carro = '1' THEN 'S' ELSE 'N' END AS Possui_Moto_Carro"
                           + ", Qual, Escolaridade, CASE WHEN Estuda = '1' THEN 'S' ELSE 'N' END AS Estuda, Horario_Estudo, Cursos, Pretensao_Salarial from tbpessoal where id in (" + selecionar_pdf + ")";

                            SqlDataAdapter dscmd = new SqlDataAdapter(sql, conn);
                            DataSet ds = new DataSet();
                            dscmd.Fill(ds, "tbpessoal");

                            FrmRelatorio_Pessoal objRpt = new FrmRelatorio_Pessoal();

                            var caminho = Path.GetFullPath("~/pasta") + "\\FrmRelatorio_Pessoal.rpt";

                            objRpt.Load(caminho);

                            objRpt.SetDataSource(ds.Tables["tbpessoal"]);


                            // Enviando email com anexo pdf

                            MailMessage mail = new MailMessage();

                            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                            mail.From = new MailAddress(email, nome_exibicao);
                            mail.To.Add((txtDestinatario.Text).Replace(";", ",")); // Enviado por quem
                            if (txtCc.Text != "")
                            {
                                mail.CC.Add((txtCc.Text).Replace(";", ",")); //Enviar com copia devera inseri virgula ou converte para virgula
                            }
                            mail.Subject = txtAssunto.Text; // Cabeçalho do Email
                            mail.Body = txtCorpo_Email.Text + "\n" + "\n" + "Segue em Anexo Relação de Curriculum"; // Corpo do Email
                            mail.Attachments.Add(new Attachment(objRpt.ExportToStream(ExportFormatType.PortableDocFormat), "Relação de Curriculum.pdf"));
                            try
                            {
                                SmtpServer.Port = porta;
                                SmtpServer.UseDefaultCredentials = false;
                                SmtpServer.Credentials = new System.Net.NetworkCredential(email, senha);
                                SmtpServer.EnableSsl = seguranca;

                                if (SmtpServer.Timeout > 100000)
                                {
                                    string message = "Não foi possível enviar seu e-mail\n tente novamente.";
                                    string caption = "Erro ao Enviar E-mail";
                                    var result = MessageBox.Show(message, caption,
                                                                 MessageBoxButtons.OK,
                                                                 MessageBoxIcon.Question);
                                }
                                else
                                {
                                    SmtpServer.Send(mail);

                                    MessageBox.Show("E-mail enviado com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    Conexao.fecharConexao();

                                    this.Close();

                                }
                            }

                            catch (Exception)
                            {
                                string message = "Não foi possível enviar seu e-mail\n tente novamente.";
                                string caption = "Erro ao Enviar E-mail";
                                var result = MessageBox.Show(message, caption,
                                                             MessageBoxButtons.OK,
                                                             MessageBoxIcon.Question);
                            }
                        }

                        Conexao.fecharConexao();
                    }

                    Conexao.fecharConexao();
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }
        private void Enviar_Email_KeyDown(object sender, KeyEventArgs e)
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

        private void btnEmail_Click(object sender, EventArgs e)
        {
            Contato_Email Contato_Email = new Contato_Email(this);

            Contato_Email.ShowDialog();
        }
    }
}