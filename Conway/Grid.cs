using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conway
{
    class Grid
    {
        public List<Row> Rows;

        public Grid()
        {
            Rows = new List<Row>();
        }

        public void AddRowTop()
        {
            Rows.Insert(0, new Row());
        }

        public void AddRowBottom()
        {
            Rows.Add(new Row());
        }

        
    }
}
