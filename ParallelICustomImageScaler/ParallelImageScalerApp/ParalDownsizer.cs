using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ParallelImageScalerApp
{
    public class ParalDownsizer
    {
        public static Bitmap ParallelDownsizer(Bitmap originalImage, int width, int height)
        {
            var newResizedImage     = new Bitmap(width, height, PixelFormat.Format32bppRgb);

            var originalData        = originalImage.LockBits(
                                        new Rectangle(0, 0, originalImage.Width, originalImage.Height), 
                                        ImageLockMode.ReadOnly, 
                                        PixelFormat.Format32bppRgb
                                    );

            var resizedData         = newResizedImage.LockBits(
                                        new Rectangle(0, 0, width, height), 
                                        ImageLockMode.WriteOnly, 
                                        PixelFormat.Format32bppRgb
                                    );

            var bytesForPixel           = Image.GetPixelFormatSize(PixelFormat.Format32bppRgb) / 8;
            var originalImagePixels     = new byte[originalData.Stride * originalImage.Height];
            var newResizedImagePixels   = new byte[resizedData.Stride * height];

            Marshal.Copy(originalData.Scan0, originalImagePixels, 0, originalImagePixels.Length);

            var newImageWidth   = (float)originalImage.Width / width;
            var newImageHeight  = (float)originalImage.Height / height;

            Parallel.For(0, height, y =>
            {
                var resizedYOffset = y * resizedData.Stride;

                for (var x = 0; x < width; x++)
                {
                    var originalX      = (int)(x * newImageWidth);
                    var originalY      = (int)(y * newImageHeight);
                    var originalImageOffset = (originalY * originalData.Stride) + (originalX * bytesForPixel);

                    for (var bytePerIndex = 0; bytePerIndex < bytesForPixel; bytePerIndex++)
                    {
                        var index = resizedYOffset + (x * bytesForPixel) + bytePerIndex;

                        newResizedImagePixels[index] = originalImagePixels[originalImageOffset + bytePerIndex];
                    }
                }
            });

            Marshal.Copy(newResizedImagePixels, 0, resizedData.Scan0, newResizedImagePixels.Length);

            originalImage.UnlockBits(originalData);
            newResizedImage.UnlockBits(resizedData);

            return newResizedImage;
        }
    }
}

