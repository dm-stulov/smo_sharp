using smo_sharp.ViewModels;

namespace smo_sharp.Models
{
    public static class SingletoneFactory
    {
        private static ProgramInterface _programInterface;
        private static ResultPaneViewModel _resultPaneViewModel;
        private static ResultTableViewModel _resultTableViewModel;

        public static ProgramInterface GetProgramInterface()
        {
            if (_programInterface == null)
            {
                _programInterface = new ProgramInterface();
            }

            return _programInterface;
        }

        public static ResultPaneViewModel GetResultPaneViewModel(ProgramInterface programInterface)
        {
            if (_resultPaneViewModel == null)
            {
                _resultPaneViewModel = new ResultPaneViewModel(programInterface);
            }

            return _resultPaneViewModel;
        }

        public static ResultTableViewModel GetResultTableViewModel()
        {
            if (_resultTableViewModel == null)
            {
                _resultTableViewModel = new ResultTableViewModel(GetProgramInterface());
            }

            return _resultTableViewModel;
        }
    }
}