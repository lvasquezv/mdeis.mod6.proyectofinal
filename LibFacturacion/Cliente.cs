using LibEntidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibFacturacion
{
    public class Cliente : LibEntidades.AEntidad
    {


        public int Nit { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }

        public override string NombreEntidad => "Cliente";

        public Cliente()
        {
            Nit = -1;
            Nombres = "Nuevo Cliente";
            Apellidos = "Sin Apellidos";
            Direccion = "";
            Estado = LibEntidades.Constante._ESTADO_ACTIVO;
        }
        public Cliente(Cliente cliente)
        {
            cargar(cliente.obtenerDiccionario());
        }
        public Cliente(Dictionary<string, object> d)
        {
            cargar(d);
        }

        public override Dictionary<string, object> obtenerDiccionario()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Nit", Nit);
            d.Add("Nombres", Nombres);
            d.Add("Apellidos", Apellidos);
            d.Add("Direccion", Direccion);
            d.Add("Estado", Estado);
            return d;
        }


        public override string toStr()
        {
            return Nombres + " " + Apellidos + " (" + Nit+")";
        }

        public override void cargar(Dictionary<string, object> datos)
        {
            Nit = int.Parse(datos["Nit"].ToString());
            Nombres = datos["Nombres"].ToString();
            Apellidos = datos["Apellidos"].ToString();
            Direccion = datos["Direccion"].ToString();
            Estado = datos["Estado"].ToString();
        }

        public override Dictionary<string, object> obtenerDiccionarioPK()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Nit", Nit);
            return d;
        }
    }
}
