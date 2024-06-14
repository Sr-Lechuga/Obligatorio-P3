using LogicaAplicacion.CasosUso.CasosUsoTipoMovimiento.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.TipoMovimiento;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Devuelve una lista con todos los tipos de movimiento registrados en el sistema
        /// </summary>
        /// <returns>Lista de tipos de movimiento</returns>
        [HttpGet(Name = "getAllTipoMovimientos")]
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

        /// <summary>
        /// Devuelve una lista filtrada por un tipo de movimiento seleccionado
        /// </summary>
        /// <param name="tipoMovimiento">Tipo de movimiento utilizado para filtrar la lista completa</param>
        /// <returns>Lista de tipos de movimiento</returns>
        [HttpGet("getByTipo/{tipoMovimiento}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Registra un nuevo tipo de movimiento en el sistema.
        /// </summary>
        /// <param name="tipoDTO">Tipo de movimiento a registrar en el sistema.</param>
        /// <returns>Sin retorno</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> Create([FromBody] TipoMovimientoDTO tipoDTO)
        {
            try
            {
                _altaTipoMovimiento.AltaTipoMovimiento(tipoDTO);
                return Created("api/TipoMovimiento", tipoDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Modifica la informacion de un tipo de movimiento registrado en el sistema.
        /// </summary>
        /// <param name="tipoMovimientoId">Id del tipo de movimiento que se va a modificar.</param>
        /// <param name="tipoDTO">Datos utilizados para modificar el tipo de movimiento seleccionado</param>
        /// <returns>Sin retorno</returns>
        [HttpPut("update/{tipoMovimientoId}")]
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

        /// <summary>
        /// Elimina el registro de un tipo de movimiento en el sistema
        /// </summary>
        /// <param name="id">Id del tipo de movimiento que se desea eliminar</param>
        /// <param name="tipoDTO">Datos del tipo de movimiento que se desea eliminar</param>
        /// <returns>Sin retorno</returns>
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> Delete(int id, [FromBody] TipoMovimientoDTO tipoDTO)
        {
            try
            {
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
