namespace TemperatureHumidityApi.Moppers

open System

    module DeviceMopper =
        
        type ExisitingDevice = 
            {
                Id : int
                Name: string
                CreatedAt: DateTime
            }
        
        type NewDevice = {
            Name: string
        }


        let mapDbSeviceToApi ( d: DbService.DeviceMopper.ExistingDevice ) : ExisitingDevice = 
            {
                Id = d.Id
                Name = d.Name
                CreatedAt = d.CreatedAt
            }

        let mapApiToDbService (nd : NewDevice) : DbService.DeviceMopper.NewDevice =
           {
            Name = nd.Name
            CreatedAt = DateTime.Now
           }
        
        
