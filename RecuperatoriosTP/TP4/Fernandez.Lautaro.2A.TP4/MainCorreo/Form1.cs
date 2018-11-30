using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        /// <summary>
        /// Se agrega al constructor de FrmPpal la instancia del correo y el evento FrmClosing
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
            this.FormClosing += new FormClosingEventHandler(this.FrmPpal_FormClosing);
        }

        #region Atributos
        private Correo correo;
        #endregion

        #region Metodos

        /// <summary>
        /// Limpia los estados de las listBox y los actualiza segun su estado
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            
            foreach (Paquete paquetes in this.correo.Paquetes)
            {              
                switch(paquetes.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(paquetes);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(paquetes);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(paquetes);
                        break;
                }
            }
        }

        /// <summary>
        /// Al cerrar se llama a la funcion FinEntregas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }
   
        /// <summary>
        /// El boton Agregar agregara la ID y la direccion del paquete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);

            paquete.InformaEstado += new Paquete.DelegadoEstado(this.paq_InformaEstado);
            paquete.ServerError += new Paquete.DelegadoSqlError(this.SqlError);
            try
            {
                this.correo += paquete;
            }
            catch (TrackingIdRepetidoException exception)
            {
                MessageBox.Show(exception.Message, "ERROR!, el Paquete esta repetido.", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            this.ActualizarEstados();
        }

        /// <summary>
        /// Mostrara y guardara los datos del paquete
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(!object.Equals(elemento,null))
            {
                string datos = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text = datos;
                try
                {
                    datos.Guardar("salida.txt");
                }
                catch
                {
                    MessageBox.Show("Error!, se produjo un error al guardar el fichero");
                }
            }
            else
            {
                MessageBox.Show("Error!, elemento nulo");
            }
            
        }

        /// <summary>
        /// Mostrata la informacion en la lista de texto inferior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)this.correo);
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void FinEntregas()
        {

        }

        private void SqlError()
        {
            MessageBox.Show("ERROR! se a producido un error en la base de datos.");
        }
        #endregion

        
    }
}
