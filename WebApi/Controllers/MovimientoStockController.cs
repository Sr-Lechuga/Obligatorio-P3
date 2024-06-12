using LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovimientoStockController : ControllerBase
    {
        #region Properties
        private ICasoUsoAltaMovimientoStock _altaMovimientoStock;
        #endregion

        #region Constructor
        public MovimientoStockController(ICasoUsoAltaMovimientoStock altaMovimientoStock) 
        {
            _altaMovimientoStock = altaMovimientoStock;
        }
        #endregion

        // GET: api/<MovimientoStockController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MovimientoStockController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MovimientoStockController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MovimientoStockController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovimientoStockController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
