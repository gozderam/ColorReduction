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
    public static class KMeansAlgorithm
    {
        public static Bitmap ReduceColors(Options options, ProgressBar progressBar)
        {
            if (options.OriginalImage.Width * options.OriginalImage.Height <= 1024 * 1024)
                return ReduceColorsWithCachedBitmap(options, progressBar);
            else return ReduceColorsWithoutCachedBitmap(options, progressBar);

        }

        private static Bitmap ReduceColorsWithoutCachedBitmap(Options options, ProgressBar progressBar)
        {
            Bitmap reducedImage = new Bitmap(options.OriginalImage);

            using (var reducedWrapper = new BmpPixelSnoop(reducedImage))
            {
                var random = new Random();
                bool isChange = true;

                int k = options.ColorsNumber;
                Color[] centroids = new Color[k];
                (int R, int G, int B)[] sums = new (int R, int G, int B)[k];
                int[] counts = new int[k];

                int[,] pixelsToCentroids = new int[reducedImage.Width, reducedImage.Height];

                // choose firs cntroids - random
                for (int i = 0; i < k; i++)
                    centroids[i] = reducedWrapper.GetPixel(random.Next(k), random.Next(k));

                int iterCount = 0;
                int maxIters = 1_000;
                while (isChange && iterCount< maxIters)
                {
                    iterCount++;
                    // calculate nearest centroid for each pixel
                    for (int i = 0; i < reducedImage.Width; i++)
                        for (int j = 0; j < reducedImage.Height; j++)
                        {
                            var c = reducedWrapper.GetPixel(i, j);
                            pixelsToCentroids[i, j] = GetCentroidByDistance(c, centroids);
                            sums[pixelsToCentroids[i, j]] = (
                                sums[pixelsToCentroids[i, j]].R + c.R,
                                sums[pixelsToCentroids[i, j]].G + c.G,
                                sums[pixelsToCentroids[i, j]].B + c.B);
                            counts[pixelsToCentroids[i, j]]++;
                        }

                    // calculate new centrois - average sums/counts
                    isChange = false;
                    for (int i = 0; i < k; i++)
                    {
                        if (counts[i] == 0)
                            continue;
                        var avg = Color.FromArgb(sums[i].R / counts[i], sums[i].G / counts[i], sums[i].B / counts[i]);
                        if (centroids[i].R != avg.R || centroids[i].G != avg.G || centroids[i].B != avg.B)
                        {
                            isChange = true;
                            centroids[i] = avg;
                        }
                    }

                progressBar.Value = (int)((double)(iterCount * progressBar.Maximum) / (double)maxIters);
                }

                // set pixels in reduced (k) colors
                for (int i = 0; i < reducedImage.Width; i++)
                    for (int j = 0; j < reducedImage.Height; j++)
                        reducedWrapper.SetPixel(i, j, centroids[pixelsToCentroids[i, j]]);
            }
            progressBar.Value = progressBar.Maximum;
            return reducedImage;
        }

        private static Bitmap ReduceColorsWithCachedBitmap(Options options, ProgressBar progressBar)
        {
            Bitmap reducedImage = new Bitmap(options.OriginalImage);

            using (var reducedWrapper = new BmpPixelSnoop(reducedImage))
            {
                var random = new Random();
                bool isChange = true;

                int k = options.ColorsNumber;
                (byte R, byte G, byte B)[] centroids = new (byte R, byte G, byte B)[k];
                (int R, int G, int B)[] sums = new (int R, int G, int B)[k];
                int[] counts = new int[k];

                int[,] pixelsToCentroids = new int[reducedImage.Width, reducedImage.Height];

                // cache Bitmap
                (byte R, byte G, byte B)[,] cachedBitmap = new (byte R, byte G, byte B)[reducedImage.Width, reducedImage.Height];
                for(int i =0; i<reducedImage.Width; i++)
                    for(int j=0; j<reducedImage.Height; j++)
                    {
                        var c = reducedWrapper.GetPixel(i, j);
                        cachedBitmap[i, j] = (c.R, c.G, c.B);
                    }
                      

                // choose firs cntroids - random
                for (int i = 0; i < k; i++)
                    centroids[i] = cachedBitmap[random.Next(k), random.Next(k)];

                int iterCount = 0;
                while (isChange)
                {
                    iterCount++;
                    // calculate nearest centroid for each pixel
                    for (int i = 0; i < reducedImage.Width; i++)
                        for (int j = 0; j < reducedImage.Height; j++)
                        {
                            var c = cachedBitmap[i, j];
                            pixelsToCentroids[i, j] = GetCentroidByDistance(c, centroids);
                            sums[pixelsToCentroids[i, j]] = (
                                sums[pixelsToCentroids[i, j]].R + c.R,
                                sums[pixelsToCentroids[i, j]].G + c.G,
                                sums[pixelsToCentroids[i, j]].B + c.B);
                            counts[pixelsToCentroids[i, j]]++;
                        }

                    // calculate new centrois - average sums/counts
                    isChange = false;
                    for (int i = 0; i < k; i++)
                    {
                        if (counts[i] == 0)
                            continue;
                        (byte R, byte G, byte B) avg = ((byte)(sums[i].R / counts[i]), (byte)(sums[i].G / counts[i]), (byte)(sums[i].B / counts[i]));
                        if (centroids[i].R != avg.R || centroids[i].G != avg.G || centroids[i].B != avg.B)
                        {
                            isChange = true;
                            centroids[i] = avg;
                        }
                    }

                    var progress = 2 * (int)((double)(iterCount * progressBar.Maximum) / (double)k);
                    progressBar.Value = progress < progressBar.Maximum * 0.90 ? progress : (int)(progressBar.Maximum * 0.90);
                }

                // set pixels in reduced (k) colors
                for (int i = 0; i < reducedImage.Width; i++)
                    for (int j = 0; j < reducedImage.Height; j++)
                        reducedWrapper.SetPixel(i, j, Color.FromArgb(centroids[pixelsToCentroids[i, j]].R, centroids[pixelsToCentroids[i, j]].G, centroids[pixelsToCentroids[i, j]].B));
            }
            progressBar.Value = progressBar.Maximum;
            return reducedImage;
        }

        private static int GetCentroidByDistance(Color c, Color[] centroids)
        {
            double minDist = double.MaxValue;
            int centroid = 0;
            for(int i =0; i<centroids.Length; i++)
            {
                var dist = Math.Sqrt(
                    (c.R - centroids[i].R) * (c.R - centroids[i].R) +
                    (c.G - centroids[i].G) * (c.G - centroids[i].G) +
                    (c.B - centroids[i].B) * (c.B - centroids[i].B));

                if(dist < minDist)
                {
                    minDist = dist;
                    centroid = i;
                }
            }
            return centroid;
        }

        private static int GetCentroidByDistance((byte R, byte G, byte B) c, (byte R, byte G, byte B)[] centroids)
        {
            double minDist = double.MaxValue;
            int centroid = 0;
            for (int i = 0; i < centroids.Length; i++)
            {
                var dist = 
                    (c.R - centroids[i].R) * (c.R - centroids[i].R) +
                    (c.G - centroids[i].G) * (c.G - centroids[i].G) +
                    (c.B - centroids[i].B) * (c.B - centroids[i].B);

                if (dist < minDist)
                {
                    minDist = dist;
                    centroid = i;
                }
            }
            return centroid;
        }
    }
}
