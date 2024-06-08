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
    internal class CasoUsoEditTipoMovimiento : ICasoUsoEditTipoMovimiento
    {
        public IRepositorioTipoMovimiento RepositorioTiposMovimiento { get; init; }

        public CasoUsoEditTipoMovimiento(IRepositorioTipoMovimiento repositorioTiposMovimiento)
        {
            // Inyeccion de dependencia
            this.RepositorioTiposMovimiento = repositorioTiposMovimiento;
        }

        public void EditTipoMovimiento(int id, TipoMovimientoDTO editTipoMovimientoDTO)
        {
            RepositorioTiposMovimiento.Update(id, MapperTipoMovimiento.FromDTO(editTipoMovimientoDTO));
        }
    }
}
