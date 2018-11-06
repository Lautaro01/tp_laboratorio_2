using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        #region Atributos

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #endregion

        #region Propiedades  
        /// <summary>
        /// propiedad de lectura y escritura para el campo Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                if (!Object.Equals(null, value))
                {
                    this.alumnos = value;
                }
            }
        }

        /// <summary>
        /// propiedad de lectura y escritura para el campo Instructores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                if (!Object.Equals(null, value))
                {
                    this.profesores = value;
                }
            }
        }

        /// <summary>
        /// propiedad de lectura y escritura para el campo Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                if (!Object.Equals(null, value))
                {
                    this.jornada = value;
                }

            }
        }

        /// <summary>
        /// Indezador del atriburo Jornada
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>Retorna la jornada del indice especificado</returns>
        public Jornada this[int i]
        {
            get
            {
                Jornada retorno;

                if(i >= 0 && i < this.Jornadas.Count)
                {
                    retorno = this.Jornadas[i];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }

                return retorno;
            }
            set
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    this.jornada.Add(value);
                }
            }
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Guarda una tipo de dato univercidad en formato XmL
        /// </summary>
        /// <param name="uni">Dato que se va a guardar</param>
        /// <returns>Retorna verdadero si se puedo guardar</returns>
        public static bool Guardar(Universidad uni)
        {
            return new Xml<Universidad>().Guardar(AppDomain.CurrentDomain.BaseDirectory + @"\Universidad.xml", uni);          
        }

        /// <summary>
        /// Muestra todos los datos de la univercidad
        /// </summary>
        /// <param name="uni">Univercidad</param>
        /// <returns>retorna todos los datos de la univercidad en formato string</returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine("JORNADA: ");
            foreach (Jornada jornadasEnUnivercidad in uni.Jornadas)
            {
                datos.AppendLine(jornadasEnUnivercidad.ToString());
            }

            datos.AppendLine("ALUMNOS: ");
            foreach (Alumno alumnosEnUnivercidad in uni.Alumnos)
            {
                datos.AppendLine(alumnosEnUnivercidad.ToString());
            }

            datos.AppendLine("<------------------------------------------------>\r\n");

            datos.AppendLine("PROFESORES: ");
            foreach (Profesor profesoresEnUnivercidad in uni.Instructores)
            {
                datos.AppendLine(profesoresEnUnivercidad.ToString());
            }

            datos.AppendLine("<------------------------------------------------>");

            return datos.ToString();
        }
        
        /// <summary>
        /// overrride del metodo ToString que retorna todos los datos de la univercidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

        #region Operadores
        /// <summary>
        /// Sobrecarga del operador != entre una universidad y un alumno
        /// </summary>
        /// <param name="g">Univercidad</param>
        /// <param name="a">alumno</param>
        /// <returns>retorna un booleano dependiando si el alumno es distinto (no esta) en la univercidad o no</returns>
        public static bool operator !=(Universidad g,Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobrecarga del operador != entre una univercidad y un profesor
        /// </summary>
        /// <param name="g">Univercidad</param>
        /// <param name="a">profesor</param>
        /// <returns>retorna un booleano dependiando si el profesor es distinto (no esta) en la univercidad o no</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// sobrecarga del != entre una universidad y una clase
        /// </summary>
        /// <param name="u">univercidad</param>
        /// <param name="clase">clase</param>
        /// <returns>retorna un profesor que NO pueda dar la clase</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profesor = null;

            foreach (Profesor profesorEnUniversidad in u.Instructores)
            {
                if (profesorEnUniversidad != clase)
                {
                    profesor = profesorEnUniversidad;
                    break;
                }
            }

            if (object.Equals(profesor, null))
            {
                throw new SinProfesorException();
            }

            return profesor;
        }

        /// <summary>
        /// Sobrecarga del operador == entre una universidad y un alumno
        /// </summary>
        /// <param name="g">univercidad</param>
        /// <param name="a">alumno</param>
        /// <returns>retorna un booleano dependiendo si el alumno esta en esta univercidad o no</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            if (!object.Equals(g, null))
            {
                foreach (Alumno alumnoEnUnivercidad in g.Alumnos)
                {
                    if (alumnoEnUnivercidad == a)
                    {
                        retorno = true;
                        break;
                    }
                }
            }


            return retorno;
        }


        /// <summary>
        /// Sobrecarga del operador == entre una universidad y un profesor
        /// </summary>
        /// <param name="g">univercidad</param>
        /// <param name="a">profesor</param>
        /// <returns>retorna un booleano dependiendo si el profesor esta en esta univercidad o no</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            if (!object.Equals(g, null))
            {
                foreach (Profesor profeEnUnivercidad in g.Instructores)
                {
                    if (profeEnUnivercidad == i)
                    {
                        retorno = true;
                        break;
                    }
                }
            }


            return retorno;
        }

        /// <summary>
        /// sobrecarga del == entre una universidad y una clase
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="clase">clase</param>
        /// <returns>retorna un profesor que  pueda dar la clase</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor profesor = null;

            foreach (Profesor profesorEnUniversidad in u.Instructores)
            {
                if (profesorEnUniversidad == clase)
                {
                    profesor = profesorEnUniversidad;
                    break;
                }
            }

            if (object.Equals(profesor, null))
            {
                throw new SinProfesorException();
            }

            return profesor;
        }


        /// <summary>
        /// sobrecarga del operador + entre una universidad y una clase
        /// </summary>
        /// <param name="g">univercidad</param>
        /// <param name="clase">clase</param>
        /// <returns>retorna la univercidad con la clase agregada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor = g == clase;
            Jornada jornada = new Jornada(clase, profesor);

            foreach (Alumno alumnosEnUnivercidad in g.Alumnos)
            {                
                if(alumnosEnUnivercidad == clase)
                {
                    jornada += alumnosEnUnivercidad;
                }               
            }

            g.Jornadas.Add(jornada);

            return g;
        }

        /// <summary>
        /// Sobrecarga del operador + entre una universidad y un alumno
        /// </summary>
        /// <param name="u">univercidad</param>
        /// <param name="a">alumno</param>
        /// <returns>retorna una universidad con el alumno agregado</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }

        /// <summary>
        /// sobrecarda del operador + entre una universidad y un profesor
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="i">profesor</param>
        /// <returns>retorna la univercidad con el profesor agregado</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(u != i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }


        

        #endregion

        #region Constructor

        public Universidad()
        {
            this.Instructores = new List<Profesor>();
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
        }

        #endregion

        #region Enumerado
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion
    }
}
