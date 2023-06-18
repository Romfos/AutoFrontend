using AutoFrontend.BlazorServer;
using AutoFrontend.Builders;
using Playground.Services;

var demoStateService = new UserService();
var calculatorService = new CalculatorService();

var frontendBuilder = new FrontendBuilder();
frontendBuilder.Service(demoStateService);
frontendBuilder.Service(calculatorService);

await frontendBuilder.BuildBlazorServerApplication().RunAsync();
