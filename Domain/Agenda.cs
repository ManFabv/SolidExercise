using System;
using System.Collections.Generic;

namespace Domain
{
    public class Agenda
    {
        private List<Contacto> contactos = new List<Contacto>();

        public void Agregar(Contacto contacto)
        {
            throw new NotImplementedException();
        }

        public Contacto Leer()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contacto> LeerTodos(string expresionDeBusqueda)
        {
            throw new NotImplementedException();
        }
    }
}
