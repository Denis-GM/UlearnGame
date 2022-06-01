using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проба_пера
{
    public class Door
    {
        public bool isOpen = true;
        public PictureBox pictureBox = new PictureBox();
        public Door(int x, int y, Form form)
        {
            Image playerImg = new Bitmap(@"C:\Users\denis\source\repos\Проба пера\Проба пера\Sprites\Door.png");
            pictureBox.Location = new Point(x, y);
            pictureBox.Image = playerImg;
            pictureBox.Size = new Size(199, 300);
            form.Controls.Add(pictureBox);

            pictureBox.BackColor = Color.Transparent;
        }
    }
}
