using System;
using System.IO;
using Avalonia.Controls;
using BlazorDemo.Dialogs;

namespace BlazorDemo.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();

            buttonSingle.Click += async (_, _) =>
            {
                if (App.InputDialogService is null)
                {
                    return;
                }
                Console.WriteLine("buttonSingle.Click Begin");
                var dlg = new InputDialogOptions()
                {
                    Callback = Callback,
                    Filter = ".txt,.json",
                    AllowMultiple = false,
                    OpenFolder = false,
                    MaxAllowedSize = long.MaxValue,
                    MaximumFileCount = 1
                };
                await App.InputDialogService.ShowInputDialog(dlg);
                Console.WriteLine("buttonSingle.Click End");
            };

            buttonMultiple.Click += async (_, _) =>
            {
                if (App.InputDialogService is null)
                {
                    return;
                }
                Console.WriteLine("buttonMultiple.Click Begin");
                var dlg = new InputDialogOptions()
                {
                    Callback = Callback,
                    Filter = ".txt,.json",
                    AllowMultiple = true,
                    OpenFolder = false,
                    MaxAllowedSize = long.MaxValue,
                    MaximumFileCount = 10
                };
                await App.InputDialogService.ShowInputDialog(dlg);
                Console.WriteLine("buttonMultiple.Click End");
            };

            buttonFolder.Click += async (_, _) =>
            {
                if (App.InputDialogService is null)
                {
                    return;
                }
                Console.WriteLine("buttonFolder.Click Begin");
                var dlg = new InputDialogOptions()
                {
                    Callback = Callback,
                    Filter = ".txt,.json",
                    AllowMultiple = true,
                    OpenFolder = true,
                    MaxAllowedSize = long.MaxValue,
                    MaximumFileCount = 10
                };
                await App.InputDialogService.ShowInputDialog(dlg);
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
    }
}
