using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IRepositorioMovimientoDeStock :IRepositorioCRUD<MovimientoStock>
    {
        public IEnumerable<MovimientoStock> GetMovimientos(int articuloId, int tipoMovimientoId, int pageNumber, int pageSize);

        public IEnumerable<MovimientoStock> GetResumenMovimientos();
    }
}
