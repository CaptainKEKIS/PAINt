using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAINt
{
    public partial class MainForm : Form
    {
        int _x;
        int _y;
        bool _mouseClicked = false;
        string FileName;

        Color SelectedColor
        {
            get { return Color.Red; }
        }

        int SelectedSize
        {
            get { return tbBrushSize.Value; }
        }
        Brush _selectedBrush;

        Color DefaultColor
        {
            get { return Color.White; }
        }

        void CreateBlank(int Width, int Height)
        {
            var oldImage = pictureBox1.Image;
            var bmp = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    bmp.SetPixel(i, j, DefaultColor);
                }
            }
            pictureBox1.Image = bmp;
            if (oldImage != null)
            {
                oldImage.Dispose();
            }
        }

        public MainForm()
        {
            InitializeComponent();
            CreateBlank(pictureBox1.Width = 1000, pictureBox1.Height = 500);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            _selectedBrush = new QuadBrush(SelectedColor, SelectedSize);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_selectedBrush == null)
            {
                return;
            }
                _selectedBrush.Draw(pictureBox1.Image as Bitmap, _x, _y, pictureBox1.Width, pictureBox1.Height, pictureBox1.CreateGraphics());
                pictureBox1.Refresh();
                _mouseClicked = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseClicked = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            _x = e.X;// > 0 ? e.X : 0;
            _y = e.Y;// > 0 ? e.Y : 0;
            if (_mouseClicked)
            {
                    _selectedBrush.Draw(pictureBox1.Image as Bitmap, _x, _y, pictureBox1.Width, pictureBox1.Height, pictureBox1.CreateGraphics());
                    pictureBox1.Refresh();
            }
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            _selectedBrush = new CircleBrush(SelectedColor, SelectedSize);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
