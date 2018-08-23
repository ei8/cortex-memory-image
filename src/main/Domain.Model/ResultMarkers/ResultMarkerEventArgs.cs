using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace works.ei8.Cortex.MemoryImage.Domain.Model.ResultMarkers
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
