using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Windows.Forms;

namespace Securit
{
    class IeHistoryDaysToKeep : IRule
    {
        private static RegistryKey ROOT = Registry.CurrentUser;
        private static string PATH = @"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Url History";
        private static string NAME = "DaysToKeep";
        private static int VALUE = 180;

        private bool _effective;

        string IRule.Title { get => "IE设置：在历史记录中保存网页的天数为180"; }

        bool IRule.Effective => _effective;

        void IRule.Apply()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(PATH, true);
            regKey.SetValue(NAME, VALUE, RegistryValueKind.DWord);
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
            _effective = (n == VALUE);
        }
    }
}
