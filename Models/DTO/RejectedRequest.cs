namespace smo_sharp.Models.DTO
{
    public class RejectedRequest : Request
    {
        public RejectedRequest(Request request) : base(request.Id, request.SourceId,
            request.CreateTime)
        {
            Status = Request.RequestStatus.REJECTED;
        }
    }
}