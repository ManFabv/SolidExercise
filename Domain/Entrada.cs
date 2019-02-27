using System;

namespace Domain
{
    public enum TipoEntrada
    {
        Domicilio,
        Email,
        Telefono
    }

    public class Entrada
    {
        public string Valor { get; private set; }
        public TipoEntrada TipoEntrada { get; private set; }

        public Entrada(string valor, TipoEntrada tipoEntrada)
        {
            Valor = valor;

            TipoEntrada = tipoEntrada;
        }

        public bool Contiene(string expresionDeBusqueda)
        {
            if (expresionDeBusqueda == null) return false;
            if (string.IsNullOrWhiteSpace(expresionDeBusqueda)) return true;

            return Valor.Contains(expresionDeBusqueda);
        }
    }
}