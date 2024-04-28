using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IRepositorioClientes : IRepositorioCRUD<Cliente>
    {
        public IEnumerable<Cliente> GetByText(string texto);
        public IEnumerable<Cliente> GetByMonto(decimal monto);
        public Cliente GetByRut(string monto);
    }
}
