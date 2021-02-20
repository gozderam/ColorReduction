using ColorReduction.Definitions;
using ColorReduction.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorReduction.Modules
{
    public class PictureModule
    {
        private PictureBox originalBox;

        private PictureBox reducedBox;

        private ProgressBar progressBar;

        public PictureModule(PictureBox originalBox, PictureBox reducedBox, ProgressBar progressBar)
        {
            this.originalBox = originalBox;      
            this.reducedBox = reducedBox;
            this.progressBar = progressBar;
        }

        public void Reduce(Options options)
        {
            originalBox.Image = options.OriginalImage;
            reducedBox.Image = AlgorithmUtils.ReduceColors(options, progressBar);
        }

        public Bitmap CreateImage()
        {
            var bmp = new Bitmap(originalBox.Width, originalBox.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (var graphics = Graphics.FromImage(bmp))
            {
                using (var p_background = new SolidBrush(Color.White))
                    graphics.FillRectangle(p_background, 0, 0, bmp.Width, bmp.Height);

                using (var p_border = new Pen(Color.Black, 20))
                    graphics.DrawRectangle(p_border, 0, 0, bmp.Width, bmp.Height);

                int mid_x = bmp.Width / 2 - 30;
                int mid_y = bmp.Height / 2;

                int currAngle = 0;
                int angleStep = 360 / 12;

                double R = bmp.Width / 2 - 60;

                using (var p_circle = new Pen(Color.Black, 1))
                    for (; currAngle<360; currAngle+=angleStep)
                    {
                        int c_x = (int)(R*Math.Cos(6.28 * (double)currAngle / 360.0));
                        int c_y = (int)(R*Math.Sin(6.28 * (double)currAngle / 360.0));

                        var color = HsvToRgb(currAngle, 1, 1);
                        using (var p_fill = new SolidBrush(color))
                            graphics.FillEllipse(p_fill, mid_x+c_x, mid_y+c_y, 60, 60);
                    }
                

            }

            return bmp;
        }


        static Color HsvToRgb(double h, double S, double V)
        {
            double H = h;
            while (H < 0) { H += 360; };
            while (H >= 360) { H -= 360; };
            double R, G, B;
            if (V <= 0)
            { R = G = B = 0; }
            else if (S <= 0)
            {
                R = G = B = V;
            }
            else
            {
                double hf = H / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = V * (1 - S);
                double qv = V * (1 - S * f);
                double tv = V * (1 - S * (1 - f));
                switch (i)
                {

                    // Red is the dominant color

                    case 0:
                        R = V;
                        G = tv;
                        B = pv;
                        break;

                    // Green is the dominant color

                    case 1:
                        R = qv;
                        G = V;
                        B = pv;
                        break;
                    case 2:
                        R = pv;
                        G = V;
                        B = tv;
                        break;

                    // Blue is the dominant color

                    case 3:
                        R = pv;
                        G = qv;
                        B = V;
                        break;
                    case 4:
                        R = tv;
                        G = pv;
                        B = V;
                        break;

                    // Red is the dominant color

                    case 5:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

                    case 6:
                        R = V;
                        G = tv;
                        B = pv;
                        break;
                    case -1:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // The color is not defined, we should throw an error.

                    default:
                        //LFATAL("i Value error in Pixel conversion, Value is %d", i);
                        R = G = B = V; // Just pretend its black/white
                        break;
                }
            }
            var r = Clamp((int)(R * 255.0));
            var g = Clamp((int)(G * 255.0));
            var b = Clamp((int)(B * 255.0));
            return Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Clamp a value to 0-255
        /// </summary>
        static int Clamp(int i)
        {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return i;
        }
    }
}
