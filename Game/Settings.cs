using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проба_пера
{
    public class Settings
    {
        int MusicVolume { get; set; }
        int WidthWindow { get; set; }
        int HeightWindow { get; set; }

        public Size Resolution
        {
            get
            {
                return System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            }
        }
    }
}
