using System;
using System.IO;

namespace BlazorDemo.Dialogs
{
    public class OpenFileDialogOptions
    {
        public Action<Stream, string>? Callback { get; set; }

        public string Filter { get; set; } = ".*";

        public bool AllowMultiple { get; set; } = false;

        public bool OpenFolder { get; set; } = false;

        public long MaxAllowedSize { get; set; } = 512000;

        public int MaximumFileCount { get; set; } = 10;
    }
}
