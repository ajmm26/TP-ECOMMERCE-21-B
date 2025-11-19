using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accesoAdatos;
using dominio;

namespace negocio
{
    public class negocioMarca
    {
        public List<Marca> listar()
        {
			List<Marca> lista = new List<Marca>();
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("select Id,Nombre from marca");
				datos.ejecutarLectura();
				while(datos.Lector.Read())
				{
					Marca marca = new Marca();
					marca.Id=(int)datos.Lector["Id"];
					marca.Nombre=(string)datos.Lector["Nombre"];
					lista.Add(marca);
				}
				return lista;
			}
			catch (Exception)
			{

				throw;
			}
        }

		public void agregarMarca(Marca nueva)
		{
			AccesoDatos datos =new AccesoDatos();
			try
			{
				datos.setearConsulta("insert into marca (Nombre) values (@nombre)");
				datos.agregarParametros("@nombre",nueva.Nombre);
				
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


        public void eliminarMarca(int idMarca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM Marca WHERE Id = @idMarca");
                datos.agregarParametros("@idMarca", idMarca);
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
