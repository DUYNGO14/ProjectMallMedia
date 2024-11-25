var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.MallMedia_API>("mallmedia-api");

builder.AddProject<Projects.MallMedia_Presentation>("mallmedia-presentation");

builder.Build().Run();
