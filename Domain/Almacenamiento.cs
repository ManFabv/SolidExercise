using System.IO;
using Newtonsoft.Json;

namespace Domain
{
    public class Almacenamiento : IAlmacenamiento
    {
        private TextReader Reader { get; set; }
        private TextWriter Writer { get; set; }

        public Almacenamiento(TextReader reader, TextWriter writer)
        {
            Reader = reader;
            Writer = writer;
        }

        public Agenda Leer()
        {
            string json = Reader.ReadToEnd();
            Reader.Close();

            return JsonConvert.DeserializeObject<Agenda>(json);
        }

        public void Escribir(Agenda agenda)
        {
            var json = JsonConvert.SerializeObject(this);

            Writer.WriteLine(json);
            Writer.Close();
        }
    }
}
