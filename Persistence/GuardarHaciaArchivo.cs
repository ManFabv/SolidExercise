using System.IO;
using Domain;
using Newtonsoft.Json;

namespace Persistence
{
    public class GuardarHaciaArchivo
    {
        public string FilePath { get; private set; }

        public void GrabarArchivo(Agenda a)
        {
            if (a == null) return;

            var json = JsonConvert.SerializeObject(a);

            var directory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"json\");
            FilePath = directory + "agenda.json";
            Directory.CreateDirectory(directory);

            File.WriteAllText(FilePath, json);
        }

        public bool ExistenDatos()
        {
            return File.Exists(FilePath);
        }
    }
}