using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
     public abstract class Universitario : Persona
     {
        #region Atributos
        private int legajo;
        #endregion

        #region Métodos

        /// <summary>
        /// Overrride del metodo Equals para la clase Universitario, verifica si el objeto es de tipo universitario 
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>Retorna verdadero si el objeto es de tipo universidad</returns>
        public override bool Equals(object obj)
        {
            return (obj is Universitario);
        }


        /// <summary>
        /// Muestra todos los datos del universitario
        /// </summary>
        /// <returns>Retorna los datos del universitaro en una cadena string</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine(base.ToString());
            datos.AppendFormat("LEGAJO NÚMERO: " + this.legajo);

            return datos.ToString();
        }


        /// <summary>
        /// Metoro abstracto de la clase Universidad.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion

        #region Operadores

        /// <summary>
        /// Sobrecarga del operator != entre un univertario y otro
        /// </summary>
        /// <param name="pg1">Universitario 1 a comprar</param>
        /// <param name="pg2">Universitario 2 a comprar</param>
        /// <returns>Retorna un booleano dependiando si son iguales o no(segun su tipo, legajo y DNI</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Sobrecarga del operador == entre un universitario y otro
        /// </summary>
        /// <param name="pg1">Universitario 1 a comprar</param>
        /// <param name="pg2">Universitario 2 a comprar</param>
        /// <returns>Retorna un booleano dependiando si son iguales o no(segun su tipo, legajo y DNI)</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.Equals(pg1) && pg2.Equals(pg2) && ((pg1.DNI == pg2.DNI) || (pg1.legajo == pg2.legajo))); 
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Contructor vacio de la clase Universitario
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Contructor de la clase universitario para inizualizar los parametros del universitario
        /// </summary>
        /// <param name="legajo">Lejago del Universitario</param>
        /// <param name="nombre">Nombre del Universitario</param>
        /// <param name="apellido">Apellido del Universitario</param>
        /// <param name="dni">DNI del Universitario en formato string</param>
        /// <param name="nacionalidad">Nacionalidad del Universitario</param>
        public Universitario(int legajo, string nombre, string apellido,string dni,ENacionalidad nacionalidad) : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion     
     }
}
