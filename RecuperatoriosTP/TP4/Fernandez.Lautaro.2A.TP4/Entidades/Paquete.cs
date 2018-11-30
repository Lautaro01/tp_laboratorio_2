using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Atributos

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura de DireccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                if(!object.Equals(value, null))
                {
                    this.direccionEntrega = value;
                }
                
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura usando el enumerado EEstado
        /// </summary>
        public EEstado Estado
        {

            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del campo TrackingID
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = (object.Equals(value, null)) ? this.trackingID : value;
            }
        }
        #endregion

        #region Evento

        public event DelegadoEstado InformaEstado;
        public event DelegadoSqlError ServerError;

        #endregion

        #region Metodos

        /// <summary>
        /// Cambia de estado los paquetes cada 4 segundos
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado++;
                this.InformaEstado(null, null);
            }

            if(this.Estado == EEstado.Entregado)
            {
                if(!PaqueteDAO.Insertar(this))
                {
                    this.ServerError();
                }
            }

        }

        /// <summary>
        /// Muestra los datos del paquete su id y direccion
        /// </summary>
        /// <param name="elemento">Paquete</param>
        /// <returns>retorna los datos del paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);      
        }

        /// <summary>
        /// Sobrecarga del ToString que llama a MostrarDatos
        /// </summary>
        /// <returns>retorna los datos del paquete</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region Operadores

        /// <summary>
        /// sobrecarga del operador != entre un paquete y otro
        /// </summary>
        /// <param name="p1">Paquete</param>
        /// <param name="p2">otro Paquete</param>
        /// <returns>retorna true o false si son o no iguales</returns>
        public static bool operator !=(Paquete p1,Paquete p2)
        {
            return !(p1== p2);
        }

        /// <summary>
        /// SObrecarga del operador == entre un paquete y otro, seran iguales solo si sus ID son iguales
        /// </summary>
        /// <param name="p1">Paquete</param>
        /// <param name="p2">otro Paquete</param>
        /// <returns>retorna true o false si son o no iguales</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.TrackingID == p2.TrackingID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de la clase paquete
        /// </summary>
        /// <param name="direccionEntrega">Inicializa el campo direccionEntrega</param>
        /// <param name="trackingID">Inicializa el campo trackingID</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            DireccionEntrega = direccionEntrega;
            TrackingID = trackingID;
            Estado = EEstado.Ingresado;
        }

        #endregion

        #region Delegado

         public delegate void DelegadoEstado(object sender, EventArgs e);
         public delegate void DelegadoSqlError();

         #endregion

        #region Enumerado
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
    #endregion
    }




}
