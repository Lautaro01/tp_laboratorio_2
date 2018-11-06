using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{  
    public abstract class Persona
    {
        #region Atributos

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de lectura y escritura para el campo "Apellido"
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para el campo "DNI"
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para el campo "Nacionalidad"
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para el campo "Nombre"
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de solo escritura para el campo "DNI" en formato String
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad,value);
            }
        }

        #endregion

        #region Constructores

        public Persona()
        {

        }

        /// <summary>
        /// Sobrecarga del constructor de la clase Persona que inicializa los campos "nombre", "Apellido" y "nacionalidad"
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Sobrecarga del constructor de la clase Persona que inicializa los campos "nombre", "Apellido" "dni" y "nacionalidad"
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">DNI de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido,dni.ToString(), nacionalidad)
        {

        }

        /// <summary>
        /// Sobrecarga del constructor de la clase Persona que inicializa los campos "nombre", "Apellido" "dni"(En formato string) y "nacionalidad"
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">DNI de la persona en formato string></param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Override del metodo "ToString" para la clase Persona
        /// </summary>
        /// <returns>Retorna los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendFormat("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre + "\n\r");
            datos.AppendFormat("NACIONALIDAD: " + this.Nacionalidad.ToString() + "\n\r");
            datos.AppendFormat("DNI:" + this.DNI.ToString());

            return datos.ToString();
        }

        /// <summary>
        /// Valida el DNI de una persona segun su nacionalidad y los numeros del DNI en si
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI de la persona</param>
        /// <returns>Retorna el DNI validado, en caso contrario retorna una Excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (!(nacionalidad == ENacionalidad.Argentino && (dato > 1 && dato < 89999999)))
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se coincide con el número de DNI.");
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (!((nacionalidad == ENacionalidad.Extranjero && (dato > 90000000 && dato < 99999999))))
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se coincide con el número de DNI.");
                    }
                    break;
                default:
                    break;
            }
            
         
            return dato;
        }

        /// <summary>
        /// Valida el DNI en un tipo de dato string
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI en tipo de dato string</param>
        /// <returns>Retorna en DNI validado en tipo de dato int, si el dni es incorecto tira una excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (dato.Length > 0 && dato.Length < 9 && int.TryParse(dato, out dni))
            {
                dni = this.ValidarDni(nacionalidad, dni);
            }
            else
            {
                throw new DniInvalidoException("Error en el DNI, formato incorecto");
            }

            return dni;
        }


        /// <summary>
        /// Metodo para validad que el nombre no contenga caracteres
        /// </summary>
        /// <param name="dato">El nombre a validar</param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char caracter in dato)
            {
                if (!char.IsLetter(caracter))
                {
                    dato = "";
                    break;
                }
            }


            return dato;
        }

        #endregion

        #region Enumerado
        public enum ENacionalidad
        {
        Argentino,
        Extranjero
        }
        #endregion
    }
}