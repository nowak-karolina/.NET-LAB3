namespace App {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

        }

        Bitmap? img;
        private readonly object imgLock = new object();

        private void loadButton_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|(*.*)";
            openFileDialog1.FilterIndex = 1;

            DialogResult result = openFileDialog1.ShowDialog();
            if(result != DialogResult.OK) {
                MessageBox.Show("Error: no file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var file = openFileDialog1.FileName;
            if (file != null) {
                img = new Bitmap(file);
                pictureBox1.Image = img;
            }

        }


        private void Greyscale() {
            Bitmap tmp;
            lock (imgLock) {
                tmp = (Bitmap)img.Clone();
            }
            Color c;

            for (int i = 0; i < tmp.Width; i++) {
                for (int j = 0; j < tmp.Height; j++) {
                    c = tmp.GetPixel(i, j);
                    byte gray = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);

                    tmp.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }

            pictureBox2.Image = tmp;
        }

        private void Invert() {
            Bitmap tmp;
            lock (imgLock) {
                tmp = (Bitmap)img.Clone();
            }
            Color c;

            for(int i = 0; i< tmp.Width; i++) {
                for(int j = 0;j< tmp.Height; j++) {
                    c=tmp.GetPixel(i, j);
                    tmp.SetPixel(i, j, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                }
            }
            pictureBox3.Image = tmp;
        }

        public void Contrast(double contrast) {
            Bitmap tmp;
            lock (imgLock) {
                tmp = (Bitmap)img.Clone();
            }

            if (contrast < -100) contrast = -100;
            if (contrast > 100) contrast = 100;
            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            Color c;
            for (int i = 0; i < tmp.Width; i++) {
                for (int j = 0; j < tmp.Height; j++) {
                    c = tmp.GetPixel(i, j);
                    double pR = c.R / 255.0;
                    pR -= 0.5;
                    pR *= contrast;
                    pR += 0.5;
                    pR *= 255;
                    if (pR < 0) pR = 0;
                    if (pR > 255) pR = 255;

                    double pG = c.G / 255.0;
                    pG -= 0.5;
                    pG *= contrast;
                    pG += 0.5;
                    pG *= 255;
                    if (pG < 0) pG = 0;
                    if (pG > 255) pG = 255;

                    double pB = c.B / 255.0;
                    pB -= 0.5;
                    pB *= contrast;
                    pB += 0.5;
                    pB *= 255;
                    if (pB < 0) pB = 0;
                    if (pB > 255) pB = 255;

                    tmp.SetPixel(i, j, Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                }
            }
            pictureBox4.Image = tmp;
        }

        public void Brightness(int brightness) {
            Bitmap tmp;
            lock (imgLock) {
                tmp = (Bitmap)img.Clone();
            }

            if (brightness < -255) brightness = -255;
            if (brightness > 255) brightness = 255;
            Color c;
            for (int i = 0; i < tmp.Width; i++) {
                for (int j = 0; j < tmp.Height; j++) {
                    c = tmp.GetPixel(i, j);
                    int cR = c.R + brightness;
                    int cG = c.G + brightness;
                    int cB = c.B + brightness;

                    if (cR < 0) cR = 1;
                    if (cR > 255) cR = 255;

                    if (cG < 0) cG = 1;
                    if (cG > 255) cG = 255;

                    if (cB < 0) cB = 1;
                    if (cB > 255) cB = 255;

                    tmp.SetPixel(i, j, Color.FromArgb((byte)cR, (byte)cG, (byte)cB));
                }
            }
            pictureBox5.Image = tmp;
        }

        private void processButton_Click(object sender, EventArgs e) {
            Parallel.For(0, 4, i => {
                if (i == 0) Greyscale();
                if (i == 1) Invert();
                if (i == 2) Contrast(200);
                if (i == 3) Brightness(150);
            });
        }

    }
}
