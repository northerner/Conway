using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conway
{
    class Row
    {
        public List<Cell> Cells;

        public Row()
        {
            Cells = new List<Cell>();
        }

        public void AddCellLeft(int row, int column)
        {
            Cells.Insert(0, new Cell(row, column));
        }

        public void AddCellRight(int row, int column)
        {
            Cells.Add(new Cell(row, column));
        }
    }
}
