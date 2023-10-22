using System.Drawing.Imaging;
using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Devices;
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
            var exists = File.Exists(textBoxFilePath.Text);
            if (!exists)
            {
                return;
            }

            bool existsFolder = Directory.Exists(textBoxOutputFolder.Text);
            if (!existsFolder)
            {
                return;
            }

            var longImage = checkBoxLongImage.Checked;
            var document = new Document(textBoxFilePath.Text);
            
            foreach (var page in document.Pages)
            {
                var tempPath = $"{textBoxOutputFolder.Text}\\page{page.Number}_temp" + ".Png";
                using var imageStream = new FileStream(tempPath, FileMode.Create);
                // Create Resolution object
                var resolution = new Resolution(300);
                // Create PNG device with specified attributes (Width, Height, Resolution)
                var pngDevice = new PngDevice(resolution);

                // Convert a particular page and save the image to stream
                pngDevice.Process(page, imageStream);

                //Remove watermark
                Bitmap bitmap = RemoveWatermark(imageStream);

                var filename = $"{textBoxOutputFolder.Text}\\page{page.Number}" + ".Png";
                bitmap.Save(filename, ImageFormat.Png);

                // Close stream
                imageStream.Close();

                File.Delete(tempPath);
            }
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