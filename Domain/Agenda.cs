using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Agenda
    {
        public List<Contacto> contactos = new List<Contacto>();

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
    }
}