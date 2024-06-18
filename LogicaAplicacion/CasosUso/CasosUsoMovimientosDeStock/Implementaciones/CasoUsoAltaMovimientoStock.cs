using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Interfaces;
using LogicaAplicacion.DataTransferObjects.Mappers;
using LogicaAplicacion.DataTransferObjects.Models.MovimientosDeStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Implementaciones
{
    public class CasoUsoAltaMovimientoStock : ICasoUsoAltaMovimientoStock
    {
        public IRepositorioMovimientoDeStock RepositorioMovimientoStock { get; init; }
        private IRepositorioSettings RepositorioSettings { get; init; }
        public CasoUsoAltaMovimientoStock(
            IRepositorioMovimientoDeStock repositorioMovimientoDeStock, 
            IRepositorioSettings repositorioSettings

            )
        {
            // Inyeccion de dependencia
            RepositorioMovimientoStock = repositorioMovimientoDeStock;
            RepositorioSettings = repositorioSettings;
        }
        public void AltaMovimientoStock(MovimientoDeStockDTO movimientosDeStockDTO)
        {
            int tope = int.Parse(RepositorioSettings.GetValueByName("Tope") + "");
            if (movimientosDeStockDTO.Cantidad <= tope)
            {
                RepositorioMovimientoStock.Add(MapperMovimientoStock.FromDTO(movimientosDeStockDTO));
            }
            else
            {
                throw new Exception("No se puede superar el tope " + tope);
            }
            
        }

    }
}
