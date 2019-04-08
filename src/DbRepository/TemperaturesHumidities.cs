using System;
using System.Collections.Generic;

namespace DbRepository
{
    public partial class TemperaturesHumidities
    {
        public int Id { get; set; }
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
        public DateTime Timestamp { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public int DeviceId { get; set; }

        public virtual Devices Device { get; set; }
    }
}