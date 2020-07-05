using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Securit.Rules
{
    class NoAutoRun : IRule
    {
        private bool _effective = false;
        private static string PATH = @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer!NoAutoRun";
        private static string VALUE = "1";

        public string Title => "设置自动运行的默认行为";

        public bool Effective => _effective;

        public void Apply()
        {
            ComputerGroupPolicyObject.SetPolicySetting(PATH, VALUE, Microsoft.Win32.RegistryValueKind.DWord);
        }

        public void Scan()
        {
            object o = ComputerGroupPolicyObject.GetPolicySetting(PATH);
            string s = Convert.ToString(o);
            _effective = (s == VALUE);
        }
    }
}
