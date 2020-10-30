using System.Collections.Generic;
using smo_sharp.Models.DTO;

namespace smo_sharp.Models.Repository
{
    public interface IRequestRepository
    {
        public Request Save(Request request);
        public List<Request> FindAll();
        public void Clear();
        public int Size();
    }
}