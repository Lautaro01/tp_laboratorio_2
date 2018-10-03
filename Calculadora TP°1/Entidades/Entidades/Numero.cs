using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos        
        private double _numero; //Unico atributo de la clase Numero.
        #endregion

        #region Propiedades
        /// <summary>
        /// Setea un numero a los tipos de datos "Numero" en formato string.
        /// </summary>
        public string SetNumero
        {
            set { if (ValidarNumero(value) != 0) { this._numero = double.Parse(value); } }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Combierte un numero Binario a decimal. Si el numero no es binario se retorna un mensaje de error.
        /// </summary>
        /// <param name="binario">Numero en binario</param>
        /// <returns></returns>
        public static string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido\n";

            double cantidad = binario.Length;
            double numero = 0;
            bool flat = false;

            for (int i = 0; i < cantidad; i++)
            {
                if (binario[i] == '1' || binario[i] == '0')
                {
                    numero += int.Parse(binario[i].ToString()) * Math.Pow(2, (cantidad - 1 - i));
                }
                else
                {
                    flat = true;
                    break;
                }
            }

            if (!flat)
            {
                retorno = numero.ToString();
            }

            return retorno;
        }

        /// <summary>
        ///  Combierte un numero Decimal a Binario. Si no se puede convertir retorna un mensaje de error.
        /// </summary>
        /// <param name="numero">Numero en decimal</param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            string retorno = "Valor invalido\n";
            string numeroBinario = "";
            string numeroBinarioInvertido = "";
            string aux = numero.ToString();

            while (numero != 0)
            {
                numeroBinario += (int)numero % 2;
                numero = (int)numero / 2;
            }

            if (numero == 0)
            {
                for (int i = numeroBinario.Length - 1; i >= 0; i--)
                {
                    numeroBinarioInvertido += numeroBinario[i];
                }
                retorno = numeroBinarioInvertido;
            }
            return retorno;
        }

        /// <summary>
        /// Combierte un numero string Decimal a Binario. Si no se puede convertir retorna un mensaje de error.
        /// </summary>
        /// <param name="strNumero">Un numero en decimal con formato string</param>
        /// <returns></returns>
        public static string DecimalBinario(string strNumero)
        {
            string retorno = "";
            double aux;

            if (!double.TryParse(strNumero, out aux))
            {
                retorno = "valor invalido";
            }
            else
            {
                retorno = DecimalBinario(double.Parse(strNumero));
            }

            return retorno;
        }

        /// <summary>
        /// Valida si un numero string puede pasarse a duoble. si es posible, se retorna el valor string a double, si no, retorna 0.
        /// </summary>
        /// <param name="strNumero">Un numero en decimal con formato string</param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;

            if (!(string.IsNullOrWhiteSpace(strNumero)))
            {
                if (double.TryParse(strNumero, out retorno))
                {
                    retorno = double.Parse(strNumero);
                }
            }

            return retorno;
        }
        #endregion

        #region Constructor
        public Numero() : this(0)
        {

        }

        public Numero(double numero)
        {
            this._numero = numero;
        }

        public Numero(string strNumero)
        {
            double aux = 0;

            if (double.TryParse(strNumero, out aux))
            {
                this._numero = double.Parse(strNumero);
            }
            else
            {
                this._numero = 0;
            }

        }
        #endregion

        #region Operadores

        public static double operator -(Numero n1, Numero n2)
        {
            Numero n3 = new Numero();
            double resultado = n1._numero - n2._numero;
            n3.SetNumero = resultado.ToString();
            return n3._numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            Numero n3 = new Numero();
            double resultado = n1._numero * n2._numero;
            n3.SetNumero = resultado.ToString();
            return n3._numero;

        }

        public static double operator /(Numero n1, Numero n2)
        {

            Numero n3 = new Numero();
            double resultado = n1._numero / n2._numero;
            n3.SetNumero = resultado.ToString();
            return n3._numero;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            Numero n3 = new Numero();
            double resultado = n1._numero + n2._numero;
            n3.SetNumero = resultado.ToString();
            return n3._numero;
        }

        #endregion
    }
}
