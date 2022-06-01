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
    public partial class Lvl1 : Form
    {
        PlayerController playerController = new();
        GameController gameController = new();
        public Form ReturnForm;


        public Lvl1()
        {
            InitializeComponent();
            //Cursor.Hide();

            playerController.player = new Player(0, 720, 100, Side.Right);
            playerController.form = this;

            gameController.player = playerController.player;
            gameController.enemies = playerController.enemies;
            gameController.nextForm = new Lvl2();
            gameController.thisForm = this;
            gameController.door = new Door(1980 - 260, 580, this);

            var playerPicBox = playerController.player.pictureBox;
            Controls.Add(playerPicBox);
            Controls.Add(gameController.label);

            playerController.enemies.Add(new Enemy(800, 580, 0, 100, this));
            playerController.enemies.Add(new Enemy(1500, 720, 0, 100, this));

            timer1.Interval = 100;
            timer1.Tick += new EventHandler(gameController.KeyboardControl);
            timer1.Start();
            KeyDown += new KeyEventHandler(playerController.KeyboardControl);

        }
    }
}
