using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проба_пера
{
    public class Enemy
    {
        public ProgressBar progressBar = new ProgressBar();
        public int Health { get; set; }
        static public int Damage
        {
            get
            {
                return 25;
            }
        }
        public PictureBox pictureBox = new PictureBox();

        public Enemy(int x, int y, int earthLevel, int health, Form form)
        {
            Health = health;
            pictureBox.Image = Image.FromFile(@"C:\Users\denis\source\repos\Проба пера\Проба пера\Sprites\Enemy1.png");
            pictureBox.Size = new Size(142, 298);
            pictureBox.Location = new Point(x, y);

            progressBar.Location = new Point(pictureBox.Location.X + 20, pictureBox.Top - 30);
            progressBar.Size = new Size(100, 20);
            progressBar.Minimum = 0;
            progressBar.Maximum = Health;
            progressBar.Value = Health;
            form.Controls.Add(pictureBox);
            form.Controls.Add(progressBar);
        }
    }
}
