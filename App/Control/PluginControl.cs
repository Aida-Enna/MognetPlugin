using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIVPostParse
{
    public partial class PluginControl : UserControl
    {
        public Boolean IsEnabled { get; set; }

        public PluginControl()
        {
            InitializeComponent();
        }

        private void enabled_CheckedChanged(object sender, EventArgs e)
        {
            if (this.enabled.Checked)
            {
                this.IsEnabled = true;
            }
            else
            {
                this.IsEnabled = false;
            }
        }

        public void CombatStatusText(String text)
        {
            this.combatStatus.Text = text;
        }
    }

}
