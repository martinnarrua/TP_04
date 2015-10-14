using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    class CapaAplicacion
    {
        public void Ejecutar()
        {
            try
            {
                CapaDominio dominio = new CapaDominio();
                dominio.Ejecutar();
            }
            catch(ErrorPuntualException exception)
            {
                CapaAplicacionException exception2 = new CapaAplicacionException("Se produjo un error ", exception);
                throw exception2;
            }
            
        }
    }
}
