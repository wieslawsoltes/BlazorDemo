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

            void Callback(Stream stream, string name)
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

            buttonSingle.Click += async (_, _) =>
            {
                var dlg = Avalonia.AvaloniaLocator.Current.GetService<IDialogService?>();
                if (dlg is null)
                {
                    return;
                }

                var options = new OpenFileDialogOptions()
                {
                    Callback = Callback,
                    Filter = ".txt,.json",
                    AllowMultiple = false,
                    OpenFolder = false,
                    MaxAllowedSize = long.MaxValue,
                    MaximumFileCount = 1
                };

                await dlg.ShowOpenFileDialog(options);
            };

            buttonMultiple.Click += async (_, _) =>
            {
                var dlg = Avalonia.AvaloniaLocator.Current.GetService<IDialogService?>();
                if (dlg is null)
                {
                    return;
                }

                var options = new OpenFileDialogOptions()
                {
                    Callback = Callback,
                    Filter = ".txt,.json",
                    AllowMultiple = true,
                    OpenFolder = false,
                    MaxAllowedSize = long.MaxValue,
                    MaximumFileCount = 10
                };

                await dlg.ShowOpenFileDialog(options);
            };

            buttonSave.Click += async (_, _) =>
            {
                var dlg = Avalonia.AvaloniaLocator.Current.GetService<IDialogService?>();
                if (dlg is null)
                {
                    return;
                }

                if (DataContext is MainViewModel viewModel && viewModel.SelectedFile is { })
                {
                    var options = new SaveFileDialogOptions()
                    {
                        FileData = System.Text.Encoding.ASCII.GetBytes(viewModel.SelectedFile.Contents),
                        FileName = viewModel.SelectedFile.Name
                    };

                    await dlg.ShowSaveFileDialog(options);
                }
            };

            buttonFolder.Click += async (_, _) =>
            {
                var dlg = Avalonia.AvaloniaLocator.Current.GetService<IDialogService?>();
                if (dlg is null)
                {
                    return;
                }

                var options = new OpenFileDialogOptions()
                {
                    Callback = Callback,
                    Filter = ".txt,.json",
                    AllowMultiple = true,
                    OpenFolder = true,
                    MaxAllowedSize = long.MaxValue,
                    MaximumFileCount = 10
                };

                await dlg.ShowOpenFileDialog(options);
            };
        }
    }
}
