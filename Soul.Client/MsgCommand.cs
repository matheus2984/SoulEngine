using System;
using Soul.Engine.Command;

namespace Soul.Client
{
    [Command("msg", "xx")]
    public sealed class MsgCommand : Command
    {
        public override void Execute(CommandArguments args)
        {
            Console.WriteLine("oi");
        }
    }
}