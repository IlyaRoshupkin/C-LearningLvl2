using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class HealphPack : BaseObject
    {
        public HealphPack(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Brush brush = new SolidBrush(Color.OrangeRed);
            Game.Buffer.Graphics.FillRectangle(brush, Pos.X, Pos.Y, Size.Width+1,
            Size.Height+1);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width/2, Pos.Y, Pos.X + Size.Width/2,
            Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y+Size.Height/2, Pos.X+Size.Width,
            Pos.Y + Size.Height/2);
        }
        public override void Update()
        {
            Pos.X += Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
