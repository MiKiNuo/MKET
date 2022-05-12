import { FairyEditor } from 'csharp';
import CodeWriter from './CodeWriter';

function genGet(uitype:string,uiname:string,uifind:string){
    let realUIName = uiname.replace('m_','')
    return `public ${uitype} ${uiname}_${realUIName}
        {
            get
            {
                if (this.UITransform == null)
                {
                    Log.Error("UITransform is null.");
                    return null;
                }
                if( this.${realUIName} == null )
                {
                    this.${realUIName} = ${uifind}
                }
                return this.${realUIName};
            }
        }`;
}

function genHoftixCode(handler: FairyEditor.PublishHandler) {
    let settings = (<FairyEditor.GlobalPublishSettings>handler.project.GetSettings("Publish")).codeGeneration;
    let codePkgName = handler.ToFilename(handler.pkg.name); //convert chinese to pinyin, remove special chars etc.
    let exportCodePath = handler.exportCodePath + '/' + codePkgName;
    let exportCodeModelViewPath = handler.exportCodePath + '/ModelView/AutoFGUICode/' + codePkgName;
    let exportCodeHoftixViewPath = handler.exportCodePath + '/HotfixView/AutoFGUICode/' + codePkgName;
    let namespaceName = codePkgName;
    let isMonoGame = handler.project.type == FairyEditor.ProjectType.MonoGame;

    if (settings.packageName)
        namespaceName = settings.packageName + '.' + namespaceName;

    //CollectClasses(stripeMemeber, stripeClass, fguiNamespace)
    let classes = handler.CollectClasses(settings.ignoreNoname, settings.ignoreNoname, null);
    //handler.SetupCodeFolder(exportCodePath, "cs"); //check if target folder exists, and delete old files
    handler.SetupCodeFolder(exportCodeModelViewPath, "cs");
    handler.SetupCodeFolder(exportCodeHoftixViewPath, "cs");

    let getMemberByName = settings.getMemberByName;

    let classCnt = classes.Count;
    let writer = new CodeWriter();
    for (let i: number = 0; i < classCnt; i++) {
        let classInfo = classes.get_Item(i);
        let members = classInfo.members;
        writer.reset();

        // ET组件文件名
        let genETCompName = classInfo.className

        writer.writeln('using FairyGUI;');
        writer.writeln('using FairyGUI.Utils;');
        writer.writeln();
        writer.writeln('namespace ET');
        writer.startBlock();
        writer.writeln('public class %s : Entity,IAwake,IAwake<GObject>,IDestroy', genETCompName);
        writer.startBlock();

        // 包信息
        writer.writeln(`public const string UIPackageName = "${codePkgName}";
        public const string UIResName = "${classInfo.resName}";
        public const string URL = "ui://${handler.pkg.id}${classInfo.resId}";
        public GObject GObject = null;

        public ${classInfo.superClassName} UITransform = null;`)

        // 字段信息
        let memberCnt = members.Count

        for (let j: number = 0; j < memberCnt; j++) {
            let memberInfo = members.get_Item(j);
            writer.writeln('public %s %s = null;', memberInfo.type, memberInfo.varName);
        }
        writer.writeln();

        // 生成get方法，懒加载
        for (let j: number = 0; j < memberCnt; j++) {
            let memberInfo = members.get_Item(j);
            let typeName = memberInfo.type
            //
            if (memberInfo.group == 0) {
                if (getMemberByName) {
                    // 判断是不是我们自定义类型
                    let isCustomComponent:boolean = false
                    for (let i:number = 0 ; i < classCnt; i++){
                        if(typeName == classes.get_Item(i).className){
                            isCustomComponent = true;
                        }
                    }
                    if(isCustomComponent){
                        let findPath = `this.AddChild<${typeName}, GObject>(UITransform.GetChild("${memberInfo.name}"));`
                        writer.writeln(genGet(memberInfo.type,memberInfo.varName,findPath));
                    }else{
                        let findPath = `(${memberInfo.type})UITransform.GetChild("${memberInfo.name}");`
                        writer.writeln(genGet(memberInfo.type,memberInfo.varName,findPath));
                    }
                    // writer.writeln('%s = (%s)GetChild("%s");', memberInfo.varName, memberInfo.type, memberInfo.name);
                }
                else {
                    // 判断是不是我们自定义类型
                    let isCustomComponent:boolean = false
                    for (let i:number = 0 ; i < classCnt; i++){
                        if(typeName == classes.get_Item(i).className){
                            isCustomComponent = true;
                        }
                    }
                    if(isCustomComponent){
                        let findPath = `this.AddChild<${typeName}, GObject>(UITransform.GetChildAt(${memberInfo.index}));`
                        writer.writeln(genGet(memberInfo.type,memberInfo.varName,findPath));
                    }else{
                        let findPath = `(${memberInfo.type})UITransform.GetChildAt(${memberInfo.index});`
                        writer.writeln(genGet(memberInfo.type,memberInfo.varName,findPath));
                    }
                    // writer.writeln('%s = (%s)GetChildAt(%s);', memberInfo.varName, memberInfo.type, memberInfo.index);
                }
            }
            else if (memberInfo.group == 1) {
                if (getMemberByName) {
                    let findPath = `(${memberInfo.type})UITransform.GetController(${memberInfo.name});`
                    writer.writeln(genGet(memberInfo.type,memberInfo.varName,findPath));
                    //writer.writeln('%s = UITransform.GetController("%s");', memberInfo.varName, memberInfo.name);
                }
                else {
                    let findPath = `(${memberInfo.type})UITransform.GetControllerAt(${memberInfo.index});`
                    writer.writeln(genGet(memberInfo.type,memberInfo.varName,findPath));
                    //writer.writeln('%s = UITransform.GetControllerAt(%s);', memberInfo.varName, memberInfo.index);
                }
            }
            else {
                if (getMemberByName) {
                    let findPath = `(${memberInfo.type})UITransform.GetTransition(${memberInfo.name});`
                    writer.writeln(genGet(memberInfo.type,memberInfo.varName,findPath));
                    //writer.writeln('%s = UITransform.GetTransition("%s");', memberInfo.varName, memberInfo.name);
                }
                else {
                    let findPath = `(${memberInfo.type})UITransform.GetTransitionAt(${memberInfo.index});`
                    writer.writeln(genGet(memberInfo.type,memberInfo.varName,findPath));
                    //writer.writeln('%s = UITransform.GetTransitionAt(%s);', memberInfo.varName, memberInfo.index);
                }
            }
        }

        writer.endBlock(); //class
        writer.endBlock(); //namepsace

        writer.save(exportCodeModelViewPath + '/' + genETCompName + '.cs');

        // 生成system
        writer.reset();
        // ET组件System文件名
        let genETCompSystemName = `${genETCompName}System`

        // ET生命周期类名
        let awakeSystemName = `${genETCompName}AwakeSystem`
        let destorySystemName = `${genETCompName}DestroySystem`
        //
        writer.writeln(`using FairyGUI;
using FairyGUI.Utils;
namespace ET
{
    [ObjectSystem]
    [FriendClass(typeof(FGUIBaseWindow))]
	public class ${awakeSystemName} : AwakeSystem<${genETCompName}>
	{
		public override void Awake(${genETCompName} self)
		{
			self.GObject = self.GetParent<FGUIBaseWindow>().UIPrefabGameObject;
			self.UITransform = (${classInfo.superClassName})self.GObject;
		}
	}

    [ObjectSystem]
    public class ${awakeSystemName}1 : AwakeSystem<${genETCompName},GObject>
    {
        public override void Awake(${genETCompName} self,GObject transform)
        {
            self.GObject = transform;
            self.UITransform = (${classInfo.superClassName})transform;
        }
    }

    [ObjectSystem]
    public class ${destorySystemName} : DestroySystem<${genETCompName}>
    {
        public override void Destroy(${genETCompName} self)
        {
            self.GObject?.Dispose();
            self.GObject = null;
            self.UITransform = null;`);

        // 置空
        for (let j: number = 0; j < memberCnt; j++) {
            let memberInfo = members.get_Item(j);
            let typeName = memberInfo.type;
            //
            if (memberInfo.group == 0) {
                //
                if(typeName.indexOf('FUI') >= 0){
                    writer.writeln(`\t\t\tself.${memberInfo.varName}?.Dispose();`)
                }
                writer.writeln(`\t\t\tself.${memberInfo.varName} = null;`)
            }
            else if (memberInfo.group == 1) {
                writer.writeln(`\t\t\tself.${memberInfo.varName} = null;`)
            }
            else {
                writer.writeln(`\t\t\tself.${memberInfo.varName} = null;`)
            }
        }

       
        // 后半截
        writer.writeln(`        }
    }
    
    [FriendClass(typeof(${genETCompName}))]
    public static class ${genETCompName}System
    {
        private static GObject CreateGObject(this ${genETCompName} self)
        {
            return UIPackage.CreateObject(${genETCompName}.UIPackageName, ${genETCompName}.UIResName);
        }

        private static void CreateGObjectAsync(this ${genETCompName} self,UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(${genETCompName}.UIPackageName, ${genETCompName}.UIResName, result);
        }

        public static ${genETCompName} CreateInstance(this ${genETCompName} self,Entity domain)
        {
            return domain.AddChild<${genETCompName}, GObject>(CreateGObject(self));
        }

        public static async ETTask<${genETCompName}> CreateInstanceAsync(this ${genETCompName} self,Entity domain)
        {
            ETTask<${genETCompName}> tcs = ETTask<${genETCompName}>.Create(true);
            CreateGObjectAsync(self,(go) =>
            {
                tcs.SetResult(domain.AddChild<${genETCompName}, GObject>(go));
            });
            return await tcs;
        }
    } 

}`)
        writer.save(exportCodeHoftixViewPath + '/' + genETCompSystemName + '.cs');
    }

    writer.reset();

    // 写入fuipackage
    let binderName = 'Package'+codePkgName;

    writer.writeln('using FairyGUI;');
    writer.writeln();
    writer.writeln('namespace ET');
    writer.startBlock();
    writer.writeln('public static partial class FUIPackag');
    writer.startBlock();

    writer.writeln(`public const string ${codePkgName} = "${codePkgName}";`);

    // 生成所有的
    let itemCount = handler.items.Count;
    for (let i: number = 0; i < itemCount; i++) {
        writer.writeln('public const string %s_%s = "ui://%s/%s";', codePkgName, handler.items.get_Item(i).name, codePkgName, handler.items.get_Item(i).name);
    }

    writer.endBlock(); //class
    writer.endBlock(); //namespace

    writer.save(exportCodeModelViewPath + '/' + binderName + '.cs');
}

export { genHoftixCode };