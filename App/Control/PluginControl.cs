using MognetPlugin.Http;
using MognetPlugin.Model;
using MognetPlugin.Properties;
using System;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace MognetPlugin.Control
{
    public partial class PluginControl : UserControl
    {
        public PluginControl()
        {
            InitializeComponent();
            FillLists();
            AttachEvents();
        }

        

        public void LogInfo(String text)
        {
            text = DateTime.Now.ToString("HH:mm:ss") + ": " + text;
            text += Environment.NewLine;
            this.rchPluginLog.Text += text;
        }

        private void PluginControl_Load(object sender, System.EventArgs e)
        {
            this.chkEnabled.Checked = (bool)PluginSettings.GetSetting("Enabled");
            this.txtToken.Text = (string)PluginSettings.GetSetting("Token");
            this.lblGuildName.Text = (string)PluginSettings.GetSetting("GuildName");
            this.lblChannelName.Text = (string)PluginSettings.GetSetting("ChannelName");
            this.txtToken.Text = (string)PluginSettings.GetSetting("Token");

            this.chlAttributes.SetItemChecked(0, (bool)PluginSettings.GetSetting("MaxHitParty"));
            this.chlAttributes.SetItemChecked(1, (bool)PluginSettings.GetSetting("TotalHealing"));
            this.chlAttributes.SetItemChecked(2, (bool)PluginSettings.GetSetting("MapName"));
            this.chlAttributes.SetItemChecked(3, (bool)PluginSettings.GetSetting("DamagePerc"));
            this.chlAttributes.SetItemChecked(4, (bool)PluginSettings.GetSetting("MaxHitIndividual"));
            this.chlAttributes.SetItemChecked(5, (bool)PluginSettings.GetSetting("HPS"));
            this.chlAttributes.SetItemChecked(6, (bool)PluginSettings.GetSetting("HealingPerc"));
            this.chlAttributes.SetItemChecked(7, (bool)PluginSettings.GetSetting("MaxHeal"));
            this.chlAttributes.SetItemChecked(8, (bool)PluginSettings.GetSetting("OverHealPerc"));
            this.chlAttributes.SetItemChecked(9, (bool)PluginSettings.GetSetting("Deaths"));
            this.chlAttributes.SetItemChecked(10, (bool)PluginSettings.GetSetting("Crits"));
            this.chlAttributes.SetItemChecked(11, (bool)PluginSettings.GetSetting("CritDmgPerc"));
            this.chlAttributes.SetItemChecked(12, (bool)PluginSettings.GetSetting("CritHealPerc"));
            this.chlAttributes.SetItemChecked(13, (bool)PluginSettings.GetSetting("Misses"));

            this.cmbSort.Text = (string)PluginSettings.GetSetting("SortBy");
        }

        private void chlAttributes_ItemCheck(object sender, EventArgs e)
        {
            ItemCheckEventArgs args = (ItemCheckEventArgs)e;

            switch (args.Index)
            {
                case 0:
                    PluginSettings.SetSetting("MaxHitParty", Checked(args.NewValue));
                    break;
                case 1:
                    PluginSettings.SetSetting("TotalHealing", Checked(args.NewValue));
                    break;
                case 2:
                    PluginSettings.SetSetting("MapName", Checked(args.NewValue));
                    break;
                case 3:
                    PluginSettings.SetSetting("DamagePerc", Checked(args.NewValue));
                    break;
                case 4:
                    PluginSettings.SetSetting("MaxHitIndividual", Checked(args.NewValue));
                    break;
                case 5:
                    PluginSettings.SetSetting("HPS", Checked(args.NewValue));
                    break;
                case 6:
                    PluginSettings.SetSetting("HealingPerc", Checked(args.NewValue));
                    break;
                case 7:
                    PluginSettings.SetSetting("MaxHeal", Checked(args.NewValue));
                    break;
                case 8:
                    PluginSettings.SetSetting("OverHealPerc", Checked(args.NewValue));
                    break;
                case 9:
                    PluginSettings.SetSetting("Deaths", Checked(args.NewValue));
                    break;
                case 10:
                    PluginSettings.SetSetting("Crits", Checked(args.NewValue));
                    break;
                case 11:
                    PluginSettings.SetSetting("CritDmgPerc", Checked(args.NewValue));
                    break;
                case 12:
                    PluginSettings.SetSetting("CritHealPerc", Checked(args.NewValue));
                    break;
                case 13:
                    PluginSettings.SetSetting("Misses", Checked(args.NewValue));
                    break;
            }
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            PluginSettings.SetSetting("Enabled", chkEnabled.Checked);

            if (this.chkEnabled.Checked)
            {
                LogInfo("Plugin enabled. Log will be sent after the ending of an encounter.");
            }
            else
            {
                LogInfo("Plugin disabled. No log will be sent.");
            }
        }

        private async void btnApplyToken_Click(object sender, EventArgs e)
        {
            try
            {
                JavaScriptSerializer Serializer = new JavaScriptSerializer();
                PluginHttpClient Client = new PluginHttpClient();
                HttpResponseMessage response = Client.Get(txtToken.Text);
                if (response.IsSuccessStatusCode)
                {
                    DiscordChannel DiscordChannel = Serializer.Deserialize<DiscordChannel>(await response.Content.ReadAsStringAsync());

                    lblGuildName.Text = DiscordChannel.guild;
                    lblChannelName.Text = DiscordChannel.channel;
                    PluginSettings.SetSetting("Token", txtToken.Text);
                    PluginSettings.SetSetting("GuildName", lblGuildName.Text);
                    PluginSettings.SetSetting("ChannelName", lblChannelName.Text);
                }
                else
                {
                    lblGuildName.Text = "";
                    lblChannelName.Text = "";
                    txtToken.Text = "";
                    PluginSettings.SetSetting("Token", "");
                    PluginSettings.SetSetting("GuildName", "");
                    PluginSettings.SetSetting("ChannelName", "");
                }
            } catch (Exception ex)
            {
                LogInfo("Something went wrong.");
                MessageBox.Show(ex.Message);
            }
            
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            PluginSettings.SetSetting("SortBy", cmbSort.Text);
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            this.rchPluginLog.Clear();
        }

        private void rchPluginLog_TextChanged(object sender, EventArgs e)
        {
            rchPluginLog.SelectionStart = rchPluginLog.Text.Length;
            rchPluginLog.ScrollToCaret();
        }

        private bool Checked(CheckState checkState)
        {
            if (checkState.ToString().Equals("Checked"))
            {
                return true;
            }

            return false;
        }
    }

}
