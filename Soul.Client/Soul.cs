using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Soul.Engine;
using Soul.Engine.Command;
using Soul.Engine.Data;
using Soul.Engine.Extentions;
using Soul.Engine.Graphics.Animation;
using Soul.Engine.Managers;
using Soul.Engine.Serialization;
using Soul.Engine.Threading;
using Soul.Engine.Window;
using Soul.Engine.World.TileEngine;

namespace Soul.Client   
{   
    public class Soul : SoulGame
    {
        private readonly GraphicsDeviceManager graphics;
        private HUD hud;
        private Map map;
        private SpriteBatch spriteBatch;
        private Animator animator;
        public Soul()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Mouse.IsVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            GameService.AddService(Content);
            GameService.AddService(Window);
            GameService.AddService(graphics);
            GameService.AddService(spriteBatch);


            /*  layer.Tiles = new Tile[2, 2];

            layer.Tiles[0, 0] = new Tile(0, 0, 0, 0, 0);
            layer.Tiles[0, 1] = new Tile(0, 0, 1, 16, 0);
            layer.Tiles[1, 0] = new Tile(0, 1, 0, 0, 16);
            layer.Tiles[1, 1] = new Tile(0, 1, 1, 16, 16);*/


            /*map = new Map("hu3", 2, 2);
            var layer = new Layer(map);
            var tileset = new Tileset(0, Content.Load<Texture2D>("t1"));
            tileset.Name = "oi";
            map.AddTileset(tileset);

            layer.Tiles = new Tile[2, 2];

            layer.Tiles[0, 0] = new Tile(0, 0, 0, 0, 0);
            layer.Tiles[0, 1] = new Tile(0, 0, 1, 16, 0);
            layer.Tiles[1, 0] = new Tile(0, 1, 0, 0, 16);
            layer.Tiles[1, 1] = new Tile(0, 1, 1, 16, 16);

            map.AddLayer(layer);

            Serializer.Serialize<Map>("map/map.pks", map);
            */
            map = Serializer.Deserialize<Map>("map/map.pks", GraphicsDevice);


             animator = new Animator(Content.Load<Texture2D>("1"), new Vector2(50, 50));
            Animation animation = new Animation("teste", 5);
            animation.AddKeyFrame(8, 37, 16, 19);
            animation.AddKeyFrame(25, 36, 15, 19);
            animation.AddKeyFrame(41, 37, 15, 19);
            animator.AddAnimation(animation);
            animation = new Animation("stop", 1);
            animation.AddKeyFrame(8, 37, 16, 19);
            animator.AddAnimation(animation);
            animator.Play("stop");     
            hud = new HUD(this, Content, GraphicsDevice);
            ThreadAction.Factory(ScriptManager.Instance.Load, false);
            ThreadAction.Factory(ConsoleThread, 1, true); 
        }

        private static void ConsoleThread()
        {
            string line = Console.ReadLine();
            CommandManager.Instance.ExecuteCommand(new CommandArguments(line.ParseCommand()));
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                ScriptManager.Instance.GetItemScript(721157).OnUsage();
                var a = DataContext.Aluno.GetById(1);
                this.Window.Title = a.Nome;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                animator.Play("teste");
            }
            animator.Update(gameTime);
            hud.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            map.Draw(spriteBatch, gameTime);
            hud.Draw(spriteBatch, gameTime);
            animator.Draw(spriteBatch,gameTime);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}