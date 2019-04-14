namespace TemperatureHumidityApi
open System
open Giraffe
open Microsoft.AspNetCore.Http
open FSharp.Control.Tasks
open TemperatureHumidityApi.Moppers.DeviceMopper
open DbService.DeviceServiceHandler
open DbHelper
    module DeviceHandler =
        
        let getAllDevices =
            fun (next : HttpFunc) (context : HttpContext) -> 
                task {
                    let! s = context |> getDbConnStringFromServices 
                    let! a = getDevicesAsync s
                    let b = a |> Seq.map mapDbSeviceToApi
                    let r =  b |> context.WriteJsonAsync
                    return! r
                }
        
        let getDeviceById (id: int) =
             fun (next : HttpFunc) (context : HttpContext) -> 
                task {
                    let! s = context |> getDbConnStringFromServices 
                    let! a = (getDeviceByIdAsync s) id
                    let r = a |> mapDbSeviceToApi |> context.WriteJsonAsync
                    return! r
                }

        let addNewDevice (nd : NewDevice) =
            fun (next : HttpFunc) (context : HttpContext) ->
                task {
                    let! s = context |> getDbConnStringFromServices 
                    let dsnd = nd |> mapApiToDbService
                    let! q = dsnd |> (addNewDeviceAsync s)
                    let r = q |> context.WriteJsonAsync
                    return! r
                }
            

