using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Asteroid : BaseObject
    {
        public int Power { get; set; }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y,
            Size.Width, Size.Height);
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
