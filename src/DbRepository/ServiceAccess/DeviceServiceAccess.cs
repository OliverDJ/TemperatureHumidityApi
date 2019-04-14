using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DbRepository
{
    public class DeviceServiceAccess
    {
        private TemphumidContext _c;
        public DeviceServiceAccess(TemphumidContext c)
        {
            _c = c;
        }

        public async Task<List<Devices>> getAllDevicesAsync()
        {
            var r = await
                _c
                    .Devices
                    .ToListAsync();
            return r;
        }


        public async Task<Devices> getDeviceByIdAsync (int id)
        {
            var r = await
                   _c
                    .Devices
                    .SingleOrDefaultAsync(q => q.Id == id);
            return r;
        }

    }

}
