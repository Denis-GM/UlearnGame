using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проба_пера
{
    public partial class LvlEnd : Form
    {
        PlayerController playerController = new();
        GameController gameController = new();
        public Form ReturnForm;
        bool win = true;

        public LvlEnd()
        {
            InitializeComponent();

            playerController.player = new Player(0, 720, 100, Side.Right);
            playerController.form = this;

            gameController.player = playerController.player;
            gameController.enemies = playerController.enemies;
            gameController.thisForm = this;
            gameController.door = new Door(1980, 580, this);

            var playerPicBox = playerController.player.pictureBox;
            Controls.Add(playerPicBox);
            Controls.Add(gameController.label);

            playerController.enemies.Add(new Enemy(800, 650, 0, 300, this));

            timer1.Interval = 100;
            timer1.Tick += new EventHandler(gameController.KeyboardControl);
            timer1.Tick += new EventHandler(vic);
            timer1.Start();
            KeyDown += new KeyEventHandler(playerController.KeyboardControl);

        }

        private void vic(object sender, EventArgs e)
        {
            if (gameController.enemies.Count == 0 && win)
            {
                win = false;
                new VicForm().ShowDialog();
            }
        }
    }
}
