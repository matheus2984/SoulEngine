namespace Soul.Engine.Command
{
    public abstract class Command
    {
        public virtual string Description
        {
            get { return string.Empty; }
        }

        public abstract void Execute(CommandArguments args);
    }
}