using ET;
using MessagePack;
using System.Collections.Generic;
namespace ET
{
	[Message(MongoOpcode.ObjectQueryResponse)]
	[MessagePackObject]
	public partial class ObjectQueryResponse: Object, IActorResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

		[Key(3)]
		public Entity entity { get; set; }

	}

	[ResponseType(nameof(M2M_UnitTransferResponse))]
	[Message(MongoOpcode.M2M_UnitTransferRequest)]
	[MessagePackObject]
	public partial class M2M_UnitTransferRequest: Object, IActorRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public Unit Unit { get; set; }

		[Key(2)]
		public List<Entity> Entitys = new List<Entity>();

	}

}
