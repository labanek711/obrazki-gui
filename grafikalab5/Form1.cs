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


namespace grafikalab5
{
    public partial class Form1 : Form
    {
        Image picture1;
        Image picture2;
        Bitmap bitmappicture1;
        Bitmap bitmappicture2;
        private int picture1Width, picture1Height, picture2Width, picture2Height;


        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            picture1 = pictureBox1.Image;
            picture2 = pictureBox2.Image;

            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            picture2 = resizeImage(picture2, new Size(pictureBox2.Size.Width, pictureBox2.Size.Height));
            picture1 = resizeImage(picture1, new Size(pictureBox1.Size.Width, pictureBox1.Size.Height));

            bitmappicture1 = new Bitmap(picture1);
            bitmappicture2 = new Bitmap(picture2);

            picture1Width = bitmappicture1.Width;
            picture1Height = bitmappicture1.Height;
            picture2Width = bitmappicture2.Width;
            picture2Height = bitmappicture2.Height;
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
            {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }
        public int rgbRange(int value)
        {
            if (value >= 255) return 255;
            if (value <= 0) return 1;
            else return value;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < picture1Height; y++)
            {
                for (int x = 0; x < picture1Width; x++)
                {
                    Color picture1 = bitmappicture1.GetPixel(x, y);
                    Color picture2 = bitmappicture2.GetPixel(x, y);
                    int a = rgbRange(picture1.A + picture2.A);
                    int r = rgbRange(picture1.R + picture2.R);
                    int g = rgbRange(picture1.G + picture2.G);
                    int b = rgbRange(picture1.B + picture2.B);


                    bitmappicture1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox3.Image = bitmappicture1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < picture1Height; y++)
            {
                for (int x = 0; x < picture1Width; x++)
                {
                    Color picture1 = bitmappicture1.GetPixel(x, y);
                    Color picture2 = bitmappicture2.GetPixel(x, y);
                    int a = rgbRange(picture1.A + picture2.A - 255);
                    int r = rgbRange(picture1.R + picture2.R - 255);
                    int g = rgbRange(picture1.G + picture2.G - 255);
                    int b = rgbRange(picture1.B + picture2.B - 255);

                    bitmappicture1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox3.Image = bitmappicture1;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < picture1Height; y++)
            {
                for (int x = 0; x < picture1Width; x++)
                {
                    Color picture1 = bitmappicture1.GetPixel(x, y);
                    Color picture2 = bitmappicture2.GetPixel(x, y);
                    int a = picture1.A;
                    int r = rgbRange(Math.Abs(picture1.R - picture2.R));
                    int g = rgbRange(Math.Abs(picture1.G - picture2.G));
                    int b = rgbRange(Math.Abs(picture1.B - picture2.B));

                    bitmappicture1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox3.Image = bitmappicture1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < picture1Height; y++)
            {
                for (int x = 0; x < picture1Width; x++)
                {
                    Color picture1 = bitmappicture1.GetPixel(x, y);
                    Color picture2 = bitmappicture2.GetPixel(x, y);
                    int a = picture1.A;
                    int r = rgbRange(picture1.R * picture2.R);
                    int g = rgbRange(picture1.G * picture2.G);
                    int b = rgbRange(picture1.B * picture2.B);

                    bitmappicture1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox3.Image = bitmappicture1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < picture1Height; y++)
            {
                for (int x = 0; x < picture1Width; x++)
                {
                    Color picture1 = bitmappicture1.GetPixel(x, y);
                    Color picture2 = bitmappicture2.GetPixel(x, y);

                    double a = rgbRange(255 - rgbRange((255 - picture1.A)) * rgbRange(255 - picture2.B));
                    double r = rgbRange(255 - rgbRange((255 - picture1.R)) * rgbRange(255 - picture2.R));
                    double g = rgbRange(255 - rgbRange((255 - picture1.G)) * rgbRange(255 - picture2.G));
                    double b = rgbRange(255 - rgbRange((255 - picture1.B)) * rgbRange(255 - picture2.B));
                    bitmappicture1.SetPixel(x, y, Color.FromArgb((int)a, (int)r, (int)g, (int)b));

                }
            }
            pictureBox3.Image = bitmappicture1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < picture1Height; y++)
            {
                for (int x = 0; x < picture1Width; x++)
                {
                    Color picture1 = bitmappicture1.GetPixel(x, y);
                    Color picture2 = bitmappicture2.GetPixel(x, y);
                    int a = picture1.A;
                    int r = rgbRange(a - rgbRange(Math.Abs(a - picture1.R - picture2.R)));
                    int g = rgbRange(a - rgbRange(Math.Abs(a - picture1.G - picture2.G)));
                    int b = rgbRange(a - rgbRange(Math.Abs(a - picture1.B - picture2.B)));

                    bitmappicture1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox3.Image = bitmappicture1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < picture1Height; y++)
            {
                for (int x = 0; x < picture1Width; x++)
                {
                    Color picture1 = bitmappicture1.GetPixel(x, y);
                    Color picture2 = bitmappicture2.GetPixel(x, y);
                    int a = picture1.A , r, g, b;

                    if (picture1.R < picture2.R)
                        r = picture2.R;
                    else
                        r = picture2.R;

                    if (picture1.G < picture2.G)
                        g = picture1.G;
                    else
                        g = picture2.G;

                    if (picture1.B < picture2.B)
                        b = picture1.B;
                    else
                        b = picture2.B;

                    bitmappicture1.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            pictureBox3.Image = bitmappicture1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < picture1Height; y++)
            {
                for (int x = 0; x < picture1Width; x++)
                {
                    Color picture1 = bitmappicture1.GetPixel(x, y);
                    Color picture2 = bitmappicture2.GetPixel(x, y);
                    int a, r, g, b;
                    if (picture1.A > picture2.A)
                        a = picture1.A;
                    else
                        a = picture2.A;

                    if (picture1.R > picture2.R)
                        r = picture2.R;
                    else
                        r = picture2.R;

                    if (picture1.G > picture2.G)
                        g = picture1.G;
                    else
                        g = picture2.G;

                    if (picture1.B > picture2.B)
                        b = picture1.B;
                    else
                        b = picture2.B;


                    bitmappicture1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox3.Image = bitmappicture1;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < picture1Height; y++)
            {
                for (int x = 0; x < picture1Width; x++)
                {
                    Color picture1 = bitmappicture1.GetPixel(x, y);
                    Color picture2 = bitmappicture2.GetPixel(x, y);
                    int a = 255;
                    int r = rgbRange(picture1.R + picture2.R - rgbRange(2 * a * ( picture1.R * picture2.R)));
                    int g = rgbRange(picture1.G + picture2.G - rgbRange(2 * a * ( picture1.G * picture2.G)));
                    int b = rgbRange(picture1.B + picture2.B - rgbRange(2 * a * ( picture1.B * picture2.B)));

                    bitmappicture1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
                pictureBox3.Image = bitmappicture1;
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < picture1Height; y++)
            {
                for (int x = 0; x < picture1Width; x++)
                {
                    Color picture1 = bitmappicture1.GetPixel(x, y);
                    Color picture2 = bitmappicture2.GetPixel(x, y);
                    int a = picture1.A , r, g, b;

                    if (picture1.R < a * 0.5)
                        r = rgbRange(2 * picture1.R * picture2.R);
                    else
                        r = rgbRange(1 - 2 * (1 - picture1.R) * (1 - picture2.R));

                    if (picture1.G < a * 0.5)
                        g = rgbRange(2 * picture1.G * picture2.G);
                    else
                        g = rgbRange(1 - 2 * (1 - picture1.G) * (1 - picture2.G));

                    if (picture1.B < a * 0.5)
                        b = rgbRange(2 * picture1.B * picture2.B);
                    else
                        b = rgbRange(1 - 2 * (1 - picture1.B) * (1 - picture2.B));

                    bitmappicture1.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            pictureBox3.Image = bitmappicture1;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < picture1Height; y++)
            {
                for (int x = 0; x < picture1Width; x++)
                {
                    Color picture1 = bitmappicture1.GetPixel(x, y);
                    Color picture2 = bitmappicture2.GetPixel(x, y);
                    int a = picture1.A , r, g, b;

                    if (picture2.R < a * 0.5)
                        r = rgbRange(510 * picture1.R * picture2.R);
                    else
                        r = rgbRange(a - 510 * (255 - picture1.R) * (255 - picture2.R));

                    if (picture2.G < a * 0.5)
                        g = rgbRange(510 * picture1.G * picture2.G);
                    else
                        g = rgbRange(a - 510 * (255 - picture1.G) * (255 - picture2.G));

                    if (picture2.B < a * 0.5)
                        b = rgbRange(510 * picture1.B * picture2.B);
                    else
                        b = rgbRange(a - 510 * (255 - picture1.B) * (255 - picture2.B));

                    bitmappicture1.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            pictureBox3.Image = bitmappicture1;
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < picture1Height; y++)
            {
                for (int x = 0; x < picture1Width; x++)
                {
                    Color picture1 = bitmappicture1.GetPixel(x, y);
                    Color picture2 = bitmappicture2.GetPixel(x, y);

                    int a = rgbRange(picture1.A / rgbRange((255 - picture2.A)));
                    int r = rgbRange(picture1.R / rgbRange((255 - picture2.R)));
                    int g = rgbRange(picture1.G / rgbRange((255 - picture2.G)));
                    int b = rgbRange(picture1.B / rgbRange((255 - picture2.B)));

                    bitmappicture1.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            pictureBox3.Image = bitmappicture1;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < picture1Height; y++)
            {
                for (int x = 0; x < picture1Width; x++)
                {
                    Color picture1 = bitmappicture1.GetPixel(x, y);
                    Color picture2 = bitmappicture2.GetPixel(x, y);
                    int a = rgbRange(255 - (255 - picture1.A) / rgbRange(picture2.A));
                    int r = rgbRange(255 - (255 - picture1.R) / rgbRange(picture2.R));
                    int g = rgbRange(255 - (255 - picture1.G) / rgbRange(picture2.G));
                    int b = rgbRange(255 - (255 - picture1.B) / rgbRange(picture2.B));

                    bitmappicture1.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            pictureBox3.Image = bitmappicture1;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < picture1Height; y++)
            {
                for (int x = 0; x < picture1Width; x++)
                {
                    Color picture1 = bitmappicture1.GetPixel(x, y);
                    Color picture2 = bitmappicture2.GetPixel(x, y);

                    int a = rgbRange((int)(Math.Pow(picture1.A, 2) / rgbRange(255 - picture2.A)));
                    int r = rgbRange((int)(Math.Pow(picture1.R, 2) / rgbRange(255 - picture2.R)));
                    int g = rgbRange((int)(Math.Pow(picture1.G, 2) / rgbRange(255 - picture2.G)));
                    int b = rgbRange((int)(Math.Pow(picture1.B, 2) / rgbRange(255 - picture2.B)));

                    bitmappicture1.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            pictureBox3.Image = bitmappicture1;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < picture1Height; y++)
            {
                for (int x = 0; x < picture1Width; x++)
                {
                    Color picture1 = bitmappicture1.GetPixel(x, y);
                    Color picture2 = bitmappicture2.GetPixel(x, y);
                    int a = rgbRange((trackBar2.Value * ((picture2.A + 127) - picture1.A)) / 255 + picture1.A - (trackBar2.Value / 4));
                    int r = rgbRange((trackBar2.Value * ((picture2.R + 127) - picture1.R)) / 255 + picture1.R - (trackBar2.Value / 4));
                    int g = rgbRange((trackBar2.Value * ((picture2.G + 127) - picture1.G)) / 255 + picture1.G - (trackBar2.Value / 4));
                    int b = rgbRange((trackBar2.Value * ((picture2.B + 127) - picture1.B)) / 255 + picture1.B - (trackBar2.Value / 4));

                    bitmappicture1.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            pictureBox3.Image = bitmappicture1;
        }

    private void button17_Click(object sender, EventArgs e)
    {
        {
            for (int y = 0; y < picture1Height; y++)
            {
                for (int x = 0; x < picture1Width; x++)
                {
                    Color picture1 = bitmappicture1.GetPixel(x, y);
                    int a = picture1.A;
                    int r = picture1.R;
                    int g = picture1.G;
                    int b = picture1.B;

                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    bitmappicture1.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            pictureBox3.Image = bitmappicture1;
        }
    }

        private void button18_Click(object sender, EventArgs e)
        {
                bitmappicture1 = new Bitmap(picture1);
                pictureBox3.Image = bitmappicture1;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
                {

        }
        public static Bitmap jasnosc(Bitmap Image, int Value)
        {
            Bitmap tempBitmap = Image;
            float finalValue = (float)Value / 255.0f;
            Bitmap newBitmap = new Bitmap(tempBitmap.Width, tempBitmap.Height);
            Graphics newGraphics = Graphics.FromImage(newBitmap);
            float[][] floatColorMatrix =
            {
                new float[] {1,0,0,0,0},
                new float[] {0,1,0,0,0},
                new float[] {0,0,1,0,0},
                new float[] {0,0,0,1,0},
                new float[] {finalValue,finalValue,finalValue,1,1}
            };
            ColorMatrix newcolorMatrix = new ColorMatrix(floatColorMatrix);
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(newcolorMatrix);
            newGraphics.DrawImage(tempBitmap, new Rectangle(0, 0, tempBitmap.Width, tempBitmap.Height), 0, 0,
                tempBitmap.Width, tempBitmap.Height, GraphicsUnit.Pixel, attributes);
            attributes.Dispose();
            newGraphics.Dispose();

            return newBitmap;
        }
        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            pictureBox3.Image = jasnosc(bitmappicture1, trackBar1.Value);
        }

    }
}
