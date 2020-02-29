using LibEntidades;
using LibFacturacion;
using LibInventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            LibEntidades.GestorPersistencia gestor = new LibEntidades.GestorPersistencia(new LibEntidades.Persistencia.PersistenciaArchivo("D:\\mdeis"));
            LibInventario.Producto p = new LibInventario.Producto();
            p.Nombre = "Grano de soya";
            p.Codigo = "G01";
            p.Descripcion = "material de grano de soya";
            p.PrecioReferencial = 10;
            LibEntidades.GestorPersistencia.Persistencia().insertar(p);
            LibInventario.Producto p1 = new LibInventario.Producto();
            p1.Nombre = "Grano de girasol";
            p1.Codigo = "G02";
            p1.Descripcion = "material de grano de girasol";
            p1.PrecioReferencial = 25;
            LibEntidades.GestorPersistencia.Persistencia().insertar(p1);
            LibFacturacion.Cliente c = new LibFacturacion.Cliente();
            c.Nit = 1;
            c.Nombres = "Juan";
            c.Apellidos = "Perez";
            c.Direccion = "Calle 21";
            c.Estado = LibEntidades.Constante._ESTADO_ACTIVO;
            LibEntidades.GestorPersistencia.Persistencia().insertar(c);
            FormaDePago fdp = new FormaDePago();
            fdp.Codigo = "F1";
            fdp.Nombre = "Al Contado";
            fdp.Estado = Constante._ESTADO_ACTIVO;
            GestorPersistencia.Persistencia().insertar(fdp);
            Factura f = new Factura();
            f.CodigoControl = "11-AA-N0";
            f.Cliente = c;
            f.FormaDePago = fdp;
            f.Nro = 1;
            f.NroAutorizacion = 111111;
            f.Fecha = DateTime.Now;
            f.MontoTotal = 100;


        }
    }
}
