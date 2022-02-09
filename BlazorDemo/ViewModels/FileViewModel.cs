using ReactiveUI;

namespace BlazorDemo.ViewModels
{
    public class FileViewModel : ViewModelBase
    {
        private string _name;
        private string _contents;

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        public string Contents
        {
            get => _contents;
            set => this.RaiseAndSetIfChanged(ref _contents, value);
        }

        public FileViewModel(string name, string contents)
        {
            _name = name;
            _contents = contents;
        }
    }
}
