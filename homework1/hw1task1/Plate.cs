using MyGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Plate: BaseObject 
    {
        public Plate(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawEllipse(Pens.DarkGray, Pos.X+Size.Width/3, Pos.Y+Size.Height/3, Size.Width/3, Size.Height/3);
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
