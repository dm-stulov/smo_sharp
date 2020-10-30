using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using smo_sharp.Models;
using smo_sharp.ViewModels;

namespace SMO.Views
{
    public class StartButton : UserControl
    {
        public StartButton()
        {
            var programInterface = SingletoneFactory.GetProgramInterface();
            var resultPaneViewModel = SingletoneFactory.GetResultPaneViewModel(programInterface);
            var resultTableViewModel = SingletoneFactory.GetResultTableViewModel();

            DataContext = new StartButtonViewModel(programInterface, resultPaneViewModel, resultTableViewModel);

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}