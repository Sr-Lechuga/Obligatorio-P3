using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Models.Articulos
{
    public class ArticulosDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long Codigo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }

        public ArticulosDTO() { }
    }
}
