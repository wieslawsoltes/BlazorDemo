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
                button.Click += (_, _) =>
                {
                    App.ShowInputDialog?.Invoke();
                };
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}