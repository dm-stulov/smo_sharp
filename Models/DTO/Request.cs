namespace smo_sharp.Models.DTO
{
    public class Request
    {
        public long Id { get; }
        public long SourceId { get; set; }

        public long CreateTime { get; }

        public RequestStatus Status { get; set; } = RequestStatus.GENERATED;

        public enum RequestStatus
        {
            GENERATED,
            HANDLED,
            REJECTED
        }

        public Request(long id, long sourceId, long createTime)
        {
            Id = id;
            SourceId = sourceId;
            CreateTime = createTime;
        }
    }
}