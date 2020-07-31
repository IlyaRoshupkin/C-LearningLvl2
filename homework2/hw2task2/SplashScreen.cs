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
        public SplashScreen()
        {
            InitializeComponent();           
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new Form
                {
                    Width = 500,
                    Height = 500
                };
                Game.Init(form);
                form.ShowDialog();
                Game.Load();
                Game.Draw();
                Application.Run(form);
            }
            catch { return; }
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
