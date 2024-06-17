using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Settings
    {
        [Key]
        public string Name { get; set; }
        public double Value { get; set; }
    }
}
