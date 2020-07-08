using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using Securit.Rules;

namespace Securit
{
    class RuleList: IEnumerable<IRule>
    {
        private List<IRule> _rules = new List<IRule>();

        public RuleList()
        {
            _rules.Add(new RegistryRule<string>("屏保：在恢复时显示登录屏幕", Registry.CurrentUser, @"Control Panel\Desktop", "ScreenSaverIsSecure", "1"));
            _rules.Add(new RegistryRule<int>("IE设置：在历史记录中保存网页的天数为180", Registry.CurrentUser,
                @"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Url History", "DaysToKeep", 180));
            _rules.Add(new NoDriveTypeAutoRun());
            _rules.Add(new RemovableStorageDevicesDenyExecute());
            _rules.Add(new GroupPolicyRule("设置自动运行的默认行为", @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer!NoAutoRun", "1", Microsoft.Win32.RegistryValueKind.DWord));
            _rules.Add(new WUServer());

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
