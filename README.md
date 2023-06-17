# Owerview

AutoFrontend is a framework for automatically building UI applications based on custom business logic

## Why this framework could be useful for you?

Some use cases:

1. For prototyping. If you need to create prototype of some UI applciation in a very fast way.

2. For initial development phase.  
   If you want to **start from business logic and build custom UI later** when BL will have more final shape.

3. For builing test data generators.
   These types of applications often do not require custom UI. Often it should just works.

4. For builing test\admin\internal usage applications.  
   Typical examples: test client apps for some services, token generators, admin tools, e.t.c

## Supported platforms

| Technology | Supported platforms                           | Nuget                                                               |
| ---------- | --------------------------------------------- | ------------------------------------------------------------------- |
| Wpf        | .NET 6+ (Recomended) or .NET Framework 4.6.2+ | [AutoFrontend.Wpf](https://www.nuget.org/packages/AutoFrontend.Wpf) |

## How to use

1. Create new empty project for target technology
2. Install nuget package AutoFrontend.\* based on selected technology
3. Create FrontendBuilder, register services, and run application. Example:

```csharp
public class CustomService
{
  public int Add(int x, int y) => x + y;

  public int Substract(int x, int y) => x - y;
}
```

Program.cs

```csharp
internal class Program
{
    [STAThread]
    public static void Main()
    {
        var customService = new CustomService(); //Get instance of your service somehow

        var applicationBuilder = new FrontendBuilder();
        applicationBuilder.Service(customService);
        applicationBuilder.BuildWpfFrontend().Run();
    }
}
```
