using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Rocket : BaseObject
    {
        public Rocket(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Brush brushMain = new SolidBrush(Color.WhiteSmoke);
            Game.Buffer.Graphics.FillRectangle(brushMain, Pos.X, Pos.Y, Size.Width, Size.Height);

            Brush brushSecond = new SolidBrush(Color.LightSkyBlue);
            Game.Buffer.Graphics.FillRectangle(brushSecond, Pos.X - Size.Width, Pos.Y + Size.Height/2, Size.Width, Size.Height/2);
            Game.Buffer.Graphics.FillRectangle(brushSecond, Pos.X + Size.Width, Pos.Y + Size.Height / 2, Size.Width, Size.Height / 2);
            Game.Buffer.Graphics.FillEllipse(brushSecond, Pos.X, Pos.Y - Size.Height / 2 + 1, Size.Width, Size.Height / 2);
        }
        public override void Update()
        {
            Pos.Y += Dir.Y;
            if (Pos.Y < 0) Pos.Y = Game.Height + Size.Height;
        }
    }
}