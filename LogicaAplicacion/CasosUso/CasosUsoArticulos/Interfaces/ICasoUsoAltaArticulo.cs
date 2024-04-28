using LogicaAplicacion.DataTransferObjects.Models.Articulos;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoArticulos.Interfaces
{
    public interface ICasoUsoAltaArticulo
    {
        public void AltaArticulo(ArticulosDTO articuloNuevo);
    }
}
