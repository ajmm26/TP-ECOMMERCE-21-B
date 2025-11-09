using accesoAdatos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class negocioUsuario
    {
        public List<Usuario> listarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select id,Dni,Nombre,Apellido,Correo,Contraseña,rol,Telefono from Usuario");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario users = new Usuario();
                    users.Id = (int)datos.Lector["id"];
                    users.Dni = (string)datos.Lector["Dni"];
                    users.Nombre = (string)datos.Lector["Nombre"];
                    users.Apellido = (string)datos.Lector["Apellido"];
                    users.Email = (string)datos.Lector["Correo"];
                    users.RolUsuario = (string)datos.Lector["rol"];
                    users.Telefono = (string)datos.Lector["Telefono"];
                    lista.Add(users);
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Usuario Login(string email, string clave)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT * FROM Usuario WHERE Correo = @email AND Contraseña = @clave");
                datos.agregarParametros("@email", email);
                datos.agregarParametros("@clave", clave);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.Nombre = (string)datos.Lector["Nombre"];
                    usuario.Apellido = (string)datos.Lector["Apellido"];
                    usuario.Email = (string)datos.Lector["Correo"];
                    usuario.RolUsuario = (string)datos.Lector["Rol"];
                    

                    return usuario;
                }

                return null;
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
        public void agregarUsuario(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Usuario (Dni,Nombre,Apellido,Correo,Contraseña,Rol,Telefono,Direccion,CodigoPostal,Estado) VALUES (@dni,@nombre,@apellido,@correo,@contraseña,@rol,@telefono,@direccion,@codigoPostal,@estado);");
                datos.agregarParametros("@dni", nuevo.Dni);
                datos.agregarParametros("@nombre", nuevo.Nombre);
                datos.agregarParametros("@apellido", nuevo.Apellido);
                datos.agregarParametros("@correo", nuevo.Email);
                datos.agregarParametros("@contraseña", nuevo.Contraseña);
                datos.agregarParametros("@rol", nuevo.RolUsuario);
                datos.agregarParametros("@telefono", nuevo.Telefono);
                datos.agregarParametros("@direccion", nuevo.Direccion);
                datos.agregarParametros("@codigoPostal", nuevo.CodigoPostal);
                datos.agregarParametros("@estado", nuevo.Estado);
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
