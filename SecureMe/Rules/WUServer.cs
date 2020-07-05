using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Securit.Rules
{
    class WUServer : IRule
    {
        // ComputerGroupPolicyObject.SetPolicySetting(@"HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate!WUServer", "http://10.160.5.20:8530", RegistryValueKind.String);
        private bool _effective = false;
        private static string PATH = @"HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate!WUServer";
        private static string VALUE = "http://10.160.5.20:8530";

        public string Title => "指定 Intranet Microsoft 更新服务位置";

        public bool Effective => _effective;

        public void Apply()
        {
            ComputerGroupPolicyObject.SetPolicySetting(PATH, VALUE, Microsoft.Win32.RegistryValueKind.String);
        }

        public void Scan()
        {
            object o = ComputerGroupPolicyObject.GetPolicySetting(PATH);
            string s = Convert.ToString(o);
            _effective = (s == VALUE);
        }
    }
}
