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
        Form form;   
        public SplashScreen()
        {
            InitializeComponent();           
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);
            form.ShowDialog();
            Game.Draw();
            Application.Run(form);
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
