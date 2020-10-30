using smo_sharp.Models.DTO;
using System.Collections.Concurrent;

namespace smo_sharp.Models.Workers
{
    public class Source
    {
        private static readonly object Lock1 = new object();

        private long _timeLine;
        private readonly int _id;
        private readonly int _minArg;
        private readonly int _maxArg;
        private readonly int _requestAmount;
        private readonly ConcurrentQueue<Request> _generatedRequests;
        
        public Source(int id, int requestAmount, int minArg, int maxArg, ConcurrentQueue<Request> generatedRequests)
        {
            _id = id;
            _timeLine = 0;
            _minArg = minArg;
            _maxArg = maxArg;
            _requestAmount = requestAmount;
            _generatedRequests = generatedRequests;
        }

        public void StartGeneration()
        {
            while (true)
            {
                lock (Lock1)
                {
                    if (IsFinished())
                    {
                        break;
                    }

                    _timeLine += MathHelper.GetLineDistribution(_minArg, _maxArg);

                    var request = CreateRequest();

                    _generatedRequests.Enqueue(request);
                }
            }
        }

        private Request CreateRequest()
        {
            var request = new Request(_generatedRequests.Count, _id, _timeLine);

            return request;
        }

        private bool IsFinished()
        {
            return _generatedRequests.Count == _requestAmount;
        }
    }
}