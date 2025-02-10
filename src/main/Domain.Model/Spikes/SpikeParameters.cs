using ei8.Cortex.Spiker.Domain.Model.Neurons;
using System.Collections.Generic;

namespace ei8.Cortex.Spiker.Domain.Model.Spikes
{
    public class SpikeParameters
    {
        public Neuron Target { get; set; }

        public SpikeOrigin Origin { get; set; }

        public TriggerInfo Trigger { get; set; }

        public IEnumerable<FireInfo> Path { get; set; }

        public NeuronCollection Neurons { get; set; }
    }
}
