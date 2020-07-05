using Securit.Rules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Securit
{
    public partial class MainForm : Form
    {
        private List<IRule> _rules = new List<IRule>();

        public MainForm()
        {
            InitializeComponent();

            _rules.Add(new ScreenSaverIsSecure());
            _rules.Add(new IeHistoryDaysToKeep());
            _rules.Add(new NoDriveTypeAutoRun());
            _rules.Add(new RemovableStorageDevicesDenyExecute());
            _rules.Add(new GroupPolicyRule("设置自动运行的默认行为", @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer!NoAutoRun", "1", Microsoft.Win32.RegistryValueKind.DWord));
            _rules.Add(new WUServer());
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            lsbRules.Items.Clear();
            foreach (IRule r in _rules)
            {
                r.Scan();
                lsbRules.Items.Add(string.Format("{0} - {1}", r.Effective, r.Title));
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            lsbRules.Items.Clear();
            foreach (IRule r in _rules)
            {
                r.Apply();
                r.Scan();
                lsbRules.Items.Add(string.Format("{0} - {1}", r.Effective, r.Title));
            }
        }
    }
}
