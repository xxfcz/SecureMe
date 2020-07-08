using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecureMe
{
    public class GroupPolicyRule: IRule
    {
        private bool _effective = false;
        public readonly string Title; // => "设置自动运行的默认行为";
        public readonly string Path; // = @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer!NoAutoRun";
        public readonly string Value; // "1";

        public GroupPolicyRule(string title, string path, string value, Microsoft.Win32.RegistryValueKind kind)
        {
            Title = title;
            Path = path;
            Value = value;
        }

        public bool Effective { get { return _effective; } }

        string IRule.Title => this.Title;

        public void Apply()
        {
            ComputerGroupPolicyObject.SetPolicySetting(Path, Value, Microsoft.Win32.RegistryValueKind.DWord);
        }

        public void Scan()
        {
            object o = ComputerGroupPolicyObject.GetPolicySetting(Path);
            string s = Convert.ToString(o);
            _effective = (s == Value);
        }
    }
}
