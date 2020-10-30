using System;
using System.Collections.ObjectModel;
using System.Linq;
using DynamicData;
using smo_sharp.Models;
using smo_sharp.Models.DTO;
using smo_sharp.Models.Repository;

namespace smo_sharp.ViewModels
{
    public class ResultTableViewModel : ViewModelBase
    {
        public ObservableCollection<SourceTableView> SourceTable { get; }
        public ObservableCollection<HandlerTableView> HandlerTable { get; }

        private readonly ProgramInterface _programInterface;

        public ResultTableViewModel(ProgramInterface iInterface)
        {
            _programInterface = iInterface;
            SourceTable = new ObservableCollection<SourceTableView>();
            HandlerTable = new ObservableCollection<HandlerTableView>();
            UpdateState();
        }

        public void UpdateState()
        {
            UpdateSourceTable();
            UpdateHandlerTable();
        }

        private void UpdateSourceTable()
        {
            var requests = _programInterface.RequestRepository.FindAll();

            var sourceAmount = _programInterface.SourceAmount;

            SourceTable.Clear();

            for (int i = 0; i < sourceAmount; i++)
            {
                var n = requests.Where(k => k.SourceId.Equals(i)).ToArray().Length;
                var rejectedAmount = requests.Where(k => k.SourceId.Equals(i)).Count(k => k is RejectedRequest);

                SourceTable.Add(new SourceTableView()
                    {SourceId = i, GeneratedAmount = n, RejectedAmount = rejectedAmount});
            }
        }

        private void UpdateHandlerTable()
        {
            var requests = _programInterface.RequestRepository.FindAll();

            var handlerAmount = _programInterface.HandlerAmount;

            HandlerTable.Clear();

            for (int i = 0; i < handlerAmount; i++)
            {
                var n = requests.Count(k => k is HandledRequest request && request.HandlerId.Equals(i));

                var handlerTime = n != 0
                    ? requests
                        .Where(k => k is HandledRequest request && request.HandlerId.Equals(i))
                        .Aggregate(0L, (i1, request) => i1 += ((HandledRequest) request).HandledFor) / n
                    : 0;

                HandlerTable.Add(new HandlerTableView()
                {
                    HandlerId = i,
                    Time = handlerTime,
                    HandledAmount = n,
                });
            }
        }
    }
}