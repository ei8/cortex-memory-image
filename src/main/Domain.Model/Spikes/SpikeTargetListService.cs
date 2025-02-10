using System;
using System.Collections.Generic;

namespace ei8.Cortex.Spiker.Domain.Model.Spikes
{
    public class SpikeTargetListService : ISpikeTargetListService
    {
        public event EventHandler<SpikeTargetEventArgs> Added;
        public event EventHandler<SpikeTargetEventArgs> Removed;

        private IList<SpikeTarget> spikeTargets = new List<SpikeTarget>();

        public void Add(SpikeTarget value)
        {
            this.spikeTargets.Add(value);
            this.Added?.Invoke(this, new SpikeTargetEventArgs(value));
        }

        public void Remove(SpikeTarget value)
        {
            this.spikeTargets.Remove(value);
            this.Removed?.Invoke(this, new SpikeTargetEventArgs(value));
        }
        
        public IEnumerable<SpikeTarget> Targets => this.spikeTargets;
    }
}
