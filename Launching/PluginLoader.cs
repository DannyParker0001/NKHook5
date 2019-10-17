using NKHook5.API;
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
                    if (!file.Name.Contains(".dll"))
                    {
                        Logger.Log("Skipping " + file.Name + " as it isnt a .dll");
                        continue;
                    }
                    BackgroundWorker pluginLoadWorker = new BackgroundWorker();
                    pluginLoadWorker.DoWork += (object obj, DoWorkEventArgs dw) =>
                    {
                        Logger.Log("Attempting to load " + file.Name);
                        Assembly pluginAsm = Assembly.LoadFrom(file.FullName);
                        Type pluginType = typeof(NkPlugin);
                        foreach(Type t in pluginAsm.GetTypes())
                        {
                            Logger.Log("Found class " + t.Name);
                            if(pluginType.IsAssignableFrom(t))
                            {
                                Logger.Log("Found " + t.Name + " to be assignable");
                                NkPlugin plugin = (NkPlugin)Activator.CreateInstance(t);
                                plugin.NkLoad();
                                Logger.Log("Loaded " + t.Name + " via NkPlugin load function");
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
