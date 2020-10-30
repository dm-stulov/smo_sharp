using System;
using System.Linq;
using ReactiveUI.Fody.Helpers;
using smo_sharp.Models;
using smo_sharp.Models.DTO;

namespace smo_sharp.ViewModels
{
    public class ResultPaneViewModel : ViewModelBase
    {
        private readonly ProgramInterface _programInterface;

        public ResultPaneViewModel(ProgramInterface programInterface)
        {
            _programInterface = programInterface;
            GeneratedRequestAmount = 0;
            HandledRequestAmount = 0;
            RejectedRequestAmount = 0;
        }

        public void UpdateState()
        {
            GeneratedRequestAmount = _programInterface.RequestRepository.FindAll().Count;
            HandledRequestAmount = _programInterface.RequestRepository.FindAll()
                .Count(r => r.Status == Request.RequestStatus.HANDLED);
            RejectedRequestAmount = _programInterface.RequestRepository.FindAll()
                .Count(r => r.Status == Request.RequestStatus.REJECTED);
        }

        [Reactive] public int GeneratedRequestAmount { get; set; }

        [Reactive] public int HandledRequestAmount { get; set; }

        [Reactive] public int RejectedRequestAmount { get; set; }
    }
}