using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorReduction.Definitions
{
    public class Options
    {
        public Algorithms Algorithm { get; set; }
        public Bitmap OriginalImage { get; set; }

        // Error Diffusion Dithering 
        public int RNumber { get; set; }
        public int GNumber { get; set; }
        public int BNumber { get; set; }
        public EDDFilters EDDFiler { get; set; }

        // K-Means Algorithm, Popularity Algorithm
        public int ColorsNumber { get; set; }

    }

    public enum Algorithms
    {
        ErrorDiffusionDithering,
        PopularityAlgorithm,
        KMeansAlgorithm
    }

    public enum EDDFilters
    {
        FloydAndSteinbergFilter,
        BurkesFilter,
        StuckyFilter,
    }
}
