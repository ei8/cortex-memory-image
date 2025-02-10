﻿using System;

namespace ei8.Cortex.Spiker.Domain.Model.Spikes
{
    public struct SpikeTarget
    {
        public SpikeTarget(string id)
        {
            this.Id = id;
        }

        public readonly string Id;

        public override bool Equals(Object obj)
        {
            return obj is SpikeTarget && this == (SpikeTarget)obj;
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); // ^ this.Id2.GetHashCode();
        }
        public static bool operator ==(SpikeTarget x, SpikeTarget y)
        {
            return x.Id == y.Id; // && x.im == y.im;
        }
        public static bool operator !=(SpikeTarget x, SpikeTarget y)
        {
            return !(x == y);
        }
    }
}
