using System;
using System.IO;
using Domain;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace Test
{
    [TestFixture()]
    class AgendaTest
    {
        private Agenda agenda;
        private Contacto contacto_JL;
        private Contacto contacto_JP;
        private Entrada entrada_JL;
        private Entrada entrada_JP;
        private IAlmacenamiento almacenamiento;
        private string path;

        [SetUp]
        public void SetUp()
        {
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"json\");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var stream = new MemoryStream();
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);

            almacenamiento = new Almacenamiento(reader, writer);
            agenda = new Agenda(almacenamiento);

            contacto_JL = new Contacto("Jose", "Lopez", new DateTime(2015, 5, 10));
            contacto_JP = new Contacto("Juan", "Perez", new DateTime(1984, 4, 28));

            entrada_JL = new Entrada("San Martin 200", TipoEntrada.Domicilio);
            entrada_JP = new Entrada("25 de Mayo 1000", TipoEntrada.Domicilio);

            contacto_JL.Agregar(entrada_JL);
            contacto_JP.Agregar(entrada_JP);

            agenda.Agregar(contacto_JL);
            agenda.Agregar(contacto_JP);
        }

        [Test]
        public void GuardarDatosEnDisco()
        {
            agenda.GrabarArchivo();
        }

        [Test]
        public void LeerDatosDeDisco()
        {
            var a = agenda.LeerArchivo();
        }

        [Test]
        public void BuscarApellidoYNombreIntercambiado()
        {
            Assert.True(agenda.Contiene("Lopez Jose"));
        }

        [Test]
        public void BuscarApellidoYNombreCompletoInvalido()
        {
            Assert.False(agenda.Contiene("Jose Perez"));
        }

        [Test]
        public void BuscarEnEntradaInvalido()
        {
            Assert.False(agenda.Contiene("San Mayo 1000"));
        }

        [Test]
        public void BuscarEnEntradaMezcladosDatos()
        {
            Assert.True(agenda.Contiene("San Martin Lopez"));
        }

        [Test]
        public void BuscarEnEntradaComienzaConValido()
        {
            Assert.True(agenda.ComienzaCon("Lop"));
        }

        [Test]
        public void BuscarEnEntradaComienzaConInvalido()
        {
            Assert.False(agenda.ComienzaCon("pez"));
        }
    }
}