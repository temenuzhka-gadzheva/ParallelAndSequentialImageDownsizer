using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;

namespace ParallelImageScalerApp
{
    public class ThreadedDownsizer
    {
        public static Bitmap ParallelDownsizer(Bitmap originalImage, int width, int height)
        {
            var resizedNewImage     = new Bitmap(
                                                    width, 
                                                    height, 
                                                    PixelFormat.Format32bppRgb
                                                );
            var originalImageWidth  = originalImage.Width; 
            var originalImageHeight = originalImage.Height;
            var originalImageData   = originalImage.LockBits(
                                                           new Rectangle(0, 0, originalImageWidth, originalImageHeight),
                                                           ImageLockMode.ReadOnly,
                                                           PixelFormat.Format32bppRgb
                                                      );

            var resizedImageData    = resizedNewImage.LockBits(
                                                            new Rectangle(0, 0, width, height),
                                                            ImageLockMode.WriteOnly,
                                                            PixelFormat.Format32bppRgb
                                                      );

            var bytesPerPixel       = Image.GetPixelFormatSize(PixelFormat.Format32bppRgb) / 8;
            var originalPixels      = new byte[originalImageData.Stride * originalImageHeight];
            var newResizedPixels    = new byte[resizedImageData.Stride * height];

            Marshal.Copy(originalImageData.Scan0, originalPixels, 0, originalPixels.Length);

            var scaleX              = (float)originalImageWidth / width;
            var scaleY              = (float)originalImageHeight / height;

            var threadCount         = Environment.ProcessorCount;
            var threads             = new Thread[threadCount];

            for (var indexThread = 0; indexThread < threadCount; indexThread++)
            {
                int start           = indexThread * height / threadCount;
                int end             = (indexThread + 1) * height / threadCount;

                threads[indexThread] = new Thread(() =>
                {
                    for (var y = start; y < end; y++)
                    {
                        var resizedOffsetY = y * resizedImageData.Stride;

                        for (var x = 0; x < width; x++)
                        {
                            var originalX      = (int)(x * scaleX);
                            var originalY      = (int)(y * scaleY);
                            var originalOffset = (originalY * originalImageData.Stride) + (originalX * bytesPerPixel);

                            for (var indexByte = 0; indexByte < bytesPerPixel; indexByte++)
                            {
                                var index               = resizedOffsetY + (x * bytesPerPixel) + indexByte;
                                newResizedPixels[index] = originalPixels[originalOffset + indexByte];
                            }
                        }
                    }
                });

                threads[indexThread].Start();
            }

            JoinForAllThreads(threads);

            Marshal.Copy(newResizedPixels, 0, resizedImageData.Scan0, newResizedPixels.Length);

            originalImage.UnlockBits(originalImageData);
            resizedNewImage.UnlockBits(resizedImageData);

            return resizedNewImage;
        }

        private static void JoinForAllThreads(Thread[] threads)
        {
           foreach (var thread in threads)
           {
                thread.Join();
           }
        }
    }
}
