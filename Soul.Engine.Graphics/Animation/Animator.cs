using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Soul.Engine.Common;
using Soul.Engine.Serialization;
using IDrawable = Soul.Engine.Common.IDrawable;

namespace Soul.Engine.Graphics.Animation
{
    public class Animator : IUpdatable, IDrawable, ISerializable
    {
        private Dictionary<string, Animation> animations;
        private Animation currentAnimation;
        public Vector2 Position;
        public Texture2D Texture;

        public Animator(Texture2D texture, Vector2 position)
        {
            animations = new Dictionary<string, Animation>();

            Texture = texture;
            Position = position;
        }

        public Animator()
        {
        }

        public void AddAnimation(Animation animation)
        {
            animations.Add(animation.Name, animation);
        }

        public void Play(string key)
        {
            currentAnimation = animations[key];
            currentAnimation.Reset();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (currentAnimation == null) return;
            KeyFrame cframe = currentAnimation.CurrentKeyFrame;

            spriteBatch.Draw(Texture, Position, cframe.Source, Color.White, currentAnimation.Rotation, Vector2.Zero, 1,
                currentAnimation.FlipEffect, 0);
        }

        public void Serialize(BinaryOutput output)
        {
            output.Write(Texture);
            output.Write(Position);

            int size = animations.Count;
            output.Write(size);
            for (var i = 0; i < size; i++)
            {
                KeyValuePair<string, Animation> element = animations.ElementAt(i);
                output.Write(element.Key);
                output.Write(element.Value);
            }
        }

        public ISerializable Deserialize(BinaryInput input)
        {
            Texture = input.ReadTexture();
            Position = input.ReadVector2();

            int size = input.ReadInt32();
            animations = new Dictionary<string, Animation>(size);
            for (var i = 0; i < size; i++)
            {
                string key = input.ReadString();
                var value = input.ReadObject<Animation>();
                animations.Add(key, value);
            }

            return this;
        }

        public void Update(GameTime gameTime)
        {
            if (currentAnimation == null) return;

            currentAnimation.Update(gameTime);
        }
    }
}