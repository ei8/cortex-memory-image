using ei8.Cortex.Spiker.Domain.Model.Neurons;
using System;

namespace ei8.Cortex.Spiker.Domain.Model.SpikeResults
{
    public interface ISpikeResultsService
    {
        event EventHandler Cleared;
        event EventHandler<SpikeResultEventArgs> FiredAdded;
        event EventHandler<SpikeResultEventArgs> TriggeredAdded;

        void AddFired(Neuron value, FiredEventArgs firedEventArgs);

        void AddTriggered(Neuron result, TriggeredEventArgs triggeredEventArgs);

        void Clear();

        void Enable(bool value);
    }
}
