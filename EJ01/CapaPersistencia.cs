using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    class CapaPersistencia
    {
        public void Ejecutar()
        {
            ErrorPuntualException exception = new ErrorPuntualException("Ocurrio un error en la capa Persistencia, fecha y hora: ");
            throw exception;
        }
    }
}
