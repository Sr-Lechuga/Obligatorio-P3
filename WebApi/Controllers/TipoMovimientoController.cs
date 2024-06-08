using LogicaAplicacion.CasosUso.CasosUsoTipoMovimiento.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.TipoMovimiento;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMovimientoController : ControllerBase
    {
        private ICasoUsoGetAll _getAll;
        private ICasoUsoAltaTipoMovimiento _altaTipoMovimiento;
        private ICasoUsoBajaTipoMovimiento _bajaTipoMovimiento;
        private ICasoUsoEditTipoMovimiento _editTipoMovimiento;
        private ICasoUsoObtenerPorTipoMovimiento _obtenerPorTipoMovimiento;

        public TipoMovimientoController(
            ICasoUsoGetAll getAll, 
            ICasoUsoAltaTipoMovimiento altaTipoMovimiento, 
            ICasoUsoBajaTipoMovimiento bajaTipoMovimiento, 
            ICasoUsoEditTipoMovimiento editTipoMovimiento, 
            ICasoUsoObtenerPorTipoMovimiento obtenerPorTipoMovimiento
        )
        {
            _getAll = getAll;
            _altaTipoMovimiento = altaTipoMovimiento;
            _bajaTipoMovimiento = bajaTipoMovimiento;
            _editTipoMovimiento = editTipoMovimiento;
            _obtenerPorTipoMovimiento = obtenerPorTipoMovimiento;
        }

    

        // GET: api/<TipoMovimientoController>
        [HttpGet]
        public IEnumerable<TipoMovimientoDTO> Get()
        {
            return null;
        }

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
