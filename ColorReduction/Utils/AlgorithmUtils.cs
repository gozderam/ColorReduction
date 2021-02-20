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
    public static class AlgorithmUtils
    {
        public static Bitmap ReduceColors(Options options, ProgressBar progressBar)
        {
            progressBar.Visible = true;
            Bitmap ret = null;
            switch(options.Algorithm)
            {
                case Algorithms.ErrorDiffusionDithering:
                    ret =  ErrorDiffusionDithering.ReduceColors(options, progressBar);
                    break;
                case Algorithms.PopularityAlgorithm:
                    ret = PopularityAlgorithm.ReduceColors(options, progressBar);
                    break;
                case Algorithms.KMeansAlgorithm:
                    ret = KMeansAlgorithm.ReduceColors(options, progressBar);
                    break;
            }
            progressBar.Visible = false;
            return ret;
        }
    }
}
