using System;
using System.Collections.Generic;
using System.Text;

namespace LibEntidades.Persistencia
{
    public class PersistenciaArchivo : IPersistencia
    {
        //private const string SEPARADOR_CAMPOS = "";
        //  {"nombre":"Pedro","apellido":"Fernandez"}
        public string _ruta { get; set; }
        public bool _archivo_unico { get; set; }
        public PersistenciaArchivo(string ruta, bool archivoUnico)
        {
            this._ruta = ruta;
            this._archivo_unico = archivoUnico;
        }

        public void eliminar(AEntidad e)
        {
            throw new NotImplementedException();
        }

        public void insertar(AEntidad e)
        {
            throw new NotImplementedException();
        }

        public void modificar(AEntidad e)
        {
            throw new NotImplementedException();
        }

        public AEntidad obtener(string nombreEntidad, Dictionary<string, object> parametros)
        {
            throw new NotImplementedException();
        }

        public AEntidad obtenerTodos(string nombreEntidad)
        {
            throw new NotImplementedException();
        }


        private string campoToStr(string nombre, object valor)
        {
            //[{"nombre":"Pedro","apellido":"Fernandez"}
            return "\"" + nombre + "\",\"" + valor.ToString() + "\"";
        }
    }
}
