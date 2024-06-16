using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoTipoMovimiento.Interfaces
{
    public interface ICasoUsoBuscarTipoMovimiento
    {
        public TipoMovimiento BuscarTipoMovimiento(int id);
    }
}
