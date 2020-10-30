using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using smo_sharp.Models;

namespace SMO.Views
{
    public class ResultTable : UserControl
    {
        public ResultTable()
        {
            DataContext = SingletoneFactory.GetResultTableViewModel();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}