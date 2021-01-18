using System;
using System.Collections.Generic;
using System.Text;

namespace Suitcase
{
    public class Aviary : Cell
    {
        public string TypeOfTerritory;
        public int Area;
        public Aviary(string name, string type, int area)
            :base(name)
        {
            this.Area = area;
            this.TypeOfTerritory = type;
        }
    }

    public class WaterZone : Cell
    {
        public string TypeOfWater;
        public int Volume;
        public WaterZone(string name, string type, int volume)
            : base(name)
        {
            this.TypeOfWater = type;
            this.Volume = volume;
        }
    }
}
