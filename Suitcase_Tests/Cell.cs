using System;
using System.Collections.Generic;
using System.Text;

namespace Suitcase
{
    public abstract class Cell
    {
        //  protected string type;
        public string NameOfCell;
        public List<AnimalHandler> Animals = new List<AnimalHandler>();

           public Cell(string name)
          {
              this.NameOfCell = name;
          }

        public virtual void Add(Cell cell) { }

        public virtual void Remove(Cell cell) { }
    }
}
