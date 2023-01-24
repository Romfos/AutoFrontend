using AutoFrontend.Builders;
using AutoFrontend.WindowsForms;
using Playground.Services;

var demoStateService = new UserService();

var applicationBuilder = new FrontendBuilder();
applicationBuilder.Service(demoStateService);
applicationBuilder.RunWindowsFormsApplication();
