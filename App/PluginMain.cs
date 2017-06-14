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

namespace MognetPlugin
{
    public class PluginMain : IActPluginV1
    {
        TabPage TabPage;
        Label PluginStatusLabel;
        PluginControl PluginControl;

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            this.TabPage = pluginScreenSpace;
            this.PluginStatusLabel = pluginStatusText;

            this.PluginStatusLabel.Text = "Mognet Plugin";
            this.TabPage.Text = "Mognet Plugin";

            this.PluginControl = new PluginControl();
            this.PluginControl.Dock = DockStyle.Fill;
            this.TabPage.Controls.Add(this.PluginControl);

            ActGlobals.oFormActMain.OnCombatStart += CombatStarted;
            ActGlobals.oFormActMain.OnCombatEnd += CombatEnded;

            this.PluginControl.LogInfo("Plugin started.");
            if (IsEnabled())
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
            if (IsEnabled())
            {
                PluginControl.LogInfo("Encounter detected! Will send the parse after it finishes...");
            }
        }

        private void CombatEnded(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            if (IsEnabled())
            {
                try
                {
                    Log Log = PluginUtil.ACTEncounterToModel(encounterInfo.encounter);
                    JavaScriptSerializer Serializer = new JavaScriptSerializer();
                    String Json = Serializer.Serialize(Log);
                    PluginHttpClient Client = new PluginHttpClient();
                    HttpResponseMessage Result = Client.PostDiscord(Json, (string)PluginSettings.GetSetting("Token"));
                    
                    if (Result.IsSuccessStatusCode)
                    {
                        PluginControl.LogInfo("Parse sent to your Discord channel.");
                        this.PluginControl.LogInfo("Waiting the next encounter...");
                    }
                    else
                    {
                        PluginControl.LogInfo("Could not send the parse to your Discord channel. Check your token.");
                    }
                }
                catch (Exception ex)
                {
                    PluginControl.LogInfo("Something went wrong.");
                }
            }
        }

        private bool IsEnabled()
        {
            bool enabled = (bool)PluginSettings.GetSetting("Enabled");
            string token = (string)PluginSettings.GetSetting("Token");
            return enabled && token != null;
        }
    }
}
