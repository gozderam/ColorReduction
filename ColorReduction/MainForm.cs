using ColorReduction.Definitions;
using ColorReduction.Modules;
using ColorReduction.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorReduction
{
    public partial class MainForm : Form
    {
        private PictureModule pictureModule;
        private Dictionary<string, Bitmap> images = new Dictionary<string, Bitmap>();
        public MainForm()
        {
            InitializeComponent();

            this.pictureModule = new PictureModule(originalPB, reducedPB, reduceProgressBar);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            errorDifussionFilterCB.SelectedIndex = 0;
            rText.Text = rTB.Value.ToString();
            gText.Text = gTB.Value.ToString();
            bText.Text = bTB.Value.ToString();
            colorText.Text = colorTB.Value.ToString();

            // load textures 
            foreach (DictionaryEntry res in Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true))
            {
                if (res.Value is Bitmap b)
                    images.Add($"{res.Key}", ConvertTo32bppArgb(b));
            }
            imageCB.DataSource = images.Keys.ToList();
        }

        private void rTB_Scroll(object sender, EventArgs e)
        {
            rText.Text = rTB.Value.ToString();
        }

        private void gTB_Scroll(object sender, EventArgs e)
        {
            gText.Text = gTB.Value.ToString();

        }

        private void bTB_Scroll(object sender, EventArgs e)
        {
            bText.Text = bTB.Value.ToString();
        }

        private void colorTB_Scroll(object sender, EventArgs e)
        {
            colorText.Text = colorTB.Value.ToString();
        }

        private void reduceButton_Click(object sender, EventArgs e)
        {
            pictureModule.Reduce(ReadOptionsFromUI());
        }

        private void rText_TextChanged(object sender, EventArgs e)
        {
            rTB.Value = CutTo_1_256(rText.Text);
        }

        private void gText_TextChanged(object sender, EventArgs e)
        {
            gTB.Value = CutTo_1_256(gText.Text);
        }

        private void bText_TextChanged(object sender, EventArgs e)
        {
            bTB.Value = CutTo_1_256(bText.Text);
        }
        private void colorText_TextChanged(object sender, EventArgs e)
        {
            colorTB.Value = CutTo_1_256(colorText.Text);
        }

        private void errorDiffusionDitheringRB_CheckedChanged(object sender, EventArgs e)
        {
            if (errorDiffusionDitheringRB.Checked)
            {
                // invisible UI for other algorithms
                colorNumber2GB.Visible = false;

                // visible UI for this algorithm
                colorNumberGB.Visible = true;
                errorDiffusionFilterGB.Visible = true;
            }
        }

        private void popularityAlgorithmRB_CheckedChanged(object sender, EventArgs e)
        {
            if (popularityAlgorithmRB.Checked)
            {
                // unvisible UI for other algorithms
                colorNumberGB.Visible = false;
                errorDiffusionFilterGB.Visible = false;

                // visible UI for this algorithm
                colorNumber2GB.Location = colorNumberGB.Location;
                colorNumber2GB.Visible = true;
            }
        }

        private void kMenasAlgorithmRB_CheckedChanged(object sender, EventArgs e)
        {
            if (kMenasAlgorithmRB.Checked)
            {
                // unvisible UI for other algorithms
                colorNumberGB.Visible = false;
                errorDiffusionFilterGB.Visible = false;

                // visible UI for this algorithm
                colorNumber2GB.Location = colorNumberGB.Location;
                colorNumber2GB.Visible = true;
            }
        }
       
        #region private methods
        public Options ReadOptionsFromUI()
        {
            Options opts = new Options();
            var alg = errorDiffusionDitheringRB.Checked
                ? Algorithms.ErrorDiffusionDithering : (popularityAlgorithmRB.Checked
                ? Algorithms.PopularityAlgorithm
                : Algorithms.KMeansAlgorithm);

            opts.OriginalImage = images[imageCB.SelectedItem.ToString()];
            opts.Algorithm = alg;
            
            switch (opts.Algorithm)
            {
                case Algorithms.ErrorDiffusionDithering:
                    opts.RNumber = rTB.Value;
                    opts.GNumber = gTB.Value;
                    opts.BNumber = bTB.Value;
                    opts.EDDFiler = ParseAlgorithmName(errorDifussionFilterCB.SelectedItem.ToString());
                    break;
                case Algorithms.KMeansAlgorithm:
                    opts.ColorsNumber = colorTB.Value;
                    break;
                case Algorithms.PopularityAlgorithm:
                    opts.ColorsNumber = colorTB.Value;
                    break;
            }

            return opts;
        }

        private EDDFilters ParseAlgorithmName(string nameFromUI)
        {
            StringBuilder ret = new StringBuilder(nameFromUI);
            for (int i = 0; i < ret.Length; i++)
            {
                if (i == 0 || ret[i - 1] == ' ')
                    ret[i] = char.ToUpper(ret[i]);
            }
            return (EDDFilters)Enum.Parse(typeof(EDDFilters), ret.ToString().Replace(" ", ""));
        }

        private Bitmap ConvertTo32bppArgb(Bitmap b)
        {
            if (b.PixelFormat != PixelFormat.Format32bppArgb)
            {
                // convert to Format32bppArgb
                Bitmap clone = new Bitmap(b.Width, b.Height,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                using (Graphics gr = Graphics.FromImage(clone))
                {
                    gr.DrawImage(b, new Rectangle(0, 0, clone.Width, clone.Height));
                }
                return clone;
            }
            return b;
        }

        private int CutTo_1_256(string n)
        {
            if (!int.TryParse(n, out int num))
                return 1;
            if (num > 256) return 256;
            if (num < 1) return 1;
            return num;
        }



        #endregion

        private void createImageButton_Click(object sender, EventArgs e)
        {
            var opts = ReadOptionsFromUI();
            opts.OriginalImage = pictureModule.CreateImage();
            pictureModule.Reduce(opts);
        }
    }
}
