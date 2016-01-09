using Microsoft.Xna.Framework.Content;
using Soul.Engine.Common;

namespace Soul.Engine.UI
{
    public interface IViewState : IGameComponent
    {
        void LoadContent(ContentManager content);
    }
}