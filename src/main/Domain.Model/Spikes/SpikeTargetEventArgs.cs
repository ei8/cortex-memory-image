﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace works.ei8.Cortex.MemoryImage.Domain.Model.Spikes
{
    public class SpikeTargetEventArgs : EventArgs
    {
        public SpikeTargetEventArgs(SpikeTarget target)
        {
            this.Target = target;
        }

        public SpikeTarget Target { get; private set; }
    }
}
