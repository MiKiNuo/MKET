# MKET

ET6 + MessagePack-CSharp + YooAsset + Fairygui + Luban + Huatuo

一、项目运行、

1、按照ET运行步骤指南进行编译工程

2、Unity菜单找到YooAsset->AssetBundle Builder，然后打开资源包构建工具界面点击构建按钮

3、打开场景Init，然后运行服务器运行Unity即可

二、注意事项

1、MessagePack-CSharp协议延用ET的proto文件进行定义，新增协议按照UWA ET教程进行新增

2、Excel导出改用Luban进行导出，相关教程请前往[快速上手 | Luban使用文档 (focus-creative-games.github.io)](https://focus-creative-games.github.io/lubandoc/start_up.html)

3、如果要还原protobuf-net，需要把Tool工程相关的注释代码打开，然后服务器nuget进行添加，客户端ThirdParty文件夹拷贝ET仓库下ThirdParty文件夹的protobuf-net，MessagePackHelper.cs代码进行注释，ProtobufHelper.cs代码注释打开，Proto文件夹下的InnerMessage.proto、MongoMessage.proto、OuterMessage.proto还原ET仓库下定Proto文件夹，同理Excel也是一样。

4、如果需要还原ILRuntime,需要ThirdParty文件夹还原ET仓库的ILRuntime，项目init.cs代码也是对应的修改

三、引用库

1、[ET](https://github.com/egametang/ET)

2、[luban](https://github.com/focus-creative-games/luban)

3、[YooAsset](https://github.com/tuyoogame/YooAsset)

4、[Fairygui](https://github.com/fairygui/FairyGUI-unity)

5、[CatJson](https://github.com/CatImmortal/CatJson)

6、[Huatuo)](https://github.com/focus-creative-games/huatuo)
