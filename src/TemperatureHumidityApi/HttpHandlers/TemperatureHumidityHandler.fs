namespace TemperatureHumidityApi
open Giraffe
open Microsoft.AspNetCore.Http
open FSharp.Control.Tasks
open DbService.TemperatureHumidityServiceHandler

open TemperatureHumidityMopper
    module TemperatureHumidityHandler =
        

        let getAllTempHumids = 
            fun (next : HttpFunc) (context : HttpContext) -> 
                task {
                    let! q = getAllTempHumidsAsync()
                    let dsth = q |> Seq.map mapDbServiceToApi |> Seq.toList
                    let r = dsth |> context.WriteJsonAsync
                    return! r
                }
        

        let addNewTempHumid (nth : NewTemperatureHumidity) = 
            fun (next : HttpFunc) (context : HttpContext) ->
                task {
                    let dsth = nth |> mapApiToDbService
                    let! m = DbService.TemperatureHumidityServiceHandler.addNewTempHumidAsync dsth
                    let r = m |> context.WriteJsonAsync
                    return! r                
                }

