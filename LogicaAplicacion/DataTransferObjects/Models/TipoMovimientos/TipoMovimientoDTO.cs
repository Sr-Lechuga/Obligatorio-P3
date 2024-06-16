using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Models.TipoMovimientos
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class TipoMovimientoDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public bool Reduccion { get; set; }
    }
}
