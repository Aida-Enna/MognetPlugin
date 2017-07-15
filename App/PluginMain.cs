using Advanced_Combat_Tracker;

using System.Windows.Forms;
using System.Web.Script.Serialization;
using System;
using System.Net.Http;

using MognetPlugin.Control;
using MognetPlugin.Util;
using MognetPlugin.Model;
using MognetPlugin.Properties;
using MognetPlugin.Http;
using MognetPlugin.Service;
using System.Text.RegularExpressions;

namespace MognetPlugin
{
    public class PluginMain : IActPluginV1
    {
        TabPage TabPage;
        Label PluginStatusLabel;
        PluginControl PluginControl;
        DiscordService Service;

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
                this.PluginControl.LogInfo("Waiting the next encounter...");
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
                        string Json = PluginUtil.ToJson(Log);
                        bool Sent = Service.PostDiscord(Json, PluginSettings.GetSetting<string>("Token"));

                        if (Sent)
                        {
                            PluginControl.LogInfo("Parse sent to your Discord channel.");
                            PluginControl.LogInfo("Waiting the next encounter...");
                        }
                        else
                        {
                            PluginControl.LogInfo("Could not send the parse to your Discord channel. Check your token.");
                        }
                    } else
                    {
                        PluginControl.LogInfo("Nothing to be sent. Waiting the next encounter...");
                    }
                }
                catch (Exception ex)
                {
                    PluginControl.LogInfo("Something went wrong. " + ex.Message);
                }
            }
        }
    }
}
