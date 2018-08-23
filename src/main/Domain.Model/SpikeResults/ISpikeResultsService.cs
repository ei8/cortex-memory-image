using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using works.ei8.Cortex.MemoryImage.Domain.Model.Neurons;

namespace works.ei8.Cortex.MemoryImage.Domain.Model.SpikeResults
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
