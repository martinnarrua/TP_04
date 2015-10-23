using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace EJ05
{
    /// <summary>
    /// 
    /// </summary>
    internal class UserCodeAscendingComparer : IComparer<Usuario>
    {

        int IComparer<Usuario>.Compare(Usuario pUsuario1, Usuario pUsuario2)
        {
            return String.Compare(pUsuario1.Codigo, pUsuario1.Codigo, true, Thread.CurrentThread.CurrentCulture);        
        }

    }
}
