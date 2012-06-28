using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Conway
{
    class Cell
    {
        public bool Alive;
        public bool nextAlive;
        public int RowNumber;
        public int ColumnNumber;
        public Rectangle CellRectangle;

        public Cell(int row, int column)
        {
            Alive = false;
            RowNumber = row;
            ColumnNumber = column;
        }
    }
}
