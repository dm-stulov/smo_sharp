using ReactiveUI;
using smo_sharp.Models;

namespace smo_sharp.ViewModels
{
    public class InputStateViewModel : ViewModelBase
    {
        private readonly ProgramInterface _programInterface;

        public InputStateViewModel(ProgramInterface programInterface)
        {
            _programInterface = programInterface;

            RequestAmount = 1;
            SourceAmount = 1;
            HandlerAmount = 1;
            SourceMinArg = 1;
            SourceMaxArg = 2;
            HandlerMinArg = 1;
            HandlerMaxArg = 2;
            BufferSize = 0;
        }

        public int RequestAmount
        {
            get => _programInterface.RequestAmount;
            set
            {
                _programInterface.RequestAmount = value;
                this.RaisePropertyChanged(nameof(RequestAmount));
            }
        }

        public int SourceAmount
        {
            get => _programInterface.SourceAmount;
            set
            {
                _programInterface.SourceAmount = value;
                this.RaisePropertyChanged(nameof(SourceAmount));
            }
        }

        public int HandlerAmount
        {
            get => _programInterface.HandlerAmount;
            set
            {
                _programInterface.HandlerAmount = value;
                this.RaisePropertyChanged(nameof(HandlerAmount));
            }
        }

        public int SourceMinArg
        {
            get => _programInterface.SourceMinArg;
            set
            {
                _programInterface.SourceMinArg = value;
                this.RaisePropertyChanged(nameof(SourceMinArg));
            }
        }

        public int SourceMaxArg
        {
            get => _programInterface.SourceMaxArg;
            set
            {
                _programInterface.SourceMaxArg = value;
                this.RaisePropertyChanged(nameof(SourceMaxArg));
            }
        }

        public int HandlerMinArg
        {
            get => _programInterface.HandlerMinArg;
            set
            {
                _programInterface.HandlerMinArg = value;
                this.RaisePropertyChanged(nameof(HandlerMinArg));
            }
        }

        public int HandlerMaxArg
        {
            get => _programInterface.HandlerMaxArg;
            set
            {
                _programInterface.HandlerMaxArg = value;
                this.RaisePropertyChanged(nameof(HandlerMaxArg));
            }
        }

        public int BufferSize
        {
            get => _programInterface.BufferSize;
            set
            {
                _programInterface.BufferSize = value;
                this.RaisePropertyChanged(nameof(BufferSize));
            }
        }
    }
}