using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Models.Clientes
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Display(Name = "Razon Social")]
        public string RazonSocial { get; set; }

        [Display(Name = "RUT")]
        [Range(12, int.MinValue, ErrorMessage = "El RUT debe tener 12 digitos")]
        public string Rut { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Ciudad { get; set; }
        public int Distancia { get; set; }

        public ClienteDTO() { }
    }
}
