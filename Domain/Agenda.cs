using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Domain
{
    public static class StringExtensionMethods
    {
        public static bool ComienzaCon(this string palabra, string filtro)
        {
            return filtro.Split(new[] {' '}).All(p => palabra.StartsWith(p, true, CultureInfo.InvariantCulture));
        }
    }

    public class Agenda
    {
        private List<Contacto> contactos = new List<Contacto>();

        private IAlmacenamiento Almacenamiento { get; set; }

        public Agenda(IAlmacenamiento almacenamiento)
        {
            Almacenamiento = almacenamiento;
        }

        public void Agregar(Contacto contacto)
        {
            if(contacto == null) return;
            if(contactos.Contains(contacto)) return;

            contactos.Add(contacto);
        }

        public Contacto Leer(string filtro)
        {
            if (string.IsNullOrEmpty(filtro)) return null;

            return contactos.FirstOrDefault(item => item.Contiene(filtro));
        }

        public IEnumerable<Contacto> LeerTodos()
        {
            return contactos;
        }

        public Agenda LeerArchivo()
        {
            return Almacenamiento?.Leer();
        }

        public void GrabarArchivo()
        {
            Almacenamiento?.Escribir(this);
        }

        public bool Contiene(string filtro)
        {
            return contactos.Any(contacto => contacto.Contiene(filtro));
        }

        public bool ComienzaCon(string filtro)
        {
            return contactos.Any(contacto => contacto.ComienzaCon(filtro));
        }
    }
}