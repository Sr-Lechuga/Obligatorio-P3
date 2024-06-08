using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoTipoMovimiento.Interfaces;
using LogicaAplicacion.DataTransferObjects.Mappers;
using LogicaAplicacion.DataTransferObjects.Models.TipoMovimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoTipoMovimiento.Implementaciones
{
    public class CasoUsoObtenerPorTipoMovimiento : ICasoUsoObtenerPorTipoMovimiento
    {
        public IRepositorioTipoMovimiento RepositorioTiposMovimiento { get; init; }

        public CasoUsoObtenerPorTipoMovimiento(IRepositorioTipoMovimiento repositorioTiposMovimiento)
        {
            // Inyeccion de dependencia
            RepositorioTiposMovimiento = repositorioTiposMovimiento;
        }
        public IEnumerable<TipoMovimientoDTO> ObtenerPorTipoMovimiento(string tipoMovimiento)
        {
            return MapperTipoMovimiento.ToDTOList(RepositorioTiposMovimiento.GetByTipoMovimiento(tipoMovimiento));
        }
    }
}
