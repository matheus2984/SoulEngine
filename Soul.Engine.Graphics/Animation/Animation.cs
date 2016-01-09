using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Soul.Engine.Common;
using Soul.Engine.Serialization;

namespace Soul.Engine.Graphics.Animation
{
    public class Animation : IUpdatable, ISerializable
    {
        public AnimationFlags AnimationFlag;
        private int currentFrame;
        private bool isCompleted;
        private float totalElapsedTime;
        public string Name { get; set; }

        public float FramesPerSecond { get; set; }
        public float TimePerFrame { get; set; }
        public List<KeyFrame> Frames { get; set; }
        public SpriteEffects FlipEffect { get; set; }
        public float Rotation { get; set; }

        public KeyFrame CurrentKeyFrame
        {
            get { return Frames[currentFrame]; }
        }

        public Animation(string name, float framesPerSecond)
        {
            Frames = new List<KeyFrame>();

            Name = name;
            FramesPerSecond = framesPerSecond;
            TimePerFrame = 1.0f/framesPerSecond;
        }

        public Animation(string name,  float framesPerSecond, AnimationFlags animationFlag = AnimationFlags.None,
            SpriteEffects flipEffect = SpriteEffects.None, float rotation = 0f)
            : this(name, framesPerSecond)
        {
            FlipEffect = flipEffect;
            AnimationFlag = animationFlag;
            Rotation = rotation;
        }

        public Animation()
        {
        }

        public void AddKeyFrame(int x, int y, int width, int height)
        {
            var keyFrame = new KeyFrame(x, y, width, height);
            Frames.Add(keyFrame);
        }

        public void AddKeyFrame(KeyFrame keyFrame)
        {
            Frames.Add(keyFrame);
        }

        public void Reset()
        {
            currentFrame = 0;
            totalElapsedTime = 0;
            isCompleted = false;
        }

        public void Serialize(BinaryOutput output)
        {
            output.Write(Name);
            output.Write(TimePerFrame);
            output.Write(Frames);
            output.Write((byte) AnimationFlag);
            output.Write((byte) FlipEffect);
            output.Write(Rotation);
        }

        public ISerializable Deserialize(BinaryInput input)
        {
            Name = input.ReadString();
            TimePerFrame = input.ReadSingle();
            Frames = input.ReadList<KeyFrame>();
            AnimationFlag = (AnimationFlags) input.ReadByte();
            FlipEffect = (SpriteEffects) input.ReadByte();
            Rotation = input.ReadSingle();
            return this;
        }

        public void Update(GameTime gameTime)
        {
            if (isCompleted) return;

            totalElapsedTime += (float) gameTime.ElapsedGameTime.TotalSeconds;
            //  KeyFrame keyFrame = Frames[currentFrame];

            if (totalElapsedTime >= TimePerFrame)
            {
                if (currentFrame >= Frames.Count - 1)
                {
                    if (AnimationFlag == AnimationFlags.Loopable)
                        currentFrame = 0;
                    else
                        isCompleted = true;
                }
                else
                {
                    currentFrame++;
                }

                totalElapsedTime -= totalElapsedTime;
            }
        }
    }
}