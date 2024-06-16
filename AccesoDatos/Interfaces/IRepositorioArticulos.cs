using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IRepositorioArticulos : IRepositorioCRUD<Articulo>
    {
        public IEnumerable<Articulo> ListadoAscendente();
        public IEnumerable<Articulo> GetArticulosConMovimientos(DateTime fecha1, DateTime fecha2, int pageNumber, int pageSize);
    }
}
