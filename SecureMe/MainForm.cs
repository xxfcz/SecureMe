using SecureMe.Rules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SecureMe
{
    public partial class MainForm : Form
    {
        private RuleList _rules = new RuleList();

        public MainForm()
        {
            InitializeComponent();

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
