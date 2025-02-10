using System;
using System.Collections.Generic;

namespace ei8.Cortex.Spiker.Domain.Model.Spikes
{
    public interface ISpikeTargetListService
    {
        void Add(SpikeTarget value);

        void Remove(SpikeTarget value);

        event EventHandler<SpikeTargetEventArgs> Added;
        event EventHandler<SpikeTargetEventArgs> Removed;
        
        IEnumerable<SpikeTarget> Targets
        {
            get;
        }
    }
}
