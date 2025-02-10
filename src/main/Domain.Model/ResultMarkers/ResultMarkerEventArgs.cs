using System;

namespace ei8.Cortex.Spiker.Domain.Model.ResultMarkers
{
    public class ResultMarkerEventArgs : EventArgs
    {
        public ResultMarkerEventArgs(ResultMarker marker)
        {
            this.Marker = marker;
        }

        public ResultMarker Marker { get; private set; }
    }
}
