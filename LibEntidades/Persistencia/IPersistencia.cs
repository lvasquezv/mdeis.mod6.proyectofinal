using System;
using System.Collections.Generic;
using System.Text;

namespace LibEntidades.Persistencia
{
    public interface IPersistencia
    {
        void insertar(AEntidad e);
        void modificar(AEntidad e);
        void eliminar(AEntidad e);
        AEntidad obtener(string nombreEntidad, Dictionary<string,object> parametros);
        AEntidad obtenerTodos(string nombreEntidad);
    }
}
