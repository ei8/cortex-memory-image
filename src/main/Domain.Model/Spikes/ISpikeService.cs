using System;
using System.Collections.Generic;

namespace ei8.Cortex.Spiker.Domain.Model.Spikes
{
    public interface ISpikeService
    {
        event EventHandler Spiking;

        void SetSpikeCount(int value);

        void Spike(IEnumerable<SpikeTarget> spikeTargets);
    }
}
