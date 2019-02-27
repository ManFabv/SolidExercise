using System;
using System.Linq;
using Domain;
using NUnit.Framework;

namespace Business.Test
{
    [TestFixture()]
    class ContactoTest
    {
        private Contacto juan;
        private Entrada  telefono;

        [SetUp]
        public void Setup()
        {
            juan = new Contacto("Juan", "Perez", new DateTime(1984, 4, 28));
            telefono = new Entrada("345678", TipoEntrada.Telefono);
        }

        [Test]
        public void AgregarEntradaValidaEnContacto()
        {
            juan.Agregar(telefono);

            var resultado = juan.LeerTodas().Any();

            Assert.IsTrue(resultado);
        }

        [Test]
        public void AgregarEntradaNullEnContacto()
        {
            juan.Agregar(null);

            var resultado = juan.LeerTodas().Any();

            Assert.IsFalse(resultado);
        }

        [Test]
        public void ContieneEntradaExistenteEnContacto()
        {
            juan.Agregar(telefono);

            var resultado = juan.Contiene(telefono.Valor);

            Assert.IsTrue(resultado);
        }

        [Test]
        public void ContieneEntradaInexistenteNullEnContacto()
        {
            juan.Agregar(telefono);

            var resultado = juan.Contiene(null);

            Assert.IsFalse(resultado);
        }

        [Test]
        public void ContieneEntradaInexistenteVacioEnContacto()
        {
            juan.Agregar(telefono);

            var resultado = juan.Contiene("");

            Assert.IsTrue(resultado);
        }

        [Test]
        public void ContieneEntradaInexistenteEnContacto()
        {
            juan.Agregar(telefono);

            var resultado = juan.Contiene("xxx");

            Assert.IsFalse(resultado);
        }

        [Test]
        public void ContieneEnNombre()
        {
            juan.Agregar(telefono);

            var resultado = juan.Contiene("Juan");

            Assert.IsTrue(resultado);
        }

        [Test]
        public void ContieneEnApellido()
        {
            juan.Agregar(telefono);

            var resultado = juan.Contiene("Perez");

            Assert.IsTrue(resultado);
        }

        [Test]
        public void ContieneEnEntrada()
        {
            juan.Agregar(telefono);

            var resultado = juan.Contiene("345");

            Assert.IsTrue(resultado);
        }
    }
}