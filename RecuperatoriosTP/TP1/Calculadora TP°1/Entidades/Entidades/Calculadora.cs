using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Realiza una operacion entre el tipo de dato "Numero" segundo el operador asignado.
        /// </summary>
        /// <param name="num1">Tipo de dato "Numero"(a la derecha de la ecuacion)</param>
        /// <param name="num2">Tipo de dato "Numero"(a la izquierda de la ecuacion)</param>
        /// <param name="operador">Operador en tipo de dato string, define la operacion a realizar( +, - , * , / )</param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double num3 = 0;

            operador = ValidarOperador(operador);

            if (!(object.Equals(num1, null)) && !(object.Equals(num2, null)))
            {

                switch (operador)
                {
                    case "+":
                        num3 = num1 + num2;
                        break;
                    case "-":
                        num3 = num1 - num2;
                        break;
                    case "*":
                        num3 = num1 * num2;
                        break;
                    case "/":
                        num3 = num1 / num2;
                        break;
                    default:
                        num3 = num1 + num2;
                        break;
                }
            }
            return num3;
        }

        /// <summary>
        /// Valida un operador en formato string, si el operador es incorrecto se retorna un +.
        /// </summary>
        /// <param name="operador">Operador en formato string</param>
        /// <returns></returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";

            if (!(object.Equals(operador, null)))
            {
                if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
                {
                    retorno = operador;
                }
            }

            return retorno;
        }

        #endregion
    }
}
