using LibEntidades;
using System;
using System.Collections.Generic;

namespace LibFacturacion
{
    public class Factura : LibEntidades.AEntidad
    {

        public const string _ESTADO_FACTURA_PENDIENTEPAGO = "";
        public const string _ESTADO_FACTURA_PAGADO = "";
        public const string _ESTADO_FACTURA_ANULADO = "";

        private string _fact_codigocontrol;
        public string CodigoControl
        {
            get { return _fact_codigocontrol; }
            set
            {
                if (value.Length > 10) throw new InvalidOperationException("Longitud de Código Control no válida");
                _fact_codigocontrol = value;
            }
        }
        public Cliente Cliente { get; set; }
        public int Nro { get; set; }
        public double NroAutorizacion { get; set; }
        public DateTime Fecha { get; set; }
        public float MontoTotal { get; set; }
        public string Estado { get; set; }
        public FormaDePago FormaDePago { get; set; }

        public override string NombreEntidad => "Factura";

        public Factura()
        {
            CodigoControl = "";
            Cliente = new Cliente();
            Nro = -1;
            NroAutorizacion = -1;
            Fecha = DateTime.Now;
            MontoTotal = 0;
            Estado = LibEntidades.Constante._ESTADO_ACTIVO;
            FormaDePago = new FormaDePago();
        }
        public Factura(Factura factura)
        {
            cargar(factura.obtenerDiccionario());
        }
        public Factura(Dictionary<string, object> datos)
        {
            cargar(datos);
        }

        public override Dictionary<string, object> obtenerDiccionario()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("CodigoControl", CodigoControl);
            d.Add("Cliente", Cliente.Nit);
            d.Add("Nro", Nro);
            d.Add("NroAutorizacion", NroAutorizacion);
            d.Add("Fecha", Fecha);
            d.Add("MontoTotal", MontoTotal);
            d.Add("Estado", Estado);
            d.Add("FormaDePago", FormaDePago.Codigo);
            return d;
        }

        public override string toStr()
        {
            return CodigoControl;
        }
        public override void cargar(Dictionary<string, object> datos)
        {
            Dictionary<string, object> dcliente = new Dictionary<string, object>();
            dcliente.Add("Nit", int.Parse(datos["Cliente"].ToString()));
            Cliente = new Cliente(((Dictionary<string, object>[])GestorPersistencia.Persistencia().obtener(Cliente.NombreEntidad, dcliente).ToArray())[0]);

            Dictionary<string, object> dformadepago = new Dictionary<string, object>();
            dformadepago.Add("Codigo", int.Parse(datos["FormaDePago"].ToString()));
            FormaDePago = new FormaDePago(((Dictionary<string, object>[])GestorPersistencia.Persistencia().obtener(FormaDePago.NombreEntidad, dformadepago).ToArray())[0]);

            Nro = int.Parse(datos["Nro"].ToString());
            NroAutorizacion = double.Parse(datos["NroAutorizacion"].ToString());
            Fecha = DateTime.Parse(datos["Fecha"].ToString());
            MontoTotal = float.Parse(datos["MontoTotal"].ToString());
            Estado = datos["Estado"].ToString();
        }

        public override Dictionary<string, object> obtenerDiccionarioPK()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("CodigoControl", CodigoControl);
            return d;
        }
    }
}
