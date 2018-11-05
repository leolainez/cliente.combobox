using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
   public class CiudadBL
    {
        Contexto2 _contexto2;

         public BindingList<Ciudad> ListaCiudades { get; set; }

        public CiudadBL()
        {
            _contexto2 = new Contexto2();
            ListaCiudades = new BindingList<Ciudad>();
        }
        public BindingList<Ciudad> ObtenerCiudades()
        {
            _contexto2.Ciudades.Load();
            ListaCiudades = _contexto2.Ciudades.Local.ToBindingList();

            return ListaCiudades;
                }
    }

    public class Ciudad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
