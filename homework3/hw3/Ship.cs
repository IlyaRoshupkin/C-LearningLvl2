
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
        Messages.AddMessage myDelegat;
       
        public void Die()
        {
            MessageDie?.Invoke();
        }
        public void EnergyLow(int n)
        {
            Energy -= n;
            myDelegat += Messages.ConsoleMessage;
            myDelegat += Messages.JournalMessage;
            myDelegat("Корабль уничтожен");
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
            myDelegat += Messages.ConsoleMessage;
            myDelegat += Messages.JournalMessage;
            myDelegat("Набрать высоту!");
        }
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
            myDelegat += Messages.ConsoleMessage;
            myDelegat += Messages.JournalMessage;
            myDelegat("Снизить высоту!");
        }

        internal void AddEnergy(int plusEnergy)
        {
            Energy += plusEnergy;
            myDelegat += Messages.ConsoleMessage;
            myDelegat += Messages.JournalMessage;
            myDelegat($"Энергия пополнена на {plusEnergy}#!");
        }
    }
}
