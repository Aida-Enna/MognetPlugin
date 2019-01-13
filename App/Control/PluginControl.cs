using MognetPlugin.Model;
using MognetPlugin.Properties;
using MognetPlugin.Service;
using System;
using System.Windows.Forms;

namespace MognetPlugin.Control
{
    public partial class PluginControl : UserControl
    {
        private DiscordService Service;

        public PluginControl()
        {
            InitializeComponent();
            FillLists();
            AttachEvents();
            Service = new DiscordService();
        }

        public void LogInfo(String text)
        {
            text = DateTime.Now.ToString("HH:mm:ss") + ": " + text;
            text += Environment.NewLine;
            this.rchPluginLog.Text += text;
        }

        private void PluginControl_Load(object sender, System.EventArgs e)
        {
            this.chkEnabled.Checked = PluginSettings.GetSetting<bool>("Enabled");
            this.txtToken.Text = PluginSettings.GetSetting<string>("Token");
            this.lblGuildName.Text = PluginSettings.GetSetting<string>("GuildName");
            this.lblChannelName.Text = PluginSettings.GetSetting<string>("ChannelName");
            this.txtToken.Text = PluginSettings.GetSetting<string>("Token");

            this.chlAttributes.SetItemChecked(0, PluginSettings.GetSetting<bool>("MaxHitParty"));
            this.chlAttributes.SetItemChecked(1, PluginSettings.GetSetting<bool>("TotalHealing"));
            this.chlAttributes.SetItemChecked(2, PluginSettings.GetSetting<bool>("MapName"));
            this.chlAttributes.SetItemChecked(3, PluginSettings.GetSetting<bool>("DamagePerc"));
            this.chlAttributes.SetItemChecked(4, PluginSettings.GetSetting<bool>("MaxHitIndividual"));
            this.chlAttributes.SetItemChecked(5, PluginSettings.GetSetting<bool>("HPS"));
            this.chlAttributes.SetItemChecked(6, PluginSettings.GetSetting<bool>("HealingPerc"));
            this.chlAttributes.SetItemChecked(7, PluginSettings.GetSetting<bool>("MaxHeal"));
            this.chlAttributes.SetItemChecked(8, PluginSettings.GetSetting<bool>("OverHealPerc"));
            this.chlAttributes.SetItemChecked(9, PluginSettings.GetSetting<bool>("Deaths"));
            this.chlAttributes.SetItemChecked(10, PluginSettings.GetSetting<bool>("Crit"));
            this.chlAttributes.SetItemChecked(11, PluginSettings.GetSetting<bool>("DirectHit"));
            this.chlAttributes.SetItemChecked(12, PluginSettings.GetSetting<bool>("DirectHitCrit"));
            this.chlAttributes.SetItemChecked(13, PluginSettings.GetSetting<bool>("CritHealPerc"));

            this.cmbSort.Text = PluginSettings.GetSetting<string>("SortBy");

            this.chkTimeEnabled.Checked = PluginSettings.GetSetting<bool>("TimeEnabled");
            this.dtpStartTime.Value = DateTime.Parse(PluginSettings.GetSetting<string>("StartTime"));
            this.dtpEndTime.Value = DateTime.Parse(PluginSettings.GetSetting<string>("EndTime"));

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
                    PluginSettings.SetSetting("Crit", Checked(args.NewValue));
                    break;

                case 11:
                    PluginSettings.SetSetting("DirectHit", Checked(args.NewValue));
                    break;

                case 12:
                    PluginSettings.SetSetting("DirectHitCrit", Checked(args.NewValue));
                    break;

                case 13:
                    PluginSettings.SetSetting("CritHealPerc", Checked(args.NewValue));
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

        private void btnApplyToken_Click(object sender, EventArgs e)
        {
            DiscordChannel Channel = Service.CheckToken(txtToken.Text).Result;
            if (Channel != null)
            {
                LogInfo("Token validated! Parses will be posted to the displayed channel/server.");
                lblGuildName.Text = Channel.guild;
                lblChannelName.Text = Channel.channel;
                PluginSettings.SetSetting("Token", txtToken.Text);
                PluginSettings.SetSetting("GuildName", lblGuildName.Text);
                PluginSettings.SetSetting("ChannelName", lblChannelName.Text);
            }
            else
            {
                LogInfo("Invalid token. Please check it or re-create it and try again.");
                lblGuildName.Text = "";
                lblChannelName.Text = "";
                //txtToken.Text = "";
                PluginSettings.SetSetting("Token", "");
                PluginSettings.SetSetting("GuildName", "");
                PluginSettings.SetSetting("ChannelName", "");
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

        private void chkTimeEnabled_CheckedChanged(object sender, EventArgs e)
        {
            PluginSettings.SetSetting("TimeEnabled", chkEnabled.Checked);

            if (this.chkTimeEnabled.Checked)
            {
                LogInfo("Time lock enabled. Parses will only be sent to discord between the specified times.");
            }
            else
            {
                LogInfo("Time lock disabled. Parses will be sent as usual.");
            }

            this.dtpStartTime.Enabled = chkTimeEnabled.Checked;
            this.dtpEndTime.Enabled = chkTimeEnabled.Checked;
        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            PluginSettings.SetSetting("StartTime", dtpStartTime.Value.ToString());
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            PluginSettings.SetSetting("EndTime", dtpEndTime.Value.ToString());
        }
    }
}