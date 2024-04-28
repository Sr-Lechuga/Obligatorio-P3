using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Cliente
    {
        #region Properties
        public int Id { get; set; }
        public NombreCompleto NombreCompleto { get; set; }
        public string RazonSocial { get; set; }
        public RUT RUT { get; set; }
        public Direccion Direccion { get; set; }
        #endregion

        #region Constructor
        public Cliente(string razonSocial, string nombre, string apellido, string nroRut, string calle, int numero, string ciudad, int distancia)
        {
            RazonSocial = razonSocial;
            NombreCompleto = new NombreCompleto(nombre, apellido);
            RUT = new RUT(nroRut);
            Direccion = new Direccion(calle, numero, ciudad, distancia);
        }
        public Cliente(int id, string razonSocial, string nombre, string apellido, string nroRut, string calle, int numero, string ciudad, int distancia)
        {
            Id = id;
            RazonSocial = razonSocial;
            NombreCompleto = new NombreCompleto(nombre, apellido);
            RUT = new RUT(nroRut);
            Direccion = new Direccion(calle, numero, ciudad, distancia);
        }
        //Used for EntityFramework
        public Cliente() { }
        #endregion
    }
}
