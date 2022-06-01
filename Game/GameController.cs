using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проба_пера
{
    public class GameController
    {
        public Player player;
        public List<Enemy> enemies = new();
        public Form nextForm;
        int speed = 10;
        public Form thisForm;
        public Door door;
        public Label label = new();
        public Label labelName = new();

        public void KeyboardControl(object sender, EventArgs e)
        {
            labelName.Text = thisForm.Name;
            labelName.Location = new Point(thisForm.Width / 2, 0);
            thisForm.Controls.Add(labelName);
            label.Text = player.Health.ToString();

            if (player.pictureBox.Location.X + player.pictureBox.Width > door.pictureBox.Location.X + 5 && Math.Abs(player.pictureBox.Location.Y - door.pictureBox.Location.Y) < 75 && door.isOpen)
            {
                door.isOpen = false;
                var gameForm = nextForm;
                gameForm.Show();
                thisForm.Close();
            }
            foreach (var el in enemies)
            {
                var enemy = el.pictureBox;
                if (Math.Abs(enemy.Location.X - player.pictureBox.Location.X) <= 200 && Math.Abs(enemy.Location.Y - player.pictureBox.Location.Y) <= 100 && player.Health > 0)
                {
                    player.Health -= 20;
                    label.Text = player.Health.ToString();
                    if (player.Health <= 0)
                    {
                        thisForm.Controls.Remove(player.pictureBox);
                        EndGameForm endGameForm = new() { ReturnForm = thisForm };
                        endGameForm.ShowDialog();
                    }
                }

                if (player.pictureBox.Location.Y < enemy.Location.Y - 10
                    && Math.Abs(player.pictureBox.Location.X - enemy.Location.X) < 500
                    && (player.pictureBox.Location.X > enemy.Location.X + 142 - 20 || player.pictureBox.Location.X + 142 < enemy.Location.X - 20
                     || player.pictureBox.Location.Y + 298 < enemy.Location.Y - 20 || player.pictureBox.Location.Y > enemy.Location.Y + 298 - 20))
                {
                    enemy.Location = new Point(enemy.Location.X, enemy.Location.Y - 10);
                    el.progressBar.Location = new Point(enemy.Location.X, enemy.Top - 30);
                }
                if (player.pictureBox.Location.Y > enemy.Location.Y + 10
                    && Math.Abs(player.pictureBox.Location.X - enemy.Location.X) < 500
                    && (!(player.pictureBox.Location.X + player.pictureBox.Width + 20 >= enemy.Location.X + 20 && player.pictureBox.Location.X <= enemy.Location.X + 142 + 20)
                    || player.pictureBox.Location.Y + 298 <= enemy.Location.Y + 20 || player.pictureBox.Location.Y >= enemy.Location.Y + 298 + 20))
                {
                    enemy.Image = new Bitmap(@"C:\Users\denis\source\repos\Проба пера\Проба пера\Sprites\Player1.png");
                    enemy.Location = new Point(enemy.Location.X, enemy.Location.Y + 10);
                    el.progressBar.Location = new Point(enemy.Location.X, enemy.Top - 30);
                }
                if (player.pictureBox.Location.X - enemy.Location.X < 500 && player.pictureBox.Location.X - enemy.Location.X > 200)
                {
                    enemy.Image = new Bitmap(@"C:\Users\denis\source\repos\Проба пера\Проба пера\Sprites\Player0.png");
                    enemy.Location = new Point(enemy.Location.X + 20, enemy.Location.Y);
                    el.progressBar.Location = new Point(enemy.Location.X + 20, enemy.Top - 30);
                }
                if (enemy.Location.X - player.pictureBox.Location.X < 500 && enemy.Location.X - player.pictureBox.Location.X > 200)
                {
                    enemy.Location = new Point(enemy.Location.X - 20, enemy.Location.Y);
                    el.progressBar.Location = new Point(enemy.Location.X + 20, enemy.Top - 30);
                }

            }
        }
    }
}
