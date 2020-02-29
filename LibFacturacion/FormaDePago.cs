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
        public string Estado { get; set; }

        public override string NombreEntidad => "FormaDePago";

        public FormaDePago()
        {
            Codigo = "";
            Nombre = "";
            Estado = LibEntidades.Constante._ESTADO_ACTIVO;
        }
        public FormaDePago(FormaDePago formaDePago)
        {
            cargar(formaDePago.obtenerDiccionario());
        }
        public FormaDePago(Dictionary<string, object> datos)
        {
            cargar(datos);
        }

        public override Dictionary<string, object> obtenerDiccionario()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Codigo", Codigo);
            d.Add("Nombre", Nombre);
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
            Estado = datos["Estado"].ToString();
        }

        public override Dictionary<string, object> obtenerDiccionarioPK()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Codigo", Codigo);
            return d;
        }
    }
}
