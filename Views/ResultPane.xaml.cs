using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using smo_sharp.Models;

namespace SMO.Views
{
    public class ResultPane : UserControl
    {
        public ResultPane()
        {
            var programInterface = SingletoneFactory.GetProgramInterface();

            DataContext = SingletoneFactory.GetResultPaneViewModel(programInterface);

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}