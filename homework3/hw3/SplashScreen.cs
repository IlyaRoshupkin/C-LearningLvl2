using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public partial class SplashScreen : Form
    {
        const int WIDTH = 900;
        const int HEIGHT = 700;
        public SplashScreen()
        {
            InitializeComponent();           
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            try
            {
            Form form = new Form()
            {
                Width = WIDTH,
                Height = HEIGHT
            };
                
                Game.Init(form);
                form.ShowDialog();
                form.MaximizeBox = false;
                
                Game.Draw();
                Application.Run(form);
            }
            catch { Application.ExitThread(); }
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Здесь будут Ваши рекорды", "Рекорды",MessageBoxButtons.OK);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
