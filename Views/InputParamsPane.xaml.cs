using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using smo_sharp.Models;
using smo_sharp.ViewModels;

namespace SMO.Views
{
    public class InputParamsPane : UserControl
    {
        public InputParamsPane()
        {
            var programInterface = SingletoneFactory.GetProgramInterface();

            DataContext = new InputStateViewModel(programInterface);
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}