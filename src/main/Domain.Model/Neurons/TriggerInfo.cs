using System;

namespace ei8.Cortex.Spiker.Domain.Model.Neurons
{
    public struct TriggerInfo
    {
        public TriggerInfo(DateTime timestamp, NeurotransmitterEffect effect, float strength, string presynapticId)
        {
            this.Timestamp = timestamp;
            this.Effect = effect;
            this.Strength = strength;
            this.PresynapticId = presynapticId;
        }

        public readonly DateTime Timestamp;
        public readonly NeurotransmitterEffect Effect;
        public readonly float Strength;
        public readonly string PresynapticId;
    }
}
