using System.Drawing.Imaging;
using System.Drawing;
using System;

namespace ParallelImageScalerApp
{
    public class SequentialDownsizer
    {
        public static Bitmap SequentiallyDownsizer(Bitmap originalImage, double scaleFactor)
        {
            var originalImageWidth      = originalImage.Width;
            var originalImageHeight     = originalImage.Height;
            var newImageWidth           = (int)(originalImageWidth * scaleFactor);
            var newImageHeight          = (int)(originalImageHeight * scaleFactor);

            var downscaledImageAsBitmap = new Bitmap(
                                             newImageWidth,
                                             newImageHeight,
                                             PixelFormat.Format32bppArgb
                                         );

            var originalData            = originalImage.LockBits(
                                               new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                                               ImageLockMode.ReadOnly,
                                               PixelFormat.Format32bppArgb
                                          );

            var downsizedData           = downscaledImageAsBitmap.LockBits(
                                              new Rectangle(0, 0, newImageWidth, newImageHeight),
                                              ImageLockMode.WriteOnly,
                                              PixelFormat.Format32bppArgb
                                          );

            var bytesPerPixel           = 4;

            unsafe
            {
                byte* baseOriginalPixels = (byte*)originalData.Scan0;
                byte* downscaledPixels   = (byte*)downsizedData.Scan0;

                for (var y = 0; y < newImageHeight; y++)
                {
                    for (var x = 0; x < newImageWidth; x++)
                    {
                        var originalImageX = (int)(x / scaleFactor);
                        var originalImageY = (int)(y / scaleFactor);

                        var rangedWidth    = originalImage.Width - originalImageX;
                        var rangedHeight   = originalImage.Height - originalImageY;
                        var scaledFactor   = (int)Math.Ceiling(1 / scaleFactor);

                        var rangeWidth     = Math.Min(scaledFactor, rangedWidth);
                        var rangeHeight    = Math.Min(scaledFactor, rangedHeight);

                        // Variables for sum of colors and alpha
                        long sumRed = 0, sumGreen = 0, sumBlue = 0, sumAlpha = 0;

                        // Sum pixels for every color in the range of image
                        for (var newY = 0; newY < rangeHeight; newY++)
                        {
                            var newOffsetY          = originalImageY + newY;
                            byte* originalImageRow  = baseOriginalPixels + (newOffsetY * originalData.Stride);

                            for (var newX = 0; newX < rangeWidth; newX++)
                            {
                                var newOffsetX  = originalImageX + newX;
                                byte* pixel     = originalImageRow + (newOffsetX * bytesPerPixel);

                                sumBlue     += pixel[0]; // Blue
                                sumGreen    += pixel[1]; // Green
                                sumRed      += pixel[2]; // Red
                                sumAlpha    += pixel[3]; // Alpha
                            }
                        }

                        // Average color and alpha
                        var pixelCount      = rangeWidth * rangeHeight;
                        var averageRed      = (int)(sumRed / pixelCount);
                        var averageGreen    = (int)(sumGreen / pixelCount);
                        var averageBlue     = (int)(sumBlue / pixelCount);
                        var averageAlpa     = (int)(sumAlpha / pixelCount);

                        // Average color and alpha for downscaled image
                        byte* downscaledRow     = downscaledPixels + (y * downsizedData.Stride);
                        byte* downscaledPixel   = downscaledRow + (x * bytesPerPixel);

                        downscaledPixel[0] = (byte)averageBlue; // Blue
                        downscaledPixel[1] = (byte)averageGreen; // Green
                        downscaledPixel[2] = (byte)averageRed; // Red
                        downscaledPixel[3] = (byte)averageAlpa; // Alpha
                    }
                }
            }

            originalImage.UnlockBits(originalData);
            downscaledImageAsBitmap.UnlockBits(downsizedData);

            return downscaledImageAsBitmap;
        }
    }
}
