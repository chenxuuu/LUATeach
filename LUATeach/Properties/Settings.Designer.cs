﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LUATeach.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.2.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"--此处可测试你的lua脚本运行效果
--支持Lua5.3自带功能、以及LUAT Task任务相关接口
--同时支持XLua直接调用C#接口的功能

--新建任务，每休眠1000ms继续一次
sys.taskInit(function()
    while true do
        sys.wait(1000)--等待1000ms
        log.info(""task wait"",os.time())
    end
end)

--1000ms循环定时器
sys.timerLoopStart(log.info,1000,""timer test"")

")]
        public string code {
            get {
                return ((string)(this["code"]));
            }
            set {
                this["code"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int lastPass {
            get {
                return ((int)(this["lastPass"]));
            }
            set {
                this["lastPass"] = value;
            }
        }
    }
}
