using System.Collections.Generic;
using smo_sharp.Models.DTO;
using smo_sharp.Models.Repository;

namespace smo_sharp.ViewModels
{
    public class RequestListView
    {
        private readonly IRequestRepository _repository;

        public RequestListView(IRequestRepository repository)
        {
            _repository = repository;
        }

        public List<Request> Requests()
        {
            return _repository.FindAll();
        }
    }
}