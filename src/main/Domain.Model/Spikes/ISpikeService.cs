using ei8.Cortex.Spiker.Domain.Model.Neurons;
using System;
using System.Collections.Generic;

namespace ei8.Cortex.Spiker.Domain.Model.Spikes
{
    public interface ISpikeService
    {
        event EventHandler Spiking;

        void Spike(NeuronCollection neurons, IEnumerable<SpikeTarget> spikeTargets, int spikeCount);
    }
}
