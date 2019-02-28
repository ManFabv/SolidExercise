using System;
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
            agenda.GrabarArchivo();

            //TODO: FALTA COMPLETAR TEST
        }

        [Test]
        public void LeerDatosDeDisco()
        {
            agenda.LeerArchivo();

            //TODO: FALTA COMPLETAR TEST
        }
    }
}