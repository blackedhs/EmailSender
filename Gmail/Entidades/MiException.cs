﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MiException:Exception
    {
        public MiException(string msj,Exception inner):base(msj,inner)
        {
        }
    }
}
