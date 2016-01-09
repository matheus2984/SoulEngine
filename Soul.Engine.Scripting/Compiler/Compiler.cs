using System.IO;
using System.Reflection;

namespace Soul.Engine.Scripting.Compiler
{
    public abstract class Compiler
    {
        public abstract Assembly Compile(string path, string outPath);

        protected bool ExistsAndUpToDate(string path, string outPath)
        {
            if (!File.Exists(outPath))
                return false;

            return File.GetLastWriteTime(path) <= File.GetLastWriteTime(outPath);
        }

        protected void SaveAssembly(Assembly asm, string outPath)
        {
            string outRoot = Path.GetDirectoryName(outPath);

            if (File.Exists(outPath))
                File.Delete(outPath);
            else if (outRoot != null && !Directory.Exists(outRoot))
                Directory.CreateDirectory(outRoot);

            File.Copy(asm.Location, outPath);
        }
    }
}