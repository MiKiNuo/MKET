using ET;
using MessagePack;
using System.Collections.Generic;
namespace ET
{
	[ResponseType(nameof(ObjectQueryResponse))]
	[Message(InnerOpcode.ObjectQueryRequest)]
	[MessagePackObject]
	public partial class ObjectQueryRequest: Object, IActorRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public long Key { get; set; }

		[Key(2)]
		public long InstanceId { get; set; }

	}

	[ResponseType(nameof(A2M_Reload))]
	[Message(InnerOpcode.M2A_Reload)]
	[MessagePackObject]
	public partial class M2A_Reload: Object, IActorRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

	}

	[Message(InnerOpcode.A2M_Reload)]
	[MessagePackObject]
	public partial class A2M_Reload: Object, IActorResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(G2G_LockResponse))]
	[Message(InnerOpcode.G2G_LockRequest)]
	[MessagePackObject]
	public partial class G2G_LockRequest: Object, IActorRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public long Id { get; set; }

		[Key(2)]
		public string Address { get; set; }

	}

	[Message(InnerOpcode.G2G_LockResponse)]
	[MessagePackObject]
	public partial class G2G_LockResponse: Object, IActorResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(G2G_LockReleaseResponse))]
	[Message(InnerOpcode.G2G_LockReleaseRequest)]
	[MessagePackObject]
	public partial class G2G_LockReleaseRequest: Object, IActorRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public long Id { get; set; }

		[Key(2)]
		public string Address { get; set; }

	}

	[Message(InnerOpcode.G2G_LockReleaseResponse)]
	[MessagePackObject]
	public partial class G2G_LockReleaseResponse: Object, IActorResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(ObjectAddResponse))]
	[Message(InnerOpcode.ObjectAddRequest)]
	[MessagePackObject]
	public partial class ObjectAddRequest: Object, IActorRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public long Key { get; set; }

		[Key(2)]
		public long InstanceId { get; set; }

	}

	[Message(InnerOpcode.ObjectAddResponse)]
	[MessagePackObject]
	public partial class ObjectAddResponse: Object, IActorResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(ObjectLockResponse))]
	[Message(InnerOpcode.ObjectLockRequest)]
	[MessagePackObject]
	public partial class ObjectLockRequest: Object, IActorRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public long Key { get; set; }

		[Key(2)]
		public long InstanceId { get; set; }

		[Key(3)]
		public int Time { get; set; }

	}

	[Message(InnerOpcode.ObjectLockResponse)]
	[MessagePackObject]
	public partial class ObjectLockResponse: Object, IActorResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(ObjectUnLockResponse))]
	[Message(InnerOpcode.ObjectUnLockRequest)]
	[MessagePackObject]
	public partial class ObjectUnLockRequest: Object, IActorRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public long Key { get; set; }

		[Key(2)]
		public long OldInstanceId { get; set; }

		[Key(3)]
		public long InstanceId { get; set; }

	}

	[Message(InnerOpcode.ObjectUnLockResponse)]
	[MessagePackObject]
	public partial class ObjectUnLockResponse: Object, IActorResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(ObjectRemoveResponse))]
	[Message(InnerOpcode.ObjectRemoveRequest)]
	[MessagePackObject]
	public partial class ObjectRemoveRequest: Object, IActorRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public long Key { get; set; }

	}

	[Message(InnerOpcode.ObjectRemoveResponse)]
	[MessagePackObject]
	public partial class ObjectRemoveResponse: Object, IActorResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(ObjectGetResponse))]
	[Message(InnerOpcode.ObjectGetRequest)]
	[MessagePackObject]
	public partial class ObjectGetRequest: Object, IActorRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public long Key { get; set; }

	}

	[Message(InnerOpcode.ObjectGetResponse)]
	[MessagePackObject]
	public partial class ObjectGetResponse: Object, IActorResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

		[Key(3)]
		public long InstanceId { get; set; }

	}

	[ResponseType(nameof(G2R_GetLoginKey))]
	[Message(InnerOpcode.R2G_GetLoginKey)]
	[MessagePackObject]
	public partial class R2G_GetLoginKey: Object, IActorRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public string Account { get; set; }

	}

	[Message(InnerOpcode.G2R_GetLoginKey)]
	[MessagePackObject]
	public partial class G2R_GetLoginKey: Object, IActorResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

		[Key(3)]
		public long Key { get; set; }

		[Key(4)]
		public long GateId { get; set; }

	}

	[Message(InnerOpcode.M2M_UnitTransferResponse)]
	[MessagePackObject]
	public partial class M2M_UnitTransferResponse: Object, IActorResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

		[Key(3)]
		public long NewInstanceId { get; set; }

	}

	[Message(InnerOpcode.G2M_SessionDisconnect)]
	[MessagePackObject]
	public partial class G2M_SessionDisconnect: Object, IActorLocationMessage
	{
		[Key(0)]
		public int RpcId { get; set; }

	}

}
