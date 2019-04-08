namespace TemperatureHumidityApi
open System
open Giraffe
open Microsoft.AspNetCore.Http
open FSharp.Control.Tasks
open TemperatureHumidityApi.Moppers.DeviceMopper

open DbService.DeviceServiceHandler
    module DeviceHandler =
        
        let getAllDevices =
            fun (next : HttpFunc) (context : HttpContext) -> 
                task {
                    let! a = getDevicesAsync()
                    let b = a |> Seq.map mapDbSeviceToApi
                    let r =  b |> context.WriteJsonAsync
                    return! r
                }
        
        let getDeviceById (id: int) =
             fun (next : HttpFunc) (context : HttpContext) -> 
                task {
                    let! a = getDeviceByIdAsync id
                    let r = a |> mapDbSeviceToApi |> context.WriteJsonAsync
                    return! r
                }

        let addNewDevice (nd : NewDevice) =
            fun (next : HttpFunc) (context : HttpContext) ->
                task {
                    let dsnd = nd |> mapApiToDbService
                    let! q = dsnd |> addNewDeviceAsync 
                    let r = q |> context.WriteJsonAsync
                    return! r
                }
            

