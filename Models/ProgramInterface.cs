using System;
using smo_sharp.Models.Repository;
using smo_sharp.Models.Service;
using Buffer = smo_sharp.Models.Workers.Buffer;

namespace smo_sharp.Models
{
    public class ProgramInterface
    {
        public ProgramInterface()
        {
            RequestRepository = new RequestRepositoryIml();
        }

        public void Start()
        {
            RequestRepository.Clear();

            var buffer = new Buffer(BufferSize);
            var sourceService = new SourceService(RequestAmount, SourceAmount, SourceMinArg, SourceMaxArg);
            var handlerService = new HandlerService(HandlerAmount, HandlerMinArg, HandlerMaxArg);
            var dispatcher = new RequestDispatcher(buffer, sourceService, handlerService, RequestRepository);

            dispatcher.Start();
        }

        public int RequestAmount { get; set; } = 0;
        public int SourceAmount { get; set; } = 0;
        public int HandlerAmount { get; set; } = 0;
        public int SourceMinArg { get; set; } = 0;
        public int SourceMaxArg { get; set; } = 0;
        public int HandlerMinArg { get; set; } = 0;
        public int HandlerMaxArg { get; set; } = 0;
        public int BufferSize { get; set; } = 1;

        public IRequestRepository RequestRepository { get; set; } = null;
    }
}