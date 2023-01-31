using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class WishWindow : Form
    {
        string y;
        Color h;

        public WishWindow()
        {
            InitializeComponent();

            for (var i = 1; i < 15; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    Label label = new Label();

                    label.Size = new Size(40, 35);
                    label.BackColor = Color.PowderBlue;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Click += Label_Click;

                    tableLayoutPanel1.Controls.Add(label, i, j);
                }
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (y != null)
            {
                var label = sender as Label;
                label.Text = y;
                label.BackColor = h;
            }
        }

        private void Choice_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            y = button.Text;
            h = button.BackColor;
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
