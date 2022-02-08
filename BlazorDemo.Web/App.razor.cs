using Avalonia.ReactiveUI;
using Avalonia.Web.Blazor;

namespace BlazorDemo.Web;

public partial class App
{
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        
        WebAppBuilder.Configure<BlazorDemo.App>()
            .UseReactiveUI()
            .SetupWithSingleViewLifetime();
    }
}