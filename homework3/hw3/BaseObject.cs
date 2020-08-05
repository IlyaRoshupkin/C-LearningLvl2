using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MyGame
{
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public delegate void Message();
        public BaseObject(Point pos, Point dir, Size size)
        {
            
                if (size.Width < 1) throw new GameObjectException("Ширина объекта слишком маленькая.");
                if (size.Height < 1) throw new GameObjectException("Высота объекта слишком маленькая.");
                if (Math.Abs(dir.X) > 30) throw new GameObjectException("Максимальная скорость объекта превышена.");
                if (pos.X < 0 || pos.X > Game.Width) throw new GameObjectException("Неверная позиция объекта по абциссе.");
                if (pos.Y < 0 || pos.Y > Game.Height) throw new GameObjectException("Неверная позиция объекта по ординате.");
                Pos = pos;
                Dir = dir;
                Size = size;            
        }
        
        public abstract void Draw();
        public abstract void Update();
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);
    }
}
