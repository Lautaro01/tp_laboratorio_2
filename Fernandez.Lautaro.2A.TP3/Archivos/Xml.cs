using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region Métodos
        /// <summary>
        /// Guarda un tipo de dato en un archivo de tipo XmL.
        /// </summary>
        /// <param name="archivo">Ruta del archivo donde se guardaran los dato</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>retorna verdadero si se pudo guardar los datos, de lo contrario tira una excepcion</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlTextWriter xmlTextWriter = new XmlTextWriter(archivo, Encoding.UTF8);
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                serializer.Serialize(xmlTextWriter, datos);

                xmlTextWriter.Close();
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return true;
        }


        /// <summary>
        /// Lee un tipo de dato XmL.
        /// </summary>
        /// <param name="archivo">Ruta del archivo donde se van a leer los dato</param>
        /// <param name="datos">Campo donde se guardaran los datos</param>
        /// <returns>Retorna verdadero si se pudieron leer los datos, caso contrario larga una excepcion</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlTextReader xmlTextReader = new XmlTextReader(archivo);
                XmlSerializer DeSerializer = new XmlSerializer(typeof(T));

                datos = (T)DeSerializer.Deserialize(xmlTextReader);

                xmlTextReader.Close();
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
