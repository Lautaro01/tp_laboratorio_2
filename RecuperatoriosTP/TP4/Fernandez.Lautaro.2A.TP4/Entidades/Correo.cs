using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Thread> mockPaquete;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedad

        /// <summary>
        /// Propiedad de lectura y escritura para el campo "Paquetes"
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                if (!object.Equals(value, null))
                {
                    this.paquetes = value;
                }
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Recorre la lista de hilos finalizandolos
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread hilos in this.mockPaquete)
            {
                hilos.Abort();
            }
        }

        /// <summary>
        /// Mostrara los datos del paquete que este en la lista
        /// </summary>
        /// <param name="elementos">Paquete</param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string datos = "";
            if (!object.Equals(elementos, null))
            {
                foreach (Paquete item in ((Correo)elementos).Paquetes)
                {
                    datos += string.Format("{0} para {1} ({2})\r\n", item.TrackingID, item.DireccionEntrega, item.Estado.ToString());
                }
            }
            return datos;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa los campos de tipo lista paquetes y mockPaquetes
        /// </summary>
        public Correo()
        {
            this.mockPaquete = new List<Thread>();
            this.Paquetes = new List<Paquete>();
        }

        #endregion

        #region Operador

        /// <summary>
        /// Sobrecarga del operador + para sumar un paquete a la lista de paquetes del correo
        /// </summary>
        /// <param name="c">Correo</param>
        /// <param name="p">Paquete a sumar</param>
        /// <returns>Retorna el correo con el paquete agregado</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            if (!object.Equals(c, null) && !object.Equals(p, null))
            { 
                foreach (Paquete paquetes in c.Paquetes)
                {
                    if(paquetes == p)
                    {
                    throw new TrackingIdRepetidoException("Este paquete ya esta en la lista");
                    }
                }
                 c.Paquetes.Add(p);
                Thread ciclo = new Thread(p.MockCicloDeVida);
                c.mockPaquete.Add(ciclo);
                ciclo.Start();
            }
            return c;
        }

        #endregion
    }
}
