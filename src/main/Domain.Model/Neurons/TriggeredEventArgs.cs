using ei8.Cortex.Spiker.Domain.Model.Spikes;
using System;
using System.Collections.Generic;

namespace ei8.Cortex.Spiker.Domain.Model.Neurons
{
    public class TriggeredEventArgs : EventArgs
    {
        public TriggeredEventArgs(SpikeOrigin spikeOrigin, TriggerInfo triggerInfo, int charge, IEnumerable<FireInfo> path)
        {
            this.SpikeOrigin = spikeOrigin;
            this.TriggerInfo = triggerInfo;
            this.Charge = charge;
            this.Path = path;
        }

        public SpikeOrigin SpikeOrigin { get; private set; }
        public TriggerInfo TriggerInfo { get; private set; }
        public int Charge { get; private set; }
        public IEnumerable<FireInfo> Path { get; private set; }
    }
}
