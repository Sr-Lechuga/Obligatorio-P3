using LogicaAplicacion.DataTransferObjects.Models.Clientes;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Mappers
{
    public class MapperCliente
    {
        public static ClienteDTO ToDTO(Cliente client)
        {
            return new ClienteDTO()
            {
                Id = client.Id,
                Nombre = client.NombreCompleto.Nombre,
                Apellido = client.NombreCompleto.Apellido,
                RazonSocial = client.RazonSocial,
                Rut = client.RUT.NroRut,
                Calle = client.Direccion.Calle,
                Numero = client.Direccion.Numero,
                Ciudad = client.Direccion.Ciudad,
                Distancia = client.Direccion.Distancia
            };
        }
        public static IEnumerable<ClienteDTO> FromList(IEnumerable<Cliente> clients)
        {
            return clients.Select(x => ToDTO(x));
        }
    }
}
