using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace Sindicato
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Filtrar_Vaga Filtrar_Vaga = new Filtrar_Vaga();

            if (Application.OpenForms.OfType<Filtrar_Vaga>().Count() > 0)
            {
                // Trazendo form para frente

                Application.OpenForms["Filtrar_Vaga"].BringToFront();
            }
            else
            {
                Filtrar_Vaga.Show();
            }
        }

        private void btnPessoal_Click(object sender, EventArgs e)
        {
            Pessoal Pessoal = new Pessoal();

            if (Application.OpenForms.OfType<Pessoal>().Count() > 0)
            {
                // Trazendo form para frente

                Application.OpenForms["Pessoal"].BringToFront();
            }
            else
            {
                Pessoal.Show();
            }
        }

        private void btnCadastro_Vaga_Click(object sender, EventArgs e)
        {
            Empresa_Solicitante Empresa_Solicitante = new Empresa_Solicitante();

            if (Application.OpenForms.OfType<Empresa_Solicitante>().Count() > 0)
            {
                // Trazendo form para frente

                Application.OpenForms["Cadastro_Vaga"].BringToFront();
            }
            else
            {
                Empresa_Solicitante.Show();
            }
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnConfigurar_smtp_Click(object sender, EventArgs e)
        {
            Servidor_Email Servidor_Email = new Servidor_Email();

            if (Application.OpenForms.OfType<Servidor_Email>().Count() > 0)
            {
                // Trazendo form para frente

                Application.OpenForms["Servidor_Email"].BringToFront();
            }
            else
            {
                Servidor_Email.Show();
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            // Chamar form sem sobrepor menu iniciar

            this.WindowState = FormWindowState.Maximized;
        }

        private void Principal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.Control && e.KeyCode == Keys.F12)
            {
                // chamando tela ao pressionar CTRL + F12

                Servidor_Email Servidor_Email = new Servidor_Email();
                Servidor_Email.ShowDialog();
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            Backup backup = new Backup();
            backup.ShowDialog();
        }
    }
}