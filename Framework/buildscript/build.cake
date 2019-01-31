var configuration = Argument("Configuration","debug");

Task("Clean")
    .Does(()=>{
        CleanDirectories("../src/**/bin/" + configuration);
        CleanDirectories("../src/**/obj/" + configuration);
});

Task("Build")
    .Does(()=>{
        DotNetCoreBuild("../src/Hercules.Core.sln");
});

Task("Pack-Nuget-Packages")
    .Does(()=>{
     var settings = new DotNetCorePackSettings
     {
         Configuration = configuration,
         OutputDirectory = "./artifacts/"
     };

     DotNetCorePack("../src/Hercules.Core.sln", settings);
});

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Build")
    .IsDependentOn("Pack-Nuget-Packages")
    ;

RunTarget("Default");