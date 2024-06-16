using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoTipoMovimiento.Interfaces;
using LogicaAplicacion.DataTransferObjects.Mappers;
using LogicaAplicacion.DataTransferObjects.Models.TipoMovimientos;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoTipoMovimiento.Implementaciones
{
    public class CasoUsoBuscarTipoMovimiento : ICasoUsoBuscarTipoMovimiento
    {

        public IRepositorioTipoMovimiento RepositorioTiposMovimiento { get; init; }

        public CasoUsoBuscarTipoMovimiento(IRepositorioTipoMovimiento repositorioTiposMovimiento)
        {
            // Inyeccion de dependencia
            RepositorioTiposMovimiento = repositorioTiposMovimiento;
        }

        public TipoMovimiento BuscarTipoMovimiento(int id)
        {
            return RepositorioTiposMovimiento.GetById(id);
        }
    }
}
