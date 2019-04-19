using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_18._04
{
    public partial class Form1 : Form
    {
        private int X, Y;
        static int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                X = e.X;
                Y = e.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int size1 = e.X - X, size2 = e.Y - Y;
                if (size1 < 0)
                {
                    size1 = -size1;
                    X = e.X;
                }
                if (size2 < 0)
                {
                    size2 = -size2;
                    Y = e.Y;
                }
                if (size1 < 10 || size2 < 10)
                {
                    MessageBox.Show("Слишком маленький размер!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Label lbl = new Label();
                lbl.Location = new System.Drawing.Point(X, Y);
                lbl.Size = new System.Drawing.Size(size1, size2);
                lbl.BackColor = Color.LightGray;
                lbl.Text = (++count).ToString();
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(lbl);
                lbl.MouseClick += Lbl_MouseClick;
                lbl.MouseDoubleClick += Lbl_MouseDoubleClick;
            }
        }

        private void Lbl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Label lbl = sender as Label;
                this.Controls.Remove(lbl);
            }
        }

        private void Lbl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Label lbl = sender as Label;
                this.Text = $"{lbl.Width * lbl.Height}  {lbl.Location.X};{lbl.Location.Y}";
            }
        }
    }
}
