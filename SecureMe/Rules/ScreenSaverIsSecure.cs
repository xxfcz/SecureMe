using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Securit
{
    class ScreenSaverIsSecure : IRule
    {
        private static RegistryKey ROOT = Registry.CurrentUser;
        private static string PATH = @"Control Panel\Desktop";
        private static string NAME = "ScreenSaverIsSecure";

        private bool _effective;

        string IRule.Title { get => "屏保：在恢复时显示登录屏幕"; }

        bool IRule.Effective => _effective;

        void IRule.Apply()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(PATH, true);
            regKey.SetValue(NAME, "1", RegistryValueKind.String);
            _effective = true;
        }

        void IRule.Scan()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(PATH);
            object o = regKey.GetValue(NAME);
            if (o == null)
            {
                throw new Exception(string.Format(@" 不包含键：{0}\{1}\{2}", ROOT, PATH, NAME));
            }
            int n = Convert.ToInt32(o);
            _effective = (n == 1);
        }
    }
}
