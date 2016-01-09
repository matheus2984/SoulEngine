using System;
using System.Collections.Generic;

namespace Soul.Engine.Scripting.Compiler
{
    public class CompilerException : Exception
    {
        public List<CompilerError> Errors { get; protected set; }

        public CompilerException()
        {
            Errors = new List<CompilerError>();
        }
    }

    public class CompilerError : Exception
    {
        public string File { get; protected set; }
        public int Line { get; protected set; }
        public int Column { get; protected set; }
        public bool IsWarning { get; protected set; }

        public CompilerError(string file, int line, int column, string message, bool isWarning)
            : base(message)
        {
            File = file;
            Line = line;
            Column = column;
            IsWarning = isWarning;
        }
    }
}