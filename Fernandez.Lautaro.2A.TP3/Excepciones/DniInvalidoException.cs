using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private const string mensajeBase = "El formato del DNI no es correcto. Este debe ser numérico y tener de 1 a 8 caracteres inclusive para documentos argentinos u 8 caracteres para documentos extranjeros.";

        

        public DniInvalidoException() : base(mensajeBase)
        {

        }

        public DniInvalidoException(string message, Exception e) : base(message, e)
        {

        }

        public DniInvalidoException(Exception e) : this(mensajeBase, e)
        {

        }

        public DniInvalidoException(string message) : this(message, null)
        {

        }
    }
}
