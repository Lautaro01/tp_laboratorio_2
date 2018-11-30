using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Test_Unitarios
{
    [TestClass]
    public class TestCorreo
    {
        [TestMethod]
        public void TestPaquetesCorreo()
        {
            Correo correoTestUno = new Correo();
            bool verificar = false;
            try
            {
                Assert.IsNotNull(correoTestUno.Paquetes);
                verificar = true;
            }
            catch(Exception e)
            {
                throw e;
            }

            Assert.IsTrue(verificar, "El correo se instancio correctamente");

        }

        [TestMethod]
        public void TestPaquetesTrackingID()
        {
            
            Correo correoTestDos = new Correo();
            Paquete paqueteUno = new Paquete("Calle falsa", "123456");
            Paquete paqueteDos = new Paquete("Calle falsa", "123456");
            bool error = false;

            try
            {
                correoTestDos += paqueteUno;
                correoTestDos += paqueteDos;
            }
            catch(TrackingIdRepetidoException e)
            {
                error = true;   
            }

            Assert.IsTrue(error, "Se lanzo una excepcion ya que no se pueden agregar dos paqueres del mismo ID");

        }
    }
}
