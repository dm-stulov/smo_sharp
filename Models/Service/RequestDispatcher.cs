using System.Collections.Generic;
using smo_sharp.Models.DTO;
using smo_sharp.Models.Repository;
using Buffer = smo_sharp.Models.Workers.Buffer;

namespace smo_sharp.Models.Service
{
    public class RequestDispatcher
    {
        private readonly Buffer _buffer;
        private readonly SourceService _sourceService;
        private readonly HandlerService _handlerService;
        private readonly IRequestRepository _repository;

        public RequestDispatcher(
            Buffer buffer,
            SourceService sourceService,
            HandlerService handlerService,
            IRequestRepository repository)
        {
            _sourceService = sourceService;
            _handlerService = handlerService;
            _repository = repository;
            _buffer = buffer;
        }

        public void Start()
        {
            var requests = _sourceService.GenerateRequests();
            HandleRequests(requests);
            HandleBuffer();
        }

        private void HandleRequests(List<Request> requests)
        {
            requests.ForEach(HandleRequest);
        }

        private void HandleRequest(Request request)
        {
            while (_handlerService.CanHandle(request.CreateTime) && !_buffer.IsEmpty())
            {
                _repository.Save(_handlerService.Handle(_buffer.Get(), request.CreateTime));
            }

            if (_buffer.IsEmpty())
            {
                if (_handlerService.CanHandle(request.CreateTime))
                {
                    _repository.Save(_handlerService.Handle(request, request.CreateTime));
                }
                else
                {
                    _buffer.Put(request);
                }
            }
            else if (_buffer.HasPlace())
            {
                _buffer.Put(request);
            }
            else
            {
                _repository.Save(new RejectedRequest(request));
            }
        }

        private void HandleBuffer()
        {
            while (!_buffer.IsEmpty())
            {
                _repository.Save(_handlerService.Handle(_buffer.Get()));
            }
        }
    }
}