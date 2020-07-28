using System;
using System.Drawing;
namespace MyGame
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public virtual void Draw()
        {
            Image newImage = Image.FromFile("moon.jpeg");
            Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public virtual void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            Dir.X = (Pos.X < 0 || Pos.X >= Game.Width) ?  -Dir.X : Dir.X;
            Dir.Y = (Pos.Y < 0 || Pos.Y >= Game.Height) ? -Dir.Y : Dir.Y;
        }
    }
}
