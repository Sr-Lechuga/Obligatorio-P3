using LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.MovimientosDeStock;
using LogicaAplicacion.DataTransferObjects.Models.TipoMovimiento;
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
        #endregion

        #region Constructor
        public MovimientoStockController(
            ICasoUsoAltaMovimientoStock altaMovimientoStock,
            ICasoUsoListarMovimientoStock listarMovimientoStock
        ) 
        {
            _listarMovimientoStock = listarMovimientoStock;
            _altaMovimientoStock = altaMovimientoStock;
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
            IEnumerable<TipoMovimientoDTO> lista = _listarMovimientoStock.GetAll();
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
        public ActionResult<MovimientoDeStockDTO> Post([FromBody] MovimientoDeStockDTO movimientoDeStockDTO)
        {

            try
            {
                _altaMovimientoStock.AltaMovimientoStock(movimientoDeStockDTO);
                return Created("api/TipoMovimiento", movimientoDeStockDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
