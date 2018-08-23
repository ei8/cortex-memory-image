using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using works.ei8.Cortex.MemoryImage.Domain.Model.Neurons;

namespace works.ei8.Cortex.MemoryImage.Domain.Model.SpikeResults
{
    public class SpikeResultsService : ISpikeResultsService
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private bool enabled = true;
        private NeuronCollection neurons;

        public event EventHandler Cleared;
        public event EventHandler<SpikeResultEventArgs> FiredAdded;
        public event EventHandler<SpikeResultEventArgs> TriggeredAdded;

        public SpikeResultsService(NeuronCollection neurons)
        {
            this.neurons = neurons;
        }

        public void AddFired(Neuron value, FiredEventArgs firedEventArgs)
        {
            if (this.enabled)
            {
                SpikeResultsService.logger.Info($"{value.ToString()} fired.{Environment.NewLine}");
                this.FiredAdded?.Invoke(this, new SpikeResultEventArgs(
                    new NeuronResult(firedEventArgs.FireInfo.Timestamp, value.Id, value.Data, NeurotransmitterEffect.Excite, firedEventArgs.Charge)
                    ));
            }
        }

        public void AddTriggered(Neuron value, TriggeredEventArgs triggeredEventArgs)
        {
            if (this.enabled)
            {
                this.TriggeredAdded?.Invoke(this, new SpikeResultEventArgs(new NeuronResult(triggeredEventArgs.TriggerInfo.Timestamp, value.Id, value.Data, triggeredEventArgs.TriggerInfo.Effect, triggeredEventArgs.Charge)));

                var path = string.Join(" >> ", triggeredEventArgs.Path.Select(fi => SpikeResultsService.GetTriggersWithChargeString(fi.Triggers, this.neurons)));
                SpikeResultsService.logger.Info($"{value.ToString()} triggered." +
                    $"{Environment.NewLine}\t{triggeredEventArgs.SpikeOrigin.ToString()}" +
                    $"{Environment.NewLine}\tCharge: {triggeredEventArgs.Charge} mV" +
                    $"{Environment.NewLine}\tPath: {path} >> {(neurons.Contains(triggeredEventArgs.TriggerInfo.PresynapticId) ? neurons[triggeredEventArgs.TriggerInfo.PresynapticId].Data : string.Empty)} " +
                    $"{Environment.NewLine}");
            }
        }

        private static string GetTriggersWithChargeString(IEnumerable<TriggerInfo> triggers, NeuronCollection neurons)
        {
            string result = string.Join(
                string.Empty,
                triggers.Select(et => (et.Effect == NeurotransmitterEffect.Excite ? "+" : "-") + (neurons.Contains(et.PresynapticId) ? neurons[et.PresynapticId].Data : string.Empty))
            );
            return result;
        }

        public void Clear()
        {
            this.Cleared?.Invoke(this, EventArgs.Empty);
        }

        public void Enable(bool value)
        {
            this.enabled = value;
        }
    }
}
