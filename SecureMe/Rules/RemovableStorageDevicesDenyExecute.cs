using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecureMe.Rules
{
    class RemovableStorageDevicesDenyExecute : IRule
    {
        private bool _effective = false;
        private static string PATH = @"HKLM\SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices\{53f5630d-b6bf-11d0-94f2-00a0c91efb8b}\!Deny_Execute";
        private static string VALUE = "1";

        public string Title => "可移动磁盘：拒绝执行权限";

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
