using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using works.ei8.Cortex.MemoryImage.Domain.Model.Neurons;

namespace works.ei8.Cortex.MemoryImage.Domain.Model.Spikes
{
    public class SpikeService : ISpikeService
    {
        private class SpikeParameters
        {
            public Neuron Target { get; set; }

            public SpikeOrigin Origin { get; set; }

            public TriggerInfo Trigger { get; set; }

            public IEnumerable<FireInfo> Path { get; set; }

            public NeuronCollection Neurons { get; set; }
        }

        public event EventHandler<SpikeTargetEventArgs> Added;
        public event EventHandler<SpikeTargetEventArgs> Removed;
        public event EventHandler Spiking;

        private IList<SpikeTarget> spikeTargets = new List<SpikeTarget>();
        private int spikeCount = 1;
        private NeuronCollection neurons;

        public SpikeService(NeuronCollection neurons)
        {
            this.neurons = neurons;
        }

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

        public void SetSpikeCount(int value)
        {
            this.spikeCount = value;
        }

        public void Spike()
        {
            this.Spiking?.Invoke(this, EventArgs.Empty);

            for (int i = 1; i <= this.spikeCount; i++)
            {
                var targets = this.Targets.Select(st => this.neurons[st.Id]);
                foreach (Neuron target in targets)
                {
                    SpikeService.SpikeNeuron(
                        new SpikeParameters()
                        {
                            Target = target,
                            Origin = new SpikeOrigin(Guid.NewGuid().ToString()),
                            Trigger = new TriggerInfo(DateTime.Now, NeurotransmitterEffect.Excite, 1f, "User"),
                            Path = new FireInfo[0],
                            Neurons = this.neurons
                        }
                        );
                }
            }
        }

        private static void SpikeNeuron(object stateInfo)
        {
            SpikeParameters parameters = (SpikeParameters)stateInfo;
            var spikeResultingFireInfo = parameters.Target.Spike(parameters.Origin, parameters.Trigger, parameters.Path);
            if (spikeResultingFireInfo != FireInfo.Empty)
            {
                parameters.Target.Terminals.ToList().ForEach(
                    t => ThreadPool.QueueUserWorkItem(SpikeService.SpikeNeuron, new SpikeParameters()
                        {
                            Target = parameters.Neurons[t.TargetId],
                            Origin = parameters.Origin,
                            Trigger = new TriggerInfo(DateTime.Now, t.Effect, t.Strength, parameters.Target.Id),
                            Path = parameters.Path.Concat(new FireInfo[] { spikeResultingFireInfo }),
                            Neurons = parameters.Neurons
                        }
                    )
                );
            }
        }

        public IEnumerable<SpikeTarget> Targets => this.spikeTargets;
    }
}
