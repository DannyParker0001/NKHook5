using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NKHook5
{
    internal class PluginLoader
    {
        public static void loadPlugins()
        {
            BackgroundWorker pluginWorker = new BackgroundWorker();
            pluginWorker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                string currentDir = Environment.CurrentDirectory;
                DirectoryInfo pluginDir = new DirectoryInfo(currentDir+"\\Plugins");
                if (!pluginDir.Exists)
                {
                    pluginDir.Create();
                }
                foreach(FileInfo file in pluginDir.GetFiles())
                {
                    BackgroundWorker pluginLoadWorker = new BackgroundWorker();
                    pluginLoadWorker.DoWork += (object obj, DoWorkEventArgs dw) =>
                    {
                        Assembly pluginAsm = Assembly.LoadFrom(file.FullName);
                        Type pluginType = typeof(NkPlugin);
                        foreach(Type t in pluginAsm.GetTypes())
                        {
                            if(pluginType.IsAssignableFrom(t))
                            {
                                NkPlugin plugin = (NkPlugin)Activator.CreateInstance(t);
                                plugin.NkLoad();
                            }
                        }
                    };
                    pluginLoadWorker.RunWorkerAsync();
                }
                Console.Title = "NKHook5-Console";
            };
            pluginWorker.RunWorkerAsync();
        }
    }
}
