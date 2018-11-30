using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public class PaqueteDAO 
    {
        #region Atributos

        private static SqlCommand comando;
        private static SqlConnection conexion;

        #endregion

        #region Metodo

        /// <summary>
        /// Inserta en la base de datos SQL los datos del paquete
        /// </summary>
        /// <param name="p">paquete a agregar en la base de datos</param>
        /// <returns>retorna true o false si se pudo o no guardar en la base de datos</returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            comando.CommandText = string.Format("INSERT INTO Paquetes values ('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Fernandez Lautaro");
            comando.CommandType = CommandType.Text;

            try
            {             
                conexion.Open();
                comando.ExecuteNonQuery();
                retorno = true;

            }
            catch(Exception e)
            {
                throw e;                
            }
            finally
            {               
              conexion.Close();
                               
            }

             return retorno;
        }

        #endregion

        #region Constructor

        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            PaqueteDAO.comando = new SqlCommand();          
            PaqueteDAO.comando.Connection = conexion;
        }

        #endregion
        
    }
}
