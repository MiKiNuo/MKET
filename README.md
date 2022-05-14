# MKET

ET6 + MessagePack-CSharp + YooAsset + Fairygui + Luban + Huatuo

一、项目运行、

1、按照ET运行步骤指南进行编译工程

2、Unity菜单找到YooAsset->AssetBundle Builder，然后打开资源包构建工具界面点击构建按钮

3、打开场景Init，然后运行服务器运行Unity即可

二、注意事项

1、MessagePack-CSharp协议延用ET的proto文件进行定义，新增协议按照demo进行定义，协议的请求和回复建议从0开始定义

2、Excel导出改用Luban进行导出，相关教程请前往[ Luban使用文档 ](https://focus-creative-games.github.io/lubandoc/start_up.html)

3、如果要还原protobuf-net，需要把Tool工程相关的protobuf注释代码打开，然后服务器nuget进行添加，客户端ThirdParty文件夹拷贝ET仓库下ThirdParty文件夹的protobuf-net，MessagePackHelper.cs代码进行注释，ProtobufHelper.cs代码注释打开，Proto文件夹下的InnerMessage.proto、MongoMessage.proto、OuterMessage.proto还原ET仓库下定Proto文件夹，同理Excel也是一样还原。

4、如果需要还原ILRuntime,需要ThirdParty文件夹还原ET仓库的ILRuntime，项目init.cs代码也是对应的修改

5、在 Unity/UIProject下，生成代码插件为ts编写 ，在UI工程 plugins目录，生成代码如果勾选则生成mono代码，不勾选则生成hoftix代码

三、引用库

1、[ET](https://github.com/egametang/ET) Unity3D Client And C# Server Framework

2、[Luban](https://github.com/focus-creative-games/luban) 你的最佳游戏配置解决方案

3、[YooAsset](https://github.com/tuyoogame/YooAsset) unity3d resources management system

4、[Fairygui](https://github.com/fairygui/FairyGUI-unity) A flexible UI framework for Unity

5、[CatJson](https://github.com/CatImmortal/CatJson) 为Unity开发者量身打造的功能强大的高性能Json库，内置ILRuntime支持

6、[Huatuo](https://github.com/focus-creative-games/huatuo) huatuo是一个特性完整、零成本、高性能、低内存的近乎完美的Unity全平台原生c#热更方案。

7、[ET-FUI](https://github.com/sosloop/ET-FUI) ET6 + GameFrameWork(UGFExtensions扩展) + FairyGui + LuBan 集 大家之作 粘贴为 一体
