using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;
using static EntidadesInstanciables.Universidad;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region atributos

        private Queue<EClases> clasesDelDia;
        private static Random random;

        #endregion

        #region Métodos

        /// <summary>
        /// Metodo que agrega dos clases aleatorias al atriburo de cola clasesDelDia
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
        }

        /// <summary>
        /// override del metodo MostrarDatos que muestra todos los datos del profesor
        /// </summary>
        /// <returns>retorna los datos del profesor en formato string</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }

        /// <summary>
        /// Override del metodo ParticiparEnClase que muestra las clases del profesor
        /// </summary>
        /// <returns>retorna las clases del dia en formato string</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine("\nCLASES DEL DÍA: \r");
            foreach (EClases clases in this.clasesDelDia)
            {
                datos.AppendLine(clases.ToString() + "\r");
            }

            return datos.ToString();
        }

        /// <summary>
        /// override del metodo ToString para la clase profesor que retorna todos los datos del profesor
        /// </summary>
        /// <returns>todos los datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Sobrecarga del operador != entre un profesor y la clase
        /// </summary>
        /// <param name="i">profesor</param>
        /// <param name="clase">clase</param>
        /// <returns>retorna un booleano si el profesor NO da la clase o si</returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// sobrecarga del operador == entre un profesor y la clase 
        /// </summary>
        /// <param name="i">profesor</param>
        /// <param name="clase">clase</param>
        /// <returns>Retorna un booleano si el profesor da la clase o no</returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        #endregion

        #region Constructores
        public Profesor()
        {

        }

        /// <summary>
        /// contructor statico que instancia el atriburo random
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }
     
        /// <summary>
        /// Contructor de la clase profesor que inicializa todos sus campos
        /// </summary>
        /// <param name="id">legajo</param>
        /// <param name="nombre">nombre</param>
        /// <param name="apellido">apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }
        #endregion
    }
}