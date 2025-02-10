using ei8.Cortex.Spiker.Domain.Model.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ei8.Cortex.Spiker.Domain.Model.Spikes
{
    public class SpikeService : ISpikeService
    {
        public event EventHandler Spiking;

        public SpikeService()
        {
        }

        public void Spike(NeuronCollection neurons, IEnumerable<SpikeTarget> targets, int spikeCount)
        {
            this.Spiking?.Invoke(this, EventArgs.Empty);

            for (int i = 1; i <= spikeCount; i++)
            {
                var nts = targets.Select(st => neurons[st.Id]);
                foreach (Neuron target in nts)
                {
                    SpikeService.SpikeNeuron(
                        new SpikeParameters()
                        {
                            Target = target,
                            Origin = new SpikeOrigin(Guid.NewGuid().ToString()),
                            Trigger = new TriggerInfo(DateTime.Now, NeurotransmitterEffect.Excite, 1f, "User"),
                            Path = new FireInfo[0],
                            Neurons = neurons
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
    }
}
