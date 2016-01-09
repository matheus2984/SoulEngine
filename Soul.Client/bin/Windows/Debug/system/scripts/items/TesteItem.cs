using System.Windows.Forms;
using Soul.Engine.Scripts;

namespace Soul.Scripts.Item
{
    public sealed class TesteItem : ItemScript
    {
        protected override void Load()
        {
            Hook(721157); 
        }

        public override void OnUsage()
        {
            MessageBox.Show("eae");
        }
    }
}