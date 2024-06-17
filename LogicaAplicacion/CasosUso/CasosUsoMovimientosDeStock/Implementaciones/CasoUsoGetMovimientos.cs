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
    public class CasoUsoGetMovimientos : ICasoUsoGetMovimientos
    {
        private IRepositorioMovimientoDeStock _repositorioMovimientoStock { get; init; }
        private IRepositorioSettings _settings {  get; set; }

        public CasoUsoGetMovimientos(
            IRepositorioMovimientoDeStock repositorioMovimientoDeStock, 
            IRepositorioSettings repositorioSettings)
        {
            // Inyeccion de dependencia
            _repositorioMovimientoStock = repositorioMovimientoDeStock;
            _settings = repositorioSettings;
        }
        public IEnumerable<MovimientoDeStockDTO> GetMovimientos(int articuloId, int tipoMovimientoId, int pageNumber)
        {
            int size = int.Parse(_settings.GetValueByName("PageSize") + "");
            return _repositorioMovimientoStock.GetMovimientos(articuloId, tipoMovimientoId, pageNumber, size)
                                              .Select(m => MapperMovimientoStock.ToDTO(m));
        }
    }
}
