using AccesoDatos.Implementaciones.EntityFramework;
using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Interfaces;
using LogicaAplicacion.DataTransferObjects.Mappers;
using LogicaAplicacion.DataTransferObjects.Models.MovimientosDeStock;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Implementaciones
{
    public class CasoUsoFindByIdMovimientoStock : ICasoUsoFindByIdMovimientoStock
    {
        public IRepositorioMovimientoDeStock RepositorioMovimientoDeStock { get; init; }

        public CasoUsoFindByIdMovimientoStock(IRepositorioMovimientoDeStock repositorioMovimientoDeStock)
        {
            // Inyeccion de dependencia
            RepositorioMovimientoDeStock = repositorioMovimientoDeStock;
        }
        public MovimientoDeStockDTO FindById(int id)
        {
            MovimientoStock movimiento = RepositorioMovimientoDeStock.GetById(id);
            return MapperMovimientoStock.ToDTO(movimiento);
        }
    }
}
