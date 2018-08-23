using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace works.ei8.Cortex.MemoryImage.Domain.Model.SpikeResults
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
