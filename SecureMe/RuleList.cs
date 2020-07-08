using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace SecureMe
{
    class RuleList : IEnumerable<IRule>
    {
        private List<IRule> _rules = new List<IRule>();

        public RuleList()
        {
            _rules.Add(new RegistryRule<string>("屏保：在恢复时显示登录屏幕", Registry.CurrentUser, @"Control Panel\Desktop", "ScreenSaverIsSecure", "1"));
            _rules.Add(new RegistryRule<int>("IE设置：在历史记录中保存网页的天数为180", Registry.CurrentUser,
                @"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Url History", "DaysToKeep", 180));
            _rules.Add(new GroupPolicyRule("关闭自动播放",
                @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer!NoDriveTypeAutoRun", "255"));
            _rules.Add(new GroupPolicyRule("可移动磁盘：拒绝执行权限",
                @"HKLM\SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices\{53f5630d-b6bf-11d0-94f2-00a0c91efb8b}\!Deny_Execute", "1"));
            _rules.Add(new GroupPolicyRule("设置自动运行的默认行为",
                @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer!NoAutoRun", "1"));
            _rules.Add(new GroupPolicyRule("指定 Intranet Microsoft 更新服务位置",
                @"HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate!WUServer", "http://10.160.5.20:8530"));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _rules.GetEnumerator();
        }

        IEnumerator<IRule> IEnumerable<IRule>.GetEnumerator()
        {
            return _rules.GetEnumerator();
        }
    }
}
