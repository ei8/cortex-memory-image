namespace ei8.Cortex.Spiker.Domain.Model.Spikes
{
    public struct SpikeOrigin
    {
        public SpikeOrigin(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }

        public override string ToString()
        {
            return $"SpikeOrigin: '{this.Id}'";
        }
    }
}
