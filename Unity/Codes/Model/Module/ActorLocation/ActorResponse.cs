using MessagePack;

namespace ET
{
    [Message(ushort.MaxValue)]
    [MessagePackObject]
    public partial class ActorResponse: ProtoObject, IActorResponse
    {
        [Key(0)]
        public int RpcId { get; set; }
        [Key(1)]
        public int Error { get; set; }
        [Key(2)]
        public string Message { get; set; }
    }
}