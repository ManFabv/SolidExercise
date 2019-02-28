using System.IO;
using Domain;
using Newtonsoft.Json;

namespace Persistence
{
    public class GuardarHaciaArchivo
    {
        public void GrabarArchivo(Agenda a)
        {
            if (a == null) return;

            var json = JsonConvert.SerializeObject(a);

            string directory = Path.Combine(Directory.GetCurrentDirectory(), @"json\");
            string path = directory + "agenda.json";
            Directory.CreateDirectory(directory);

            File.WriteAllText(path, json);
        }
    }
}