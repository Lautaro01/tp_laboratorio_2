using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public class Changuito
    {
        private List<Producto> productos;
        private int espacioDisponible;
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        public Changuito(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito changuito, ETipo tipo) 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", changuito.productos.Count, changuito.espacioDisponible);
            sb.AppendLine("");

            foreach (Producto productosEnElchanguito in changuito.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if (productosEnElchanguito is Snacks)
                            sb.AppendLine(productosEnElchanguito.Mostrar());
                        break;
                    case ETipo.Dulce:
                        if(productosEnElchanguito is Dulce)
                            sb.AppendLine(productosEnElchanguito.Mostrar());
                        break;
                    case ETipo.Leche:
                        if (productosEnElchanguito is Leche)
                            sb.AppendLine(productosEnElchanguito.Mostrar());
                        break;
                    default:
                       
                            sb.AppendLine(productosEnElchanguito.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito changuito, Producto producto)
        {
            bool flat = false;

            if (changuito.espacioDisponible > changuito.productos.Count)
            {
                foreach (Producto productosEnElChanguito in changuito.productos)
                {
                    if (productosEnElChanguito == producto)
                    {
                        flat = true;
                    }
                        
                }

                if(!flat)
                {
                    changuito.productos.Add(producto);
                }
                
            }


            return changuito;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito changuito, Producto producto)
        {
            foreach (Producto productosEnElChanguito in changuito.productos)
            {
                if (productosEnElChanguito == producto)
                {
                    changuito.productos.Remove(producto);
                    break;
                }
            }

            return changuito;
        }
        #endregion
    }
}
