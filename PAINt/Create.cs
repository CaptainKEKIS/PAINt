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
    public partial class Create : Form
    {
        public Create()
        {
            InitializeComponent();
        }

        public int Wdth
        {
            get
            {
                string text2 = textBox3.Text;
                int value2 = Convert.ToInt32(text2);
                return value2;
            }
        }

        public int Hght
        {
            get
            {
                string text3 = textBox2.Text;
                int value3 = Convert.ToInt32(text3);
                return value3;
            }
        }

        public string FileName
        {
            get
            {
                string text1 = textBox1.Text;
                return text1;
            }
        }

        bool _canceled = false;
        public bool Canceled
        {
            get { return _canceled; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _canceled = true;
            Close();
        }
    }
}