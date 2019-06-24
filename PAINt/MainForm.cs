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
            get { return colorDialog1.Color; }
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
            pictureBox1.Width = Width;
            pictureBox1.Height = Height;
            if (oldImage != null)
            {
                oldImage.Dispose();
            }
        }

        public MainForm()
        {
            InitializeComponent();
            CreateBlank(pictureBox1.Width, pictureBox1.Height);
            colorDialogButt.BackColor = SelectedColor;
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
            _selectedBrush.Draw(pictureBox1.Image as Bitmap, _x, _y, pictureBox1.Width, pictureBox1.Height);
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
                _selectedBrush.Draw(pictureBox1.Image as Bitmap, _x, _y, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Refresh();
            }
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            _selectedBrush = new SuperStar(SelectedColor, SelectedSize);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Create form = new Create();
            form.ShowDialog();
            if (form.Canceled == false)
            {
                CreateBlank(form.Wdth, form.Hght);
                FileName = form.FileName;
            }
        }

        private void colorDialogButt_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorDialogButt.BackColor = colorDialog1.Color;
                if (_selectedBrush != null)
                {
                    _selectedBrush.BrushColor = colorDialog1.Color;
                }
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            colorDialogButt.BackColor = (sender as Button).BackColor;
            colorDialog1.Color = (sender as Button).BackColor;
            if (_selectedBrush != null)
            {
                _selectedBrush.BrushColor = (sender as Button).BackColor;
            }
        }

        private void tbBrushSize_ValueChanged(object sender, EventArgs e)
        {
            if (_selectedBrush != null)
            {
                _selectedBrush.Size = SelectedSize;
            }
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            _selectedBrush = new RectBrush(SelectedColor, SelectedSize);
        }

        private void buttonWhat_Click(object sender, EventArgs e)
        {
            _selectedBrush = new Eraser(DefaultColor, SelectedSize);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog.FileName);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(openFileDialog.FileName);
                //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                this.pictureBox1.Size = image.Size;
                pictureBox1.Image = image;
                pictureBox1.Invalidate();
            }
        }
    }
}