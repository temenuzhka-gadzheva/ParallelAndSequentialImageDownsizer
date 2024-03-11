using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ParallelImageScalerApp
{
    public partial class ParallelICustomImageScalerForm : Form
    {
        private static readonly string allowedFileFormatsToUpload   = "Allowed files to upload (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
        private static readonly string allowedFileFormatsToDownload = "JPEG Image|*.jpeg;*.jpg|PNG Image|*.png|Bitmap Image|*.bmp|GIF Image|*.gif|TIFF Image|*.tiff";
        public ParallelICustomImageScalerForm()
        {
            InitializeComponent();
            SetUpWinForm();
            DeactivateClearButton();
            DisableResizeButtons();
        }
        private void ChooseImageButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = allowedFileFormatsToUpload;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DisposeImage(originalPictureBox.Image);
                    originalPictureBox.Image = Image.FromFile(openFileDialog.FileName);
                }
            }

            EnableClearButton(originalPictureBox.Image);
            EnableResizeButtons();
            DisableChooseImageButton();
        }
        
        private void ResizeSequentialButton_Click(object sender, EventArgs e)
        {
            ShowErrorMessageIfNeeded(originalPictureBox.Image);

            var stopwatch                   = Stopwatch.StartNew();
            var convertScaleFactorToDouble  = ScaleFactorNumeric.Value / 100;
            var scaleFactor                 = (double)convertScaleFactorToDouble;
            var originalImageAsBitmap       = (Bitmap)originalPictureBox.Image;
            var sequentiallyDownsizedImage  = SequentialDownsizer.SequentiallyDownsizer(originalImageAsBitmap, scaleFactor);

            stopwatch.Stop();

            DisposeImage(resizedPictureBox.Image);

            resizedPictureBox.Image = sequentiallyDownsizedImage;

            ShowResizingTime("Sequential", stopwatch);
            ActivateClearButton();
            DisableResizeButtons();
        }

        private void ResizeParallelButton_Click(object sender, EventArgs e)
        {
            ShowErrorMessageIfNeeded(originalPictureBox.Image);

            var stopwatch                   = Stopwatch.StartNew();

            var convertScaleFactorToDouble  = ScaleFactorNumeric.Value / 100;
            var scaleFactor                 = (double)convertScaleFactorToDouble;
           
            var originalImageWidth          = originalPictureBox.Image.Width;
            var originalImageHeight         = originalPictureBox.Image.Height;
            
            var newImageWidth               = (int)(originalImageWidth * scaleFactor);
            var newImageHeight              = (int)(originalImageHeight * scaleFactor);

            var originalImageAsBitmap       = (Bitmap)originalPictureBox.Image;
            var resizedImageAsBitmap        = ThreadedDownsizer.ParallelDownsizer(originalImageAsBitmap, newImageWidth, newImageHeight);

            stopwatch.Stop();

            DisposeImage(resizedPictureBox.Image);

            resizedPictureBox.Image = resizedImageAsBitmap;

            ShowResizingTime("Parallel", stopwatch);
            ActivateClearButton();
            DisableResizeButtons();
        }
        
        private void ClearButton_Click(object sender, EventArgs e)
        {
            DisposeImageIfNeededAndClear(originalPictureBox);
            DisposeImageIfNeededAndClear(resizedPictureBox);
            DeactivateClearButton();
            DisableResizeButtons();
            EnableChooseImageButton();
        }

        private void DownloadResizedImage_Click(object sender, EventArgs e)
        {
            if (resizedPictureBox.Image == null) { MessageBox.Show("Ulpoad image"); return; }

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = allowedFileFormatsToDownload;
                saveFileDialog.Title  = "Save image as ...";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var extension   = Path.GetExtension(saveFileDialog.FileName).ToLowerInvariant();
                    var imageFormat = GetFormatToDownload(extension);

                    resizedPictureBox.Image.Save(saveFileDialog.FileName, imageFormat);
                    MessageBox.Show("Successfully downloaded");
                }
            }
        }
       
        private void SetUpWinForm()
        {
            var formSize = Screen.PrimaryScreen.Bounds;

            var calculatedWidth  = this.CalculateWinFormSize(formSize.Width);
            var calculatedHeight = this.CalculateWinFormSize(formSize.Height);

            var castedWidth      = (int)calculatedWidth;
            var castedHeight     = (int)calculatedHeight;

            this.Width           = castedWidth;
            this.Height          = castedHeight;
            this.StartPosition   = FormStartPosition.CenterScreen;
        }
        
        private double CalculateWinFormSize(double size) { return size * 0.8; }
        
        private void DisposeImage(Image image) { image?.Dispose(); }
        
        private void EnableClearButton(Image pictureBoxImage) { ClearButton.Enabled = pictureBoxImage != null; }

        private void ActivateClearButton() { ClearButton.Enabled = true; }
        
        private void DeactivateClearButton() { ClearButton.Enabled = false; }

        private void DisableChooseImageButton() { ChooseImageButton.Enabled = false; }
        
        private void EnableChooseImageButton() { ChooseImageButton.Enabled = true; }

        private void ShowErrorMessageIfNeeded(Image image)
        {
            if (image == null) { MessageBox.Show("There are not uploaded image"); return; }
        }
        
        // methodName => Parallel & Sequential
        private void ShowResizingTime(string methodName, Stopwatch stopwatch)
        {
            MessageBox.Show($"{methodName} resizing took {stopwatch.ElapsedMilliseconds} ms");
        }
        
        private void DisableResizeButtons()
        {
            ResizeSequentialButton.Enabled = false;
            ResizeParallelButton.Enabled = false;
        }
        
        private void EnableResizeButtons()
        {
            ResizeSequentialButton.Enabled = true;
            ResizeParallelButton.Enabled = true;
        }
       
        private void DisposeImageIfNeededAndClear(PictureBox pictureBox)
        {
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
                pictureBox.Image = null;
            }
        }
        
        private ImageFormat GetFormatToDownload(string extension)
        {
            if (extension == ".png")  return ImageFormat.Png;
            if (extension == ".bmp")  return ImageFormat.Bmp;
            if (extension == ".gif")  return ImageFormat.Gif;

            // Jpeg and Jpg are treated the same as Jpeg
            return extension == ".tiff" ? ImageFormat.Tiff : ImageFormat.Jpeg;
        }
    }
}
