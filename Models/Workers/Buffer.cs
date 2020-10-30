using System.Collections.Generic;
using smo_sharp.Models.DTO;

namespace smo_sharp.Models.Workers
{
    public class Buffer
    {
        private readonly Queue<Request> _requests;

        public int Size { get; }

        public Buffer(int size)
        {
            Size = size;
            _requests = new Queue<Request>(size);
        }

        public bool HasPlace()
        {
            return _requests.Count < Size;
        }

        public void Put(Request request)
        {
            _requests.Enqueue(request);
        }

        public Request Get()
        {
            return _requests.Dequeue();
        }

        public bool IsEmpty()
        {
            return _requests.Count == 0;
        }
    }
}