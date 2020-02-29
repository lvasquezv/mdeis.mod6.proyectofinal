using System;
using System.Collections.Generic;
using System.Text;

namespace LibEntidades.Persistencia
{
    public class PersistenciaBDSql : IPersistencia
    {
        public void eliminar(AEntidad e)
        {
            throw new NotImplementedException();
        }

        public bool existe(AEntidad e)
        {
            throw new NotImplementedException();
        }

        public void insertar(AEntidad e)
        {
            throw new NotImplementedException();
        }

        public void modificar(AEntidad e, Dictionary<string, object> pksInicial)
        {
            throw new NotImplementedException();
        }

        public List<Dictionary<string, object>> obtener(string nombreEntidad, Dictionary<string, object> parametros)
        {
            throw new NotImplementedException();
        }

        public List<Dictionary<string, object>> obtenerTodos(string nombreEntidad)
        {
            throw new NotImplementedException();
        }
    }
}
