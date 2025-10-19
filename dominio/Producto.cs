using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Producto
    {
        int ID { get; set; }
        string Codigo { get; set; }
        string Nombre { get; set; }
        string Descripcion {  get; set; }
        Marca IdMarca { get; set; }
        Categoria IdCategoria { get; set; }
        List<Imagen> Imagenes { get; set; }
        decimal PrecioCompra {  get; set; }
        decimal PorcentajeGanancia { get; set; }
        decimal PrecioVenta { get; set; }
        int StockActual {  get; set; }  
        int StockMinimo { get; set; }
    }
}
