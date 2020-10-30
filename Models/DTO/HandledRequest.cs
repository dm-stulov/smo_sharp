namespace smo_sharp.Models.DTO
{
    public class HandledRequest : Request
    {
        public long HandlerId { get; }
        public long HandledAt { get; }

        public long HandledFor { get; }

        public HandledRequest(Request request, long handlerId, long handledAt, long handledFor) : base(request.Id,
            request.SourceId,
            request.CreateTime)
        {
            HandlerId = handlerId;
            HandledAt = handledAt;
            HandledFor = handledFor;
            Status = RequestStatus.HANDLED;
        }
    }
}