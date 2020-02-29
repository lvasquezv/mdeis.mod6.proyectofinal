using System;
using System.Collections.Generic;
using System.IO;

namespace LibEntidades.Persistencia
{
    public class PersistenciaArchivo : IPersistencia
    {
        //private const string SEPARADOR_CAMPOS = "";
        //  {"nombre":"Pedro","apellido":"Fernandez"}
        public string _carpeta { get; set; }
       
        public PersistenciaArchivo(string ruta)
        {
            this._carpeta = ruta;
            if (!(Directory.Exists(ruta)))
            {
                Directory.CreateDirectory(ruta);
            }
        }

        public void eliminar(AEntidad e)
        {
            string rutaFichero = Path.Combine(_carpeta, e.NombreEntidad + ".dat");
            string rutaFicheroTemp = Path.Combine(_carpeta, e.NombreEntidad + "Temp" + ".dat");
            if (!File.Exists(rutaFichero))
                File.Create(rutaFichero);
            else
            {                
                using (StreamWriter fileWrite = new StreamWriter(@rutaFicheroTemp))
                {
                    using (StreamReader fielRead = new StreamReader(@rutaFichero))
                    {
                        String line;
                        while ((line = fielRead.ReadLine()) != null)
                        {
                            if (!line.Equals(entidadToStr(e)))
                            {
                                fileWrite.WriteLine(line);
                            }
                        }
                    }
                }
                //aqui se renombrea el archivo temporal
                File.Delete(rutaFichero);
                File.Move(rutaFicheroTemp, rutaFichero);
            }
        }

        public bool existe(AEntidad e)
        {            
            string rutaFichero = Path.Combine(_carpeta, e.NombreEntidad + ".dat");
            if (!File.Exists(rutaFichero))
                File.Create(rutaFichero);
            else
            {
                bool b = false;
                using (StreamReader fielRead = new StreamReader(@rutaFichero))
                {
                    String line;
                    while ((line = fielRead.ReadLine()) != null)
                    {
                        if (line.Equals(entidadToStr(e)))
                        {
                            b = true;
                            break;
                        }
                    }
                }
                return b;
            }
            return false;
        }

        public void insertar(AEntidad e)
        {
            if (!existe(e))
            {
                string rutaFichero = Path.Combine(_carpeta, e.NombreEntidad + ".dat");
                if (!File.Exists(rutaFichero))
                    File.Create(rutaFichero);

                StreamWriter fichero;
                fichero = File.AppendText(rutaFichero);
                fichero.WriteLine(entidadToStr(e));
                fichero.Close();
            }
            
        }

        public void modificar(AEntidad e, Dictionary<string, object> pksInicial)
        {
            string rutaFichero = Path.Combine(_carpeta, e.NombreEntidad + ".dat");
            string rutaFicheroTemp = Path.Combine(_carpeta, e.NombreEntidad + "Temp" + ".dat");
            if (!File.Exists(rutaFichero))
                File.Create(rutaFichero);
            else
            {
                using (StreamWriter fileWrite = new StreamWriter(@rutaFicheroTemp))
                {
                    using (StreamReader fielRead = new StreamReader(@rutaFichero))
                    {
                        String line;
                        while ((line = fielRead.ReadLine()) != null)
                        {
                            bool b = true;
                            foreach (var item in pksInicial)
                            {
                                if (!line.Contains(campoToStr(item.Key, item.Value)))
                                {
                                    b = false;
                                }
                            }
                            if (b)
                            {
                                fileWrite.WriteLine(entidadToStr(e));
                            }
                            else { 
                                fileWrite.WriteLine(line);
                            }
                        }
                    }
                }
                //aqui se renombrea el archivo temporal
                File.Delete(rutaFichero);
                File.Move(rutaFicheroTemp, rutaFichero);
            }
        }

        public List<Dictionary<string, object>> obtener(string nombreEntidad, Dictionary<string, object> parametros)
        {
            List<Dictionary<string, object>> lista = new List<Dictionary<string, object>>();
            string rutaFichero = Path.Combine(_carpeta,nombreEntidad + ".dat");
            if (!File.Exists(rutaFichero))
                File.Create(rutaFichero);
            else
            {
                using (StreamReader fielRead = new StreamReader(@rutaFichero))
                {
                    String line;
                    while ((line = fielRead.ReadLine()) != null)
                    {
                        bool b = true;
                        foreach (var item in parametros)
                        {                            
                            if (!line.Contains(campoToStr(item.Key,item.Value)))
                            {
                                b =  false;
                            }
                        }
                        if (b)
                        {
                            lista.Add(strToDiccionario(line));
                        }
                    }
                }
            }
            return lista;
        }

        public List<Dictionary<string, object>> obtenerTodos(string nombreEntidad)
        {
            List<Dictionary<string, object>> lista = new List<Dictionary<string, object>>();
            string rutaFichero = Path.Combine(_carpeta, nombreEntidad + ".dat");
            if (!File.Exists(rutaFichero))
                File.Create(rutaFichero);
            else
            {
                using (StreamReader fielRead = new StreamReader(@rutaFichero))
                {
                    String line;
                    while ((line = fielRead.ReadLine()) != null)
                    {
                        lista.Add(strToDiccionario(line));
                    }
                }
            }
            return lista;
        }




        private Dictionary<string, object> strToDiccionario(string datos)
        {
            //{ "nombre":"Pedro","apellido":"Fernandez"}
            string sepCampos = "\",\"";
            string sepValor = "\":\"";
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string[] s = datos.Split(sepCampos.ToCharArray());
            foreach (var item in s)
            {
                string[] v = item.Split(sepValor.ToCharArray());
                dic.Add(v[0].Substring(1, v[0].Length - 1), v[1].Substring(0,v[1].Length));
            }            
            return dic;
        }
        private string diccionarioToStr(Dictionary<string, object> datos)
        {
            string str = "";
            foreach (var item in datos)
            {
                str = str + campoToStr(item.Key, item.Value);
            }
            return str;
        }
        private string entidadToStr(AEntidad e)
        {
            return diccionarioToStr(e.obtenerDiccionario());
        }
        private string campoToStr(string nombre, object valor)
        {
            //[{"nombre":"Pedro","apellido":"Fernandez"}
            return "\"" + nombre + "\":\"" + valor.ToString() + "\"";
        }
    }
}
