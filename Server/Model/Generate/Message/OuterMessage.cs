using ET;
using MessagePack;
using System.Collections.Generic;
namespace ET
{
	[ResponseType(nameof(M2C_TestResponse))]
	[Message(OuterOpcode.C2M_TestRequest)]
	[MessagePackObject]
	public partial class C2M_TestRequest: Object, IActorLocationRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public string request { get; set; }

	}

	[Message(OuterOpcode.M2C_TestResponse)]
	[MessagePackObject]
	public partial class M2C_TestResponse: Object, IActorLocationResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

		[Key(3)]
		public string response { get; set; }

	}

	[ResponseType(nameof(Actor_TransferResponse))]
	[Message(OuterOpcode.Actor_TransferRequest)]
	[MessagePackObject]
	public partial class Actor_TransferRequest: Object, IActorLocationRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int MapIndex { get; set; }

	}

	[Message(OuterOpcode.Actor_TransferResponse)]
	[MessagePackObject]
	public partial class Actor_TransferResponse: Object, IActorLocationResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(G2C_EnterMap))]
	[Message(OuterOpcode.C2G_EnterMap)]
	[MessagePackObject]
	public partial class C2G_EnterMap: Object, IRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_EnterMap)]
	[MessagePackObject]
	public partial class G2C_EnterMap: Object, IResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

// 自己unitId
		[Key(3)]
		public long MyId { get; set; }

	}

	[Message(OuterOpcode.MoveInfo)]
	[MessagePackObject]
	public partial class MoveInfo: Object
	{
		[Key(0)]
		public List<float> X = new List<float>();

		[Key(1)]
		public List<float> Y = new List<float>();

		[Key(2)]
		public List<float> Z = new List<float>();

		[Key(3)]
		public float A { get; set; }

		[Key(4)]
		public float B { get; set; }

		[Key(5)]
		public float C { get; set; }

		[Key(6)]
		public float W { get; set; }

		[Key(7)]
		public int TurnSpeed { get; set; }

	}

	[Message(OuterOpcode.UnitInfo)]
	[MessagePackObject]
	public partial class UnitInfo: Object
	{
		[Key(0)]
		public long UnitId { get; set; }

		[Key(1)]
		public int ConfigId { get; set; }

		[Key(2)]
		public int Type { get; set; }

		[Key(3)]
		public float X { get; set; }

		[Key(4)]
		public float Y { get; set; }

		[Key(5)]
		public float Z { get; set; }

		[Key(6)]
		public float ForwardX { get; set; }

		[Key(7)]
		public float ForwardY { get; set; }

		[Key(8)]
		public float ForwardZ { get; set; }

		[Key(9)]
		public List<int> Ks = new List<int>();

		[Key(10)]
		public List<long> Vs = new List<long>();

		[Key(11)]
		public MoveInfo MoveInfo { get; set; }

	}

	[Message(OuterOpcode.M2C_CreateUnits)]
	[MessagePackObject]
	public partial class M2C_CreateUnits: Object, IActorMessage
	{
		[Key(0)]
		public List<UnitInfo> Units = new List<UnitInfo>();

	}

	[Message(OuterOpcode.M2C_CreateMyUnit)]
	[MessagePackObject]
	public partial class M2C_CreateMyUnit: Object, IActorMessage
	{
		[Key(0)]
		public UnitInfo Unit { get; set; }

	}

	[Message(OuterOpcode.M2C_StartSceneChange)]
	[MessagePackObject]
	public partial class M2C_StartSceneChange: Object, IActorMessage
	{
		[Key(0)]
		public long SceneInstanceId { get; set; }

		[Key(1)]
		public string SceneName { get; set; }

	}

	[Message(OuterOpcode.M2C_RemoveUnits)]
	[MessagePackObject]
	public partial class M2C_RemoveUnits: Object, IActorMessage
	{
		[Key(0)]
		public List<long> Units = new List<long>();

	}

	[Message(OuterOpcode.C2M_PathfindingResult)]
	[MessagePackObject]
	public partial class C2M_PathfindingResult: Object, IActorLocationMessage
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public float X { get; set; }

		[Key(2)]
		public float Y { get; set; }

		[Key(3)]
		public float Z { get; set; }

	}

	[Message(OuterOpcode.C2M_Stop)]
	[MessagePackObject]
	public partial class C2M_Stop: Object, IActorLocationMessage
	{
		[Key(0)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.M2C_PathfindingResult)]
	[MessagePackObject]
	public partial class M2C_PathfindingResult: Object, IActorMessage
	{
		[Key(0)]
		public long Id { get; set; }

		[Key(1)]
		public float X { get; set; }

		[Key(2)]
		public float Y { get; set; }

		[Key(3)]
		public float Z { get; set; }

		[Key(4)]
		public List<float> Xs = new List<float>();

		[Key(5)]
		public List<float> Ys = new List<float>();

		[Key(6)]
		public List<float> Zs = new List<float>();

	}

	[Message(OuterOpcode.M2C_Stop)]
	[MessagePackObject]
	public partial class M2C_Stop: Object, IActorMessage
	{
		[Key(0)]
		public int Error { get; set; }

		[Key(1)]
		public long Id { get; set; }

		[Key(2)]
		public float X { get; set; }

		[Key(3)]
		public float Y { get; set; }

		[Key(4)]
		public float Z { get; set; }

		[Key(5)]
		public float A { get; set; }

		[Key(6)]
		public float B { get; set; }

		[Key(7)]
		public float C { get; set; }

		[Key(8)]
		public float W { get; set; }

	}

	[ResponseType(nameof(G2C_Ping))]
	[Message(OuterOpcode.C2G_Ping)]
	[MessagePackObject]
	public partial class C2G_Ping: Object, IRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_Ping)]
	[MessagePackObject]
	public partial class G2C_Ping: Object, IResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

		[Key(3)]
		public long Time { get; set; }

	}

	[Message(OuterOpcode.G2C_Test)]
	[MessagePackObject]
	public partial class G2C_Test: Object, IMessage
	{
	}

	[ResponseType(nameof(M2C_Reload))]
	[Message(OuterOpcode.C2M_Reload)]
	[MessagePackObject]
	public partial class C2M_Reload: Object, IRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public string Account { get; set; }

		[Key(2)]
		public string Password { get; set; }

	}

	[Message(OuterOpcode.M2C_Reload)]
	[MessagePackObject]
	public partial class M2C_Reload: Object, IResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(R2C_Login))]
	[Message(OuterOpcode.C2R_Login)]
	[MessagePackObject]
	public partial class C2R_Login: Object, IRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public string Account { get; set; }

		[Key(2)]
		public string Password { get; set; }

	}

	[Message(OuterOpcode.R2C_Login)]
	[MessagePackObject]
	public partial class R2C_Login: Object, IResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

		[Key(3)]
		public string Address { get; set; }

		[Key(4)]
		public long Key { get; set; }

		[Key(5)]
		public long GateId { get; set; }

	}

	[ResponseType(nameof(G2C_LoginGate))]
	[Message(OuterOpcode.C2G_LoginGate)]
	[MessagePackObject]
	public partial class C2G_LoginGate: Object, IRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public long Key { get; set; }

		[Key(2)]
		public long GateId { get; set; }

	}

	[Message(OuterOpcode.G2C_LoginGate)]
	[MessagePackObject]
	public partial class G2C_LoginGate: Object, IResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

		[Key(3)]
		public long PlayerId { get; set; }

	}

	[Message(OuterOpcode.G2C_TestHotfixMessage)]
	[MessagePackObject]
	public partial class G2C_TestHotfixMessage: Object, IMessage
	{
		[Key(0)]
		public string Info { get; set; }

	}

	[ResponseType(nameof(M2C_TestRobotCase))]
	[Message(OuterOpcode.C2M_TestRobotCase)]
	[MessagePackObject]
	public partial class C2M_TestRobotCase: Object, IActorLocationRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int N { get; set; }

	}

	[Message(OuterOpcode.M2C_TestRobotCase)]
	[MessagePackObject]
	public partial class M2C_TestRobotCase: Object, IActorLocationResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

		[Key(3)]
		public int N { get; set; }

	}

	[ResponseType(nameof(M2C_TransferMap))]
	[Message(OuterOpcode.C2M_TransferMap)]
	[MessagePackObject]
	public partial class C2M_TransferMap: Object, IActorLocationRequest
	{
		[Key(0)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.M2C_TransferMap)]
	[MessagePackObject]
	public partial class M2C_TransferMap: Object, IActorLocationResponse
	{
		[Key(0)]
		public int RpcId { get; set; }

		[Key(1)]
		public int Error { get; set; }

		[Key(2)]
		public string Message { get; set; }

	}

}
