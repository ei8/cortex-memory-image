using ei8.Cortex.Spiker.Domain.Model.Neurons;
using System;

namespace ei8.Cortex.Spiker.Domain.Model.SpikeResults
{
    public struct NeuronResult
    {
        public NeuronResult(DateTime timestamp, string id, string data, NeurotransmitterEffect effect, int charge)
        {
            this.Timestamp = timestamp;
            this.Id = id;
            this.Data = data;
            this.Effect = effect;
            this.Charge = charge;
        }

        public readonly DateTime Timestamp;
        public readonly string Id;
        public readonly string Data;
        public NeurotransmitterEffect Effect { get; private set; }
        public int Charge { get; private set; }
    }
}
