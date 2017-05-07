using Advanced_Combat_Tracker;
using System.Windows.Forms;
using FFXIVPostParse.Control;
using FFXIVPostParse.Util;
using FFXIVPostParse.Model;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System;
using FFXIVPostParse.Enum;

namespace FFXIVPostParse
{
    public class PluginMain
    {
        TabPage TabPage;
        Label PluginStatusLabel;
        PluginControl PluginControl;

        public PluginMain(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            this.TabPage = pluginScreenSpace;
            this.PluginStatusLabel = pluginStatusText;
        }

        public void Init()
        {
            this.PluginStatusLabel.Text = "FFXIV Post Parse";
            this.TabPage.Text = "FFXIV Post Parse";

            this.PluginControl = new PluginControl();
            this.PluginControl.Dock = DockStyle.Fill;
            this.TabPage.Controls.Add(this.PluginControl);

            ActGlobals.oFormActMain.OnCombatStart += CombatStarted;
            ActGlobals.oFormActMain.OnCombatEnd += CombatEnded;

            this.PluginControl.AddPluginLogText("Plugin started. Waiting for the next encounter...");
        }

        public void DeInit()
        {
            ActGlobals.oFormActMain.OnCombatStart -= CombatStarted;
            ActGlobals.oFormActMain.OnCombatEnd -= CombatEnded;
        }

        private void CombatStarted(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            if (PluginControl.IsEnabled)
            {
                PluginControl.AddPluginLogText("Encounter detected! Waiting for the end...");
            }
        }

        private void CombatEnded(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            if (PluginControl.IsEnabled)
            {
                List<AttributeEnum> attributes = PluginControl.GetCheckedAttributes();
                if(attributes.Count == 0)
                {
                    PluginControl.AddPluginLogText("Log not sent. You must choose at least one attribute.");
                }
                else
                {
                    Log Log = PluginUtil.ACTEncounterToModel(encounterInfo.encounter, attributes, PluginControl.GetPlayerName());
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    String json = serializer.Serialize(Log);
                    PluginControl.AddPluginLogText(json);
                    PluginControl.AddPluginLogText("Log sent to your Discord channel. Waiting for the next encounter...");
                }
            }
        }
    }
}
