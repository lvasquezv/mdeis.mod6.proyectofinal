using System;
using System.Collections.Generic;
using System.Text;

namespace LibEntidades.Persistencia
{
    public interface IPersistencia
    {
        bool existe(AEntidad e);
        void insertar(AEntidad e);
        void modificar(AEntidad e, Dictionary<string, object> pksInicial);
        void eliminar(AEntidad e);
        List<Dictionary<string, object>> obtener(string nombreEntidad, Dictionary<string,object> parametros);
        List<Dictionary<string, object>> obtenerTodos(string nombreEntidad);
    }
}
