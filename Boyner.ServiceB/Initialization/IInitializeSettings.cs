﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boyner.ServiceB
{
    public interface IInitializeSettings
    {
        Task<IEnumerable<Config>> Initialize();
    }
}
