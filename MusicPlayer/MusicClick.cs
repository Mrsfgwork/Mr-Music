using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MusicPlayer
{
    class MusicClick:Border
    {
        private string murl;
        private Label image;

        public string Link
        {
            get
            {
                return murl;
            }
            set
            {
                murl = value;
            }
        }

        public Label Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }
    }
}
