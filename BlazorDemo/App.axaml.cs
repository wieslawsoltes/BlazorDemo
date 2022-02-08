using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using BlazorDemo.ViewModels;
using BlazorDemo.Views;

namespace BlazorDemo
{
    public class InputDialogOptions
    {
        public Action<Stream, string>? Callback { get; set; }

        public string Filter { get; set; } = ".*";

        public bool AllowMultiple { get; set; } = false;

        public bool OpenFolder { get; set; } = false;

        public long MaxAllowedSize { get; set; } = 512000;

        public int MaximumFileCount { get; set; } = 10;
    }

    public partial class App : Application
    {
        public static Func<InputDialogOptions, Task>? ShowInputDialog { get; set;}
 
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainViewModel()
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = new MainViewModel()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
