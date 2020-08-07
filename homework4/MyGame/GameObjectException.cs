using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//5. * Создать собственное исключение GameObjectException, которое появляется при попытке
//создать объект с неправильными характеристиками(например, отрицательные размеры,
//слишком большая скорость или неверная позиция).
//    Рощупкин
namespace MyGame
{
    class GameObjectException : Exception
    {
        public GameObjectException(string message) : base(message)
        {
        }
    }
}
