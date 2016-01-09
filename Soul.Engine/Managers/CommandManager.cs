using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Soul.Engine.Command;
using Soul.Engine.Common;
using Soul.Engine.Extentions;

namespace Soul.Engine.Managers
{
    public sealed class CommandManager : Singleton<CommandManager>
    {
        private readonly object cmdLock = new object();

        private readonly Dictionary<string, Command.Command> commands =
            new Dictionary<string, Command.Command>(StringComparer.OrdinalIgnoreCase);

        public IDictionary<string, Command.Command> Commands
        {
            get { return new Dictionary<string, Command.Command>(commands); }
        }

        private CommandManager()
        {
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                LoadCommands(asm);
        }

        public void AddCommand(Command.Command cmd, params string[] triggers)
        {
            foreach (string trigger in triggers)
            {
                if (commands.ContainsKey(trigger))
                {
                    return;
                }
                commands.Add(trigger, cmd);
            }
        }

        public void RemoveCommand(params string[] triggers)
        {
            foreach (string trigger in triggers)
                commands.Remove(trigger);
        }

        public Command.Command GetCommand(string trigger)
        {
            return commands.TryGet(trigger);
        }

        public void ExecuteCommand(CommandArguments arguments)
        {
            try
            {
                string cmd = arguments.NextString();

                if (string.IsNullOrWhiteSpace(cmd))
                    return;

                Command.Command command = GetCommand(cmd);

                if (command == null) return;
                lock (cmdLock)
                    command.Execute(arguments);
            }

            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void LoadCommands(Assembly asm)
        {
            Type cmdType = typeof (Command.Command);

            foreach (Type type in asm.GetTypes())
            {
                var attr = type.GetCustomAttribute<CommandAttribute>();
                if (attr == null)
                    continue;

                if (type.IsGenericType)
                    throw new Exception("A command class cannot be generic.");

                if (type.IsAbstract)
                    throw new Exception("A command class cannot be abstract.");

                ConstructorInfo ctor = type.GetConstructors().FirstOrDefault(x => x.GetParameters().Length == 0);
                if (ctor == null)
                    throw new Exception("A command class must have a public parameterless constructor.");

                var cmd = (Command.Command) ctor.Invoke(null);
                AddCommand(cmd, attr.Triggers);
            }
        }
    }
}