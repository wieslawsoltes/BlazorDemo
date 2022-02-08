using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BlazorDemo.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();

            buttonSingle.Click += async (_, _) =>
            {
                if (App.ShowInputDialog is null)
                {
                    return;
                }
                Console.WriteLine("buttonSingle.Click Begin");
                var dlg = new InputDialogOptions()
                {
                    Callback = Callback,
                    Filter = ".txt,.json",
                    AllowMultiple = false,
                    OpenFolder = false
                };
                await App.ShowInputDialog(dlg);
                Console.WriteLine("buttonSingle.Click End");
            };

            buttonMultiple.Click += async (_, _) =>
            {
                if (App.ShowInputDialog is null)
                {
                    return;
                }
                Console.WriteLine("buttonMultiple.Click Begin");
                var dlg = new InputDialogOptions()
                {
                    Callback = Callback,
                    Filter = ".txt,.json",
                    AllowMultiple = true,
                    OpenFolder = false
                };
                await App.ShowInputDialog(dlg);
                Console.WriteLine("buttonMultiple.Click End");
            };

            buttonFolder.Click += async (_, _) =>
            {
                if (App.ShowInputDialog is null)
                {
                    return;
                }
                Console.WriteLine("buttonFolder.Click Begin");
                var dlg = new InputDialogOptions()
                {
                    Callback = Callback,
                    Filter = ".txt,.json",
                    AllowMultiple = true,
                    OpenFolder = true
                };
                await App.ShowInputDialog(dlg);
                Console.WriteLine("buttonFolder.Click End");
            };
        }

        private void Callback(Stream stream, string name)
        {
            if (text is { })
            {
                Console.WriteLine($"Callback(): {name}");
                using var reader = new StreamReader(stream);
                var str = reader.ReadToEnd();
                text.Text = str;
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
