using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using CSScriptLibrary;

namespace Soul.Engine.Scripting.Compiler
{
    public class CSharpCompiler : Compiler
    {
        public override Assembly Compile(string path, string outPath)
        {
            Assembly asm = null;
            try
            {
                if (ExistsAndUpToDate(path, outPath))
                    return Assembly.LoadFrom(outPath);

                asm = CSScript.LoadCode(PreCompile(File.ReadAllText(path)));

                SaveAssembly(asm, outPath);
            }
            catch (CompilerException ex)
            {
                var errors = ex.Data["Errors"] as CompilerErrorCollection;
                var newExs = new CompilerException();

                if (errors == null) throw newExs;
                foreach (System.CodeDom.Compiler.CompilerError err in errors)
                    newExs.Errors.Add(new CompilerError(path, err.Line - 1, err.Column, err.ErrorText, err.IsWarning));

                throw newExs;
            }
            catch (UnauthorizedAccessException)
            {
            }
            catch (Exception)
            {
                // ignored
            }

            return asm;
        }

        private static string PreCompile(string script)
        {
            script = Regex.Replace(script,
                @"([\{\}:;\t ])?Return\s*\(\s*\)\s*;",
                "$1yield break;",
                RegexOptions.Compiled);

            script = Regex.Replace(script,
                @"([\{\}:;\t ])?(Call|Do)\s*\(([^;]*)\)\s*;",
                "$1foreach(var __callResult in $3) yield return __callResult;",
                RegexOptions.Compiled);

            script = Regex.Replace(script,
                @"duplicate +([^\s:]+) *: *([^\s{]+) *{ *([^}]+) *}",
                "public class $1 : $2 { public override void Load() { base.Load(); $3 } }",
                RegexOptions.Compiled);

            return script;
        }
    }
}