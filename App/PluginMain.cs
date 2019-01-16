using Advanced_Combat_Tracker;
using MognetPlugin.Control;
using MognetPlugin.Model;
using MognetPlugin.Properties;
using MognetPlugin.Service;
using MognetPlugin.Util;
using System;
using System.Windows.Forms;

namespace MognetPlugin
{
    public class PluginMain : IActPluginV1
    {
        private TabPage TabPage;
        private Label PluginStatusLabel;
        private PluginControl PluginControl;
        private DiscordService Service;

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            this.TabPage = pluginScreenSpace;
            this.PluginStatusLabel = pluginStatusText;

            this.PluginStatusLabel.Text = "Mognet Plugin";
            this.TabPage.Text = "Mognet Plugin";

            this.PluginControl = new PluginControl();
            this.PluginControl.Dock = DockStyle.Fill;
            this.TabPage.Controls.Add(this.PluginControl);

            this.Service = new DiscordService();

            ActGlobals.oFormActMain.OnCombatStart += CombatStarted;
            ActGlobals.oFormActMain.OnCombatEnd += CombatEnded;

            this.PluginControl.LogInfo("Plugin started.");
            if (PluginUtil.IsPluginEnabled())
            {
                this.PluginControl.LogInfo("Waiting for the next encounter...");
            }
        }

        public void DeInitPlugin()
        {
            ActGlobals.oFormActMain.OnCombatStart -= CombatStarted;
            ActGlobals.oFormActMain.OnCombatEnd -= CombatEnded;
        }

        private void CombatStarted(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            if (PluginUtil.IsPluginEnabled())
            {
                PluginControl.LogInfo("Encounter detected! Will send the parse after it finishes...");
            }
        }

        private void CombatEnded(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            if (PluginUtil.IsPluginEnabled())
            {
                try
                {
                    Log Log = PluginUtil.ACTEncounterToModel(encounterInfo.encounter);
                    if (Log != null)
                    {

                        if (PluginSettings.GetSetting<bool>("TimeEnabled") == true && PluginUtil.TimeBetween(DateTime.Now, DateTime.Parse(PluginSettings.GetSetting<string>("StartTime")).TimeOfDay, DateTime.Parse(PluginSettings.GetSetting<string>("EndTime")).TimeOfDay) == false)
                        {
                            PluginControl.LogInfo("Parse *not* sent to your Discord channel due to time lock rules.");
                            PluginControl.LogInfo("Waiting for the next encounter...");
                            return;
                        }

                        string Json = PluginUtil.ToJson(Log);
                        bool Sent = Service.PostDiscord(Json, PluginSettings.GetSetting<string>("Token"));

                        if (Sent)
                        {
                            PluginControl.LogInfo("Parse sent to your Discord channel.");
                            PluginControl.LogInfo("Waiting for the next encounter...");
                        }
                        else
                        {
                            PluginControl.LogInfo("Could not send the parse to your Discord channel. Check your token and permissions.");
                        }
                    }
                    else
                    {
                        PluginControl.LogInfo("Nothing to be sent. Waiting for the next encounter...");
                    }
                }
                catch (Exception e)
                {
                    PluginControl.LogInfo("Something went wrong. Debug info:" + Environment.NewLine + e.ToString());
                }
            }
        }
    }
}