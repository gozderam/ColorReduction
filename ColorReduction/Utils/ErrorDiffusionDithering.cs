using ColorReduction.Definitions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorReduction.Utils
{
    public static class ErrorDiffusionDithering
    {
        public static Bitmap ReduceColors(Options options, ProgressBar progressBar)
        {
            var filter = GetFilter(options.EDDFiler);
            Bitmap reducedImage = new Bitmap(options.OriginalImage);//new Bitmap(originalImage.Width, originalImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            //using (BmpPixelSnoop originalWrapper = new BmpPixelSnoop(originalImage))
            using (BmpPixelSnoop reducedWrapper = new BmpPixelSnoop(reducedImage))
            {
                for (int i = 0; i < reducedImage.Width; i++)
                {
                    for (int j = 0; j < reducedImage.Height; j++)
                    {
                        var originalImagePixel = reducedWrapper.GetPixel(i, j);
                        var r = (int)Approximate(originalImagePixel.R, options.RNumber);
                        var g = (int)Approximate(originalImagePixel.G, options.GNumber);
                        var b = (int)Approximate(originalImagePixel.B, options.BNumber);
                        reducedWrapper.SetPixel(i, j, Color.FromArgb(r, g, b));

                        double errorR = originalImagePixel.R - r;
                        double errorG = originalImagePixel.G - g;
                        double errorB = originalImagePixel.B - b;

                        int f_x = filter.GetLength(0) / 2;
                        int f_y = filter.GetLength(1) / 2;

                        for (int ii = -f_x; ii <= f_x; ii++)
                        {
                            if (i + ii >= reducedImage.Width || i + ii < 0)
                                continue;
                            for (int jj = -f_y; jj <= f_y; jj++)
                            {
                                if (j + jj >= reducedImage.Height || j + jj < 0)
                                    continue;
                                var colorToSet = reducedWrapper.GetPixel(i + ii, j + jj);
                                colorToSet = Color.FromArgb(
                                    CutTo_0_255(colorToSet.R + (errorR * filter[f_x + ii, f_y + jj])),
                                    CutTo_0_255(colorToSet.G + (errorG * filter[f_x + ii, f_y + jj])),
                                    CutTo_0_255(colorToSet.B + (errorB * filter[f_x + ii, f_y + jj])));
                                reducedWrapper.SetPixel(i + ii, j + jj, colorToSet);
                            }
                        }
                    }
                    progressBar.Value = (int)((i * progressBar.Maximum)/ (double)reducedImage.Width);

                }
            }
            progressBar.Value = progressBar.Maximum;
            return reducedImage;
        }

        #region private methods
        private static double[,] GetFilter(EDDFilters filter)
        {
            switch(filter)
            {
                case EDDFilters.FloydAndSteinbergFilter:
                    return new double[,]{ 
                        { 0,         0,         0,},
                        { 0,         0,         7.0/16.0 },
                        { 3.0/16.0,  5.0/16.0,  1.0/16.0 }};
                case EDDFilters.BurkesFilter:
                    return new double[,] {
                        { 0,        0,          0,          0,          0},
                        { 0,        0,          0,          8.0/32.0,   4.0/32.0 },
                        { 2.0/32.0, 4.0/32.0,   8.0/32.0,   4.0/32.0,   2.0/32.0 }};
                case EDDFilters.StuckyFilter:
                    return new double[,] {
                        { 0,        0,          0,          0,          0},
                        { 0,        0,          0,          0,          0 },
                        { 0,        0,          0,          8/42,       4/32 },
                        { 2.0/42.0, 4.0/42.0,   8.0/42.0,   4.0/42.0,   2.0/42.0 },
                        { 1.0/42.0, 2.0/42.0,   4.0/42.0,   2.0/42.0,   1.0/42.0 }};
            }
            throw new ArgumentException("Wrong value of Enum EDDFilters");
        }

        private static double Approximate(double originalColor, int colorsNumber)
        {
            double rangeLength = 255.0 / (double)colorsNumber;
            int rangeNumber = (int)(originalColor / rangeLength);
            if (rangeNumber == colorsNumber) rangeNumber--;
            return (double)rangeNumber * rangeLength;
        }

        private static int CutTo_0_255(double c)
        {
            if (c < 0) return 0;
            if (c > 255) return 255;
            return (int)c;
        }
        #endregion
    }
}
