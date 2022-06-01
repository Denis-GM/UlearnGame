using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проба_пера
{
    public class CheckMoves
    {
        static public bool CheckMoveForward(List<Enemy> listObjects, PictureBox playerPic)
        {
            return listObjects.All(enemy =>
                     playerPic.Location.X + 10 + 142 < enemy.pictureBox.Location.X || playerPic.Location.X > enemy.pictureBox.Location.X + 142
                     || playerPic.Location.Y + 298 < enemy.pictureBox.Location.Y || playerPic.Location.Y > enemy.pictureBox.Location.Y + 298);
        }
        static public bool CheckMoveBack(List<Enemy> listObjects, PictureBox playerPic)
        {
            return listObjects.All(enemy =>
                     playerPic.Location.X - 10 > enemy.pictureBox.Location.X + 142 || playerPic.Location.X + 142 - 10 < enemy.pictureBox.Location.X
                     || playerPic.Location.Y + 298 < enemy.pictureBox.Location.Y || playerPic.Location.Y > enemy.pictureBox.Location.Y + 298);
        }
        static public bool CheckMoveUp(List<Enemy> listObjects, PictureBox playerPic)
        {
            return listObjects.All(enemy => !(playerPic.Location.X + 142 > enemy.pictureBox.Location.X && playerPic.Location.X < enemy.pictureBox.Location.X + 142)
                    || playerPic.Location.Y - 10 >= enemy.pictureBox.Location.Y + 298 || playerPic.Location.Y - 10 + 298 <= enemy.pictureBox.Location.Y);
        }
        static public bool CheckMoveDown(List<Enemy> listObjects, PictureBox playerPic)
        {
            return listObjects.All(enemy => !(playerPic.Location.X + 142 >= enemy.pictureBox.Location.X && playerPic.Location.X <= enemy.pictureBox.Location.X + 142)
                    || playerPic.Location.Y + 298 + 10 <= enemy.pictureBox.Location.Y || playerPic.Location.Y + 10 >= enemy.pictureBox.Location.Y + 298);
        }
    }
}
