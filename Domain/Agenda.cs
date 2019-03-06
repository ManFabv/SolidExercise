using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public Agenda LeerArchivo(TextReader reader)
        {
            string line = string.Empty;
            string json = string.Empty;

            while ((line = reader.ReadLine()) != null)
            {
                json += line;
            }

            return JsonConvert.DeserializeObject<Agenda>(json);
        }

        public void GrabarArchivo(TextWriter writer)
        {
            var json = JsonConvert.SerializeObject(this);

            writer.WriteLine(json);
            writer.Flush();
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