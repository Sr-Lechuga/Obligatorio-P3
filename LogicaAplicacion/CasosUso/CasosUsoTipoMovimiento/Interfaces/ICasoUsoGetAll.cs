﻿using LogicaAplicacion.DataTransferObjects.Models.TipoMovimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoTipoMovimiento.Interfaces
{
    public interface ICasoUsoGetAll
    {
        public IEnumerable<TipoMovimientoDTO> GetAll(); 
    }
}
