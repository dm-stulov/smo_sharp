using System;
using smo_sharp.Models.DTO;

namespace smo_sharp.Models.Workers
{
    public class Handler
    {
        private readonly long _id;
        public long Timeline { get; set; }
        private readonly int _maxArg;
        private readonly int _minArg;

        public Handler(long id, int minArg, int maxArg)
        {
            _id = id;
            Timeline = 0;
            _minArg = minArg;
            _maxArg = maxArg;
        }

        public Request Handle(Request request, long startTime)
        {
            Timeline = startTime + MathHelper.GetExpDistribution(_minArg, _maxArg);

            return new HandledRequest(request, _id, Timeline, Timeline - startTime);
        }

        public Request Handle(Request request)
        {
            var before = Timeline;
            Timeline += MathHelper.GetExpDistribution(_minArg, _maxArg);

            return new HandledRequest(request, _id, Timeline, Timeline - before);
        }

        public bool CanHandle(long handleTime)
        {
            if (Timeline == 0)
            {
                return true;
            }

            return Timeline <= handleTime;
        }
    }
}