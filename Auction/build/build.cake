var configuration = Argument("Configuration","Debug");
var artifactPath = Argument("ArtifactPath",@"C:\local-nuget");

Task("Clean")
    .Does(()=>{
    CleanDirectories("../src/**/bin/" + configuration);
    CleanDirectories("../src/**/obj/" + configuration);
});

Task("Build")
    .Does(()=>{
    DotNetBuild("../src/Auction.sln", settings =>
        settings.SetConfiguration(configuration)
            .WithTarget("Build"));
});

// Task("Run-Unit-Test")
//     .Does(()=>{
    //TODO: complete this
// });

Task("Pack")
    .Does(()=>{
     var settings = new DotNetCorePackSettings
     {
         Configuration = configuration,
         OutputDirectory = artifactPath
     };

     DotNetCorePack("../src/AuctionManagement.Domain.Contracts/AuctionManagement.Domain.Contracts.csproj", settings);
});

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Build")
    .IsDependentOn("Pack");

RunTarget("Default");