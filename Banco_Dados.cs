using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Sindicato
{
    class Conexao
    {
        // vamos nos conectar ao SQL Server Express e à base de dados
        // locadora usando Windows Authentication
        private static string servidor = (@"server=servidor;database=DBrrcsistema;Uid=sa;Pwd=#1qwer0987;");

        // representa a conexão com o banco
        private static SqlConnection conexao = null;

        // método que permite obter a conexão
        public static SqlConnection obterConexao()
        {
            // vamos criar a conexão
            conexao = new SqlConnection(servidor);

            // a conexão foi feita com sucesso?
            try
            {
                // abre a conexão e a devolve ao chamador do método
                conexao.Open();
            }
            catch (SqlException)
            {
                conexao = null;
                // ops! o que aconteceu?
                // uma boa idéia aqui é gravar a exceção em um arquivo de log
            }

            return conexao;
        }

        public static void fecharConexao()
        {
            if (conexao != null)
            {
                conexao.Close();
            }
        }
    }
}