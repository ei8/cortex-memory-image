using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace works.ei8.Cortex.MemoryImage.Domain.Model.Spikes
{
    public interface ISpikeService
    {
        event EventHandler<SpikeTargetEventArgs> Added;
        event EventHandler<SpikeTargetEventArgs> Removed;
        event EventHandler Spiking;

        void Add(SpikeTarget value);

        void Remove(SpikeTarget value);

        IEnumerable<SpikeTarget> Targets
        {
            get;
        }

        void SetSpikeCount(int value);

        void Spike();
    }
}
