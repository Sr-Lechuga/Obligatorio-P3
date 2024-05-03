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
    public class CasoUsoBuscarArticulo : ICasoUsoBuscarArticulo
    {
        public IRepositorioArticulos RepositorioArticulos { get; set; }

        public CasoUsoBuscarArticulo(IRepositorioArticulos repositorioArticulos)
        {
            RepositorioArticulos = repositorioArticulos;
        }

        public Articulo BuscarArticulo(int id)
        {
            return this.RepositorioArticulos.GetById(id);
        }
    }
}
