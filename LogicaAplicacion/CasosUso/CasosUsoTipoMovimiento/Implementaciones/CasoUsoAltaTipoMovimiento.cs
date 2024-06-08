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
    public class CasoUsoAltaTipoMovimiento : ICasoUsoAltaTipoMovimiento
    {
        public IRepositorioTipoMovimiento RepositorioTiposMovimiento { get; init; }

        public CasoUsoAltaTipoMovimiento(IRepositorioTipoMovimiento repositorioTiposMovimiento)
        {
            // Inyeccion de dependencia
            this.RepositorioTiposMovimiento = repositorioTiposMovimiento;
        }

        public void AltaTipoMovimiento(TipoMovimientoDTO nuevoTipoMovimientoDTO)
        {
            throw new NotImplementedException();
        }
    }
}
