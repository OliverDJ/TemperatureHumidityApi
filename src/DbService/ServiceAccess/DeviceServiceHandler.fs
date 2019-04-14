
namespace DbService
open DbRepository 
open FSharp.Control.Tasks.V2.ContextInsensitive
open DeviceMopper
open Context
open System
open System.Threading.Tasks

    module DeviceServiceHandler =

        let private _getDevicesAsync (dsa : DeviceServiceAccess) : Task<ExistingDevice list>= 
            task{
                let! q = dsa.getAllDevicesAsync()
                let r = q |>  Seq.map mapDbRepositoryToDbService |> Seq.toList
                return r
            }
        
        let private _tryGetDeviceByIdAsync (dsa : DeviceServiceAccess) (id: int) : Task<ExistingDevice> =
            task {
                let! q =  id |> dsa.getDeviceByIdAsync 
                let r = q |> DbService.DeviceMopper.mapDbRepositoryToDbService
                return r
            }
        
        let _addNewDeviceAsync (ctx : TemphumidContext) ( nd: NewDevice) =
            task {
                let dbnd = nd |> mapDbServiceToDbRepository
                ctx.Devices.Add(dbnd) |> ignore
                let! r = ctx.SaveChangesAsync()
                return r
            }
        
        let createCtx s =  s |> configureSqlServerContext 
        let dsa s = DeviceServiceAccess (createCtx s) 
        let getDevicesAsync s = _getDevicesAsync (dsa s)
        let getDeviceByIdAsync s = _tryGetDeviceByIdAsync (dsa s)
        let addNewDeviceAsync s = _addNewDeviceAsync (createCtx s) 
          

            

            

