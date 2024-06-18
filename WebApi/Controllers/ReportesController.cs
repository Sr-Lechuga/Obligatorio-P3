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
    //[Authorize]
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

        [HttpGet("GetArticulosConMovimientos/{fecha1}/{fecha2}/{pageNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //TODO Error con el paginado
        public ActionResult<IEnumerable<ArticulosListadoDTO>> ArticulosConMovimientos(DateTime fecha1, DateTime fecha2, int pageNumber)
        {
            try
            {
                if (pageNumber < 1) return BadRequest("El numero de pagina debe ser mayor a 0")
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
        
        [HttpGet("GetMovimientos/{articuloId}/{tipoMovimientoId}/{pageNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //TODO Error con el paginado
        public ActionResult<IEnumerable<MovimientoDeStockDTO>> Movimientos(int articuloId, int tipoMovimientoId, int pageNumber)
        {
            try
            {
                if (pageNumber < 1) return BadRequest("El numero de pagina debe ser mayor a 0")
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

        [HttpGet("GetResumenMovimientos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<MovimientoDeStockDTO>> ResumenMovimientos()
        {
            try
            {
                IEnumerable<MovimientoDeStockDTO> movimientos = _getResumenMovimientos.GetResumenMovimientos();
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
