using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проба_пера
{
    public class Player
    {
        public Side Side { get; set; }
        public int Health;
        public int Damage
        {
            get{ return 40;}
        }
        public PictureBox pictureBox = new PictureBox();
        public Image playerImg = new Bitmap(@"C:\Users\denis\source\repos\Проба пера\Проба пера\Sprites\Player0.png");

        public Player(int x, int y, int health, Side side)
        {
            pictureBox.Location = new Point(x, y);
            pictureBox.Image = playerImg;
            Side = side;
            pictureBox.Size = new Size(142, 298);
            Health = health;
        }
    }
}
