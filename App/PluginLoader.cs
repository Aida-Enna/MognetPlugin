using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIVPostParse
{
    public class PluginLoader : IActPluginV1
    {
        PluginMain main;

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            main = new PluginMain(pluginScreenSpace, pluginStatusText);
            main.Init();
        }

        public void DeInitPlugin()
        {
            main.DeInit();
        }
    }
}
