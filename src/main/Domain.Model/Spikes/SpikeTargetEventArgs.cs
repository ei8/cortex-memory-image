using System;

namespace ei8.Cortex.Spiker.Domain.Model.Spikes
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
