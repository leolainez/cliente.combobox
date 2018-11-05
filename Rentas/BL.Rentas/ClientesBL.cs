using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class ClientesBL
    {
        Contexto2 _contexto;
       public BindingList<Cliente> ListaClientes { get; set; }

        public ClientesBL()
        {
            _contexto = new Contexto2();
            ListaClientes = new BindingList<Cliente>();

        }

        public BindingList<Cliente> ObtenerClientes()

        {
            _contexto.Clientes.Load();
            ListaClientes = _contexto.Clientes.Local.ToBindingList();
        
       return ListaClientes;

    }
        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload(); 
            }

        }

        public Resultados GuardarCliente(Cliente cliente)
        {

            var resultado = Validar(cliente);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarCliente()
        {
            var nuevoCliente = new Cliente();
            ListaClientes.Add(nuevoCliente);
        }

        public bool EliminarClientes(int id)

        {
            foreach (var cliente in ListaClientes)
            {
                if (cliente.Id == id)
                {
                    ListaClientes.Remove(cliente);
                    _contexto.SaveChanges();
                    return true;
                }

            }
            return false;
       
        }
        private Resultados Validar(Cliente cliente)
        {
            var resultado = new Resultados();
            resultado.Exitoso = true;

            if (string.IsNullOrEmpty(cliente.Nombre) == true)
            {
                resultado.Mensaje = "Ingrese Un nombre";
                resultado.Exitoso = false;
            }
            if (cliente.CiudadId == 0)
            {
                resultado.Mensaje = "Seleccione una ciudad";
                resultado.Exitoso = false;
            }

            if (cliente.Correo == "")
            {
                resultado.Mensaje = "Ingrese Un correo";
                resultado.Exitoso = false;
            }

            return resultado;
        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }
        public byte[] Foto { get; set; }
        public bool Activo { get; set; }
   
    }
    public class Resultados
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
