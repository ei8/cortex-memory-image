using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace works.ei8.Cortex.MemoryImage.Domain.Model.ResultMarkers
{
    public interface IResultMarkerService
    {
        event EventHandler Initialized;
        event EventHandler<ResultMarkerEventArgs> Updated;
        event EventHandler<ResultMarkerEventArgs> Added;
        event EventHandler<ResultMarkerEventArgs> Removed;

        void Add(ResultMarker value);

        void Remove(ResultMarker value);

        void Initialize();

        void UpdateIfMarker(string id);

        IEnumerable<ResultMarker> Markers
        {
            get;
        }
    }
}
