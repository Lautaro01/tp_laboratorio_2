using System;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Excepciones;
using Archivos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class ValidarExcepciones
    {
        [TestMethod]
        public void AlumnoRepetidoValidar()
        {
            /*Se va a validar que cuando los alumnos no se repitan, no lance una excepcion*/
            bool error = false;
            try
            {
                Universidad universidad = new Universidad();

                Alumno alumnoUno = new Alumno(1, "nombre", "apellido", "42000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Alumno alumnoDos = new Alumno(2, "nombre", "apellido", "42000001", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                universidad += alumnoUno;
                universidad += alumnoDos;
            }
            catch (AlumnoRepetidoException)
            {
                error = true;
            }
            Assert.IsFalse(error, "no deberia tirar una excepción ya que no se repite los alumnos");



            /*Se va a validar que cuando los alumnos se repitan, lance una excepcion*/
            error = false;
            try
            {
                Universidad universidad = new Universidad();

                Alumno alumnoTres = new Alumno(3, "nombre", "apellido", "43000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
                Alumno CopiaAlumnoTres = new Alumno(3, "nombre", "apellido", "43000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
                universidad += alumnoTres;
                universidad += CopiaAlumnoTres;
            }
            catch (AlumnoRepetidoException)
            {
                error = true;
            }
            Assert.IsTrue(error, "se deberia tirar una excepcion ya que se repiten los alumnos, estos son identicos");
        }
        [TestMethod]
        public void SinProfesorValidar()
        {
            bool error = false;
            Universidad universidad = new Universidad();
            try
            {
                universidad += Universidad.EClases.SPD;
            }
            catch (SinProfesorException)
            {
                error = true;
            }

            Assert.IsTrue(error, "se deberia tirar  una excepcion  ya que no hay profesores de la clase spd.");

            error = false;
        }

        [TestMethod]
        public void VerificarArchivosException()
        {
            Universidad universidad = new Universidad();
            Alumno alumnoUno = new Alumno(1, "nombre", "apellido", "42000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno alumnoDos = new Alumno(2, "nombre", "apellido", "42000001", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            universidad += alumnoUno;
            universidad += alumnoDos;

            Texto texto = new Texto();
            bool error = false;
            
            try
            {
                texto.Guardar("", "datos a guardar pero sin ruta");
            }
            catch(ArchivosException)
            {
                error = true;
            }

            Assert.IsTrue(error, "se deberia tirar una excepcion ya que no se espesifico la ruta para guardar los datos");

            error = false;
            try
            {
                
                texto.Leer("",out string guardarDatosLeidos);
            }
            catch (ArchivosException)
            {
                error = true;
            }

            Assert.IsTrue(error, "se deberia tirar una excepcion ya que no se espesifico la ruta para leer los datos");

            Xml<Universidad> xml = new Xml<Universidad>();
            string datosLeidos = "";
            error = false;

            try
            {
                xml.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\univercidad.xml", universidad);
                xml.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\univercidad.xml", out universidad);
                datosLeidos = universidad.ToString();
            }
            catch (ArchivosException)
            {
                error = true;
            }
            Assert.IsFalse(error, "no deberia lansar ningun error ni excepcion.");
        }
    }
}
