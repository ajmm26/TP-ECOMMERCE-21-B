using accesoAdatos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class negocioCategoria
    {
       public List<Categoria> listarCategoria()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select id,nombreCategoria from categoria");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id =(int)datos.Lector["id"];
                    categoria.Nombre =(string)datos.Lector["nombreCategoria"];
                    lista.Add(categoria);
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

        public void agregarCategoria(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into categoria (nombreCategoria) values (@nombrecategoria)");
                datos.agregarParametros("@nombrecategoria", nuevo.Nombre);
                datos.ejecutarAccion();
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


        public void eliminarCategoria(int idCategoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM Categoria WHERE Id = @idCategoria");
                datos.agregarParametros("@idCategoria", idCategoria);
                datos.ejecutarAccion();
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
