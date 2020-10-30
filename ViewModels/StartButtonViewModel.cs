using smo_sharp.Models;

namespace smo_sharp.ViewModels
{
    public class StartButtonViewModel : ViewModelBase
    {
        private readonly ProgramInterface _programInterface;
        private readonly ResultPaneViewModel _resultPaneViewModel;
        private readonly ResultTableViewModel _resultTableViewModel;

        public StartButtonViewModel(
            ProgramInterface programInterface,
            ResultPaneViewModel resultPaneViewModel,
            ResultTableViewModel resultTableViewModel
        )
        {
            _programInterface = programInterface;
            _resultPaneViewModel = resultPaneViewModel;
            _resultTableViewModel = resultTableViewModel;
        }

        public void Start()
        {
            _programInterface.Start();
            _resultPaneViewModel.UpdateState();
            _resultTableViewModel.UpdateState();
        }
    }
}