using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Domain
{
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
    }
}