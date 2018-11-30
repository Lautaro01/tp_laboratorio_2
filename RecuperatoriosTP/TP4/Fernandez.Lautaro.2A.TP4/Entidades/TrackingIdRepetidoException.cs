using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// exepcion para los TrackingId repetidos con mensaje personalizado
        /// </summary>
        /// <param name="mensaje">Mensaje</param>
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        {

        }

        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje,inner)
        {

        }
    }
}
