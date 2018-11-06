using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;
using static EntidadesInstanciables.Universidad;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Atributos

        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de lectura y escritura para la lista del Alumnos de la jornada
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                if (!object.Equals(value, null))
                {
                    this.alumnos = value;
                }
            }
        }


        /// <summary>
        /// Propiedad de lectura y escritura para el campo clase de la jornada
        /// </summary>
        public EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }


        /// <summary>
        /// Propiedad de lectura y escritura para el campo Instructor de la clase jornada
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion
       
        #region Constructores

        /// <summary>
        /// Constructor sin parametros de la clase jonada, instancia la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de la clase jonada, inicializa todos sus campos, la lista de alumnos comienza en 0
        /// </summary>
        /// <param name="clase">La clase de la jornada</param>
        /// <param name="instructor">el instructor de la jornada</param>
        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        #endregion

        #region Operadores

        /// <summary>
        /// sobrecarga del operador != entre una Jornada y un alumno
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a comprar en la jornada</param>
        /// <returns>Retorna un booleano si el alumno es distinto a la jornada o no</returns>
        public static bool operator !=(Jornada j,Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Sobrecarde del operador + que suma un alumno a una jornada
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna la jornada con el alumno</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j == a)
            {
                j.Alumnos.Add(a);
                foreach (Alumno item in j.Alumnos)
                {
                    if (item == a && !object.Equals(a, item))
                    {
                        j.Alumnos.Remove(a);
                        throw new AlumnoRepetidoException();
                    }
                }
            }

            return j;
        }

        /// <summary>
        /// sobrecarga del operador == entre una jornada y un alumno, si el alumno asiste a esa jornada o no segun la clase que toma
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna un booleano segun si el alumno asiste a esa joranada o no segun la clase que toma</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.Clase;
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Metodo que lee los datos de una jornada
        /// </summary>
        /// <returns>retorna los datos de la jornada en string</returns>
        public static string Leer()
        {
            new Texto().Leer(@".\Jornada.txt", out string datos);
            return datos;
        }

        /// <summary>
        /// Metodo que guarda los dajos de la joranda espesificada en fotmato .txt
        /// </summary>
        /// <param name="jornada">Jornada a guardar en .txt</param>
        /// <returns>Retorna un booleano si se pudo guardar o no</returns>
        public static bool Guardar(Jornada jornada)
        {
            return new Texto().Guardar(AppDomain.CurrentDomain.BaseDirectory + @"\Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Override del metodo ToString para la clase Jornada, Muestra todos los datos de la jornada
        /// </summary>
        /// <returns>Retorna los datos de la jornada en un string</returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.Append("CLASE DE " + this.Clase.ToString());
            datos.AppendLine(" POR " + this.Instructor.ToString());
            datos.AppendLine("ALUMNOS:");
            foreach (Alumno alumnos in this.Alumnos)
            {
                datos.AppendLine(alumnos.ToString());
            }
            datos.AppendLine("<------------------------------------------------>");

            return datos.ToString();
        }
        #endregion
    }
}
