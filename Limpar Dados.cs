using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sindicato;

namespace Sindicato
{
    public static class Limpar_Dados
    {
        //Método utilizado para limpar todos os controles do formulário
        public static void LimpaControles(Control control)
        {
            foreach (Control ctle in control.Controls)
            {
                if (ctle is TextBox)
                {
                    ((TextBox)ctle).Text = string.Empty;
                }

                if (ctle is ComboBox)
                {
                    ((ComboBox)ctle).Text = string.Empty;
                }
                if (ctle is CheckBox)
                {
                    ((CheckBox)ctle).Checked = false;
                }

                if (ctle is MaskedTextBox)
                {
                    ((MaskedTextBox)ctle).Text = string.Empty;
                }
                else if (ctle.Controls.Count > 0)
                {
                    LimpaControles(ctle);
                }


                Conexao.fecharConexao();
            }
        }
    }
}