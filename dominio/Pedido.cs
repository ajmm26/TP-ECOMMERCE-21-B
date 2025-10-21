using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pedido
    {
        int id {  get; set; }
        DateTime datatime { get; set; }
        int idUsuario { get; set; }
        float precioTotal { get; set; }
        string estado {  get; set; }
       string metodoDePago { get; set; }
        List<DetallePedido> detallePedidos { get; set; }

    }
}
