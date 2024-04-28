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
    public class CasoUsoAltaArticulo(IRepositorioArticulos repositorioArticulos) : ICasoUsoAltaArticulo
    {
        public IRepositorioArticulos RepositorioArticulos { get; set; } = repositorioArticulos;

        public void AltaArticulo(Articulo articuloNuevo)
        {
            this.RepositorioArticulos.Add(articuloNuevo);
        }
    }
}
