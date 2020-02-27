using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LibUtilidades
{
    public class GestorCriptogragia
    {
        private RijndaelManaged _algoritmo { get; set; }

        public GestorCriptogragia()
        {
            configurarAlgoritmo("MDEISmod6123*", "x%wm.", "SHA1", 10, 256);
        }
        public GestorCriptogragia(string clave)
        {
            configurarAlgoritmo(clave, "x%wm.", "SHA1", 10, 256);
        }
        private void configurarAlgoritmo(string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, int keySize)
        {
            _algoritmo = new RijndaelManaged();

            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);

            _algoritmo.Mode = CipherMode.CBC;
            _algoritmo.Key = keyBytes;
            _algoritmo.IV = Encoding.ASCII.GetBytes("S????I?_?i4h??");
        }

        public Respuesta Encriptar(string texto)
        {
            Respuesta respuesta = new Respuesta(true, "Texto", null);
            MemoryStream memoryStream = null;
            CryptoStream cryptoStream = null;
            try
            {
                Rijndael RijndaelAlg = Rijndael.Create();
                memoryStream = new MemoryStream();
                cryptoStream = new CryptoStream(memoryStream,
                                                             RijndaelAlg.CreateEncryptor(_algoritmo.Key, _algoritmo.IV),
                                                             CryptoStreamMode.Write);
                byte[] plainMessageBytes = UTF8Encoding.UTF8.GetBytes(texto);
                cryptoStream.Write(plainMessageBytes, 0, plainMessageBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] cipherMessageBytes = memoryStream.ToArray();
                //memoryStream.Close();
                //cryptoStream.Close();
                respuesta.Estado = true;
                respuesta.Mensaje = Convert.ToBase64String(cipherMessageBytes);
            }
            catch (Exception ex)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = ex.Message;
            }
            finally
            {
                if (memoryStream != null)
                {
                    memoryStream.Close();
                    memoryStream.Dispose();
                }
                if (cryptoStream != null)
                {
                    cryptoStream.Close();
                    cryptoStream.Dispose();
                }
            }
            return respuesta;
        }
        public Respuesta Desencriptar(string texto)
        {
            Respuesta respuesta = new Respuesta(true, "Texto", null);

            MemoryStream memoryStream = null;
            CryptoStream cryptoStream = null;
            try
            {
                byte[] cipherTextBytes = Convert.FromBase64String(texto);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                Rijndael RijndaelAlg = Rijndael.Create();
                memoryStream = new MemoryStream(cipherTextBytes);
                cryptoStream = new CryptoStream(memoryStream,
                                                             RijndaelAlg.CreateDecryptor(_algoritmo.Key, _algoritmo.IV),
                                                             CryptoStreamMode.Read);
                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                //memoryStream.Close();
                //cryptoStream.Close();
                respuesta.Estado = true;
                respuesta.Mensaje = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            }
            catch (Exception ex)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = ex.Message;
            }
            finally
            {
                if (memoryStream != null)
                {
                    try
                    {
                        memoryStream.Close();
                        memoryStream.Dispose();
                    }
                    catch { }
                }
                if (cryptoStream != null)
                {
                    try
                    {
                        cryptoStream.Close();
                        cryptoStream.Dispose();
                    }
                    catch { }
                }
            }
            return respuesta;
        }
        public Respuesta EncriptarArchivo(string rutaArchivo, string contenido)
        {
            Respuesta respuesta = new Respuesta(true, "Texto", null);
            File.Delete(rutaArchivo);
            FileStream fileStream = File.Open(rutaArchivo, FileMode.OpenOrCreate);
            CryptoStream cryptoStream = null;
            StreamWriter streamWriter = null;
            try
            {
                Rijndael RijndaelAlg = Rijndael.Create();
                cryptoStream = new CryptoStream(fileStream,
                                                             RijndaelAlg.CreateEncryptor(_algoritmo.Key, _algoritmo.IV),
                                                             CryptoStreamMode.Write);
                streamWriter = new StreamWriter(cryptoStream);
                streamWriter.WriteLine(contenido);
                respuesta.Estado = true;
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = ex.Message;
            }
            finally
            {
                if (streamWriter != null)
                {
                    try
                    {
                        streamWriter.Close();
                        streamWriter.Dispose();
                    }
                    catch { }
                }
                if (cryptoStream != null)
                {
                    try
                    {
                        cryptoStream.Close();
                        cryptoStream.Dispose();
                    }
                    catch { }
                }
                fileStream.Close();
                fileStream.Dispose();
            }

            return respuesta;
        }
        public Respuesta DesencriptarArchivo(string rutaArchivo)
        {
            Respuesta respuesta = new Respuesta(true, "Texto", null);

            FileStream fileStream = File.Open(rutaArchivo, FileMode.OpenOrCreate);
            string plainMessage = "";
            CryptoStream cryptoStream = null;
            StreamReader streamReader = null;
            try
            {
                Rijndael RijndaelAlg = Rijndael.Create();
                cryptoStream = new CryptoStream(fileStream,
                                                RijndaelAlg.CreateDecryptor(_algoritmo.Key, _algoritmo.IV),
                                                CryptoStreamMode.Read);
                streamReader = new StreamReader(cryptoStream);
                plainMessage = streamReader.ReadLine();
                respuesta.Estado = true;
                respuesta.Mensaje = plainMessage;
            }
            catch (Exception ex)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = ex.Message;
            }
            finally
            {
                if (streamReader != null)
                {
                    try
                    {
                        streamReader.Close();
                        streamReader.Dispose();
                    }
                    catch { }
                }
                if (cryptoStream != null)
                {
                    try
                    {
                        cryptoStream.Close();
                        cryptoStream.Dispose();
                    }
                    catch { }
                }
                fileStream.Close();
                fileStream.Dispose();
            }
            return respuesta;
        }
    }
}
