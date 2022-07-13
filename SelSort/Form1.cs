using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int itr = 0;

        Dictionary<int, Pillar> valuesMap = new Dictionary<int, Pillar>();

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach(var p in valuesMap.Values)
            {
                p.Paint(e.Graphics);
            }
        }

        int sort(Dictionary<int, Pillar> arr, int i)
        {
            int n = arr.Count;

            if(i < n - 1)
            {
                // Find the minimum element in unsorted array
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j].value < arr[min_idx].value)
                    {
                        min_idx = j;
                    }
                }

                int temp = arr[min_idx].value;
                arr[min_idx].value = arr[i].value;
                arr[i].value = temp;
                arr[i].sorted = true;

                min_idx = i+1;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j].value < arr[min_idx].value)
                    {
                        min_idx = j;
                    }
                }

                foreach (var p in valuesMap.Values)
                    p.focus = false;
                arr[min_idx].focus = true;
                Invalidate();

            }
            return i+1;
        }

        public void Generate(int size)
        {
            itr = 0;
            valuesMap.Clear();
            var r = new Random();
            for (int i =0;i<size; i++)
            {
                int k = r.Next(1, 39);
                valuesMap.Add(i, new Pillar()
                {
                    value = k,
                    sorted = false,
                    Location = new Point(52 * i, Height - 100),
                    focus = false
                });
            }

            this.Width = (size * 52)+15;

            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            Generate(int.Parse(textBox1.Text) >= 10 && int.Parse(textBox1.Text) <=35 ? int.Parse(textBox1.Text): 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            itr = sort(valuesMap, itr);

            Invalidate();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
