# mdeis.mod6.proyectofinal
Caso de estudio implementado por el grupo para el modulo 6 Arquitectura de Software

Nombre Caso de Estudio: 
 - 
 Facturación y Pagos
 
Integrantes de Grupo:
 - 
 - Martha Valdés Padrón
 - Johnny Felix Suri Mamani
 - Luis Rolando Vasquez Velasquez

Se tienen implementados por proyectos para separar la logica de cada modulo, por ello contamos con los siguientes proyectos:
 - LibEntidad: Proyecto que manejara la logica de la persistencia, ya sea Base de datos o como el caso que se implemento en archivos. Ademas define clase abstracta que deben implementar las entidades que se requiera usar. Contiene las siguientes clases en su raiz:
   - AEntidad: clase abstracta que define los metodos basicos que debe implementar cualquier entidad para que pueda ser procesado con cualquier persistencia que se desee usar (BD, archivo). 
   - GestorPersistencia: clase que funciona como un Singleton, solo ayuda a definir una sola instancia de persistencia.
   - Constante: clase donde se define algunos valores constantes para ser usados, por el momento solo el estado se tiene: activo e inactivo.
   - Persistencia: submodulo, donde vamos a definir la interfaz y las diferentes implementaciones de persistencia que queramos (lo que vendria a estar implementadose el patron Repository). Contiene las siguientes interfaces y clases :
     - IPersistencia: interfaz que define los metodos que van a tener cualquier forma de persistencia: insertar, modificar, eliminar, etc.
     - PersistenciaArchivo: clase que implementa la interfaz IPersistencia, que se maneja a nivel de archivos. Ha sido implementado en su totalidad.
     - PersistenciaBDSql: clase que implementa la interfaz IPersistencia, que se maneja a nivel de base de datos sql. No ha sido implementado.
 - LibFacturacion: Proyecto que contiene las entidades del modulo de facturacion. Contiene las siguientes clases (todas heredan de la clase abstracta AEntidad) (todas ademas se inicializan con un Diccionario de datos, lo que vendria a estar aplicandose el patron Value Object):
   - Cliente 
   - Factura
   - FacturaItem
   - FormaDePago
   - Pago
 - LibInventario: Proyecto que contiene las entidades del modulo inventario. Contiene las siguientes clases (todas heredan de la clase abstracta AEntidad):
   - Producto
 - LibUtilidades: Proyecto que no se esta usando aun, pero que contiene clases de utilidad como un gestor de encriptacion y otro de manejo de archivos. por el momento obsoleto.
 - TestConsola: Proyecto que se ha usado para poder probar lo implementado.
