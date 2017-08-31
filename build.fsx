// include Fake lib
#r @"packages/make/FAKE/tools/FakeLib.dll"
open Fake

// Properties
let buildDir = "./build/"
let solutionName = "Astral.sln"



Target "Clean" (fun _ ->
    CleanDir buildDir
)

// Default target
Target "Default" (fun _ ->
    trace "Hello World from FAKE"
)



Target "Restore" (fun _ ->
    DotNetCli.Restore (fun p ->
                            { p with
                                Project = solutionName
                            })
)

Target "BuildApp" (fun _ ->
    (*!! "*.sln"
      |> MSBuildRelease buildDir "Build"
      |> Log "AppBuild-Output: "*)
    
    DotNetCli.Build (fun p ->
                         { p with
                                Configuration = "Debug"
                                Project = solutionName
                         })
)

// Dependencies
"Clean"
  ==> "Restore"
  ==> "BuildApp"
  ==> "Default"

// start build
RunTargetOrDefault "Default"
