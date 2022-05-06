using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.BL
{
    class FlooringCost
    {
        public FlooringCost(string name)
        {
            this.name = name;
            PriceOfInstallationPerSquareMeter = 300;
            PriceOfTilePerSquareMeter = 80;
            PolishRate = 10;

        }
        public FlooringCost(string name, int length)
        {
            this.name = name;
            PriceOfInstallationPerSquareMeter = 400;
            PriceOfTilePerSquareMeter = 90;
            PolishRate = 15;


        }
        public string name;
        public int PriceOfTilePerSquareMeter;
        public int PriceOfInstallationPerSquareMeter;
        public int PolishRate;
        public double totalCost(int polishRate)
        {
            return PriceOfTilePerSquareMeter + PriceOfInstallationPerSquareMeter + polishRate;
        }
        public double FindTotalCost()
        {
            return totalCost(PolishRate);
        }

    }
}
