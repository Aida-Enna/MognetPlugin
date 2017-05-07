using FFXIVPostParse.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FFXIVPostParse.Control
{
    public partial class PluginControl : UserControl
    {
        public Boolean IsEnabled { get; set; }

        public PluginControl()
        {
            InitializeComponent();
            this.IsEnabled = true;
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkEnabled.Checked)
            {
                this.IsEnabled = true;
                AddPluginLogText("Plugin enabled. Log will be sent after the ending of an encounter.");
            }
            else
            {
                AddPluginLogText("Plugin disabled. No log will be sent.");
                this.IsEnabled = false;
            }
        }

        public void AddPluginLogText(String text)
        {
            text = DateTime.Now.ToString("HH:mm:ss") + ": " + text;
            text += Environment.NewLine;
            this.rchPluginLog.Text += text;
        }

        public String GetPlayerName()
        {
            return this.txtPlayerName.Text;
        }

        public List<AttributeEnum> GetCheckedAttributes()
        {
            List<AttributeEnum> attributes = new List<AttributeEnum>();
            IEnumerator e = this.chlAttributes.CheckedIndices.GetEnumerator();
            while (e.MoveNext())
            {
                AttributeEnum attrib = AttributeEnum.GetAttributeByIndex((int) e.Current);
                if (attrib != null)
                {
                    attributes.Add(attrib);
                }
                
            }

            return attributes;
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            this.rchPluginLog.Clear();
        }

        private void btnApplyName_Click(object sender, EventArgs e)
        {
            String playerName = txtPlayerName.Text;
            playerName = playerName.TrimStart(' ');
            playerName = playerName.TrimEnd(' ');
            if (playerName == "")
            {
                playerName = "YOU";
            }
            txtPlayerName.Text = playerName;
        }
    }

}
