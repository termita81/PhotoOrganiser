using ImageMagick;
using System;

namespace PhotoOrganiser.Worker
{
    public interface IWorker
    {

    }

    public class Worker
    {
        public void Do()
        {
            var image = new MagickImage(@"c:\work\pix\nesortate\2015.02.13\20150213_185641.jpg");

            var exif = image.GetExifProfile();
            var thumbnail = exif.CreateThumbnail();
        }

        private void ResizeGif()
        {
            using (MagickImageCollection collection = new MagickImageCollection("SampleFiles.SnakewareGif"))
            {
                // This will remove the optimization and change the image to how it looks at that point
                // during the animation. More info here: http://www.imagemagick.org/Usage/anim_basics/#coalesce
                collection.Coalesce();

                // Resize each image in the collection to a width of 200. When zero is specified for the height
                // the height will be calculated with the aspect ratio.
                foreach (MagickImage image in collection)
                {
                    image.Resize(200, 0);
                }

                // Save the result
                collection.Write("SampleFiles.OutputDirectory" + "Snakeware.resized.gif");
            }
        }

        private void ResizeImage()
        {
            // Read from file
            using (MagickImage image = new MagickImage("SampleFiles.SnakewarePng"))
            {
                MagickGeometry size = new MagickGeometry(100, 100);
                // This will resize the image to a fixed size without maintaining the aspect ratio.
                // Normally an image will be resized to fit inside the specified size.
                size.IgnoreAspectRatio = true;

                image.Resize(size);

                // Save the result
                image.Write("SampleFiles.OutputDirectory" + "Snakeware.100x100.png");
            }
        }
    }
}
