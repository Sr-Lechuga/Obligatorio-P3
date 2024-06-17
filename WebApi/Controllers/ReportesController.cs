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

        public ReportesController(ICasoUsoGetArticulosConMovimientos getArticulosConMovimientos,
                                  ICasoUsoGetMovimientos getMovimientos) 
        {
            _getArticulosConMovimientos = getArticulosConMovimientos;
            _getMovimientos = getMovimientos;
        }
        [HttpGet("GetArticulosConMovimientos")]
        public ActionResult<IEnumerable<ArticulosListadoDTO>> ArticulosConMovimientos(DateTime fecha1, DateTime fecha2)
        {
            try
            {
               IEnumerable<ArticulosListadoDTO> articulos = _getArticulosConMovimientos.GetArticulosConMovimientos(fecha1, fecha2);
                if (articulos.Count() == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(articulos);
                }
            }
            catch (Exception ex)
            {

                return BadRequest("Las fechas no son correctas");
            }
        }
        [HttpGet("GetMovimientos")]

        public ActionResult<IEnumerable<MovimientoDeStockDTO>> Movimientos(int articuloId, int tipoMovimientoId)
        {
            try
            {
                IEnumerable<MovimientoDeStockDTO> movimientos = _getMovimientos.GetMovimientos(articuloId, tipoMovimientoId);
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

                return BadRequest("Los id son incorrectos intente de nuevo");
            }
        }

    }
}
