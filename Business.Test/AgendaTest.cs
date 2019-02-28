using System;
using Domain;
using NUnit.Framework;
using Persistence;

namespace Test
{
    [TestFixture()]
    class AgendaTest
    {
        private Agenda agenda;
        private Contacto contacto;
        private Entrada entrada;

        [SetUp]
        public void SetUp()
        {
            agenda = new Agenda();

            contacto = new Contacto("Jose", "Lopez", new DateTime(2015, 5, 10));

            entrada = new Entrada("San Martin 200", TipoEntrada.Domicilio);

            contacto.Agregar(entrada);

            agenda.Agregar(contacto);
        }

        [Test]
        public void GuardarDatosEnDisco()
        {
            var guardar = new GuardarHaciaArchivo();

            guardar.GrabarArchivo(agenda);

            var existe = guardar.ExistenDatos();

            Assert.IsTrue(existe);
        }

        [Test]
        public void LeerDatosDeDisco()
        {
            var leer = new LeerDesdeArchivo();

            leer.LeerArchivo();

            var existe = leer.ExistenDatos();

            Assert.IsTrue(existe);
        }
    }
}