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
    public class CasoUsoListarTipoMovimiento : ICasoUsoListarTipoMovimiento
    {
        public IRepositorioTipoMovimiento RepositorioTiposMovimiento { get; init; }

        public CasoUsoListarTipoMovimiento(IRepositorioTipoMovimiento repositorioTiposMovimiento)
        {
            // Inyeccion de dependencia
            RepositorioTiposMovimiento = repositorioTiposMovimiento;
        }
        public IEnumerable<TipoMovimientoDTO> GetAll()
        {
            return MapperTipoMovimiento.ToDTOList(RepositorioTiposMovimiento.GetAll());
        }
    }
}
