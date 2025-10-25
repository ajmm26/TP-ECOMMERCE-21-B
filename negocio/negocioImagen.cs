using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accesoAdatos;
using dominio;

namespace negocio
{
    public class negocioImagen
    {
        public List<Imagen> listarImagenes(int idProducto)
        {
            List<Imagen> imagenes = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, IdProducto, Url FROM Imagen WHERE IdProducto = @id");
                datos.agregarParametros("@id",idProducto);
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    Imagen img = new Imagen();
                    img.Id=(int)datos.Lector["Id"];
                    img.IdProducto=(int)datos.Lector["IdProducto"];
                    img.Url=(string)datos.Lector["Url"];
                    imagenes.Add(img);
                }

                return imagenes;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
