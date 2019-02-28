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
        private Contacto contacto;
        private Entrada entrada;
        private string path;

        [SetUp]
        public void SetUp()
        {
            agenda = new Agenda();

            contacto = new Contacto("Jose", "Lopez", new DateTime(2015, 5, 10));

            entrada = new Entrada("San Martin 200", TipoEntrada.Domicilio);

            contacto.Agregar(entrada);

            agenda.Agregar(contacto);

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

        [Test]
        public void LeerDatosDeDisco()
        {
            //TODO: TERMINAR TEST
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
    }
}