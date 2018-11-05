using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
   public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto2>
    {
        protected override void Seed(Contexto2 contexto2)
        {


          

            var ciudad1 = new Ciudad();
            ciudad1.Nombre = "San Pedro Sula";
            contexto2.Ciudades.Add(ciudad1);

            var ciudad2 = new Ciudad();
            ciudad2.Nombre = "Choloma";
            contexto2.Ciudades.Add(ciudad2);

            var ciudad3 = new Ciudad();
            ciudad3.Nombre = "Puerto Cortes";
            contexto2.Ciudades.Add(ciudad3);

            base.Seed(contexto2);
           
        }
    }

}
