using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class LightOrDark
    {
        public static float getDarkorLight(Bitmap bm)
        {
            var colors = new List<Color>();
            for (int x = 0; x < bm.Size.Width; x++)
            {
                for (int y = 0; y < bm.Size.Height; y++)
                {
                    colors.Add(bm.GetPixel(x, y));
                }
            }

            return colors.Average(color => color.GetBrightness());            
        }
    }
}
