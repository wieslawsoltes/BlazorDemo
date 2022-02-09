using System.Threading.Tasks;

namespace BlazorDemo.Dialogs
{
    public interface IInputDialogService
    {
        Task ShowInputDialog(InputDialogOptions options);
        Task ShowOpenFilePicker();
        Task ShowSaveFilePicker();
        Task ShowDirectoryPicker();
    }
}
