namespace ei8.Cortex.Spiker.Domain.Model.ResultMarkers
{
    public class ResultMarker
    {
        public ResultMarker(string id)
        {
            this.Id = id;
            this.Fired = false;
            this.ElapsedTime = 0;
        }

        public string Id { get; set; }

        public bool Fired { get; set; }

        public int ElapsedTime { get; set; }
    }
}
