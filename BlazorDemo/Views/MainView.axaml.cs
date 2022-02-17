using System;
using System.IO;
using Avalonia.Controls;
using BlazorDemo.Dialogs;
using BlazorDemo.ViewModels;

namespace BlazorDemo.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();

            buttonSingle.Click += async (_, _) =>
            {
                if (App.Dialogs is null)
                {
                    return;
                }
                Console.WriteLine("buttonSingle.Click Begin");
                var dlg = new DialogOptions()
                {
                    Callback = Callback,
                    Filter = ".txt,.json",
                    AllowMultiple = false,
                    OpenFolder = false,
                    MaxAllowedSize = long.MaxValue,
                    MaximumFileCount = 1
                };
                await App.Dialogs.ShowInputDialog(dlg);
                Console.WriteLine("buttonSingle.Click End");
            };

            buttonMultiple.Click += async (_, _) =>
            {
                if (App.Dialogs is null)
                {
                    return;
                }
                Console.WriteLine("buttonMultiple.Click Begin");
                var dlg = new DialogOptions()
                {
                    Callback = Callback,
                    Filter = ".txt,.json",
                    AllowMultiple = true,
                    OpenFolder = false,
                    MaxAllowedSize = long.MaxValue,
                    MaximumFileCount = 10
                };
                await App.Dialogs.ShowInputDialog(dlg);
                Console.WriteLine("buttonMultiple.Click End");
            };

            buttonFolder.Click += async (_, _) =>
            {
                if (App.Dialogs is null)
                {
                    return;
                }
                Console.WriteLine("buttonFolder.Click Begin");
                var dlg = new DialogOptions()
                {
                    Callback = Callback,
                    Filter = ".txt,.json",
                    AllowMultiple = true,
                    OpenFolder = true,
                    MaxAllowedSize = long.MaxValue,
                    MaximumFileCount = 10
                };
                await App.Dialogs.ShowInputDialog(dlg);
                Console.WriteLine("buttonFolder.Click End");
            };

            buttonOpenFilePicker.Click += async (_, _) =>
            {
                if (App.Dialogs is null)
                {
                    return;
                }
                Console.WriteLine("buttonOpenFilePicker.Click Begin");
                await App.Dialogs.ShowOpenFilePicker();
                Console.WriteLine("buttonOpenFilePicker.Click End");
            };

            buttonSaveFilePicker.Click += async (_, _) =>
            {
                if (App.Dialogs is null)
                {
                    return;
                }
                Console.WriteLine("buttonSaveFilePicker.Click Begin");
                await App.Dialogs.ShowSaveFilePicker();
                Console.WriteLine("buttonSaveFilePicker.Click End");
            };

            buttonDirectoryPicker.Click += async (_, _) =>
            {
                if (App.Dialogs is null)
                {
                    return;
                }
                Console.WriteLine("buttonDirectoryPicker.Click Begin");
                await App.Dialogs.ShowDirectoryPicker();
                Console.WriteLine("buttonDirectoryPicker.Click End");
            };
        }

        private void Callback(Stream stream, string name)
        {
            if (DataContext is MainViewModel viewModel)
            {
                Console.WriteLine($"Callback(): {name}");
                using var reader = new StreamReader(stream);
                var contents = reader.ReadToEnd();
                var file = new FileViewModel(name, contents);
                viewModel.Files.Add(file);
                viewModel.SelectedFile = file;
            }
        }
    }
}
