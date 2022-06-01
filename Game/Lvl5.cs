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
    public partial class Lvl5 : Form
    {
        PlayerController playerController = new();
        GameController gameController = new();
        public Form ReturnForm;

        public Lvl5()
        {
            InitializeComponent();
            playerController.player = new Player(0, 580,100, Side.Right);
            playerController.form = this;

            gameController.player = playerController.player;
            gameController.enemies = playerController.enemies;
            gameController.nextForm = new Lvl6();
            gameController.thisForm = this;
            gameController.door = new Door(900, 1080 - 300, this);

            var playerPicBox = playerController.player.pictureBox;
            Controls.Add(playerPicBox);
            Controls.Add(gameController.label);

            playerController.enemies.Add(new Enemy(700, 580, 0, 100, this));
            playerController.enemies.Add(new Enemy(1100, 1080 - 300, 0, 100, this));
            playerController.enemies.Add(new Enemy(500, 300, 0, 100, this));

            timer1.Interval = 100;
            timer1.Tick += new EventHandler(gameController.KeyboardControl);
            timer1.Start();
            KeyDown += new KeyEventHandler(playerController.KeyboardControl);
        }
    }
}
