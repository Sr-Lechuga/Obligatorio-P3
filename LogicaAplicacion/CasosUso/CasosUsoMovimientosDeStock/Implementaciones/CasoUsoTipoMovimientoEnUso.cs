using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Implementaciones
{
    public class CasoUsoTipoMovimientoEnUso : ICasoUsoTipoMovimientoEnUso
    {
        public IRepositorioMovimientoDeStock RepositorioMovimientoStock { get; init; }
        public CasoUsoTipoMovimientoEnUso(
            IRepositorioMovimientoDeStock repositorioMovimientoDeStock
        )

        {
            // Inyeccion de dependencia
            RepositorioMovimientoStock = repositorioMovimientoDeStock;
        }
        public bool EstaTipoMovimientoEnUso(int tipoMovimientoId)
        {
            return RepositorioMovimientoStock.TipoMovimientoEnUso(tipoMovimientoId);
        }
    }
}
