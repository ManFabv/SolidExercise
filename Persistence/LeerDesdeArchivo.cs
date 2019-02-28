using System.IO;
using Domain;
using Newtonsoft.Json;

namespace Persistence
{
    public class LeerDesdeArchivo
    {
        public Agenda LeerArchivo()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"json\agenda.json");

            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();

                return JsonConvert.DeserializeObject<Agenda>(json);
            }
        }
    }
}