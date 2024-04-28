using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoArticulos.Interfaces;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoArticulos.Implementaciones
{
    public class CasoUsoListarArticulos(IRepositorioArticulos repositorioArticulos) : ICasoUsoListarArticulos
    {
        public IRepositorioArticulos RepositorioArticulos { get; set; } = repositorioArticulos;

        public IEnumerable<Articulo> LsitarArticulos()
        {
            return this.RepositorioArticulos.GetAll();
        }
    }
}
