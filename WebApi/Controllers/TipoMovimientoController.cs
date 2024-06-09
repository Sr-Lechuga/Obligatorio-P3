using LogicaAplicacion.CasosUso.CasosUsoTipoMovimiento.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.TipoMovimiento;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/TipoMovimiento")]
    [ApiController]
    public class TipoMovimientoController : ControllerBase
    {
        #region Properties
        private ICasoUsoListarTipoMovimiento _listarTipoMovimiento;
        private ICasoUsoAltaTipoMovimiento _altaTipoMovimiento;
        private ICasoUsoBajaTipoMovimiento _bajaTipoMovimiento;
        private ICasoUsoEditTipoMovimiento _editTipoMovimiento;
        private ICasoUsoObtenerPorTipoMovimiento _obtenerPorTipoMovimiento;
        #endregion

        #region Constructor
        public TipoMovimientoController(
            ICasoUsoListarTipoMovimiento listarTipoMovimiento,
            ICasoUsoAltaTipoMovimiento altaTipoMovimiento,
            ICasoUsoBajaTipoMovimiento bajaTipoMovimiento,
            ICasoUsoEditTipoMovimiento editTipoMovimiento,
            ICasoUsoObtenerPorTipoMovimiento obtenerPorTipoMovimiento
        )
        {
            _listarTipoMovimiento = listarTipoMovimiento;
            _altaTipoMovimiento = altaTipoMovimiento;
            _bajaTipoMovimiento = bajaTipoMovimiento;
            _editTipoMovimiento = editTipoMovimiento;
            _obtenerPorTipoMovimiento = obtenerPorTipoMovimiento;
        }
        #endregion

        // GET: api/<TipoMovimientoController>
        [HttpGet(Name = "GetAllTipoMovimientos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<TipoMovimientoDTO>> Get()
        {
            IEnumerable<TipoMovimientoDTO> lista = _listarTipoMovimiento.GetAll();
            if (lista.Count() == 0)
            {
                return NoContent();
            }else
            {
                return Ok(lista);
            }
        }

        [HttpGet("tipo/{tipoMovimiento}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // GET api/<TipoMovimientoController>/5
        public ActionResult<IEnumerable<TipoMovimientoDTO>> GetByTipoMovimiento(string tipoMovimiento)
        {
            IEnumerable<TipoMovimientoDTO> lista = _obtenerPorTipoMovimiento.ObtenerPorTipoMovimiento(tipoMovimiento);
            if (lista.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(lista);
            }
        }

        // POST api/<TipoMovimientoController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> Create([FromBody] TipoMovimientoDTO tipoDTO)
        {
            try
            {
                //TODO Autenticacion JWT 
                //TODO Validacion de tipo
                _altaTipoMovimiento.AltaTipoMovimiento(tipoDTO);
                return Created("api/TipoMovimiento", tipoDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TipoMovimientoController>/5
        [HttpPut("{tipoMovimientoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> Update(int tipoMovimientoId, [FromBody] TipoMovimientoDTO tipoDTO)
        {
            try
            {
                _editTipoMovimiento.EditTipoMovimiento(tipoMovimientoId, tipoDTO);
                return Ok("Tipo movimiento " + tipoDTO.Nombre + " editado correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TipoMovimientoController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> Delete(int id, [FromBody] TipoMovimientoDTO tipoDTO)
        {
            try
            {
                //TODO caso de uso tipo movimiento sin referencias
                _bajaTipoMovimiento.BajaTipoMovimiento(id);
                return Ok("Tipo movimiento " + tipoDTO.Id + " dado de baja correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
