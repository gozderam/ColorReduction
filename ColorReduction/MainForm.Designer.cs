namespace ColorReduction
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.algorithmGB = new System.Windows.Forms.GroupBox();
            this.kMenasAlgorithmRB = new System.Windows.Forms.RadioButton();
            this.popularityAlgorithmRB = new System.Windows.Forms.RadioButton();
            this.errorDiffusionDitheringRB = new System.Windows.Forms.RadioButton();
            this.colorNumberGB = new System.Windows.Forms.GroupBox();
            this.bText = new System.Windows.Forms.TextBox();
            this.gText = new System.Windows.Forms.TextBox();
            this.rText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bTB = new System.Windows.Forms.TrackBar();
            this.gTB = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.rTB = new System.Windows.Forms.TrackBar();
            this.errorDiffusionFilterGB = new System.Windows.Forms.GroupBox();
            this.errorDifussionFilterCB = new System.Windows.Forms.ComboBox();
            this.reduceButton = new System.Windows.Forms.Button();
            this.reduceProgressBar = new System.Windows.Forms.ProgressBar();
            this.colorNumber2GB = new System.Windows.Forms.GroupBox();
            this.colorText = new System.Windows.Forms.TextBox();
            this.colorTB = new System.Windows.Forms.TrackBar();
            this.imageGB = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.createImageButton = new System.Windows.Forms.Button();
            this.imageCB = new System.Windows.Forms.ComboBox();
            this.reducedPB = new System.Windows.Forms.PictureBox();
            this.originalPB = new System.Windows.Forms.PictureBox();
            this.algorithmGB.SuspendLayout();
            this.colorNumberGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTB)).BeginInit();
            this.errorDiffusionFilterGB.SuspendLayout();
            this.colorNumber2GB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorTB)).BeginInit();
            this.imageGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reducedPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalPB)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(234, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Original";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(847, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Reduced";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Small", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(1282, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Menu";
            // 
            // algorithmGB
            // 
            this.algorithmGB.Controls.Add(this.kMenasAlgorithmRB);
            this.algorithmGB.Controls.Add(this.popularityAlgorithmRB);
            this.algorithmGB.Controls.Add(this.errorDiffusionDitheringRB);
            this.algorithmGB.Location = new System.Drawing.Point(1191, 41);
            this.algorithmGB.Name = "algorithmGB";
            this.algorithmGB.Size = new System.Drawing.Size(246, 132);
            this.algorithmGB.TabIndex = 5;
            this.algorithmGB.TabStop = false;
            this.algorithmGB.Text = "Algorithm";
            // 
            // kMenasAlgorithmRB
            // 
            this.kMenasAlgorithmRB.AutoSize = true;
            this.kMenasAlgorithmRB.Location = new System.Drawing.Point(26, 89);
            this.kMenasAlgorithmRB.Name = "kMenasAlgorithmRB";
            this.kMenasAlgorithmRB.Size = new System.Drawing.Size(148, 21);
            this.kMenasAlgorithmRB.TabIndex = 2;
            this.kMenasAlgorithmRB.Text = "K-Means Algorithm";
            this.kMenasAlgorithmRB.UseVisualStyleBackColor = true;
            this.kMenasAlgorithmRB.CheckedChanged += new System.EventHandler(this.kMenasAlgorithmRB_CheckedChanged);
            // 
            // popularityAlgorithmRB
            // 
            this.popularityAlgorithmRB.AutoSize = true;
            this.popularityAlgorithmRB.Location = new System.Drawing.Point(26, 62);
            this.popularityAlgorithmRB.Name = "popularityAlgorithmRB";
            this.popularityAlgorithmRB.Size = new System.Drawing.Size(155, 21);
            this.popularityAlgorithmRB.TabIndex = 1;
            this.popularityAlgorithmRB.Text = "Popularity Algorithm";
            this.popularityAlgorithmRB.UseVisualStyleBackColor = true;
            this.popularityAlgorithmRB.CheckedChanged += new System.EventHandler(this.popularityAlgorithmRB_CheckedChanged);
            // 
            // errorDiffusionDitheringRB
            // 
            this.errorDiffusionDitheringRB.AutoSize = true;
            this.errorDiffusionDitheringRB.Checked = true;
            this.errorDiffusionDitheringRB.Location = new System.Drawing.Point(26, 35);
            this.errorDiffusionDitheringRB.Name = "errorDiffusionDitheringRB";
            this.errorDiffusionDitheringRB.Size = new System.Drawing.Size(181, 21);
            this.errorDiffusionDitheringRB.TabIndex = 0;
            this.errorDiffusionDitheringRB.TabStop = true;
            this.errorDiffusionDitheringRB.Text = "Error Diffusion Dithering";
            this.errorDiffusionDitheringRB.UseVisualStyleBackColor = true;
            this.errorDiffusionDitheringRB.CheckedChanged += new System.EventHandler(this.errorDiffusionDitheringRB_CheckedChanged);
            // 
            // colorNumberGB
            // 
            this.colorNumberGB.Controls.Add(this.bText);
            this.colorNumberGB.Controls.Add(this.gText);
            this.colorNumberGB.Controls.Add(this.rText);
            this.colorNumberGB.Controls.Add(this.label6);
            this.colorNumberGB.Controls.Add(this.label5);
            this.colorNumberGB.Controls.Add(this.bTB);
            this.colorNumberGB.Controls.Add(this.gTB);
            this.colorNumberGB.Controls.Add(this.label4);
            this.colorNumberGB.Controls.Add(this.rTB);
            this.colorNumberGB.Location = new System.Drawing.Point(1191, 179);
            this.colorNumberGB.Name = "colorNumberGB";
            this.colorNumberGB.Size = new System.Drawing.Size(246, 179);
            this.colorNumberGB.TabIndex = 6;
            this.colorNumberGB.TabStop = false;
            this.colorNumberGB.Text = "Number of colors";
            // 
            // bText
            // 
            this.bText.Location = new System.Drawing.Point(195, 117);
            this.bText.Name = "bText";
            this.bText.Size = new System.Drawing.Size(39, 22);
            this.bText.TabIndex = 8;
            this.bText.TextChanged += new System.EventHandler(this.bText_TextChanged);
            // 
            // gText
            // 
            this.gText.Location = new System.Drawing.Point(195, 72);
            this.gText.Name = "gText";
            this.gText.Size = new System.Drawing.Size(39, 22);
            this.gText.TabIndex = 7;
            this.gText.TextChanged += new System.EventHandler(this.gText_TextChanged);
            // 
            // rText
            // 
            this.rText.Location = new System.Drawing.Point(195, 30);
            this.rText.Name = "rText";
            this.rText.Size = new System.Drawing.Size(39, 22);
            this.rText.TabIndex = 6;
            this.rText.TextChanged += new System.EventHandler(this.rText_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "G";
            // 
            // bTB
            // 
            this.bTB.Location = new System.Drawing.Point(26, 120);
            this.bTB.Maximum = 256;
            this.bTB.Minimum = 1;
            this.bTB.Name = "bTB";
            this.bTB.Size = new System.Drawing.Size(168, 56);
            this.bTB.TabIndex = 3;
            this.bTB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.bTB.Value = 1;
            this.bTB.Scroll += new System.EventHandler(this.bTB_Scroll);
            // 
            // gTB
            // 
            this.gTB.Location = new System.Drawing.Point(26, 75);
            this.gTB.Maximum = 256;
            this.gTB.Minimum = 1;
            this.gTB.Name = "gTB";
            this.gTB.Size = new System.Drawing.Size(168, 56);
            this.gTB.TabIndex = 2;
            this.gTB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.gTB.Value = 1;
            this.gTB.Scroll += new System.EventHandler(this.gTB_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "R";
            // 
            // rTB
            // 
            this.rTB.Location = new System.Drawing.Point(26, 33);
            this.rTB.Maximum = 256;
            this.rTB.Minimum = 1;
            this.rTB.Name = "rTB";
            this.rTB.Size = new System.Drawing.Size(168, 56);
            this.rTB.TabIndex = 0;
            this.rTB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.rTB.Value = 1;
            this.rTB.Scroll += new System.EventHandler(this.rTB_Scroll);
            // 
            // errorDiffusionFilterGB
            // 
            this.errorDiffusionFilterGB.Controls.Add(this.errorDifussionFilterCB);
            this.errorDiffusionFilterGB.Location = new System.Drawing.Point(1191, 364);
            this.errorDiffusionFilterGB.Name = "errorDiffusionFilterGB";
            this.errorDiffusionFilterGB.Size = new System.Drawing.Size(246, 73);
            this.errorDiffusionFilterGB.TabIndex = 6;
            this.errorDiffusionFilterGB.TabStop = false;
            this.errorDiffusionFilterGB.Text = "Error Diffusion Filter";
            // 
            // errorDifussionFilterCB
            // 
            this.errorDifussionFilterCB.FormattingEnabled = true;
            this.errorDifussionFilterCB.Items.AddRange(new object[] {
            "Floyd and Steinberg Filter",
            "Burkes Filter",
            "Stucky Filter"});
            this.errorDifussionFilterCB.Location = new System.Drawing.Point(9, 30);
            this.errorDifussionFilterCB.Name = "errorDifussionFilterCB";
            this.errorDifussionFilterCB.Size = new System.Drawing.Size(222, 24);
            this.errorDifussionFilterCB.TabIndex = 0;
            // 
            // reduceButton
            // 
            this.reduceButton.Font = new System.Drawing.Font("Sitka Small", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.reduceButton.Location = new System.Drawing.Point(9, 76);
            this.reduceButton.Name = "reduceButton";
            this.reduceButton.Size = new System.Drawing.Size(231, 38);
            this.reduceButton.TabIndex = 7;
            this.reduceButton.Text = "Reduce selected image";
            this.reduceButton.UseVisualStyleBackColor = true;
            this.reduceButton.Click += new System.EventHandler(this.reduceButton_Click);
            // 
            // reduceProgressBar
            // 
            this.reduceProgressBar.Location = new System.Drawing.Point(1191, 596);
            this.reduceProgressBar.Name = "reduceProgressBar";
            this.reduceProgressBar.Size = new System.Drawing.Size(246, 23);
            this.reduceProgressBar.Step = 1;
            this.reduceProgressBar.TabIndex = 8;
            this.reduceProgressBar.Visible = false;
            // 
            // colorNumber2GB
            // 
            this.colorNumber2GB.Controls.Add(this.colorText);
            this.colorNumber2GB.Controls.Add(this.colorTB);
            this.colorNumber2GB.Location = new System.Drawing.Point(1191, 443);
            this.colorNumber2GB.Name = "colorNumber2GB";
            this.colorNumber2GB.Size = new System.Drawing.Size(246, 95);
            this.colorNumber2GB.TabIndex = 9;
            this.colorNumber2GB.TabStop = false;
            this.colorNumber2GB.Text = "Number of colors";
            this.colorNumber2GB.Visible = false;
            // 
            // colorText
            // 
            this.colorText.Location = new System.Drawing.Point(195, 30);
            this.colorText.Name = "colorText";
            this.colorText.Size = new System.Drawing.Size(39, 22);
            this.colorText.TabIndex = 6;
            this.colorText.TextChanged += new System.EventHandler(this.colorText_TextChanged);
            // 
            // colorTB
            // 
            this.colorTB.Location = new System.Drawing.Point(6, 33);
            this.colorTB.Maximum = 256;
            this.colorTB.Minimum = 1;
            this.colorTB.Name = "colorTB";
            this.colorTB.Size = new System.Drawing.Size(188, 56);
            this.colorTB.TabIndex = 0;
            this.colorTB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.colorTB.Value = 1;
            this.colorTB.Scroll += new System.EventHandler(this.colorTB_Scroll);
            // 
            // imageGB
            // 
            this.imageGB.Controls.Add(this.label7);
            this.imageGB.Controls.Add(this.createImageButton);
            this.imageGB.Controls.Add(this.imageCB);
            this.imageGB.Controls.Add(this.reduceButton);
            this.imageGB.Location = new System.Drawing.Point(1191, 625);
            this.imageGB.Name = "imageGB";
            this.imageGB.Size = new System.Drawing.Size(246, 168);
            this.imageGB.TabIndex = 7;
            this.imageGB.TabStop = false;
            this.imageGB.Text = "Image";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Select image:";
            // 
            // createImageButton
            // 
            this.createImageButton.Font = new System.Drawing.Font("Sitka Small", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.createImageButton.Location = new System.Drawing.Point(9, 120);
            this.createImageButton.Name = "createImageButton";
            this.createImageButton.Size = new System.Drawing.Size(231, 38);
            this.createImageButton.TabIndex = 1;
            this.createImageButton.Text = "Create image and reduce";
            this.createImageButton.UseVisualStyleBackColor = true;
            this.createImageButton.Click += new System.EventHandler(this.createImageButton_Click);
            // 
            // imageCB
            // 
            this.imageCB.FormattingEnabled = true;
            this.imageCB.Location = new System.Drawing.Point(9, 46);
            this.imageCB.Name = "imageCB";
            this.imageCB.Size = new System.Drawing.Size(231, 24);
            this.imageCB.TabIndex = 0;
            // 
            // reducedPB
            // 
            this.reducedPB.BackColor = System.Drawing.Color.White;
            this.reducedPB.Location = new System.Drawing.Point(603, 41);
            this.reducedPB.Name = "reducedPB";
            this.reducedPB.Size = new System.Drawing.Size(582, 755);
            this.reducedPB.TabIndex = 1;
            this.reducedPB.TabStop = false;
            // 
            // originalPB
            // 
            this.originalPB.BackColor = System.Drawing.Color.White;
            this.originalPB.Location = new System.Drawing.Point(12, 41);
            this.originalPB.Name = "originalPB";
            this.originalPB.Size = new System.Drawing.Size(582, 755);
            this.originalPB.TabIndex = 0;
            this.originalPB.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 805);
            this.Controls.Add(this.imageGB);
            this.Controls.Add(this.colorNumber2GB);
            this.Controls.Add(this.reduceProgressBar);
            this.Controls.Add(this.errorDiffusionFilterGB);
            this.Controls.Add(this.colorNumberGB);
            this.Controls.Add(this.algorithmGB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reducedPB);
            this.Controls.Add(this.originalPB);
            this.MaximumSize = new System.Drawing.Size(1465, 852);
            this.Name = "MainForm";
            this.Text = "Color Reduction. Michał Gozdera";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.algorithmGB.ResumeLayout(false);
            this.algorithmGB.PerformLayout();
            this.colorNumberGB.ResumeLayout(false);
            this.colorNumberGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTB)).EndInit();
            this.errorDiffusionFilterGB.ResumeLayout(false);
            this.colorNumber2GB.ResumeLayout(false);
            this.colorNumber2GB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorTB)).EndInit();
            this.imageGB.ResumeLayout(false);
            this.imageGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reducedPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox originalPB;
        private System.Windows.Forms.PictureBox reducedPB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox algorithmGB;
        private System.Windows.Forms.RadioButton kMenasAlgorithmRB;
        private System.Windows.Forms.RadioButton popularityAlgorithmRB;
        private System.Windows.Forms.RadioButton errorDiffusionDitheringRB;
        private System.Windows.Forms.GroupBox colorNumberGB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar bTB;
        private System.Windows.Forms.TrackBar gTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar rTB;
        private System.Windows.Forms.GroupBox errorDiffusionFilterGB;
        private System.Windows.Forms.ComboBox errorDifussionFilterCB;
        private System.Windows.Forms.Button reduceButton;
        private System.Windows.Forms.TextBox bText;
        private System.Windows.Forms.TextBox gText;
        private System.Windows.Forms.TextBox rText;
        private System.Windows.Forms.ProgressBar reduceProgressBar;
        private System.Windows.Forms.GroupBox colorNumber2GB;
        private System.Windows.Forms.TextBox colorText;
        private System.Windows.Forms.TrackBar colorTB;
        private System.Windows.Forms.GroupBox imageGB;
        private System.Windows.Forms.ComboBox imageCB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button createImageButton;
    }
}

