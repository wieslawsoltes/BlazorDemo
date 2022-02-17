using System.Threading.Tasks;

namespace BlazorDemo.Dialogs
{
    public interface IDialogService
    {
        Task ShowOpenFileDialog(OpenFileDialogOptions options);
        Task ShowSaveFileDialog(SaveFileDialogOptions options);
    }
}
