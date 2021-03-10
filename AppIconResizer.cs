using System;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AngularAppImageResizer
{
    internal class AppIconResizer
    {
        public AppIconResizer(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Missing input image");
                return;
            }
            string[] sizes;
            if (args.Length > 1)
                sizes = args.Skip(1).ToArray();
            else
                sizes = new string[] { "72", "96", "128", "144", "152", "192", "384", "512" };


            var file = args[0];
            BitmapImage bitmapSource = new BitmapImage();
            bitmapSource.BeginInit();
            bitmapSource.UriSource = new Uri(file);
            bitmapSource.EndInit();

            foreach (var sedge in sizes)
            {
                int edge = 0;
                if (int.TryParse(sedge, out edge))
                {
                    resizeAndWrite(bitmapSource, edge);
                }
                else
                {
                    Console.WriteLine($"Invalid size: '{sedge}' ");
                }

            }
            Console.ReadKey();
        }

        private static void resizeAndWrite(BitmapImage bitmapSource, int edge)
        {
            var scale = (double)edge / (double)bitmapSource.PixelWidth;
            var newBitmap = new TransformedBitmap(bitmapSource,
                    new ScaleTransform(scale, scale));

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(newBitmap));
            using (var ms = new MemoryStream())
            {
                encoder.Save(ms);
                var bytes = ms.ToArray();
                var fn = $"icon-{edge}x{edge}.png";
                File.WriteAllBytes(fn, bytes);
                Console.WriteLine($"Created file: '{fn}' ");
            }
        }
    }
}