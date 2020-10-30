using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using smo_sharp.Models.DTO;

namespace smo_sharp.Models.Repository
{
    public class RequestRepositoryIml : IRequestRepository
    {
        private readonly List<Request> _requests;

        public RequestRepositoryIml()
        {
            _requests = new List<Request>();
        }

        public Request Save(Request request)
        {
            _requests.Add(request);

            return request;
        }

        public List<Request> FindAll()
        {
            return _requests;
        }

        public void Clear()
        {
            _requests.Clear();
        }


        public int Size()
        {
            return _requests.Count;
        }
    }
}