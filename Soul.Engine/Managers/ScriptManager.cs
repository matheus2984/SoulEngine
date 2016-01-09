using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using Soul.Engine.Common;
using Soul.Engine.Extentions;
using Soul.Engine.Scripting;
using Soul.Engine.Scripting.Compiler;
using Soul.Engine.Scripts;
using Soul.Engine.Utilities.File_Data;

namespace Soul.Engine.Managers
{
    public sealed class ScriptManager : Singleton<ScriptManager>
    {
        private const string SystemIndexRoot = "system/scripts/";
        private const string IndexPath = SystemIndexRoot + "scripts.txt";
        private readonly CSharpCompiler compiler;
        private readonly Dictionary<int, ItemScript> itemScripts;
        private readonly Dictionary<string, Type> scripts;
        // private readonly List<IDisposableResource> _scriptsToDispose;

        /*    private static ScriptManager _instance;

        public static ScriptManager Instance
        {
            get { return _instance ?? (_instance = new ScriptManager()); }
        }
        */


        private ScriptManager()
        {
            compiler = new CSharpCompiler();

            scripts = new Dictionary<string, Type>();
            itemScripts = new Dictionary<int, ItemScript>();
        }

        public void Load()
        {
            LoadScripts();
            InitializeType<ItemScript>();
        }

        private void ClearScriptContainers()
        {
            itemScripts.Clear();
            scripts.Clear();
        }

        private void InitializeScript(Type type)
        {
            try
            {
                var script = Activator.CreateInstance(type) as IScript;
                if (script != null && !script.Init())
                {
                    return;
                }

                if (!type.GetInterfaces().Contains(typeof (IAutoLoader))) return;

                var autoLoader = script as IAutoLoader;
                if (autoLoader != null) autoLoader.AutoLoad();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void LoadScriptAssembly(Assembly asm, string filePath)
        {
            Type[] types;
            try
            {
                types = asm.GetTypes();
            }
            catch (ReflectionTypeLoadException)
            {
                return;
            }

            foreach (
                Type type in
                    types.Where(
                        a =>
                            a.GetInterfaces().Contains(typeof (IScript)) && !a.IsAbstract && !a.Name.StartsWith("_"))
                )
                try
                {
                    if (scripts.ContainsKey(type.Name))
                    {
                        continue;
                    }

                    var overide = type.GetCustomAttribute<OverrideAttribute>();
                    if (overide != null)
                        if (scripts.ContainsKey(overide.TypeName))
                            scripts.Remove(overide.TypeName);

                    var removes = type.GetCustomAttribute<RemoveAttribute>();
                    if (removes != null)
                        foreach (string rm in removes.TypeNames)
                            if (scripts.ContainsKey(rm))
                                scripts.Remove(rm);

                    scripts[type.Name] = type;
                }
                catch (Exception)
                {
                    // ignored
                }
        }

        private void LoadScripts()
        {
            ClearScriptContainers();

            if (!File.Exists(IndexPath))
            {
                return;
            }

            var toLoad = new OrderedDictionary();

            using (var fr = new TextFileData(IndexPath))
            {
                foreach (string line in fr)
                {
                    string scriptPath = Path.Combine(SystemIndexRoot, line);
                    if (!File.Exists(scriptPath))
                    {
                        continue;
                    }
                    toLoad[line] = scriptPath;
                }
            }

            //  int done = 0, loaded = 0;
            foreach (string filePath in toLoad.Values)
            {
                Assembly asm = Compile(filePath);
                if (asm != null)
                {
                    LoadScriptAssembly(asm, filePath);
                    //      loaded++;
                }


                //    done++;
            }
        }

        private Assembly Compile(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            string outPath = GetCachePath(path);

            try
            {
                return compiler.Compile(path, outPath);
            }
            catch (CompilerException)
            {
                try
                {
                    File.Delete(outPath);
                }
                catch (UnauthorizedAccessException)
                {
                }

                /*  var lines = File.ReadAllLines(path);

                foreach (var err in ex.Errors)
                {

                    var startLine = Math.Max(1, err.Line - 1);
                    var endLine = Math.Min(lines.Length, startLine + 2);
                    for (var i = startLine; i <= endLine; ++i)
                    {
                        var line = (i <= lines.Length) ? lines[i - 1] : "";

                    }
                }*/
            }
            catch (Exception)
            {
                // ignored
            }

            return null;
        }

        private static string GetCachePath(string path)
        {
            string result = (!path.StartsWith("cache")
                ? Path.Combine("cache", Path.ChangeExtension(path, ".lib"))
                : Path.ChangeExtension(path, ".lib"));
            string dir = Path.GetDirectoryName(result);

            if (dir != null && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            return result;  
        }

        public void AddItemScript(ItemScript script)
        {
            itemScripts[script.HookedItemID] = script;
        }

        public ItemScript GetItemScript(int uid)
        {
            ItemScript script;
            itemScripts.TryGetValue(uid, out script);
            return script ?? new DummyItemScript(uid);
        }

        public void InitializeType<TScript>()
        {
            foreach (Type type in scripts.Values.Where(type => type.Inherits(typeof (TScript))))
                InitializeScript(type);
        }
    }
}