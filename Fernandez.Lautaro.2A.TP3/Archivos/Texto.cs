using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Métodos
        /// <summary>
        /// Guarda un tipo de dato string en la ruta especificada.
        /// </summary>
        /// <param name="archivo">Ruta del archivo donde se guardaran los datos</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>retorna verdadero si se pudo guardar los datos, de lo contrario tira una excepcion</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using(StreamWriter textArch = new StreamWriter(archivo))
                {
                    textArch.WriteLine(datos);
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }


            return true;
        }

        /// <summary>
        /// Lee datos de tipo string desde la ruta especificada.
        /// </summary>
        /// <param name="archivo">Ruta del archivo a leer</param>
        /// <param name="datos">String donde se guardaran los archivos</param>
        /// <returns>retorna verdadero si se pudieron leer los datos, caso contrario larga una excepcion</returns>
        public bool Leer(string archivo, out string datos)
        {
            datos = "";
            try
            {
                using(StreamReader textArch = new StreamReader(archivo))
                {
                    datos = textArch.ReadToEnd();
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }


            return true;
        }
        #endregion
    }
}
