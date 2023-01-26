# Owerview

AutoFrontend is a framework for automatic builing UI applciations based on custom businees logic

# Why this framework could be useful?
Some use cases:
1) For prototyping. If you need to create prototype of some UI applciation in a very fast way.
2) During initial development phase. 
Good approach to build new applciation is to **start from business logic and build custom UI later** when BL will have more final shape.
3) For builing test\admin\internal usage applications. These type of applications often do not require custom UI. Often it should just works. Typical applciations: test client apps, test data generators, token generators, e.t.c

# Supported platforms
| Technology | Supported platforms                           | Nuget            |
| ---------- | --------------------------------------------- | ---------------- |
| Wpf        | .NET 6+ (Recomended) or .NET Framework 4.6.2+ | AutoFrontend.Wpf |

# How to use
1) Create new empty projet for target technology
2) Install nuget package AutoFrontend.* based on selected technology
3) Create FrontendBuilder, register services, and run applciation. Example:

```csharp
var applicationBuilder = new FrontendBuilder();
applicationBuilder.Service(customService);
applicationBuilder.RunWpfpplication();
```
