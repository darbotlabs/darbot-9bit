using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Plugins
{
    public class PluginManager
    {
        private List<IPlugin> plugins;

        public PluginManager()
        {
            plugins = new List<IPlugin>();
        }

        public void LoadPlugins(string pluginsDirectory)
        {
            if (!Directory.Exists(pluginsDirectory))
            {
                throw new DirectoryNotFoundException($"The directory {pluginsDirectory} does not exist.");
            }

            string[] pluginFiles = Directory.GetFiles(pluginsDirectory, "*.dll");
            foreach (string pluginFile in pluginFiles)
            {
                LoadPlugin(pluginFile);
            }
        }

        private void LoadPlugin(string pluginFile)
        {
            Assembly pluginAssembly = Assembly.LoadFrom(pluginFile);
            Type[] types = pluginAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                {
                    IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                    plugins.Add(plugin);
                    plugin.Initialize();
                }
            }
        }

        public void UpdatePlugins()
        {
            foreach (IPlugin plugin in plugins)
            {
                plugin.Update();
            }
        }

        public void RenderPlugins()
        {
            foreach (IPlugin plugin in plugins)
            {
                plugin.Render();
            }
        }
    }
}
