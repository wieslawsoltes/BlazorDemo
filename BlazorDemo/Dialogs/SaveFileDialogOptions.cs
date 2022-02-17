using System.IO;

namespace BlazorDemo.Dialogs
{
    public class SaveFileDialogOptions
    {
        public byte[]? FileData { get; set; }

        public string? FileName { get; set; }
    }
}
