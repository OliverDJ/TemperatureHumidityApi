namespace DbService

    
open System
open DbRepository
    module DeviceMopper = 
        

        type ExistingDevice =
            {
                Id: int
                Name: string
                CreatedAt: DateTime
            }
        
        type NewDevice =
            {
                Name: string
                CreatedAt: DateTime
            }   

        let mapDbRepositoryToDbService (d : DbRepository.Devices ) : ExistingDevice = 
            {
                Id = d.Id
                Name = d.Name
                CreatedAt = d.CreatedAt
            }

        let mapDbServiceToDbRepository (nd : NewDevice) : DbRepository.Devices =
            new DbRepository.Devices(
                Id = 0,
                Name = nd.Name,
                CreatedAt = nd.CreatedAt
            )
