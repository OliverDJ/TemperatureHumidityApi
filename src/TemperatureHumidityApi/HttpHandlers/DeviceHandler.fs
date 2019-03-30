namespace TemperatureHumidityApi
open System
open Giraffe
open Microsoft.AspNetCore.Http
open FSharp.Control.Tasks
open TemperatureHumidityApi.Moppers.DeviceMopper

    module DeviceHandler =
        
        let getAllDevices =
            fun (next : HttpFunc) (context : HttpContext) -> 
                task {
                    let myDevice: ExisitngDevice = 
                        {
                            Id = 1
                            Name = "Grii"
                            CreatedAt = DateTime.Now
                        }
                    //let dbctx = context |> DataBaseHelpers.getDbCtx
                    //let! qr = dbctx() |> getAllQuestionsAsync
                    //let r = 
                    //    qr |> Seq.map mapDbServiceQuestionToWebApiQuestion |> context.WriteJsonAsync
                    let r =  myDevice |> context.WriteJsonAsync
                    return! r
                }

