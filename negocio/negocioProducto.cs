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
            negocioImagen negocioImagen = new negocioImagen();
            try
            {

                datos.setearConsulta("select Id,Codigo,Nombre,MarcaId,Descripcion,PrecioCompra,PorcentajeGanancia,PrecioVenta,StockActual,StockMinimo,Estado from Producto");
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
                    producto.Estado = (bool)datos.Lector["Estado"];

                    producto.Imagenes = negocioImagen.listarImagenes(producto.Id);

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
          
        public void agregarProducto(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Producto (Codigo,Nombre,MarcaId,Descripcion,PrecioCompra,PorcentajeGanancia,PrecioVenta,StockActual,StockMinimo,Estado) " +
                      "VALUES (@codigo,@nombre,@marcaId,@descripcion,@precioCompra,@porcentajeGanancia,@precioVenta,@stockActual,@stockMinimo,@estado)");

                datos.agregarParametros("@codigo", nuevo.Codigo);
                datos.agregarParametros("@nombre", nuevo.Nombre);
                datos.agregarParametros("@marcaId", nuevo.IdMarca.Id);
                datos.agregarParametros("@descripcion", nuevo.Descripcion);
                datos.agregarParametros("@precioCompra", nuevo.PrecioCompra);
                datos.agregarParametros("@porcentajeGanancia", nuevo.PorcentajeGanancia);
                datos.agregarParametros("@precioVenta", nuevo.PrecioVenta);
                datos.agregarParametros("@stockActual", nuevo.StockActual);
                datos.agregarParametros("@stockMinimo", nuevo.StockMinimo);
                datos.agregarParametros("@estado", nuevo.Estado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
