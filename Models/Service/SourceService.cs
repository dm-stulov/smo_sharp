using System.Linq;
using smo_sharp.Models.DTO;
using System.Threading.Tasks;
using smo_sharp.Models.Workers;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace smo_sharp.Models.Service
{
    public class SourceService
    {
        private readonly int _requestAmount;
        private readonly List<Source> _sources;
        private readonly ConcurrentQueue<Request> _generatedRequests;

        public SourceService(int requestAmount, int sourceAmount, int minArg, int maxArg)
        {
            _generatedRequests = new ConcurrentQueue<Request>();

            _requestAmount = requestAmount;
            _sources = CreateSourceList(sourceAmount, minArg, maxArg);
        }

        public List<Request> GenerateRequests()
        {
            Task.WaitAll(_sources.ConvertAll(source => Task.Run(source.StartGeneration)).ToArray());

            var arr = _generatedRequests.ToArray().ToList();
            arr.Sort((l, r) => l.CreateTime.CompareTo(r.CreateTime));

            return arr;
        }

        private List<Source> CreateSourceList(int sourceAmount, int minArg, int maxArg)
        {
            var list = new List<Source>();
            for (var i = 0; i < sourceAmount; ++i)
            {
                list.Add(new Source(i, _requestAmount, minArg, maxArg, _generatedRequests));
            }

            return list;
        }
    }
}