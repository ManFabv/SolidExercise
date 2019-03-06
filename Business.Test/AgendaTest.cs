using System;
using System.IO;
using Domain;
using NUnit.Framework;

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
        private string path;

        [SetUp]
        public void SetUp()
        {
            agenda = new Agenda();

            contacto_JL = new Contacto("Jose", "Lopez", new DateTime(2015, 5, 10));
            contacto_JP = new Contacto("Juan", "Perez", new DateTime(1984, 4, 28));

            entrada_JL = new Entrada("San Martin 200", TipoEntrada.Domicilio);
            entrada_JP = new Entrada("25 de Mayo 1000", TipoEntrada.Domicilio);

            contacto_JL.Agregar(entrada_JL);
            contacto_JP.Agregar(entrada_JP);

            agenda.Agregar(contacto_JL);
            agenda.Agregar(contacto_JP);

            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"json\");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        [Test]
        public void GuardarDatosEnDisco()
        {
            var memoryStreamWriter = new MemoryStream();
            using (var writer = new StreamWriter(memoryStreamWriter))
            {
                agenda.GrabarArchivo(writer);

                Assert.That(memoryStreamWriter.Length, Is.GreaterThan(0));
            }
        }

        //TODO: TERMINAR TEST
        [Test]
        public void LeerDatosDeDisco()
        {   
            //var memoryStreamWriter = new MemoryStream();
            //using (var writer = new StreamWriter(memoryStreamWriter))
            //{
            //    agenda.GrabarArchivo(writer);

            //    using (var reader = new StreamReader(memoryStreamWriter))
            //    {
            //        var a = agenda.LeerArchivo(reader);

            //        Assert.That(agenda.Leer("Juan"), Is.EqualTo(a.Leer("Juan")));
            //    }
            //}
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
    }
}