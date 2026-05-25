using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro de convolución que retorna la imagen recibida con los bordes suavizados. Basado en
    /// https://en.wikipedia.org/wiki/Box_blur utilizando el kernel
    /// https://wikimedia.org/api/rest_v1/media/math/render/svg/91256bfeece3344f8602e288d445e6422c8b8a1c.
    /// </summary>
    public class FilterImageHadFace : IConditionalFilter
    {
        
        public bool Filter(IPicture image)
        {
            Ucu.Poo.Cognitive.CognitiveFace apiCog = new Ucu.Poo.Cognitive.CognitiveFace(true, Color.GreenYellow);
            apiCog.Recognize(@"luke.jpg");

            if (apiCog.FaceFound)
                return true;
            
            return false;
        }

    }
}