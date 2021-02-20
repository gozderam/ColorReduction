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
    public static class PopularityAlgorithm
    {
        public static Bitmap ReduceColors(Options options, ProgressBar progressBar)
        {
            Dictionary<(byte R, byte G, byte B), int> colorsPopularity = new Dictionary<(byte R, byte G, byte B), int>();

            var reducedBitmap = new Bitmap(options.OriginalImage);
            using (var reducedWrapper = new BmpPixelSnoop(reducedBitmap))
            {
                for (int i = 0; i < reducedBitmap.Width; i++)
                {
                    for (int j = 0; j < reducedBitmap.Height; j++)
                    {
                        var c = reducedWrapper.GetPixel(i, j);
                        if (!colorsPopularity.TryGetValue((c.R, c.G, c.B), out int cPopularity))
                        {
                            colorsPopularity[(c.R, c.G, c.B)] = 1;
                        }
                        else
                            colorsPopularity[(c.R, c.G, c.B)] = cPopularity + 1;
                    }
                    progressBar.Value = (int)((double)i / (double)reducedBitmap.Width * 0.5 * (double)progressBar.Maximum);
                }

                var l = colorsPopularity.ToList();
                l.Sort((kvp1, kvp2) => -kvp1.Value.CompareTo(kvp2.Value));
                if(l.Count - options.ColorsNumber > 0 ) 
                    l.RemoveRange(options.ColorsNumber, l.Count - options.ColorsNumber);
                var popularColors = l.ConvertAll(kvp => kvp.Key);

                for (int i = 0; i < reducedBitmap.Width; i++)
                {
                    for (int j = 0; j < reducedBitmap.Height; j++)
                    {
                        var c = reducedWrapper.GetPixel(i, j);
                        var colorToSet = GetColorByDistance(c, popularColors);
                        reducedWrapper.SetPixel(i, j, Color.FromArgb(colorToSet.R, colorToSet.G, colorToSet.B));
                    }
                    progressBar.Value = (int)(0.5 * (double)progressBar.Maximum + (double)i / (double)reducedBitmap.Width * 0.5 * (double)progressBar.Maximum);
                }
            }
            progressBar.Value = progressBar.Maximum;
            return reducedBitmap;
        }

        private static (byte R, byte G, byte B) GetColorByDistance(Color c, List<(byte R, byte G, byte B)> popularColors)
        {
            double minDist = double.MaxValue;
            int colorIdx = 0;
            for (int i = 0; i < popularColors.Count; i++)
            {
                var dist = Math.Sqrt(
                    (c.R - popularColors[i].R) * (c.R - popularColors[i].R) +
                    (c.G - popularColors[i].G) * (c.G - popularColors[i].G) +
                    (c.B - popularColors[i].B) * (c.B - popularColors[i].B));

                if (dist < minDist)
                {
                    minDist = dist;
                    colorIdx = i;
                }
            }
            return popularColors[colorIdx];
        }
    }
}
