using LibEntidades;
using System;
using System.Collections.Generic;

namespace LibInventario
{
    public class Producto : LibEntidades.AEntidad
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float PrecioReferencial { get; set; }

        public override string NombreEntidad => "Producto";


        public override Dictionary<string, object> obtenerDiccionario()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Codigo", Codigo);
            d.Add("Nombre", Nombre);
            d.Add("Descripcion", Descripcion);
            d.Add("PrecioReferencial", PrecioReferencial);
            return d;
        }
        public override string toStr()
        {
            return Nombre + " (" + Codigo + ")";
        }
        public override void cargar(Dictionary<string, object> datos)
        {
            Codigo = datos["Codigo"].ToString();
            Nombre = datos["Nombre"].ToString();
            Descripcion = datos["Descripcion"].ToString();
            PrecioReferencial = float.Parse(datos["PrecioReferencial"].ToString());
        }
    }
}
