using accesoAdatos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace negocio
{
    public class negocioProducto
    {
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("select Id,Codigo,Nombre,MarcaId,Descripcion,PrecioCompra,PorcentajeGanancia,PrecioVenta,StockActual,StockMinimo from Producto");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = (int)datos.Lector["Id"];
                    producto.Codigo = (string)datos.Lector["Codigo"];
                    producto.Nombre = (string)datos.Lector["Nombre"];
                    producto.IdMarca = new Marca();
                    producto.IdMarca.Id = (int)datos.Lector["MarcaId"];
                    producto.Descripcion = (string)datos.Lector["Descripcion"];
                    producto.PrecioCompra = (decimal)datos.Lector["PrecioCompra"];
                    producto.PorcentajeGanancia = (decimal)datos.Lector["PorcentajeGanancia"];
                    producto.PrecioVenta = (decimal)datos.Lector["PrecioVenta"];
                    producto.StockActual = (int)datos.Lector["StockActual"];
                    producto.StockMinimo = (int)datos.Lector["StockMinimo"];
                    lista.Add(producto);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
