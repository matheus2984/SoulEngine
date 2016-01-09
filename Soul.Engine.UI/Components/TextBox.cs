using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Soul.Engine.Extentions;
using Soul.Engine.Graphics;
using Soul.Engine.UI.ViewStates;
using Soul.Engine.UI.ViewStates.TextBox;

namespace Soul.Engine.UI.Components
{
    public class TextBox : Control
    {
        private readonly Keys[] keysToCheck =
        {
            Keys.A, Keys.B, Keys.C, Keys.D, Keys.E,
            Keys.F, Keys.G, Keys.H, Keys.I, Keys.J,
            Keys.K, Keys.L, Keys.M, Keys.N, Keys.O,
            Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T,
            Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y,
            Keys.Z, Keys.Back, Keys.Space, Keys.D0,
            Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5,
            Keys.D6, Keys.D7, Keys.D8, Keys.D9,
            Keys.NumPad0, Keys.NumPad1, Keys.NumPad2,
            Keys.NumPad3, Keys.NumPad4, Keys.NumPad5,
            Keys.NumPad6, Keys.NumPad7, Keys.NumPad8,
            Keys.NumPad9, Keys.Enter
        };

        private Texture2D caret;
        private Rectangle caretRectangle;
        private KeyboardState currentKeyboardState;
        private KeyboardState lastKeyboardState;
        public SpriteFont Font { get; set; }

        private string text;

        public event EventHandler<TextEventArgs> EnterPressed;

        public string Text
        {
            get { return !string.IsNullOrEmpty(text) ? text : ""; }
            set { text = value; }
        }

        public TextBox()
        {
            CurrentState = StateType.None;
        }

        protected override void LoadContent(ContentManager content)
        {
            caret = new Texture2D(GraphicsDevice, 1, 1);
            Color[] data =
            {
                new Color(255, 255, 255, 255)
            };
            caret.SetData(data);

            caretRectangle = new Rectangle(X + 1, Y + 4, 2, Height - 8);

            IViewState state = new TextBoxNone(this);
            ViewStates.Add(StateType.None, state);

            for (var i = 0; i < ViewStates.Count; i++)
                ViewStates.ElementAt(i).Value.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            if (IsFocused)
            {
                currentKeyboardState = Keyboard.GetState();

                for (var index = 0; index < keysToCheck.Length; index++)
                {   
                    Keys key = keysToCheck[index];
                    if (!CheckKey(key)) continue;
                    AddKeyToText(key);
                    break;
                }   

                lastKeyboardState = currentKeyboardState;
            }
        }

        private bool CheckKey(Keys key)
        {
            return lastKeyboardState.IsKeyDown(key) && currentKeyboardState.IsKeyUp(key);
        }

        private void AddKeyToText(Keys key)
        {
            var newChar = "";

            if (Text.Length >= 20 && key != Keys.Back)
                return;

            switch (key)
            {
                case Keys.A:
                    newChar += "a";
                    break;
                case Keys.B:
                    newChar += "b";
                    break;
                case Keys.C:
                    newChar += "c";
                    break;
                case Keys.D:
                    newChar += "d";
                    break;
                case Keys.E:
                    newChar += "e";
                    break;
                case Keys.F:
                    newChar += "f";
                    break;
                case Keys.G:
                    newChar += "g";
                    break;
                case Keys.H:
                    newChar += "h";
                    break;
                case Keys.I:
                    newChar += "i";
                    break;
                case Keys.J:
                    newChar += "j";
                    break;
                case Keys.K:
                    newChar += "k";
                    break;
                case Keys.L:
                    newChar += "l";
                    break;
                case Keys.M:
                    newChar += "m";
                    break;
                case Keys.N:
                    newChar += "n";
                    break;
                case Keys.O:
                    newChar += "o";
                    break;
                case Keys.P:
                    newChar += "p";
                    break;
                case Keys.Q:
                    newChar += "q";
                    break;
                case Keys.R:
                    newChar += "r";
                    break;
                case Keys.S:
                    newChar += "s";
                    break;
                case Keys.T:
                    newChar += "t";
                    break;
                case Keys.U:
                    newChar += "u";
                    break;
                case Keys.V:
                    newChar += "v";
                    break;
                case Keys.W:
                    newChar += "w";
                    break;
                case Keys.X:
                    newChar += "x";
                    break;
                case Keys.Y:
                    newChar += "y";
                    break;
                case Keys.Z:
                    newChar += "z";
                    break;
                case Keys.NumPad0:
                case Keys.D0:
                    newChar += "0";
                    break;
                case Keys.NumPad1:
                case Keys.D1:
                    newChar += "1";
                    break;
                case Keys.NumPad2:
                case Keys.D2:
                    newChar += "2";
                    break;
                case Keys.NumPad3:
                case Keys.D3:
                    newChar += "3";
                    break;
                case Keys.NumPad4:
                case Keys.D4:
                    newChar += "4";
                    break;
                case Keys.NumPad5:
                case Keys.D5:
                    newChar += "5";
                    break;
                case Keys.NumPad6:
                case Keys.D6:
                    newChar += "6";
                    break;
                case Keys.NumPad7:
                case Keys.D7:
                    newChar += "7";
                    break;
                case Keys.NumPad8:
                case Keys.D8:
                    newChar += "8";
                    break;
                case Keys.NumPad9:
                case Keys.D9:
                    newChar += "9";
                    break;
                case Keys.Space:
                    newChar += " ";
                    break;
                case Keys.Back:
                    if (Text.Length != 0)
                        Text = Text.Remove(Text.Length - 1);
                    return;
                case Keys.Enter:
                    EnterPressed.SafeInvoke(this, new TextEventArgs(Text));
                    return;
            }
            if (currentKeyboardState.IsKeyDown(Keys.RightShift) ||
                currentKeyboardState.IsKeyDown(Keys.LeftShift) ||
                System.Windows.Forms.Control.IsKeyLocked(System.Windows.Forms.Keys.CapsLock))
            {
                newChar = newChar.ToUpper();
            }
            Text += newChar;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            ViewStates[CurrentState].Draw(spriteBatch, gameTime);

            if (IsFocused)
            {
                caretRectangle.X = (int) (X+Width/2 + 1 + Font.MeasureString(Text).X/2);
                spriteBatch.Draw(caret, caretRectangle, Color.Black);
            }

            if (Font != null &&  !string.IsNullOrEmpty(Text))
                spriteBatch.DrawString(Font, Text, Rectangle, FontAlignment.Alignment.Center, Color.Black);
        }
    }
}