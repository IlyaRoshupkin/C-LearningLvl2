using MyGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class ObjectImage : BaseObject
    {
        Image newImage = Image.FromFile("moon.jpeg");
        public ObjectImage(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            Dir.X = (Pos.X < 0 || Pos.X >= Game.Width) ? -Dir.X : Dir.X;
            Dir.Y = (Pos.Y < 0 || Pos.Y >= Game.Height) ? -Dir.Y : Dir.Y;
        }
    }
}
