﻿using System;
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
    public partial class Lvl3 : Form
    {
        PlayerController playerController = new();
        GameController gameController = new();
        public Form ReturnForm;

        public Lvl3()
        {
            InitializeComponent();
            playerController.player = new Player(0, 580, 100, Side.Right);
            playerController.form = this;

            gameController.player = playerController.player;
            gameController.enemies = playerController.enemies;
            gameController.nextForm = new Lvl4();
            gameController.thisForm = this;
            gameController.door = new Door(Right - 190, 500, this);

            var playerPicBox = playerController.player.pictureBox;
            Controls.Add(playerPicBox);
            Controls.Add(gameController.label);

            playerController.enemies.Add(new Enemy(800, 580, 0, 100, this));
            playerController.enemies.Add(new Enemy(1300, 720, 0, 100, this));
            playerController.enemies.Add(new Enemy(1400, 320, 0, 100, this));
            playerController.enemies.Add(new Enemy(600, 120, 0, 100, this));

            timer1.Interval = 100;
            timer1.Tick += new EventHandler(gameController.KeyboardControl);
            timer1.Start();
            KeyDown += new KeyEventHandler(playerController.KeyboardControl);
        }
    }
}
