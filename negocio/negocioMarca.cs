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
    }
}
