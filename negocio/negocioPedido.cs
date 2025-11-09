using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesoAdatos;

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
                datos.setearConsulta("SELECT id, idUsuario, precioTotal, estado, metodoDepago,fechaPedido FROM Pedido;");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    Pedido pedido = new Pedido ();
                    pedido.Id = (int)datos.Lector["id"];
                    pedido.IdUsuario = (int)datos.Lector["idUsuario"];
                    pedido.PrecioTotal = (decimal)datos.Lector["precioTotal"];
                    pedido.Estado = (string)datos.Lector["estado"];
                    pedido.MetodoDePago = (string)datos.Lector["metodoDepago"];
                    pedido.Fecha = (DateTime)datos.Lector["fechaPedido"];
                    lista.Add (pedido);
                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
