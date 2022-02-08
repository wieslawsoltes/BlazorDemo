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
                        Console.WriteLine("button.Click Begin");
                        await App.ShowInputDialog(Callback);
                        Console.WriteLine("button.Click End");
                    }
                };
            }
        }

        private void Callback(MemoryStream stream, string name)
        {
            var text = this.FindControl<TextBox>("text");
            if (text is { })
            {
                Console.WriteLine($"Callback(): {name}");
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