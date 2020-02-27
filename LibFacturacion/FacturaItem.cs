﻿using LibEntidades;
using LibInventario;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibFacturacion
{
    public class FacturaItem : LibEntidades.AEntidad
    {
        public Factura Factura { get; set; }
        public LibInventario.Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public float PrecioUnitario { get; set; }
        public float MontoParcial { get; set; }

        public override string NombreEntidad => "FacturaItem";


        public override Dictionary<string, object> obtenerDiccionario()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Factura", Factura.CodigoControl);
            d.Add("Producto", Producto.Codigo);
            d.Add("Cantidad", Cantidad);
            d.Add("PrecioUnitario", PrecioUnitario);
            d.Add("MontoParcial", MontoParcial);
            return d;
        }
        public override string toStr()
        {
            return Factura.CodigoControl + " - " + Producto.Nombre + " (" + Producto.Codigo + ")";
        }
        public override void cargar(Dictionary<string, object> datos)
        {            
            Dictionary<string, object> dfactura = new Dictionary<string, object>();
            dfactura.Add("CodigoControl", datos["Factura"].ToString());
            Factura = (Factura)GestorPersistencia.Persistencia().obtener(Factura.NombreEntidad, dfactura);

            Dictionary<string, object> dproducto = new Dictionary<string, object>();
            dproducto.Add("Codigo", int.Parse(datos["Producto"].ToString()));
            Producto = (Producto)GestorPersistencia.Persistencia().obtener(Producto.NombreEntidad, dproducto);

            Cantidad = int.Parse(datos["Cantidad"].ToString());
            PrecioUnitario = float.Parse(datos["PrecioUnitario"].ToString());
            MontoParcial = float.Parse(datos["MontoParcial"].ToString());
        }
    }
}
