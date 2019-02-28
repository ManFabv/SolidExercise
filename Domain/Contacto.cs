using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Contacto
    {
        public List<Entrada> entradas = new List<Entrada>();

        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public DateTime? Nacimiento { get; private set; }

        public Contacto(string nombre, string apellido, DateTime? nacimiento = null)
        {
            Nombre = nombre;
            Apellido = apellido;
            Nacimiento = nacimiento;
        }

        public void Agregar(Entrada entrada)
        {
            if(entrada is null) return;

            entradas.Add(entrada);
        }

        public bool Contiene(string filtro)
        {
            if(filtro is null) return false;
            if(filtro == "") return true;

            return Nombre.Contains(filtro) || Apellido.Contains(filtro) || LeerTodas().Any(x => x.Contiene(filtro));
        }

        public IEnumerable<Entrada> LeerTodas()
        {
            return entradas;
        }
    }
}