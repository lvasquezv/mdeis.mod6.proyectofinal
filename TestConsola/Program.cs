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
            LibEntidades.GestorPersistencia.Persistencia().insertar(p);
            LibInventario.Producto p1 = new LibInventario.Producto();
            p1.Nombre = "Grano de girasol";
            p1.Codigo = "G02";
            p1.Descripcion = "material de grano de girasol";
            LibEntidades.GestorPersistencia.Persistencia().insertar(p1);


        }
    }
}
