using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        int id { get; set; }
        int dni { get; set; }
        string nombre { get; set; }
        string contrasena { get; set; }
        string rolUsuario { get; set; }
        string email { get; set; } 
    }
}
