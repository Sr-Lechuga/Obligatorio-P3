using AccesoDatos.Interfaces;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementaciones.EntityFramework
{
    public class RepositorioSettings : IRepositorioSettings
    {
        private PapeleriaContext _papeleriaContext;

        public RepositorioSettings()
        {
            _papeleriaContext = new PapeleriaContext();
        }
        public double GetValueByName(string name)
        {
            return _papeleriaContext.Settings.Where(setting => setting.Name == name).FirstOrDefault().Value;
        }
    }
}
