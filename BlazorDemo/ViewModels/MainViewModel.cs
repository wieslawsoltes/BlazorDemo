using System.Collections.ObjectModel;
using ReactiveUI;

namespace BlazorDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private FileViewModel? _selectedFile;
        private ObservableCollection<FileViewModel> _files;

        public FileViewModel? SelectedFile
        {
            get => _selectedFile;
            set => this.RaiseAndSetIfChanged(ref _selectedFile, value);
        }

        public ObservableCollection<FileViewModel> Files
        {
            get => _files;
            set => this.RaiseAndSetIfChanged(ref _files, value);
        }

        public MainViewModel()
        {
            _files = new ObservableCollection<FileViewModel>();
        }
    }
}
