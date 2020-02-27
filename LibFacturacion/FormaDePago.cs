using LibEntidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibFacturacion
{
    public class FormaDePago : LibEntidades.AEntidad
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }

        public override string NombreEntidad => "FormaDePago";


        public override Dictionary<string, object> obtenerDiccionario()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Codigo", Codigo);
            d.Add("Nombre", Nombre);
            d.Add("Direccion", Direccion);
            d.Add("Estado", Estado);
            return d;
        }
        public override string toStr()
        {
            return Nombre + "(" + Codigo + ")";
        }
        public override void cargar(Dictionary<string, object> datos)
        {
            Codigo = datos["Codigo"].ToString();
            Nombre = datos["Nombre"].ToString();
            Direccion = datos["Direccion"].ToString();
            Estado = datos["Estado"].ToString();
        }
    }
}
