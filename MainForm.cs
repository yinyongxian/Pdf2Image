using System.Drawing.Imaging;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Devices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Color = System.Drawing.Color;
using Image = System.Drawing.Image;

namespace Pdf2Image
{
    public partial class MaintForm : Form
    {
        public MaintForm()
        {
            InitializeComponent();
        }

        private void buttonFilePath_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            var dialogResult = dialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                textBoxFilePath.Text = dialog.FileName;
            }
        }

        private void buttonOutputFolder_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            var dialogResult = dialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                textBoxOutputFolder.Text = dialog.SelectedPath;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (ValidFile())
            {
                return;
            }

            var longImage = checkBoxLongImage.Checked;
            int totalHeight = 0;
            int maxWidth = 0;

            var document = new Document(textBoxFilePath.Text);
            CreatePageImages(longImage, ref totalHeight, ref maxWidth, document);

            if (longImage)
            {
                CreateLongImage(totalHeight, maxWidth, document);
            }
        }

        private void CreatePageImages(bool longImage, ref int totalHeight, ref int maxWidth, Document document)
        {
            foreach (var page in document.Pages)
            {
                var tempPath = $"{textBoxOutputFolder.Text}\\page{page.Number}_temp" + ".png";
                using var imageStream = new FileStream(tempPath, FileMode.Create);
                // Create Resolution object
                var resolution = new Resolution(300);
                // Create png device with specified attributes (Width, Height, Resolution)
                var pngDevice = new PngDevice(resolution);

                // Convert a particular page and save the image to stream
                pngDevice.Process(page, imageStream);

                //Remove watermark
                var bitmap = RemoveWatermark(imageStream);
                if (longImage)
                {
                    totalHeight += bitmap.Height;
                    maxWidth = Math.Max(maxWidth, bitmap.Width);
                }

                var filename = $"{textBoxOutputFolder.Text}\\page{page.Number}" + ".png";
                bitmap.Save(filename, ImageFormat.Png);

                // Close stream
                imageStream.Close();

                File.Delete(tempPath);
            }
        }

        private void CreateLongImage(int totalHeight, int maxWidth, Document document)
        {
            using var bitmapLong = new Bitmap(maxWidth, totalHeight);
            var graphics = Graphics.FromImage(bitmapLong);
            graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(0, 0, maxWidth, totalHeight));
            var currentHeight = 0;
            foreach (var page in document.Pages)
            {
                var filename = $"{textBoxOutputFolder.Text}\\page{page.Number}" + ".png";
                using var bitmap = new Bitmap(filename);
                graphics.DrawImage(bitmap, 0, currentHeight, bitmap.Width, bitmap.Height);
                currentHeight += bitmap.Height;
                bitmap.Dispose();
                File.Delete(filename);
            }

            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(textBoxFilePath.Text);
            var filenameLongImage = $"{textBoxOutputFolder.Text}\\{fileNameWithoutExtension}" + ".png";
            bitmapLong.Save(filenameLongImage, ImageFormat.Png);
        }

        private bool ValidFile()
        {
            var exists = File.Exists(textBoxFilePath.Text);
            if (!exists)
            {
                return false;
            }

            bool existsFolder = Directory.Exists(textBoxOutputFolder.Text);
            if (!existsFolder)
            {
                return false;
            }

            return true;
        }

        private static Bitmap RemoveWatermark(Stream imageStream)
        {
            var bitmap = new Bitmap(imageStream);
            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < 120; y++)
                {
                    bitmap.SetPixel(x, y, Color.White);
                }
            }

            return bitmap;
        }
    }
}