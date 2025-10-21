using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class DetallePedido
    {

        int idPedido;

        int idProducto {  get; set; }

        string nombreProducto { get; set; }

        float precioUnitario { get; set; }

        float precioRebajado { get; set; }

    }
}
