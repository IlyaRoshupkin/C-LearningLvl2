using System;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        

        static Game()
        {
        }
        public static BaseObject[] _objs;
        static readonly int numOfObjs = 30;
        static readonly int numOfBaseObjs = 2;
        static readonly int numOfStars = 20;
        static readonly int numOfPlates = 2;
        static readonly int numOfRockets = 2;

        static Random rnd = new Random();

        public static void Load()
        {
            _objs = new BaseObject[numOfObjs];
            for (int i = 0; i < numOfBaseObjs; i++)
                _objs[i] = new BaseObject(new Point(rnd.Next(Game.Width),
                    rnd.Next(Game.Height)),
                    new Point(i+1,-2*i+1), new Size(30, 30));
            for (int i =numOfBaseObjs ; i < numOfStars+numOfBaseObjs; i++)
                _objs[i] = new Star(new Point(rnd.Next(Game.Width),
                    rnd.Next(Game.Height)), new Point(-i, 0),
                    new Size(5,5));
            for (int i = numOfStars + numOfBaseObjs; 
                i < numOfStars + numOfBaseObjs+numOfPlates; i++)
                _objs[i] = new Plate(new Point(rnd.Next(Game.Width), 
                    rnd.Next(Game.Height)), new Point(rnd.Next(1,5), 
                    rnd.Next(1,5)), new Size(20,10));
            for (int i = numOfStars + numOfBaseObjs + numOfPlates; i < _objs.Length - numOfRockets; i++)
                _objs[i] = new Satellite(new Point(rnd.Next(Game.Width), rnd.Next(Game.Height)), 
                    new Point(-rnd.Next(1,3), 0), new Size(20,10));
            for (int i = _objs.Length - numOfRockets; i < _objs.Length; i++)
                _objs[i] = new Rocket(new Point(rnd.Next(Game.Width), rnd.Next(Game.Height)),
                    new Point(0, -rnd.Next(1,15)), new Size(5, 40));
        }
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для
            //текущего приложения
        _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в
            //буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Timer timer = new Timer { Interval = 100 };


            if (form.Enabled)
            {
                timer.Start();
                timer.Tick += Timer_Tick;
            }
            else
            {
                timer.Stop();
                return;
            }
                
            Load();
        }
        public static void Draw()
        {
                // Проверяем вывод графики
                Buffer.Graphics.Clear(Color.Black);
                //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200,
                //200));
                //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200,
                //200));
                //Buffer.Render();
                Buffer.Graphics.Clear(Color.Black);
                foreach (BaseObject obj in _objs)
                    obj.Draw();
                Buffer.Render();
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}