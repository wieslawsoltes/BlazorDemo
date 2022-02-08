using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BlazorDemo.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();

            var button = this.FindControl<Button>("button");
            if (button is { })
            {
                button.Click += async (_, _) =>
                {
                    if (App.ShowInputDialog is { })
                    {
                        await App.ShowInputDialog(Callback);
                    }
                };
            }
        }

        private void Callback(MemoryStream stream)
        {
            var text = this.FindControl<TextBox>("text");
            if (text is { })
            {
                Console.WriteLine("Callback()");
                stream.Position = 0;
                using var reader = new StreamReader(stream);
                var str = reader.ReadToEnd();
                text.Text = str;
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}