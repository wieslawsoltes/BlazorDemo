using System.IO;
using Avalonia;
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
                var dialogs = Avalonia.AvaloniaLocator.Current.GetService<IDialogService?>();
                if (dialogs is null)
                {
                    return;
                }

                var dlg = new OpenFileDialogOptions()
                {
                    Callback = Callback,
                    Filter = ".txt,.json",
                    AllowMultiple = false,
                    OpenFolder = false,
                    MaxAllowedSize = long.MaxValue,
                    MaximumFileCount = 1
                };

                await dialogs.ShowOpenFileDialog(dlg);
            };

            buttonMultiple.Click += async (_, _) =>
            {
                var dialogs = Avalonia.AvaloniaLocator.Current.GetService<IDialogService?>();
                if (dialogs is null)
                {
                    return;
                }

                var dlg = new OpenFileDialogOptions()
                {
                    Callback = Callback,
                    Filter = ".txt,.json",
                    AllowMultiple = true,
                    OpenFolder = false,
                    MaxAllowedSize = long.MaxValue,
                    MaximumFileCount = 10
                };

                await dialogs.ShowOpenFileDialog(dlg);
            };

            buttonSave.Click += async (_, _) =>
            {
                var dialogs = Avalonia.AvaloniaLocator.Current.GetService<IDialogService?>();
                if (dialogs is null)
                {
                    return;
                }

                if (DataContext is MainViewModel viewModel && viewModel.SelectedFile is { })
                {
                    var dlg = new SaveFileDialogOptions()
                    {
                        FileData = System.Text.Encoding.ASCII.GetBytes(viewModel.SelectedFile.Contents),
                        FileName = viewModel.SelectedFile.Name
                    };

                    await dialogs.ShowSaveFileDialog(dlg);
                }
            };

            buttonFolder.Click += async (_, _) =>
            {
                var dialogs = Avalonia.AvaloniaLocator.Current.GetService<IDialogService?>();
                if (dialogs is null)
                {
                    return;
                }

                var dlg = new OpenFileDialogOptions()
                {
                    Callback = Callback,
                    Filter = ".txt,.json",
                    AllowMultiple = true,
                    OpenFolder = true,
                    MaxAllowedSize = long.MaxValue,
                    MaximumFileCount = 10
                };

                await dialogs.ShowOpenFileDialog(dlg);
            };
        }

        private void Callback(Stream stream, string name)
        {
            if (DataContext is MainViewModel viewModel)
            {
                using var reader = new StreamReader(stream);
                var contents = reader.ReadToEnd();
                var file = new FileViewModel(name, contents);
                viewModel.Files.Add(file);
                viewModel.SelectedFile = file;
            }
        }
    }
}
