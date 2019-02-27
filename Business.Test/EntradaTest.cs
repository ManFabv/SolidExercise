using Domain;
using NUnit.Framework;

namespace Business
{
    [TestFixture]
    class EntradaTest
    {
        /// <summary>
        /// TODO: FALTA TEST DEL CONSTRUCTOR
        /// </summary>

        Entrada entrada;

        [SetUp]
        public void SetUp()
        {
            entrada = new Entrada("345678", TipoEntrada.Telefono);
        }

        [Test]
        public void BuscarDatoNullEnEntradas()
        {
            var resultado = entrada.Contiene(null);

            Assert.That(resultado, Is.False);
        }

        [Test]
        public void BuscarDatoVacioEnEntradas()
        {
            var resultado = entrada.Contiene(string.Empty);

            Assert.That(resultado, Is.True);
        }

        [Test]
        public void BuscarDatoExistenteEnEntradas()
        {
            var resultado = entrada.Contiene("345");

            Assert.That(resultado, Is.True);
        }

        [Test]
        public void BuscarDatoInexistenteEnEntradas()
        {
            var resultado = entrada.Contiene("999");

            Assert.That(resultado, Is.False);
        }
    }
}
