using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda un archivo de texto en el escritorio con los datos del archivo
        /// </summary>
        /// <param name="texto">String que se deese guardar</param>
        /// <param name="archivo">path o nombre del archivo</param>
        /// <returns>retorna true o false si se pudo realizar o no el guardado</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo;
            bool sobreescribir = File.Exists(path);
            try
            {
                if(!object.Equals(archivo,null))
                {
                    using (StreamWriter escritor = new StreamWriter(path, sobreescribir))
                    {
                        escritor.WriteLine(texto);
                    }
                    retorno = true;
                }
            }
            catch(Exception)
            {
                
            }

            return retorno;
        }
    }
}
