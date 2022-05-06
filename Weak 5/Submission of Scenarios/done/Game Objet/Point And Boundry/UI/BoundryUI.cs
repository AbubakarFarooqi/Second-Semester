using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point_And_Boundry.DL;
using Point_And_Boundry.BL;
namespace Point_And_Boundry.UI
{
    class BoundryUI
    {
        public static Boundry TakeInputOfBoundry()
        {
            int x, y;
            Point TL;
            Point TR;
            Point BL;
            Point BR;
            Console.WriteLine("ENter X-cordinate of Top Left Point = ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("ENter Y-cordinate of Top Left Point = ");
            y = int.Parse(Console.ReadLine());
            TL = new Point(x, y);
            Console.WriteLine("ENter X-cordinate of Top Right Point = ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("ENter Y-cordinate of Top Right Point = ");
            y = int.Parse(Console.ReadLine());
            TR = new Point(x, y);
            Console.WriteLine("ENter X-cordinate of Bottom Left Point = ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("ENter Y-cordinate of Bottom Left Point = ");
            y = int.Parse(Console.ReadLine());
            BL = new Point(x, y);
            Console.WriteLine("ENter X-cordinate of Bottom Right Point = ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("ENter Y-cordinate of Bottom Right Point = ");
            y = int.Parse(Console.ReadLine());
            BR = new Point(x, y);
            Boundry temp = new Boundry(TL, TR, BL, BR);
            return temp;
        }
    }
}
