using System;

namespace ei8.Cortex.Spiker.Domain.Model.SpikeResults
{
    public class SpikeResultEventArgs : EventArgs
    {
        public SpikeResultEventArgs(NeuronResult result)
        {
            this.Result = result;
        }

        public NeuronResult Result { get; private set; }
    }
}
