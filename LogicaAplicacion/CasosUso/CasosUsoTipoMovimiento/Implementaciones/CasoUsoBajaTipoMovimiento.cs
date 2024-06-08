using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoTipoMovimiento.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.TipoMovimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoTipoMovimiento.Implementaciones
{
    internal class CasoUsoBajaTipoMovimiento : ICasoUsoBajaTipoMovimiento
    {
        public IRepositorioTipoMovimiento RepositorioTiposMovimiento { get; init; }

        public CasoUsoBajaTipoMovimiento(IRepositorioTipoMovimiento repositorioTiposMovimiento)
        {
            // Inyeccion de dependencia
            this.RepositorioTiposMovimiento = repositorioTiposMovimiento;
        }

        public void BajaTipoMovimiento(TipoMovimientoDTO bajaTipoMovimientoDTO)
        {
            throw new NotImplementedException();
        }
    }
}
