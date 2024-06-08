using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IRepositorioTipoMovimiento : IRepositorioCRUD<TipoMovimiento>
    {
        public IEnumerable<TipoMovimiento> GetByTipoMovimiento (string tipoMovimiento);
    }

}
