﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class InstructieAfgelopenArgs : EventArgs
    {
        public List<Sporter> Sporters { get; }
        public InstructieAfgelopenArgs(List<Sporter> sporters)
        {
            Sporters = sporters;
        }
    }
}
