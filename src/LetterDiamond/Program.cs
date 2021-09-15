using Spectre.Console.Cli;
using Microsoft.Extensions.DependencyInjection;

// register all the dependencies and services required to run the application
var services = new ServiceCollection();
services.AddSingleton<ISpaceCalculationService, SpaceCalculationService>();

var registrar = new TypeRegistrar(services);
var app = new CommandApp<LetterDiamond>(registrar);
await app.RunAsync(args);