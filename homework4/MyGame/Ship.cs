
using System;
using System.Drawing;

//1. Добавить космический корабль, как описано в уроке.
//    Рощупкин
namespace MyGame
{
    class Ship : BaseObject
    {
        public int Energy { get; private set; } = 100;

        public int Points { get; internal set; } = 0;

        public static event Message MessageDie;
        public void Die()
        {
            MessageDie?.Invoke();
            AddMessage("Корабль уничтожен.");
        }
        public void EnergyLow(int n)
        {
            Energy -= n;
            AddMessage($"Энергия снижена на {n}#!");

        }
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y,
            Size.Width, Size.Height);
        }
        public override void Update()
        {
        }
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
            AddMessage("Набрать высоту!");
        }
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
            AddMessage("Снизиться!");
        }

        internal void AddEnergy(int plusEnergy)
        {
            Energy += plusEnergy;
            AddMessage($"Энергия пополнена на {plusEnergy}#!");
        }
    }
}
