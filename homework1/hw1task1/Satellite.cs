using MyGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Satellite : BaseObject
    {
        public Satellite(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Brush brush = new SolidBrush(Color.Blue);
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.FillRectangle(brush, Pos.X - Size.Width, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.FillRectangle(brush, Pos.X + Size.Width, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X += Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
