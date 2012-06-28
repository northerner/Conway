using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Conway
{
    public partial class Form1 : Form
    {
        Game game;
        int generation;

        public Form1()
        {
            InitializeComponent();
            game = new Game();
            generation = 0;
            //drawTimer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics);
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            game.nextGeneration();
            generation++;
            generationLabel.Text = generation.ToString();
            Invalidate();
        }

        private void pause_Click(object sender, EventArgs e)
        {
            if (drawTimer.Enabled)
                drawTimer.Stop();
            else
                drawTimer.Start();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            game.clickCell(MousePosition.X, MousePosition.Y);
            Invalidate();
        }

    }
}
