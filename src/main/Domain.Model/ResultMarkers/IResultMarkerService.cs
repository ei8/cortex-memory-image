using System;
using System.Collections.Generic;

namespace ei8.Cortex.Spiker.Domain.Model.ResultMarkers
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
