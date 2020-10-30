using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SMO.Views
{
    public class Navbar : UserControl
    {
        public Navbar()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}