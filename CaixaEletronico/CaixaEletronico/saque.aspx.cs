using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CaixaEletronico
{
    public partial class saque : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSaque_Click(object sender, EventArgs e)
        {
            int valor;
            double num;

            lblErro.Text = "";
            lblResultado.Text = "";
            btnContinuar.Visible = false;
            btnVoltar.Visible = false;

            //valida valor digitado para saber se é numérico
            if (double.TryParse(txtValorSaque.Text, out num))
            {
                //corrigindo separador decimal
                txtValorSaque.Text = txtValorSaque.Text.Replace(",", ".");
                valor = Convert.ToInt32(Convert.ToDouble(txtValorSaque.Text));

                //verifia se valor digitado pode ser sacado com as notas disponíveis
                if ((valor % 10) != 0)
                {
                    //caso não seja possível sacar, pergunta para o usuário se ele gostaria de sacar um valor viável
                    valor = valor - (valor % 10);
                    lblErro.Text = "O valor sacado será de " + valor + ". Pois só possuimos notas disponíveis de R$ 100,00, R$ 50,00, R$ 20,00 e R$ 10,00";
                    btnContinuar.Visible = true;
                    btnVoltar.Visible = true;
                }
                else
                {
                    //chama a função que calcula a quantidade de cada cédula para o saque
                    CalculaSaque(valor);
                }
            }
            else
            {
                lblErro.Text = "Digite somente números";
            }
        }

        //Calcula quantidade de notas de cada saque
        private void CalculaSaque(int valor)
        {
            lblResultado.Text = "Valor do Saque: R$ " + valor + " -";
            int contador = 0;

            //verifica se é possível sacar notas de 100
            if ((valor / 100) >= 1)
            {
                //se for possível calcula quantas notas de 100 poderá sacar e exibe para o usuário
                lblResultado.Text += " " + (valor / 100) + " nota(s) de " + 100;
                //atualiza o valor restante para poder sacar com as outras notas
                valor = valor - ((valor / 100) * 100);
                contador++;
            }

            //verifica se é possível sacar notas de 50
            if ((valor / 50) >= 1)
            {
                //verifica se é a última nota a ser exibida para o usuário e adiciona a letra "e"
                ColocaE(valor, 50, contador);
                // se for possível calcula quantas notas de 50 poderá sacar e exibe para o usuário 
                lblResultado.Text += " " + (valor / 50) + " nota(s) de " + 50;
                //atualiza o valor restante para poder sacar com as outras notas
                valor = valor - ((valor / 50) * 50);
                contador++;
            }

            //verifica se é possível sacar notas de 20
            if ((valor / 20) >= 1)
            {
                //verifica se é a última nota a ser exibida para o usuário e adiciona a letra "e"
                ColocaE(valor, 20, contador);
                // se for possível calcula quantas notas de 20 poderá sacar e exibe para o usuário 
                lblResultado.Text += " " + (valor / 20) + " nota(s) de " + 20;
                //atualiza o valor restante para poder sacar com as outras notas
                valor = valor - ((valor / 20) * 20);
                contador++;
            }

            //verifica se é possível sacar notas de 10
            if ((valor / 10) >= 1)
            {
                //verifica se é a última nota a ser exibida para o usuário e adiciona a letra "e"
                ColocaE(valor, 10, contador);
                //se for possível calcula quantas notas de 10 poderá sacar e exibe para o usuário
                lblResultado.Text += " " + (valor / 10) + " nota(s) de " + 10;
            }
        }

        //coloca o "e" antes de exibir a últuma nota
        private void ColocaE(int valor, int cedula, int contador)
        {
            //verifica se o saque será realizado por mais de uma nota e se essa nota é a última da sequência
            if (contador > 0 && (valor - ((valor / cedula) * cedula)) == 0)
            {
                lblResultado.Text += " e";
            }
        }

        //Caso o usuário deseje continuar o saque com as notas viáveis, essa funçao chama o função que calcula o saque
        protected void BtnContinuar_Click(object sender, EventArgs e)
        {
            int valor;

            txtValorSaque.Text = txtValorSaque.Text.Replace(",", ".");
            valor = Convert.ToInt32(Convert.ToDouble(txtValorSaque.Text));
            valor = valor - (valor % 10);
            txtValorSaque.Text = "" + valor;

            CalculaSaque(valor);
            btnContinuar.Visible = false;
            btnVoltar.Visible = false;
        }

        //volta a posição inicial de saque
        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            btnContinuar.Visible = false;
            btnVoltar.Visible = false;

            txtValorSaque.Text = "";

            lblErro.Text = "";
            lblResultado.Text = "";
        }
    }
}