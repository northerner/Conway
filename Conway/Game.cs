using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Conway
{
    class Game
    {
        private const int rows = 50;
        private const int columns = 50;
        private const int cellSize = 10;

        private Grid oldGrid;
        //private Grid newGrid;

        public Game()
        {
            oldGrid = createGrid(rows, columns);
        }

        private Grid createGrid(int rows, int columns)
        {
            int rowNumber = 0;
            //int columnNumber = 0;
            Grid grid = new Grid();
            for (int i = 0; i < rows; i++ )
            {
                grid.AddRowBottom();
                
            }
            foreach (Row row in grid.Rows)
            {
                for (int i = 0; i < columns; i++)
                {
                    row.AddCellRight(rowNumber, i);
                }
                rowNumber++;
            }
            return grid;
        }

        public void Draw(Graphics graphics)
        {
            Point startPoint = new Point(5, 5);
            Point currentPoint = startPoint;
            foreach (Row row in oldGrid.Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    Rectangle cellRectangle = new Rectangle
                        (currentPoint.X, currentPoint.Y, cellSize, cellSize);
                    cell.CellRectangle = cellRectangle;
                    if (cell.Alive)
                        graphics.FillRectangle(Brushes.Blue, cellRectangle);
                    else if (!cell.Alive)
                        graphics.FillRectangle(Brushes.White, cellRectangle);

                    currentPoint = new Point((currentPoint.X + cellSize + 1), currentPoint.Y);
                }
                currentPoint = new Point(startPoint.X, (currentPoint.Y + cellSize + 1));
            }
        }

        private void setCellAlive(int row, int column)
        {
            Row findRow = oldGrid.Rows[row];
            Cell findCell = findRow.Cells[column];
            if (findCell.Alive)
                findCell.Alive = false;
            else
                findCell.Alive = true;
        }

        public void nextGeneration()
        {
            foreach (Row row in oldGrid.Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    int aliveCount = getSurroundingAliveCount(cell);
                    // The four rules of the Game of Life
                    if (aliveCount < 2 && cell.Alive)
                        cell.nextAlive = false;
                    else if (aliveCount > 3 && cell.Alive)
                        cell.nextAlive = false;
                    else if (aliveCount == 3 && cell.Alive == false)
                        cell.nextAlive = true;
                    else
                        cell.nextAlive = cell.Alive;
                }
            }
            foreach (Row row in oldGrid.Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    cell.Alive = cell.nextAlive;                    
                }
            }
        }

        private int getSurroundingAliveCount(Cell cell)
        {
            int aliveCount = 0;
            Row currentRow = oldGrid.Rows[cell.RowNumber];

            if (cell.RowNumber != 0)
            {
                Row aboveRow = oldGrid.Rows[(cell.RowNumber - 1)];
                Cell aboveMiddle = aboveRow.Cells[cell.ColumnNumber];
                if (aboveMiddle.Alive)
                    aliveCount++;
                if (cell.ColumnNumber != 0)
                {
                    Cell aboveLeft = aboveRow.Cells[(cell.ColumnNumber - 1)];
                    if (aboveLeft.Alive)
                        aliveCount++;
                }
                if (cell.ColumnNumber != (aboveRow.Cells.Count - 1))
                {
                    Cell aboveRight = aboveRow.Cells[(cell.ColumnNumber + 1)];
                    if (aboveRight.Alive)
                        aliveCount++;
                }
            }
            if (cell.ColumnNumber != 0)
            {
                Cell left = currentRow.Cells[(cell.ColumnNumber - 1)];
                if (left.Alive)
                    aliveCount++;
            }
            if (cell.ColumnNumber != (currentRow.Cells.Count - 1))
            {
                Cell right = currentRow.Cells[(cell.ColumnNumber + 1)];
                if (right.Alive)
                    aliveCount++;
            }
            if (cell.RowNumber != (oldGrid.Rows.Count - 1))
            {
                Row belowRow = oldGrid.Rows[(cell.RowNumber + 1)];
                Cell belowMiddle = belowRow.Cells[cell.ColumnNumber];
                if (belowMiddle.Alive)
                    aliveCount++;
                if (cell.ColumnNumber != 0)
                {
                    Cell belowLeft = belowRow.Cells[(cell.ColumnNumber - 1)];
                    if (belowLeft.Alive)
                        aliveCount++;
                }
                if (cell.ColumnNumber != (belowRow.Cells.Count - 1))
                {
                    Cell belowRight = belowRow.Cells[(cell.ColumnNumber + 1)];
                    if (belowRight.Alive)
                        aliveCount++;
                }
            }


            return aliveCount;
        }

        public void clickCell(int mouseX, int mouseY)
        {
            foreach (Row row in oldGrid.Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    if (cell.CellRectangle.Contains(mouseX, mouseY))
                    {
                        cell.Alive = true;
                        cell.nextAlive = true;
                    }
                }
            }
        }
    }
}
