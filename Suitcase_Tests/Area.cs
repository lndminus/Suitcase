using System;
using System.Collections.Generic;
using System.Text;

namespace Suitcase
{
    public class Area : Cell
    {
        public string TypeOfTerritory;
        public List<Cell> cells = new List<Cell>();

        public Area(string name, string type)
            :base(name)
        {
            this.TypeOfTerritory = type;
        }

        public override void Add(Cell cell)
        {
            cells.Add(cell);
        }

        public override void Remove(Cell cell)
        {
            cells.Remove(cell);
        }
    }
}
