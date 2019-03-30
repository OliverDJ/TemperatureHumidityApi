using System;
using System.Collections.Generic;

namespace DbRepository
{
    public partial class Devices
    {
        public Devices()
        {
            TemperaturesHumidities = new HashSet<TemperaturesHumidities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<TemperaturesHumidities> TemperaturesHumidities { get; set; }
    }
}