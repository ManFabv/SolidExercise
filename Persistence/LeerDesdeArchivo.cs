using System.IO;
using Domain;
using Newtonsoft.Json;

namespace Persistence
{
    public class LeerDesdeArchivo
    {
        public string FilePath { get; private set; }

        public Agenda LeerArchivo()
        {
            FilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"json\agenda.json");

            using (StreamReader jsonStream = File.OpenText(FilePath))
            {
                var json = jsonStream.ReadToEnd();

                return JsonConvert.DeserializeObject<Agenda>(json);
            }
        }

        public bool ExistenDatos()
        {
            return File.Exists(FilePath);
        }
    }
}