using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Domain
{
    public class Agenda
    {
        private List<Contacto> contactos = new List<Contacto>();

        public string FilePath { get; private set; }

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
            FilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"json\agenda.json");

            using (StreamReader jsonStream = File.OpenText(FilePath))
            {
                var json = jsonStream.ReadToEnd();

                return JsonConvert.DeserializeObject<Agenda>(json);
            }
        }

        public void GrabarArchivo()
        {
            var json = JsonConvert.SerializeObject(this);

            var directory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"json\");
            FilePath = directory + "agenda.json";
            Directory.CreateDirectory(directory);

            File.WriteAllText(FilePath, json);
        }
    }
}