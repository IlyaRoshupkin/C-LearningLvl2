using System;
using System.Windows.Forms;
using System.Drawing;
using MyGame;
//4. Сделать проверку на задание размера экрана в классе Game.Если высота или ширина
//(Width, Height) больше 1000 или принимает отрицательное значение, выбросить исключение
//ArgumentOutOfRangeException() .
//    Рощупкин

namespace MyGame
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        static Timer timer = new Timer { Interval = 100 };

        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        private static Bullet _bullet;
        private static Asteroid[] _asteroids;
        private static Random rnd = new Random();

        static Game()
        {
        }
        public static BaseObject[] _objs;

        public static void Load()
        {
            _objs = new BaseObject[30];
            _bullet = new Bullet(new Point(1, 200), new Point(5, 1), new Size(4, 1));
            _asteroids = new Asteroid[3];
            for (var i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 20);
                _objs[i] = new Star(new Point(400, rnd.Next(1, Game.Height)), new
                Point(-r, r), new Size(3, 3));
            }
            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(400, rnd.Next(1, Game.Height)),
                new Point(-r / 5, r), new Size(r, r));
            }
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
            if (form.ClientSize.Width > 1000 || form.ClientSize.Width < 0)
                throw new ArgumentOutOfRangeException("Ширина не может быть большее 1000 или меньше 0.");
            Width = form.ClientSize.Width;
            if (form.ClientSize.Height > 1000 || form.ClientSize.Height < 0)
                throw new ArgumentOutOfRangeException("Высота не может быть большее 1000 или меньше 0.");
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в
            //буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            
                timer.Start();
                timer.Tick += Timer_Tick;
            Load();
        }

        public static void Draw()
        {
            try
            {
                if (Buffer.Graphics == null)
                    Buffer.Dispose();
                Buffer.Graphics.Clear(Color.Black);
                foreach (BaseObject obj in _objs)
                    obj.Draw();
                foreach (Asteroid obj in _asteroids)
                    obj.Draw();
                _bullet.Draw();
                Buffer.Render();
            }

            catch
            {
                timer.Stop();
            }
        }
        public static void Update()
        {
            try
            {
                foreach (BaseObject obj in _objs)
                    obj.Update();
                for(int i = 0; i < _asteroids.Length; i++)
                {
                    _asteroids[i].Update();
                    if (_asteroids[i].Collision(_bullet)) 
                    { 
                        System.Media.SystemSounds.Hand.Play();
                        _bullet = new Bullet(new Point(1, 200), new Point(5, 1), new Size(4, 1));
                        int r = rnd.Next(5, 50);
                        _asteroids[i] = new Asteroid(new Point(400, rnd.Next(1, Game.Height)),
                new Point(-r / 5, r), new Size(r, r));
                    }
                }
                _bullet.Update();
            }
            catch
            {
                timer.Stop();
            }
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}