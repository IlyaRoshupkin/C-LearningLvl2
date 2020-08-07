using System;
using System.Windows.Forms;
using System.Drawing;
using MyGame;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace MyGame
{
    static class Game
    {
        private static int asteroidsAmount=3;
        private static int destroyedAsters = 0;
        public static StreamWriter streamWriter = new StreamWriter("Messages.txt");

        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static Timer _timer = new Timer();
        public static Random Rnd = new Random();
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static List<string> messagesJournal = new List<string>();
        // Ширина и высота игрового поля
        
        private static List<Asteroid> _asteroids = new List<Asteroid>();
        private static Ship _ship;
        private static HealphPack _hPack;
        private static List<Bullet> _bullets = new List<Bullet>(); 

        static Game()
        {
        }
        public static BaseObject[] _objs;

        public static void Load()
        {
            _objs = new BaseObject[30];
            _hPack = new HealphPack(new Point(200, 250), new Point(-3, 1), new Size(10, 10));
            for (var i = 0; i < _objs.Length; i++)
            {
                int r = Rnd.Next(5, 20);
                _objs[i] = new Star(new Point(400, Rnd.Next(1, Game.Height)), new
                Point(-r, r), new Size(3, 3));
            }
            for (var i = 0; i < asteroidsAmount; i++)
            {
                int r = Rnd.Next(5, 50);
                _asteroids.Add(new Asteroid(new Point(400, Rnd.Next(1, Game.Height)),
                new Point(-r / 5, r), new Size(r, r)));
                 _ship= new Ship(new Point(10, 200), new Point(5, 5), new
Size(10, 10));
            }
        }
        public static void Init(Form form)
        {
            Graphics g;
        _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.Width;
            if (form.ClientSize.Width > 1000 || form.ClientSize.Width < 0)
                throw new ArgumentOutOfRangeException("Ширина не может быть большее 1000 или меньше 0.");
            Height = form.Height;
            if (form.ClientSize.Height > 1000 || form.ClientSize.Height < 0)
                throw new ArgumentOutOfRangeException("Высота не может быть большее 1000 или меньше 0.");
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            _timer.Start();
            _timer.Tick += Timer_Tick;
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
            Load();
        }
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullets.Add(new Bullet(new Point(_ship.Rect.X
                + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1)));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
                foreach (BaseObject obj in _objs)
                    obj.Draw();
                foreach (Asteroid a in _asteroids)
                {
                    a?.Draw();
                }
                foreach (Bullet b in _bullets) b.Draw();
                _ship?.Draw();
                _hPack.Draw();
                if (_ship != null)
                {
                    Buffer.Graphics.DrawString("Energy:" + _ship.Energy,
                    SystemFonts.DefaultFont, Brushes.White, 0, 0);
                    Buffer.Graphics.DrawString("Points:" + _ship.Points,
                        SystemFonts.DefaultFont, Brushes.White, 70, 0);
                }
                Buffer.Render();
           
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs) obj.Update();
            foreach (Bullet b in _bullets) b.Update();
            
            for (var i = 0; i < _asteroids.Count; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                for (int j = 0; j < _bullets.Count; j++)
                    if (_asteroids[i] != null && _bullets[j].Collision(_asteroids[i]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        _asteroids[i] = null;
                        destroyedAsters++;
                        _bullets.RemoveAt(j);
                        j--;
                    }
                if (_asteroids[i] == null || !_ship.Collision(_asteroids[i])) continue;
                _ship.EnergyLow(Rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship.Die();
            }
            if (destroyedAsters == _asteroids.Count)
            {
                Asteroid.AddMessage("Новые астероиды!");
                Asteroid.AddAsteropids(ref _asteroids, ref asteroidsAmount, ref destroyedAsters);
                
            }

        }
        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif,
            60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
            foreach (string line in messagesJournal)
                streamWriter.WriteLine(line);
            streamWriter.Close();
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}