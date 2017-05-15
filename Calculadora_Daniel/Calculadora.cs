using Operador;
using System;
using System.Windows.Forms;

namespace Calculadora_Daniel
{
    public partial class Calculadora : Form
    {
        //private Entidade entidade = new Entidade();
        //private readonly Igual _igual = new Igual();
        //private readonly Multiplicar _multiplicar = new Multiplicar();
        //private readonly Dividir _dividir = new Dividir();
        //private readonly Somar _somar = new Somar();
        //private readonly Dividir _subtrair = new Dividir();
        //private readonly CE _limpeza = new CE();
        private readonly Operacoes _opera = new Operacoes();

        private void Calculadora_Load(object sender, EventArgs e)
        {
            txtConta.Text = "";
            _opera.Limpar();
        }

        public Calculadora()
        {
            InitializeComponent();
        }

        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if (!txtConta.Text.Contains(","))
                txtConta.Text += @",";
        }

        private void botoes_Click(object sender, EventArgs e)
        {
            txtConta.Text += ((Button)sender).Text;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtConta.Text))
            {
                txtConta.Text = _opera.RealizarOperacao(double.Parse(txtConta.Text)).ToString();
                _opera.Limpar();
            }
            else
                MessageBox.Show(@"Escreva o número para realizar a conta.");
        }

        private void btnOperacao_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtConta.Text))
            { 
                _opera.RealizarOperacao(double.Parse(txtConta.Text));
            
                _opera.Operacao(((Button)sender).Text);
                txtConta.Text = "";
            }
            else
                MessageBox.Show(@"Escreva o número para realizar a conta.");
        }

        private void txtConta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
