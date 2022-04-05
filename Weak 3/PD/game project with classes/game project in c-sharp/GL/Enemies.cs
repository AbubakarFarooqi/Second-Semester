using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_project_in_c_sharp.GL
{

    class enemy
    {

        public int x1;
        public int y1;
        public int x2;
        public int y2;
        public bool flag;

    }
    class enemyFire
    {
        public enemyFire()
        {

        }
        public int x;
        public int y;
        public bool flag = false;
        public void ChangeFlag(bool value)
        {
            flag = value;
        }
    }
    class User
    {
        public User()
        {

        }
        public User(string name, int score)
        {
            Name = name;
            Score = score;
        }
        public void View()
        {
            Console.WriteLine(Name + "\t" + Score);

        }
        public bool isValid(string name)
        {
            if (name == Name)
                return true;
            return false;
        }
        public string Name;
        public int Score;
    }
}
