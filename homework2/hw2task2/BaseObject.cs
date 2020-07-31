using System;
using System.Drawing;
using System.Windows.Forms;
//2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в
//наследниках.
//    Рощупкин
namespace MyGame
{
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public BaseObject(Point pos, Point dir, Size size)
        {
            
                if (size.Width < 1) throw new GameObjectException("Ширина объекта слишком маленькая.");
                if (size.Height < 1) throw new GameObjectException("Высота объекта слишком маленькая.");
                if (Math.Abs(dir.X) > 30) throw new GameObjectException("Максимальная скорость объекта превышена.");
                if (pos.X < 0 || pos.X > Game.Width) throw new GameObjectException("Неверная позиция объекта.");
                if (pos.Y < 0 || pos.Y > Game.Height) throw new GameObjectException("Неверная позиция объекта.");
                Pos = pos;
                Dir = dir;
                Size = size;            
        }
        public abstract void Draw();
        public abstract void Update();
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);
    }
}
