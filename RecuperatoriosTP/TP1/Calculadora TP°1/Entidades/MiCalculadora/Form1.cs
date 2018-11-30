using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
            this.cmbOperador.Text = "+";
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hasta pronto!, espero que tenga un muy lindo dia.\n                                   :)");
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!(this.lblResultado.Text == ""))
            {
                this.lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            }
            else
            {
                this.lblResultado.Text = "Valor invalido";
            }

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (!(this.lblResultado.Text == ""))
            {
                this.lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            }
            else
            {
                this.lblResultado.Text = "Valor invalido";
            }
        }



        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = this.txtNumero1.Text;
            string numero2 = this.txtNumero2.Text;
            string operador = this.cmbOperador.Text;

            double retornar = Operar(numero1, numero2, operador);
            this.lblResultado.Text = retornar.ToString();
        }

        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "                            ";
        }

        private static double Operar(string numero1, string numero2, string operar)
        {
            Numero numeroUno = new Numero();
            Numero numeroDos = new Numero();

            numeroUno.SetNumero = numero1;
            numeroDos.SetNumero = numero2;

            return Entidades.Calculadora.Operar(numeroUno, numeroDos, operar);
        }

    }
}
