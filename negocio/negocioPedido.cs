using accesoAdatos;
using dominio;
using System;
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
            List<Pedido> lista = new List<Pedido> ();
            AccesoDatos datos = new AccesoDatos ();
            try
            {
                datos.setearConsulta("SELECT id, idUsuario, precioTotal, estado, metodoDepago FROM Pedido;");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    Pedido pedido = new Pedido ();
                    pedido.Id = (int)datos.Lector["id"];
                    pedido.IdUsuario = (int)datos.Lector["idUsuario"];
                    pedido.PrecioTotal = (decimal)datos.Lector["precioTotal"];
                    pedido.Estado = (string)datos.Lector["estado"];
                    pedido.MetodoDePago = (string)datos.Lector["metodoDepago"];
                    //pedido.Fecha = (DateTime)datos.Lector["fechaPedido"];
                    lista.Add (pedido);
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
            catch (Exception ex) {
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

            try {
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

        public void verificarDetallePedido(int idpedido,bool response) {

            AccesoDatos datos = new AccesoDatos();
            try {

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

    }
}
