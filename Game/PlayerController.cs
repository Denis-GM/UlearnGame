using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проба_пера
{
    public class PlayerController
    {
        public Player player;
        public List<Enemy> enemies = new();
        int speed = 10;
        public Form form;
        public void KeyboardControl(object sender, KeyEventArgs e)
        {
            int x1 = player.pictureBox.Location.X;                                      // Левый край контрола
            int x2 = player.pictureBox.Location.X + player.pictureBox.Size.Width;       // Правый край контрола
            int y1 = player.pictureBox.Location.Y;                                      // Верхний край контрола
            int y2 = player.pictureBox.Location.Y + player.pictureBox.Size.Height;      // Нижний край контрола

            if (e.KeyValue == (char)Keys.Escape)
            {
                MenuBarForm menuBarForm = new() { ReturnForm = form };
                Cursor.Show();
                menuBarForm.ShowDialog();
            }
            switch (e.KeyCode.ToString())
            {
                case "D":
                    if (CheckMoves.CheckMoveForward(enemies, player.pictureBox) &&
                        x2 + speed <= form.Size.Width)
                    {
                        player.pictureBox.Location = new Point(player.pictureBox.Location.X + 10, player.pictureBox.Location.Y);
                    }
                    player.Side = Side.Right;
                    player.pictureBox.Image = new Bitmap(@"C:\Users\denis\source\repos\Проба пера\Проба пера\Sprites\Player0.png");
                    break;
                case "A":
                    if (CheckMoves.CheckMoveBack(enemies, player.pictureBox) &&
                        x1 - speed >= 0)
                    {
                        player.pictureBox.Location = new Point(player.pictureBox.Location.X - 10, player.pictureBox.Location.Y);
                    }
                    player.Side = Side.Left;
                    player.pictureBox.Image = new Bitmap(@"C:\Users\denis\source\repos\Проба пера\Проба пера\Sprites\Player1.png");
                    break;
                case "W":
                    if (CheckMoves.CheckMoveUp(enemies, player.pictureBox) &&
                        y1 - speed >= 0)
                        player.pictureBox.Location = new Point(player.pictureBox.Location.X, player.pictureBox.Location.Y - 10);
                    break;
                case "S":
                    if (CheckMoves.CheckMoveDown(enemies, player.pictureBox) &&
                        y2 + speed <= form.Size.Height)
                        player.pictureBox.Location = new Point(player.pictureBox.Location.X, player.pictureBox.Location.Y + 10);
                    break;
                case "Space":
                    var enemies1 = enemies
                    .Where(enemy => ((enemy.pictureBox.Location.X - player.pictureBox.Location.X) < 250 && player.Side == Side.Right && (enemy.pictureBox.Location.X - player.pictureBox.Location.X) > 0
                    || (player.pictureBox.Location.X - enemy.pictureBox.Location.X) < 250 && player.Side == Side.Left && (player.pictureBox.Location.X - enemy.pictureBox.Location.X) > 0)
                    && player.pictureBox.Location.Y <= enemy.pictureBox.Location.Y + 298
                    && player.pictureBox.Location.Y + 200 > enemy.pictureBox.Location.Y)
                    .ToList();
                    foreach (var el in enemies1)
                    {
                        el.Health -= player.Damage;
                        if (el.Health >= 0)
                            el.progressBar.Value = el.Health;
                        else el.progressBar.Value = 0;
                        if (el.Health <= 0)
                        {
                            form.Controls.Remove(el.pictureBox);
                            form.Controls.Remove(el.progressBar);
                            enemies.Remove(el);
                            continue;
                        }
                    }
                    break;

            }
        }
    }
}
