using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class DetallePedido
    {

        public int idPedido;

        public int idProducto {  get; set; }

        public string nombreProducto { get; set; }

        public decimal precioUnitario { get; set; }

        public decimal precioRebajado { get; set; }

    }
}
