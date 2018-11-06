using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        #region Métodos

        /// <summary>
        /// Guarda un tipo de dato en la ruta del archivo especificada. 
        /// </summary>
        /// <param name="archivo">Ruta donde se va a guardar el archivo</param>
        /// <param name="datos">Dato a guardar</param>
        /// <returns>Retorna verdadero si se puedo realizar el guardado</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Lee un tipo de dato en la ruta del archivo especificada. 
        /// </summary>
        /// <param name="archivo">Ruta donde se va a leer el archivo</param>
        /// <param name="datos">Dato donde se guardaran los datos leidos</param>
        /// <returns>etorna verdadero si se puedo realizar la lectura y los datos leidos</returns>
        bool Leer(string archivo, out T datos);

        #endregion
    }
}
