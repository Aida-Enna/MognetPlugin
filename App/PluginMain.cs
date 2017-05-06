using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIVPostParse
{
    public class PluginMain
    {
        TabPage tabPage;
        Label label;
        PluginControl pluginControl;

        public PluginMain(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            this.tabPage = pluginScreenSpace;
            this.label = pluginStatusText;
        }

        public void Init()
        {
            this.label.Text = "FFXIV Post Parse";

            this.pluginControl = new PluginControl();
            this.pluginControl.Dock = DockStyle.Fill;
            this.tabPage.Controls.Add(this.pluginControl);

            ActGlobals.oFormActMain.OnCombatStart += CombatStarted;
            ActGlobals.oFormActMain.OnCombatEnd += CombatEnded;
        }

        public void DeInit()
        {
            ActGlobals.oFormActMain.OnCombatStart -= CombatStarted;
            ActGlobals.oFormActMain.OnCombatEnd -= CombatEnded;
        }

        private void CombatStarted(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            if (pluginControl.IsEnabled)
            {
                pluginControl.CombatStatusText("Fight detected! Waiting for it to end...");
            }
            else
            {
                pluginControl.CombatStatusText("Plugin disabled. No log will be sent.");
            }
        }

        private void CombatEnded(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            if (pluginControl.IsEnabled)
            {
                pluginControl.CombatStatusText("Log sent to your Discord channel. Waiting for the next one...");
            }
            else
            {
                pluginControl.CombatStatusText("Plugin disabled. No log will be sent.");
            }
        }
    }
}
