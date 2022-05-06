using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Packman.BL;

namespace Packman.DL
{
    class GhostCRUD
    {
        public static List<Ghost> enemies = new List<Ghost>();
        public static void addEnemyinList(Ghost Source)
        {
            enemies.Add(Source);
        }
    }
}
