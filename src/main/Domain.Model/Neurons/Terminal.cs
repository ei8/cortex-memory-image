﻿using System.ComponentModel;

namespace ei8.Cortex.Spiker.Domain.Model.Neurons
{
    public class Terminal
    {
        public Terminal() : this(string.Empty)
        {
        }

        public Terminal(string targetId) : this(targetId, NeurotransmitterEffect.Excite, 1f)
        {
        }

        public Terminal(string targetId, float strength) : this(targetId, NeurotransmitterEffect.Excite, strength)
        {
        }

        public Terminal(string targetId, NeurotransmitterEffect effect, float strength)
        { 
            this.TargetId = targetId;
            this.Effect = effect;
            this.Strength = strength;
        }

        [ParenthesizePropertyName(true)]
        public string TargetId { get; set; }

        public NeurotransmitterEffect Effect { get; set; }

        public float Strength { get; set; }
    }
}

