using System;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class ValidarNulos
    {
        [TestMethod]
        public void ValidarNulosAlumnos()
        {
            Alumno alumnoUno = new Alumno(1, "Pepito", "Paredes", "42000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            /*Verifico que el alumno no es NULL*/
            Assert.IsNotNull(alumnoUno);
            /*Verifico sus campos*/
            Assert.IsNotNull(alumnoUno.Nombre, "El nombre no debe ser nulo");
            Assert.IsNotNull(alumnoUno.Apellido, "El Apellido no debe ser nulo");
            Assert.IsNotNull(alumnoUno.DNI, "El DNI no debe ser nulo");

            Alumno alumnoDos = new Alumno(2, "MalNombre123", "MalApellido123", "123123", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            Assert.AreNotEqual(alumnoDos.DNI, 0, "DNI no debería ser 0.");
            Assert.AreEqual(alumnoDos.Nombre, "", "El nombre es erroneo este deberia inicializarce en un string vacio");
            Assert.AreEqual(alumnoDos.Apellido, "", "El Apellido es erroneo este deberia inicializarce en un string vacio");
        }

        [TestMethod]
        public void ValidarNulosProfesor()
        {
            Profesor profesor = new Profesor(3, "profesor", "apellido", "43000000", Persona.ENacionalidad.Argentino);
            /*Verifico que el profesor no es NULL*/
            Assert.IsNotNull(profesor);
            /*Verifico sus campos*/
            Assert.IsNotNull(profesor.Nombre, "El nombre no debe ser nulo");
            Assert.IsNotNull(profesor.Apellido, "El Apellido no debe ser nulo");
            Assert.IsNotNull(profesor.DNI, "El DNI no debe ser nulo");

            Profesor profesorDos = new Profesor(3, "error1233", "error123", "44000000", Persona.ENacionalidad.Argentino);
            Assert.AreNotEqual(profesorDos.DNI, 0, "DNI no debería ser 0.");
            Assert.AreEqual(profesorDos.Nombre, "", "El nombre es erroneo este deberia inicializarce en un string vacio");
            Assert.AreEqual(profesorDos.Apellido, "", "El Apellido es erroneo este deberia inicializarce en un string vacio");

        }

        [TestMethod]
        public void ValidarNulosJornada()
        {
            Profesor profesorJornada = new Profesor(3, "Nombre", "Apellido", "45000000", Persona.ENacionalidad.Argentino);
            Jornada jornada = new Jornada(Universidad.EClases.Legislacion, profesorJornada);

            Assert.IsNotNull(jornada.Instructor, "el profesor de jornada no debería ser null.");
            Assert.IsNotNull(jornada.Alumnos, "los alumnos de jornada no debería ser null.");
            Assert.IsNotNull(jornada.Clase, "la clase de jornada no debería ser null.");

        }

        [TestMethod]
        public void VerificarAtributosNulosUniversidad()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Alumnos, "los alumnos no deberian ser null.");
            Assert.IsNotNull(universidad.Instructores, "el profesor no debería ser null.");
            Assert.IsNotNull(universidad.Jornadas, "la jornada no debería ser null.");
        }
    }
}
