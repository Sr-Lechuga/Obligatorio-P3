using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Interfaces
{
    public interface ICasoUsoTipoMovimientoEnUso
    {
        public bool EstaTipoMovimientoEnUso(int tipoMovimientoId);
    }
}
