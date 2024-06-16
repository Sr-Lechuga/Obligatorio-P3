using LogicaAplicacion.CasosUso.CasosUsoArticulos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoTipoMovimiento.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoUsuarios.Interfaces;
using LogicaAplicacion.DataTransferObjects.Mappers;
using LogicaAplicacion.DataTransferObjects.Models.MovimientosDeStock;
using LogicaAplicacion.DataTransferObjects.Models.TipoMovimientos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class MovimientoStockController : ControllerBase
    {
        #region Properties
        private ICasoUsoListarMovimientoStock _listarMovimientoStock;
        private ICasoUsoAltaMovimientoStock _altaMovimientoStock;
        private ICasoUsoBuscarArticulo _buscarArticulo;
        private ICasoUsoBuscarUsuario _buscarUsuario;
        private ICasoUsoBuscarTipoMovimiento _buscarTipoMovimiento;
        #endregion

        #region Constructor
        public MovimientoStockController(
            ICasoUsoAltaMovimientoStock altaMovimientoStock,
            ICasoUsoListarMovimientoStock listarMovimientoStock,
            ICasoUsoBuscarArticulo buscarArticulo,
            ICasoUsoBuscarUsuario buscarUsuario,
            ICasoUsoBuscarTipoMovimiento buscarTipoMovimiento
        ) 
        {
            _listarMovimientoStock = listarMovimientoStock;
            _altaMovimientoStock = altaMovimientoStock;
            _buscarArticulo = buscarArticulo;
            _buscarUsuario = buscarUsuario;
            _buscarTipoMovimiento = buscarTipoMovimiento;
        }
        #endregion

        /// <summary>
        /// Devuelve la lista de todos los movimientos de stock registrados en el sistema.
        /// </summary>
        /// <returns>Lista de movimientos de stock en el sistema</returns>
        [HttpGet(Name = "getAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<IEnumerable<MovimientoDeStockDTO>> Get()
        {
            IEnumerable<MovimientoDeStockDTO> lista = _listarMovimientoStock.ListarMovimientosDeStock();
            if (lista.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(lista);
            }
        }


        /// <summary>
        /// Registra un nuevo movimiento de stock en el sistema.
        /// </summary>
        /// <param name="movimientoDeStockDTO">Movimiento de stock que se quiere registrar</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<MovimientoDeStockDTO> Post([FromBody] AltaMovimientoDeStockDTO altaMovimientoDeStockDTO)
        {
            try
            {
                MovimientoDeStockDTO movimientoCompleto = new  MovimientoDeStockDTO()
                {
                    Fecha = DateTime.Now.ToLocalTime(),
                    Cantidad = altaMovimientoDeStockDTO.Cantidad,
                    Articulo = _buscarArticulo.BuscarArticulo(altaMovimientoDeStockDTO.ArticuloId),
                    Usuario = MapperUsuario.FromDTO(_buscarUsuario.BuscarUsuario(altaMovimientoDeStockDTO.UsuarioId)),
                    TipoMovimiento = _buscarTipoMovimiento.BuscarTipoMovimiento(altaMovimientoDeStockDTO.TipoMovimientoId)
                };
                _altaMovimientoStock.AltaMovimientoStock(movimientoCompleto);
                return Created("api/TipoMovimiento", movimientoCompleto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
