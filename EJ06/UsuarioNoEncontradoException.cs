﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ06
{
    public class UsuarioNoEncontradoException : KeyNotFoundException
    {
        public UsuarioNoEncontradoException() : base() { }

        public UsuarioNoEncontradoException(string pMensaje) : base(pMensaje) { }
    }
}
