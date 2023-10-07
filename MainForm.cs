using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Devices;

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

            var document = new Document(textBoxFilePath.Text);

            var watermarkAnnotations = document.Pages[1].Annotations
                .Where(a => a.AnnotationType == AnnotationType.Watermark)
                .Cast<WatermarkAnnotation>();

            foreach (var ca in watermarkAnnotations)
            {
                document.Pages[1].Annotations.Delete(ca);
            }

            foreach (var page in document.Pages)
            {
                //var rectWidth = (int)page.PageInfo.Width;
                //var rectHeight = (int)page.PageInfo.PureHeight;
                var rectWidth = 794;
                var rectHeight = 1123;
                var resolution = new Resolution(rectWidth, rectHeight);
                var pngDevice = new PngDevice(rectWidth, rectHeight, resolution);
                pngDevice.Process(document.Pages[page.Number], $"{textBoxOutputFolder.Text}\\image{page.Number}_out" + ".Png");
            }
        }

        private void MaintForm_Load(object sender, EventArgs e)
        {
            //new Aspose.Pdf.License().SetLicense(new MemoryStream(Convert.FromBase64String("PExpY2Vuc2U+CiAgPERhdGE+CiAgICA8TGljZW5zZWRUbz5TdXpob3UgQXVuYm94IFNvZnR3YXJlIENvLiwgTHRkLjwvTGljZW5zZWRUbz4KICAgIDxFbWFpbFRvPnNhbGVzQGF1bnRlYy5jb208L0VtYWlsVG8+CiAgICA8TGljZW5zZVR5cGU+RGV2ZWxvcGVyIE9FTTwvTGljZW5zZVR5cGU+CiAgICA8TGljZW5zZU5vdGU+TGltaXRlZCB0byAxIGRldmVsb3BlciwgdW5saW1pdGVkIHBoeXNpY2FsIGxvY2F0aW9uczwvTGljZW5zZU5vdGU+CiAgICA8T3JkZXJJRD4yMDA2MDIwMTI2MzM8L09yZGVySUQ+CiAgICA8VXNlcklEPjEzNDk3NjAwNjwvVXNlcklEPgogICAgPE9FTT5UaGlzIGlzIGEgcmVkaXN0cmlidXRhYmxlIGxpY2Vuc2U8L09FTT4KICAgIDxQcm9kdWN0cz4KICAgICAgPFByb2R1Y3Q+QXNwb3NlLlRvdGFsIGZvciAuTkVUPC9Qcm9kdWN0PgogICAgPC9Qcm9kdWN0cz4KICAgIDxFZGl0aW9uVHlwZT5FbnRlcnByaXNlPC9FZGl0aW9uVHlwZT4KICAgIDxTZXJpYWxOdW1iZXI+OTM2ZTVmZDEtODY2Mi00YWJmLTk1YmQtYzhkYzBmNTNhZmE2PC9TZXJpYWxOdW1iZXI+CiAgICA8U3Vic2NyaXB0aW9uRXhwaXJ5PjIwMjEwODI3PC9TdWJzY3JpcHRpb25FeHBpcnk+CiAgICA8TGljZW5zZVZlcnNpb24+My4wPC9MaWNlbnNlVmVyc2lvbj4KICAgIDxMaWNlbnNlSW5zdHJ1Y3Rpb25zPmh0dHBzOi8vcHVyY2hhc2UuYXNwb3NlLmNvbS9wb2xpY2llcy91c2UtbGljZW5zZTwvTGljZW5zZUluc3RydWN0aW9ucz4KICA8L0RhdGE+CiAgPFNpZ25hdHVyZT5wSkpjQndRdnYxV1NxZ1kyOHFJYUFKSysvTFFVWWRrQ2x5THE2RUNLU0xDQ3dMNkEwMkJFTnh5L3JzQ1V3UExXbjV2bTl0TDRQRXE1aFAzY2s0WnhEejFiK1JIWTBuQkh1SEhBY01TL1BSeEJES0NGbWg1QVFZRTlrT0FxSzM5NVBSWmJRSGowOUNGTElVUzBMdnRmVkp5cUhjblJvU3dPQnVqT1oyeDc4WFE9PC9TaWduYXR1cmU+CjwvTGljZW5zZT4=")));
        }
    }
}