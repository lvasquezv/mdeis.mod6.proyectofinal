using LibEntidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibEntidades
{
    public class GestorPersistencia 
    {
        private static IPersistencia _persistencia;
        public GestorPersistencia(IPersistencia persistencia)
        {
            _persistencia = persistencia;            
        }
        
        public static IPersistencia Persistencia()
        {
            if (_persistencia is null)
            {
                _persistencia = new PersistenciaArchivo("c:/MDEIS/mod6/facturacion", false);
            }
            return _persistencia;
        }
    }
}
