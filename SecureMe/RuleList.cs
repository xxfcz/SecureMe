using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Securit.Rules;

namespace Securit
{
    class RuleList: IEnumerable<IRule>
    {
        private List<IRule> _rules = new List<IRule>();

        public RuleList()
        {
            _rules.Add(new ScreenSaverIsSecure());
            _rules.Add(new IeHistoryDaysToKeep());
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
