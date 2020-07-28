using System;
using System.Windows.Forms;
// Создаем шаблон приложения, где подключаем модули
//1. Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон,
//похожий на полет в звездном пространстве.
//2. * Заменить кружочки картинками, используя метод DrawImage.
//    Рощупкин
namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            SplashScreen ss = new SplashScreen();
            ss.ShowDialog();
        }
    }
}
