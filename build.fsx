#r "paket:
nuget Fake.Core.Target 
nuget Fake.IO.FileSystem
nuget Fake.IO.Zip 
nuget Fake.DotNet.Cli
//"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.IO
open Fake.Core.TargetOperators
open Fake.IO.Globbing.Operators
open Fake.DotNet
open System.IO


let appName = "TemperatureHumidityApi"
let sourceDir = __SOURCE_DIRECTORY__ 
let slnLocation = sprintf "%s\\TemperatureHumidityApi.sln" sourceDir
let deployDir = sprintf "%s\\deploy" sourceDir
let buildDir = sprintf "%s\\build" deployDir
let preZip = sprintf "%s\\preZip" deployDir
let artifactDir = sprintf "%s\\artifacts" deployDir

let paketFile = if Environment.isLinux then "paket" else "paket.exe"
let paketExe = Path.Combine(__SOURCE_DIRECTORY__, ".paket", paketFile)


Target.create "Clean" <|fun _ ->
    Shell.cleanDirs [buildDir; preZip; artifactDir ]


Target.create "InstallPaket" (fun _ ->
    if not (File.exists paketExe) then
        DotNet.exec id "tool" "install --tool-path \".paket\" Paket --version 5.182.0-alpha001 --add-source https://api.nuget.org/v3/index.json"
        |> ignore
    else
        printfn "paket already installed"
)


Target.create "Build" <|fun _ ->
    DotNet.publish (fun opt -> { 
        opt with             
            OutputPath = Some buildDir
            Configuration = DotNet.BuildConfiguration.Release
            }) slnLocation


// Target.create "Artifact" ( fun _ ->
//     let artifactDir = sprintf "%s\\artifacts" sourceDir
//     let artifactFilename = sprintf "%s\\%s.zip" artifactDir appName
//     Shell.mkdir artifactDir
//     Shell.copyDir artifactDir buildDir (fun _ -> true)
//     !! (sprintf "%s/**/*.*" artifactDir)
//     |> Zip.zip artifactDir artifactFilename
// )
Target.create "Artifact" ( fun _ ->
    let artifactFilename = sprintf "%s\\%s.zip" artifactDir appName
    Shell.mkdir preZip
    Shell.mkdir artifactDir
    Shell.copyDir preZip buildDir (fun _ -> true)
    !! (sprintf "%s/**/*.*" preZip)
    |> Zip.zip preZip artifactFilename
)


Target.create "Default" (fun _ ->
    Trace.trace "Hello World from FAKE" )

// Dependencies
open Fake.Core.TargetOperators

"Clean"
    ==> "InstallPaket"
    ==> "Build"  
    ==> "Artifact"
    ==> "Default"

// start build
Target.runOrDefault "Default"