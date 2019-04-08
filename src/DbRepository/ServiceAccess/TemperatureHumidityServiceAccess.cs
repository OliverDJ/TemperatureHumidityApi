using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DbRepository
{
    public class TemperatureHumidityServiceAccess
    {

        private TemphumidContext _c;

        public TemperatureHumidityServiceAccess(TemphumidContext c)
        {
            this._c = c;
        }

        public async Task<List<TemperaturesHumidities>> getAllTempHumids()
        {
            var r = await
                _c
                    .TemperaturesHumidities
                    .ToListAsync();
            return r;
        }

        //public async Task<List<TemperaturesHumidities>> getTempHumidsByDeviceId(int deviceId)
        //{
        //    var r = await
        //        _c
        //            .TemperaturesHumidities
                    
        //            //.Where
        //            //.Include(th => th.DeviceId == deviceId)
        //            .ToListAsync();
        //    return r;

        //}



    }
}
