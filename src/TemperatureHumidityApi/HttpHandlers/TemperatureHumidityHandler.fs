namespace TemperatureHumidityApi
open Giraffe
open Microsoft.AspNetCore.Http
open FSharp.Control.Tasks
open TemperatureHumidityApi.Moppers.DeviceMopper

    module TemperatureHumidityHandler =
        

        let getAllTempHumids = 
            fun (next : HttpFunc) (context : HttpContext) -> 
                task {
                    let! a = getTempHumidsAsync//getDevicesAsync()
                    //let b = a |> Seq.map mapDbSeviceToApi
                    //let r =  b |> context.WriteJsonAsync
                    //return! r
                }

