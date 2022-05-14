//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;



namespace ET
{

public sealed partial class StartSceneConfig :  Bright.Config.BeanBase 
{
    public StartSceneConfig(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Process = _buf.ReadInt();
        Zone = _buf.ReadInt();
        SceneType = _buf.ReadString();
        Name = _buf.ReadString();
        OuterPort = _buf.ReadInt();
        PostInit();
    }

    public static StartSceneConfig DeserializeStartSceneConfig(ByteBuf _buf)
    {
        return new StartSceneConfig(_buf);
    }

    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// 所属进程
    /// </summary>
    public int Process { get; private set; }
    /// <summary>
    /// 所属区
    /// </summary>
    public int Zone { get; private set; }
    /// <summary>
    /// 类型
    /// </summary>
    public string SceneType { get; private set; }
    /// <summary>
    /// 名字
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// 外网端口
    /// </summary>
    public int OuterPort { get; private set; }

    public const int __ID__ = 1499456844;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "Process:" + Process + ","
        + "Zone:" + Zone + ","
        + "SceneType:" + SceneType + ","
        + "Name:" + Name + ","
        + "OuterPort:" + OuterPort + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}