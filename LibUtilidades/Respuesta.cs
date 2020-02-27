using System;
using System.Collections.Generic;
using System.Text;

namespace LibUtilidades
{
    public class Respuesta
    {
        public bool Estado { get; set; }
        public string Mensaje { get; set; }
        public object Dato { get; set; }

        public Respuesta()
        {
            this.Estado = false;
            this.Mensaje = "";
            this.Dato = null;
        }

        public Respuesta(bool estado, string mensaje, object dato)
        {
            this.Estado = estado;
            this.Mensaje = mensaje;
            this.Dato = dato;
        }
    }
}
