using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static EntidadesInstanciables.Universidad;
using static EntidadesAbstractas.Universitario;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos

        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #endregion

        #region Contructores

        /// <summary>
        /// Contrsutor de la clase universitario sin parametros, no inicializa nada
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Contructor de la clase alumno, inicializa los campos del alumno.
        /// </summary>
        /// <param name="id">Legajo del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI del alumno en formato string</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        public Alumno(int id,string nombre, string apellido,string dni,ENacionalidad nacionalidad, EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Contructor de la clase alumno, inicializa todos los campos del alumno.
        /// </summary>
        /// <param name="id">>Legajo del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        /// <param name="estadoCuenta">Estado de la cuenta del alumno,</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma,EEstadoCuenta estadoCuenta) : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos
        
        /// <summary>
        /// Override del metodo MostrarDatos para la clase Alumno, muestra todos los datos del alumno
        /// </summary>
        /// <returns>Retorna los datos del alumno en formato string</returns>
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine(base.MostrarDatos());
            datos.AppendFormat("ESTADO DE CUENTA: "+ this.estadoCuenta.ToString() +"\r\n");
            datos.AppendLine(this.ParticiparEnClase());

            return datos.ToString();
        }

        
        /// <summary>
        /// Override del metodo ParticiparEnClase, muestra en que clase participa o toma el alumno
        /// </summary>
        /// <returns>Retorna "TOMA LA CLASE DE " y la clase que toma el alumno en formato string</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma.ToString();
        }

        /// <summary>
        /// Override del metodo ToString para la clase alumno. muestra o llama al metodo MostrarDatos
        /// </summary>
        /// <returns>Retorna los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Sobrecarga del operador != entre un alumno y una clase
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna un booleano dependiando si el alumno es distinto a la clase</returns>
        public static bool operator !=(Alumno a,EClases clase)
        {
            return (a.claseQueToma != clase);
        }

        /// <summary>
        /// Sobrecarga del operador != entre un alumno y una clase
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorena un booleano dependiando si el alumno toma la clase o no(el alumno deudor no participa en la clase)</returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor);
        }

        #endregion

        #region enumerado
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion
    }
}
