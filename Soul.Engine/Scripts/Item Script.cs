using System.Diagnostics;
using Soul.Engine.Managers;

namespace Soul.Engine.Scripts
{
    public abstract class ItemScript : IScript
    {
        public int HookedItemID;

        public virtual void Hook(int itemId)
        {
            HookedItemID = itemId;
        }

        public virtual void OnUsage()
        {
        }

        protected abstract void Load();

        public bool Init()
        {
            Load();
            ScriptManager.Instance.AddItemScript(this);
            return true;
        }
    }

    public sealed class DummyItemScript : ItemScript
    {
        public DummyItemScript(int uid)
        {
            Debug.WriteLine("Invalid item id: " + uid);
        }

        protected override void Load()
        {
        }
    }
}