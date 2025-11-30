using accesoAdatos;
using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class negocioPedido
    {
        public List<Pedido> listarPedido()
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@" SELECT p.id,p.idUsuario,p.precioTotal,p.estado,p.metodoDepago,p.fechaPedido,u.nombre AS NombreUsuario,u.apellido AS ApellidoUsuario FROM Pedido p INNER JOIN Usuario u ON p.idUsuario = u.id;");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.Id = (int)datos.Lector["id"];
                    pedido.IdUsuario = (int)datos.Lector["idUsuario"];
                    pedido.PrecioTotal = (decimal)datos.Lector["precioTotal"];
                    pedido.Estado = (string)datos.Lector["estado"];
                    pedido.MetodoDePago = (string)datos.Lector["metodoDepago"];
                    pedido.Fecha = (DateTime)datos.Lector["fechaPedido"];
                    pedido.NombreUsuario = (string)datos.Lector["NombreUsuario"];
                    pedido.ApellidoUsuario = (string)datos.Lector["ApellidoUsuario"];
                    lista.Add(pedido);
                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int AgregarPedido(Pedido pedido)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.limpiarParametros();
                datos.setearProcedimiento("agregar_Pedido");
                datos.agregarParametros("@idUsuario", pedido.IdUsuario);
                datos.agregarParametros("@precioTotal", pedido.PrecioTotal);
                datos.agregarParametros("@estado", pedido.Estado);
                datos.agregarParametros("@metodoDePago", pedido.MetodoDePago);

                object res = datos.ejecutarEscalar();
                return Convert.ToInt32(res);

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



        public bool AgregarDetalleDePedido(DetallePedido dp)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("agregar_detalleProducto");
                datos.limpiarParametros();
                datos.agregarParametros("@idProducto", dp.idProducto);
                datos.agregarParametros("@idPedido", dp.idPedido);
                datos.agregarParametros("@cantidadProducto", dp.cantidadProducto);
                datos.agregarParametros("@precioUnitario", dp.precioUnitario);
                datos.agregarParametros("@precioRebajado", 0);

                SqlParameter res = datos.setParametro("@exito", SqlDbType.Bit);
                res.Direction = ParameterDirection.Output;

                datos.ejecutarAccion();

                return (bool)res.Value;

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

        public void actualizarEstado(int idPedido, string nuevoEstado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Pedido SET estado = @estado WHERE id = @id");
                datos.agregarParametros("@estado", nuevoEstado);
                datos.agregarParametros("@id", idPedido);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void verificarDetallePedido(int idpedido, bool response)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearProcedimiento("Desahacer_Compra");
                datos.limpiarParametros();
                datos.agregarParametros("@idpedido", idpedido);
                datos.agregarParametros("@exito", response);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

        }

        public List<Pedido> getPedidos(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Pedido> pedidos = new List<Pedido>();
            try
            {
                datos.setearConsulta("Select * from Pedido where pedido.idUsuario=@idUsuario");
                datos.limpiarParametros();
                datos.agregarParametros("@idUsuario", idUsuario);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.Id = (int)datos.Lector["id"];
                    pedido.IdUsuario = (int)datos.Lector["idUsuario"];
                    pedido.PrecioTotal = (decimal)datos.Lector["precioTotal"];
                    pedido.Estado = (string)datos.Lector["estado"];
                    pedido.MetodoDePago = (string)datos.Lector["metodoDepago"];
                    pedido.DetallePedidos = getDetalle(pedido.Id);
                    pedidos.Add(pedido);

                }


                return pedidos;

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

        public List<DetallePedido> getDetalle(int idPedido)
        {
            AccesoDatos datos = new AccesoDatos();
            negocioProducto productos = new negocioProducto();
            List<DetallePedido> detalles = new List<DetallePedido>();
            try
            {
                datos.setearConsulta("Select * from detalleProducto where idPedido=@idPedido");
                datos.limpiarParametros();
                datos.agregarParametros("@idPedido", idPedido);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DetallePedido detallePedido = new DetallePedido();
                    detallePedido.cantidadProducto = (int)datos.Lector["cantidadProducto"];
                    Producto pro = new Producto();
                    pro = productos.obtenerPorId((int)datos.Lector["idProducto"]);
                    detallePedido.nombreProducto = pro.Nombre;
                    detallePedido.precioUnitario = pro.PrecioVenta;

                    detalles.Add(detallePedido);
                }

                return detalles;
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

        public Pedido ObtenerPedidoConUsuario(int idPedido)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"SELECT p.id,p.idUsuario,p.precioTotal,p.estado,p.metodoDepago,p.FechaPedido,u.nombre AS NombreUsuario, u.apellido AS ApellidoUsuario  FROM Pedido p INNER JOIN Usuario u ON p.idUsuario = u.id WHERE p.id = @idPedido");
                datos.limpiarParametros();
                datos.agregarParametros("@idPedido", idPedido);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.Id = (int)datos.Lector["id"];
                    pedido.IdUsuario = (int)datos.Lector["idUsuario"];
                    pedido.Fecha = datos.Lector["FechaPedido"] != DBNull.Value ? (DateTime)datos.Lector["FechaPedido"] : DateTime.MinValue;
                    pedido.PrecioTotal = (decimal)datos.Lector["precioTotal"];
                    pedido.Estado = (string)datos.Lector["estado"];
                    pedido.MetodoDePago = (string)datos.Lector["metodoDepago"];
                    pedido.NombreUsuario = (string)datos.Lector["NombreUsuario"];
                    pedido.ApellidoUsuario = (string)datos.Lector["ApellidoUsuario"];
                    pedido.DetallePedidos = getDetalle(pedido.Id);
                    return pedido;
                }
                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
