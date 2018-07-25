using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screenshoter
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DoubleBuffered = true;
        }


        Point start, end;
        bool drawing = false;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)//нажал
        {
            start = new Point(e.X, e.Y);
            drawing = true;
        }



        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)//тяну
        {
            if (!drawing) return;


            pictureBox1.Refresh();
            var finish = new Point(e.X, e.Y);
            var pen = new Pen(Color.Red, 5f);
            var g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawRectangle(pen, start.X, start.Y, finish.X - start.X, finish.Y - start.Y);

        }



        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)//отпустил
        {
            end = new Point(e.X, e.Y);
            drawing = false;

            this.Opacity = 0;

            Rectangle rect = new Rectangle(start.X, start.Y, end.X-start.X, end.Y - start.Y);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            bmp.Save("picture.jpg");


            OpenPicture();
            Application.Exit();
        }


        private void OpenPicture()
        {
            string commandText = "picture.jpg";
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = commandText;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }

    }
}
