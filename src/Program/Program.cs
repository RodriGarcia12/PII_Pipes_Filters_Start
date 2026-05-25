using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using System.Drawing;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeSerial3 = new PipeSerial(new FilterBlurConvolution(), pipeNull);
            PipeSerial pipeSerial2 = new PipeSerial(new FilterNegative(), pipeSerial3);

            // Solo parte 1
            PipeSerial pipeSerial1 = new PipeSerial(new FilterGreyscale(), pipeNull);

            PictureProvider provider = new PictureProvider();
            IPicture pictureBase = provider.GetPicture(@"luke.jpg");

            // Guarda solo parte 1
            IPicture result = pipeSerial1.Send(pictureBase);
            provider.SavePicture(result, @"luke1.jpg");


            // Guarda parte 2 y parte 3
            IPicture picture = provider.GetPicture(@"luke1.jpg");
            result = pipeSerial2.Send(picture);
            provider.SavePicture(result, @"luke2.jpg");
            
            var apiTwitter = new Ucu.Poo.Twitter.TwitterImage();
            Console.WriteLine(apiTwitter.PublishToTwitter("Imagen Luke1", @"luke1.jpg"));
            Console.WriteLine(apiTwitter.PublishToTwitter("Imagen Luke2", @"luke2.jpg"));

            FilterImageHadFace filterImageHadFace = new FilterImageHadFace();
            bool imageHasFace = filterImageHadFace.Filter(pictureBase);
            Console.WriteLine($"La imagen tiene cara: {imageHasFace}");
            
        }
    }
}
