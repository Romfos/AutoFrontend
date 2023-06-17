using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls;
using AutoFrontend.Wpf.Controls.Arguments;
using AutoFrontend.Wpf.Controls.Operations;
using AutoFrontend.Wpf.Controls.Results;
using AutoFrontend.Wpf.Controls.Services;
using System;

namespace AutoFrontend.Wpf;

public sealed class WpfApplicationBuilder
{
    private readonly ControlFactory controlFactory = new();
    private readonly FrontendModel frontendModel;

    private string title = "AutoFrontend";

    public WpfApplicationBuilder(FrontendModel frontendModel)
    {
        this.frontendModel = frontendModel;

        RegsiterDefaults();
    }

    private void RegsiterDefaults()
    {
        controlFactory.Register<ServiceModel>(service => new DefaultServiceControl(controlFactory, service));

        controlFactory.Register<OperationModel>(operation => operation.Arguments.Count == 0 && operation.Result.Type != typeof(void) ? new QueryOperationControl(controlFactory, operation) : null);
        controlFactory.Register<OperationModel>(operation => new DefaultOperationControl(controlFactory, operation));

        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(byte) ? new TextArgumentControl(argument, x => byte.Parse(x), "0") : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(sbyte) ? new TextArgumentControl(argument, x => sbyte.Parse(x), "0") : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(short) ? new TextArgumentControl(argument, x => short.Parse(x), "0") : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(ushort) ? new TextArgumentControl(argument, x => ushort.Parse(x), "0") : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(int) ? new TextArgumentControl(argument, x => int.Parse(x), "0") : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(uint) ? new TextArgumentControl(argument, x => uint.Parse(x), "0") : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(long) ? new TextArgumentControl(argument, x => long.Parse(x), "0") : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(ulong) ? new TextArgumentControl(argument, x => ulong.Parse(x), "0") : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(decimal) ? new TextArgumentControl(argument, x => decimal.Parse(x), "0") : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(float) ? new TextArgumentControl(argument, x => float.Parse(x), "0.0") : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(double) ? new TextArgumentControl(argument, x => double.Parse(x), "0.0") : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(char) ? new TextArgumentControl(argument, x => char.Parse(x), "x") : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(Uri) ? new TextArgumentControl(argument, x => new Uri(x), "http://test.com") : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(Guid) ? new TextArgumentControl(argument, x => Guid.Parse(x), Guid.NewGuid().ToString()) : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(DateTime) ? new TextArgumentControl(argument, x => DateTime.Parse(x), DateTime.Now.ToString()) : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(DateTimeOffset) ? new TextArgumentControl(argument, x => DateTimeOffset.Parse(x), DateTimeOffset.Now.ToString()) : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(TimeSpan) ? new TextArgumentControl(argument, x => TimeSpan.Parse(x), DateTime.Now.TimeOfDay.ToString()) : null);
#if NET6_0_OR_GREATER
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(DateOnly) ? new TextArgumentControl(argument, x => DateOnly.Parse(x), DateOnly.FromDateTime(DateTime.Now).ToString()) : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(TimeOnly) ? new TextArgumentControl(argument, x => TimeOnly.Parse(x), TimeOnly.FromDateTime(DateTime.Now).ToString()) : null);
#endif
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(string) ? new StringArgumentControl(argument, argument.Name) : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type == typeof(bool) ? new BoolArgumentControl(argument) : null);
        controlFactory.Register<ArgumentModel>(argument => argument.Type.IsEnum ? new EnumArgumentControl(argument) : null);
        controlFactory.Register<ArgumentModel>(argument => new JsonArgumentControl(argument));

        controlFactory.Register<ResultModel>(result => result.Type == typeof(byte) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(sbyte) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(short) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(ushort) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(int) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(uint) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(long) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(ulong) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(decimal) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(float) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(double) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(string) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(char) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(bool) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(Uri) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(Guid) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(DateTime) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(DateTimeOffset) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(TimeSpan) ? new TextResultControl() : null);
#if NET6_0_OR_GREATER
        controlFactory.Register<ResultModel>(result => result.Type == typeof(TimeOnly) ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(DateOnly) ? new TextResultControl() : null);
#endif
        controlFactory.Register<ResultModel>(result => result.Type.IsEnum ? new TextResultControl() : null);
        controlFactory.Register<ResultModel>(result => result.Type == typeof(void) ? new VoidResultControl() : null);
        controlFactory.Register<ResultModel>(result => new JsonResultControl(result));
    }

    public WpfApplicationBuilder Title(string title)
    {
        this.title = title;
        return this;
    }

    public void Run()
    {
        var wpfFrontendWindow = new WpfFrontendWindow(controlFactory, frontendModel);
        wpfFrontendWindow.Title = title;
        wpfFrontendWindow.ShowDialog();
    }
}
