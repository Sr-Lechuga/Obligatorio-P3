using LogicaAplicacion.CasosUso.CasosUsoArticulos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.Articulos;
using LogicaAplicacion.DataTransferObjects.Models.MovimientosDeStock;
using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportesController : ControllerBase
    {
        private ICasoUsoGetArticulosConMovimientos _getArticulosConMovimientos;
        private ICasoUsoGetMovimientos _getMovimientos;
        private ICasoUsoGetResumenMovimientos _getResumenMovimientos;

        public ReportesController(ICasoUsoGetArticulosConMovimientos getArticulosConMovimientos,
                                  ICasoUsoGetMovimientos getMovimientos,
                                  ICasoUsoGetResumenMovimientos getResumenMovimientos) 
        {
            _getArticulosConMovimientos = getArticulosConMovimientos;
            _getMovimientos = getMovimientos;
            _getResumenMovimientos = getResumenMovimientos;
        }

        /// <summary>
        /// Lista los articulos que contengan movimientos entre dos fechas dadas.
        /// </summary>
        /// <param name="fecha1">Fecha desde la que se realizara la busqueda.</param>
        /// <param name="fecha2">Fecha hasta la que se realizara la busqueda.</param>
        /// <param name="pageNumber">Numero de pagina del reporte. La cantidad de elementos por pagina se define en las settings.</param>
        /// <returns>Retorna la lista de articulos con sus respectivos movimientos</returns>
        [HttpGet("GetArticulosConMovimientos/{fecha1}/{fecha2}/{pageNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ArticulosListadoDTO>> ArticulosConMovimientos(DateTime fecha1, DateTime fecha2, int pageNumber)
        {
            try
            {
                if (pageNumber < 1) return BadRequest("El numero de pagina debe ser mayor a 0");
               IEnumerable<ArticulosListadoDTO> articulos = _getArticulosConMovimientos.GetArticulosConMovimientos(fecha1, fecha2, pageNumber);
                if (articulos.Count() == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(articulos);
                }
            }
            catch (Exception)
            {

                return BadRequest("Las fechas no son correctas");
            }
        }
        
        /// <summary>
        /// Lista todos los movimientos de ese tipo Id realizados sobre ese articulo Id
        /// </summary>
        /// <param name="articuloId">Id del tipo de articulo que se desea buscar</param>
        /// <param name="tipoMovimientoId">Id del tipo de movimiento por el que se desea filtrar</param>
        /// <param name="pageNumber">Numero de pagina del reporte. La cantidad de elementos por pagina se define en las settings.</param>
        /// <returns>Retorna los movimientos</returns>
        [HttpGet("GetMovimientos/{articuloId}/{tipoMovimientoId}/{pageNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<MovimientoDeStockDTO>> Movimientos(int articuloId, int tipoMovimientoId, int pageNumber)
        {
            try
            {
                if (pageNumber < 1) return BadRequest("El numero de pagina debe ser mayor a 0");
                IEnumerable<MovimientoDeStockDTO> movimientos = _getMovimientos.GetMovimientos(articuloId, tipoMovimientoId, pageNumber);
                if (movimientos.Count() == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(movimientos);
                }
            }
            catch (Exception)
            {
                return BadRequest("Los id son incorrectos intente de nuevo");
            }
        }
        
        /// <summary>
        /// Resumen de movimientos con sus respectivas cantidades movidas agrupadas por año y por tipo de movimiento
        /// </summary>
        /// <returns>Resumen</returns>
        [HttpGet("GetResumenMovimientos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Object>> ResumenMovimientos()
        {
            try
            {
                IEnumerable<Object> movimientos = _getResumenMovimientos.GetResumenMovimientos();
                if (movimientos.Count() == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(movimientos);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
