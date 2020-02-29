using LibEntidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibFacturacion
{
    public class Pago : LibEntidades.AEntidad
    {
        public Cliente Cliente { get; set; }
        public Factura Factura { get; set; }
        public FormaDePago FormaDePago { get; set; }
        public DateTime Fecha { get; set; }
        public float Monto { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Estado { get; set; }

        public override string NombreEntidad => "Pago";

        public Pago()
        {
            Cliente = new Cliente();
            Factura = new Factura();
            FormaDePago = new FormaDePago();
            Fecha = DateTime.Now;
            Monto = 0;
            FechaVencimiento = DateTime.Now;
            Estado = LibEntidades.Constante._ESTADO_ACTIVO;
        }
        public Pago(Pago pago)
        {

        }
        public Pago(Dictionary<string, object> datos)
        {
            cargar(datos);
        }

        public override Dictionary<string, object> obtenerDiccionario()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Cliente", Cliente.Nit);
            d.Add("Factura", Factura.CodigoControl);
            d.Add("FormaDePago", FormaDePago.Codigo);
            d.Add("Fecha", Fecha);
            d.Add("Monto", Monto);
            d.Add("FechaVencimiento", FechaVencimiento);
            d.Add("Estado", Estado);
            return d;
        }

        public string obtenerNombre()
        {
            return "Pago";
        }

        public override string toStr()
        {
            return Cliente.Nit + " - (" + Factura.CodigoControl + ") - " + FormaDePago.Codigo;
        }
        public override void cargar(Dictionary<string, object> datos)
        {
            Dictionary<string, object> dcliente = new Dictionary<string, object>();
            dcliente.Add("Nit", int.Parse(datos["Cliente"].ToString()));
            List<Dictionary<string, object>> listaCliente = GestorPersistencia.Persistencia().obtener(Cliente.NombreEntidad, dcliente);
            Dictionary<string, object>[] arrayCliente = listaCliente.ToArray();
            Cliente = new Cliente(arrayCliente[0]);

            Dictionary<string, object> dfactura = new Dictionary<string, object>();
            dfactura.Add("CodigoControl", datos["Factura"].ToString());
            Factura = new Factura(((Dictionary<string, object>[])GestorPersistencia.Persistencia().obtener(Factura.NombreEntidad, dfactura).ToArray())[0]);

            Dictionary<string, object> dformadepago = new Dictionary<string, object>();
            dformadepago.Add("Codigo", int.Parse(datos["FormaDePago"].ToString()));
            FormaDePago = new FormaDePago(((Dictionary<string, object>[])GestorPersistencia.Persistencia().obtener(FormaDePago.NombreEntidad, dformadepago).ToArray())[0]);

            Fecha = DateTime.Parse(datos["Fecha"].ToString());
            Monto = float.Parse(datos["Monto"].ToString());
            FechaVencimiento = DateTime.Parse(datos["FechaVencimiento"].ToString());
            Estado = datos["Estado"].ToString();
        }

        public override Dictionary<string, object> obtenerDiccionarioPK()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Cliente", Cliente.Nit);
            d.Add("Factura", Factura.CodigoControl);            
            return d;
        }
    }
}
