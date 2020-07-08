using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Securit
{
    public class RegistryRule: IRule
    {
        private readonly string _title;
        private readonly RegistryKey _root = Registry.CurrentUser;
        private readonly string _path;
        private readonly string _name;
        private readonly string _value;

        private bool _effective;

        string IRule.Title { get => _title; }

        bool IRule.Effective => _effective;

        public RegistryRule(string title, RegistryKey root, string path, string name, string value)
        {
            _title = title;
            _root = root;
            _path = path;
            _name = name;
            _value = value;
        }

        void IRule.Apply()
        {
            RegistryKey regKey = _root.OpenSubKey(_path, true);
            regKey.SetValue(_name, _value, RegistryValueKind.String);
            _effective = true;
        }

        void IRule.Scan()
        {
            RegistryKey regKey = _root.OpenSubKey(_path);
            object o = regKey.GetValue(_name);
            if (o == null)
            {
                throw new Exception(string.Format(@" 不包含键：{0}\{1}\{2}", _root, _path, _name));
            }
            string s = o.ToString();
            _effective = (s == _value);
        }
    }
}
