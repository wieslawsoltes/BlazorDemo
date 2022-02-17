using System.Threading.Tasks;

namespace BlazorDemo.Dialogs
{
    public interface IDialogService
    {
        Task ShowInputDialog(DialogOptions options);
        Task ShowOpenFilePicker();
        Task ShowSaveFilePicker();
        Task ShowDirectoryPicker();
    }
}
