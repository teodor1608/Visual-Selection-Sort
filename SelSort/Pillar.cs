using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelSort
{
    class Pillar
    {
        public int value = 0;

        public bool sorted = false;

        public bool focus = false;

        public Point Location;

        public void Paint(Graphics g)//paint
        {
            if(focus)
                using (var brush = new SolidBrush(Color.Red))
                    g.FillRectangle(brush, Location.X, Location.Y - value * 10, 50, value * 10);
            else
                using (var brush = new SolidBrush(sorted == false ? Color.LightBlue : Color.Orange))
                    g.FillRectangle(brush, Location.X, Location.Y - value * 10, 50, value * 10);

            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            g.DrawString(value.ToString(), drawFont, drawBrush, Location.X, Location.Y - value * 10);

        }
    }
}
