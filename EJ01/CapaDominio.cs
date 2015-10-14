using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    class CapaDominio
    {
        public void Ejecutar()
        {
            CapaPersistencia persistencia = new CapaPersistencia();
            persistencia.Ejecutar();
        }
    }
}
