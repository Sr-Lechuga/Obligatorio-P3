using LogicaAplicacion.CasosUso.CasosUsoTipoMovimiento.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.TipoMovimiento;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
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
        public ActionResult<IEnumerable<TipoMovimientoDTO>> Get()
        {
            return Ok(_listarTipoMovimiento.GetAll());
        }

        [HttpGet("Page/{pageNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // GET api/<TipoMovimientoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TipoMovimientoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TipoMovimientoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TipoMovimientoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
