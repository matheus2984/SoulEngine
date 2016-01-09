using System;

namespace Soul.Engine.UI
{
    public class LoadEventArgs : EventArgs
    {
        public new static LoadEventArgs Empty
        {
            get { return new LoadEventArgs(); }
        }
    }

    public class MouseEventArgs : EventArgs
    {
        public int X { get; set; }
        public int Y { get; set; }

        public new static MouseEventArgs Empty
        {
            get { return new MouseEventArgs(0, 0); }
        }

        public MouseEventArgs(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class TextEventArgs : EventArgs
    {
        public string Text { get; set; }

        public new static TextEventArgs Empty { get { return new TextEventArgs("");} }

        public TextEventArgs(string text)
        {
            Text = text;
        }
    }
}