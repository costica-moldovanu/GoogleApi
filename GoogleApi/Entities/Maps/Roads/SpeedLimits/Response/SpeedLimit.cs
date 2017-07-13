﻿using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Request.Enums;

namespace GoogleApi.Entities.Maps.Roads.SpeedLimits.Response
{
    /// <summary>
    /// Speed Limit.
    /// Each element consists of the following fields.
    /// </summary>
    [DataContract(Name = "speedLimit")]
    public class SpeedLimit
    {
        /// <summary>
        /// PlaceId — A unique identifier for a place. 
        /// All place IDs returned by the Google Maps Roads API correspond to road segments. 
        /// Place IDs can be used with other Google APIs, including the Google Places API and the Google Maps JavaScript API. 
        /// For example, if you need to get road names for the snapped points returned by the Google Maps Roads API, you can pass the placeId to the 
        /// Google Places API or the Google Maps Geocoding API. Within the Google Maps Roads API, you can pass the placeId to the speedLimit method to 
        /// determine the speed limit along that road segment.
        /// </summary>
        [DataMember(Name = "PlaceId")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// SpeedLimit — The speed limit for that road segment.
        /// </summary>
        [DataMember(Name = "speedLimit")]
        public virtual int? Limit { get; set; }

        /// <summary>
        /// units — Returns either KPH or MPH.
        /// </summary>
        public virtual Units Units { get; set; }

        [DataMember(Name = "units")]
        internal virtual string UnitsStr
        {
            get => this.Units.ToString().ToUpper();
            set => this.Units = value.ToEnum<Units>();
        }
    }
}