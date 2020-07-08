using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecureMe.Rules
{
    class NoDriveTypeAutoRun : IRule
    {
        private bool _effective = false;
        private static string PATH = @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer!NoDriveTypeAutoRun";
        private static string VALUE = "255";

        public string Title => "关闭自动播放";

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
