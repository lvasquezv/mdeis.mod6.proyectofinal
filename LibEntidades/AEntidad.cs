using System;
using System.Collections.Generic;
using System.Text;

namespace LibEntidades
{
    public abstract class AEntidad
    {
        public abstract string NombreEntidad { get; }
        abstract public Dictionary<string, object>  obtenerDiccionario();
        abstract public Dictionary<string, object> obtenerDiccionarioPK();
        abstract public string toStr();
        abstract public void cargar(Dictionary<string, object> datos);
    }
}
