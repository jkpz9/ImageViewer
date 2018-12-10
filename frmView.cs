using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer
{
    public partial class frmView : Form
    {
        public double Ratio { get; set; }
        public frmView()
        {
            InitializeComponent();
            panel1.AutoScroll = true;
            this.Resize += resizeForm;
        }

        private void resizeForm(object sender, System.EventArgs e)
        {
            Console.WriteLine("CURRENT[{0},{1}]", Width, Height);
        }
      
        public Image ImageBox
        {
            set
            {
                Console.WriteLine("*****************IMAGE INFO**********************");
                Console.WriteLine(String.Format("[{0}, {1}]", value.Width, value.Height));
                Console.WriteLine("*****************FORM SIZE BEFORE**********************");
                Console.WriteLine(String.Format("[{0}, {1}]", Width, Height));
                this.pictureBox1.Image = value;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                Ratio = value.Width / (double)value.Height;
                if (Ratio > 0)
                {
                    this.Width = Height;
                    int newHeight = (int)(this.Width / Ratio);
                    this.Height = newHeight;

                }
                else
                {

                    this.Height = Width;
                    int newWidth = (int)(this.Width / Ratio);
                    this.Width = newWidth;
                    
                }
                Console.WriteLine("*****************FORM SIZE AFTER**********************");
                Console.WriteLine(String.Format("[{0}, {1}]", Width, Height));
                
            }
         }

        private void frmView_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void frmView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pictureBox1.Image != null)
                pictureBox1.Dispose();
        }

    }
}
