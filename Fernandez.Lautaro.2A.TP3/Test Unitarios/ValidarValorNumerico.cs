using System;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class ValidarValorNumerico
    {
        [TestMethod]
        public void VerificacionDNI()
        {
            /*Validar DNI correcto segun el rango         (si el rango y la nacionalidad concuerdan, no deberia haber error)*/
            bool error = false;
            try
            {
                Alumno alumnoUno = new Alumno(1, "Pepito", "Paredes", "42000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            }
            catch(NacionalidadInvalidaException)
            {
                error = true;
            }
            /*Error deberia ser false*/
            Assert.IsFalse(error, "No deberia tirar una excepcion ya que el DNI es correcto");

            /*Validar DNI incorecto segundo el rango*/
            try
            {
                Alumno alumnoDos = new Alumno(2, "Menganito", "Piso", "123", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
            }
            catch (NacionalidadInvalidaException)
            {
                error = true;
            }
            /*Error deberia ser true*/
            Assert.IsTrue(error, "Deberia tirar una excepcion ya que el dni es incorrecto segun el rango y la nacionalidad");

        }

        [TestMethod]
        public void VerificacionDNIincorecto()
        {
            bool error = false;

            try
            {
                Alumno alumnoTres = new Alumno(33, "Cachito", "techo", "abcdefgh", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            }
            catch (DniInvalidoException)
            {
                error = true;
            }
            Assert.IsTrue(error, "deberia tirar una excepción ya que el dni no es numero");

            error = false;

            try
            {
                Alumno alumnoCuatro = new Alumno(34, "Cachito", "techo", "99999900", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
            }
            catch (DniInvalidoException)
            {
                error = true;
            }
            Assert.IsFalse(error, "no deberia tirar una excepción ya que el dni es numero y correcto");

        }

    }
}
