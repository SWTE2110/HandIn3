﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microwave.Classes.Interfaces
{
    public interface IPowerTube
    {
        int MaxPower { get; }
        void TurnOn(int power);

        void TurnOff();
    }
}