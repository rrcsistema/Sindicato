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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Sindicato
{
    public partial class Relatorio_Pessoal : Form
    {
        public static string linha;

        public Relatorio_Pessoal()
        {
            InitializeComponent();

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

                    if (linha.EndsWith(","))
                    {
                        linha = linha.Remove(linha.Length - 1);
                    }
                    if (linha != string.Empty)
                    {
                        string sql = "SELECT TBpessoal.id,"
+ " CASE WHEN nome <> '' THEN CAST(nome AS nvarchar) ELSE '' END AS nome"
+ " ,CASE WHEN Estado_Civil <> '' THEN + 'Estado Cívil: ' + CAST(Estado_Civil AS nvarchar) ELSE '' END AS Estado_Civil"
+ " ,CASE WHEN rua <> '' or numero <> '' or bairro <> '' or cidade <> '' THEN + 'ENDEREÇO: ' + CAST(rua AS nvarchar) + ' - ' + cast(numero AS nvarchar) + ' - ' + cast(bairro AS nvarchar) + ' - ' + cast(cidade AS nvarchar) ELSE '' END AS Rua"
+ " ,replace(replace(replace(replace(replace(replace(replace(replace(CASE WHEN Fone <> '' or celular <> '' or celular_01 <> '' or celular_02 <> '' 	 THEN + 'CONTATO(S): ' + '(' + cast(COALESCE(SUBSTRING(Fone,1,2),'') + ') ' + SUBSTRING(Fone, 3, 4) + ' - ' + SUBSTRING(Fone,7,4) AS NVARCHAR) + ' / ' + '(' + CAST(COALESCE(SUBSTRING(Celular, 1, 2),'') + ') ' + COALESCE(SUBSTRING(Celular, 3, 5),'') + ' - ' + COALESCE(SUBSTRING(Celular, 8, 4),'') AS NVARCHAR) + ' / ' + '(' + CAST(SUBSTRING(Celular_01, 1, 2) + ') ' + SUBSTRING(Celular_01, 3, 5) + ' - ' + SUBSTRING(Celular_01, 8, 4) AS NVARCHAR) + ' / ' + '(' + CAST(SUBSTRING(Celular_02, 1, 2) + ') ' + SUBSTRING(Celular_02, 3, 5) + ' - ' "
+ " + SUBSTRING(Celular_02, 8, 4) AS NVARCHAR) ELSE '' END, ' / ()  -  / ()  - ',''),' / (  )       -  / (  )       - ',''),' / ()  -  / (  )       - ',''),' / ()  - ',''),' / (  )       - ',''),'(  )     -  / ',''),'()  -  / ',''),'(  )      -  / ','') AS Celular"
+ " ,CASE WHEN email <> '' THEN + 'E-MAIL: ' + CAST(email AS nvarchar) ELSE '' END AS email"
+ " ,CASE WHEN Escolaridade <> '' then cast (Escolaridade AS nvarchar) else '' END AS Escolaridade"
+ " ,CASE WHEN Cursos <> '' THEN Cursos ELSE '' END AS Cursos"
+ " FROM TBpessoal where TBpessoal.id in (" + linha + ")";

                        SqlDataAdapter dscmd = new SqlDataAdapter(sql, conn);
                        DataSet ds = new DataSet();

                        dscmd.Fill(ds, "tbpessoal");

                        FrmRelatorio_Pessoal objRpt = new FrmRelatorio_Pessoal();


                        var caminho = Path.GetFullPath("~/pasta") + "\\FrmRelatorio_Pessoal.rpt";

                        objRpt.Load(caminho);

                        objRpt.SetDataSource(ds.Tables["tbpessoal"]);

                        objRpt.SetDataSource(ds.Tables["tbhistorico_trabalho"]);

                        // Atualizar usuario e senha do banco de dados

                        objRpt.SetDatabaseLogon("sa", "#1qwer0987");

                        crvRelatorio_Pessoal.ReportSource = objRpt;
                        crvRelatorio_Pessoal.Refresh();

                        Conexao.fecharConexao();
                    }
                    else
                    {

                        linha = "1";

                        string sql = "SELECT"
+ " CASE WHEN nome <> '' THEN CAST(nome AS nvarchar) ELSE '' END AS nome"
+ " ,CASE WHEN Estado_Civil <> '' THEN + 'Estado Cívil: ' + CAST(Estado_Civil AS nvarchar) ELSE '' END AS Estado_Civil"
+ " ,CASE WHEN rua <> '' or numero <> '' or bairro <> '' or cidade <> '' THEN + 'ENDEREÇO: ' + CAST(rua AS nvarchar) + ' - ' + cast(numero AS nvarchar) + ' - ' + cast(bairro AS nvarchar) + ' - ' + cast(cidade AS nvarchar) ELSE '' END AS Rua"
+ " ,replace(replace(replace(replace(replace(replace(replace(replace(CASE WHEN Fone <> '' or celular <> '' or celular_01 <> '' or celular_02 <> '' 	 THEN + 'CONTATO(S): ' + '(' + cast(COALESCE(SUBSTRING(Fone,1,2),'') + ') ' + SUBSTRING(Fone, 3, 4) + ' - ' + SUBSTRING(Fone,7,4) AS NVARCHAR) + ' / ' + '(' + CAST(COALESCE(SUBSTRING(Celular, 1, 2),'') + ') ' + COALESCE(SUBSTRING(Celular, 3, 5),'') + ' - ' + COALESCE(SUBSTRING(Celular, 8, 4),'') AS NVARCHAR) + ' / ' + '(' + CAST(SUBSTRING(Celular_01, 1, 2) + ') ' + SUBSTRING(Celular_01, 3, 5) + ' - ' + SUBSTRING(Celular_01, 8, 4) AS NVARCHAR) + ' / ' + '(' + CAST(SUBSTRING(Celular_02, 1, 2) + ') ' + SUBSTRING(Celular_02, 3, 5) + ' - ' "
+ " + SUBSTRING(Celular_02, 8, 4) AS NVARCHAR) ELSE '' END, ' / ()  -  / ()  - ',''),' / (  )       -  / (  )       - ',''),' / ()  -  / (  )       - ',''),' / ()  - ',''),' / (  )       - ',''),'(  )     -  / ',''),'()  -  / ',''),'(  )      -  / ','') AS Celular"
+ " ,CASE WHEN email <> '' THEN + 'E-MAIL: ' + CAST(email AS nvarchar) ELSE '' END AS email"
+ " ,CASE WHEN Escolaridade <> '' then cast (Escolaridade AS nvarchar) else '' END AS Escolaridade"
+ " ,CASE WHEN Cursos <> '' THEN Cursos ELSE '' END AS Cursos"
+ " FROM TBpessoal where TBpessoal.id in (" + linha + ")";

                        SqlDataAdapter dscmd = new SqlDataAdapter(sql, conn);
                        DataSet ds = new DataSet();

                        dscmd.Fill(ds, "tbpessoal");

                        FrmRelatorio_Pessoal objRpt = new FrmRelatorio_Pessoal();

                        var caminho = Path.GetFullPath("~/pasta") + "\\FrmRelatorio_Pessoal.rpt";

                        objRpt.Load(caminho);

                        objRpt.SetDataSource(ds.Tables["tbpessoal"]);

                        crvRelatorio_Pessoal.ReportSource = objRpt;
                        crvRelatorio_Pessoal.Refresh();

                        Conexao.fecharConexao();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Favor entrar em contato com administrador da rede.");
            }
        }
    }
}