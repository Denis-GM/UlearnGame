using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проба_пера
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            var settingsGame = new Settings();
            Cursor.Show();
            this.Size = settingsGame.Resolution;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackgroundImageLayout = ImageLayout.Tile;
            //BackgroundImage = Image.FromFile(@"C:\Users\denis\source\repos\Проба пера\Проба пера\Sprites\Фон.png");
            string path = @"C:\Users\denis\source\repos\Проба пера\Проба пера\Saves\Saves.txt";

            this.WindowState = FormWindowState.Maximized;

            var buttonStart = new Button();
            var buttonSettings = new Button();
            var buttonExit = new Button();
            var buttonDownload = new Button();

            Controls.Add(buttonStart);
            Controls.Add(buttonDownload);
            Controls.Add(buttonSettings);
            Controls.Add(buttonExit);

            buttonStart.Text = "Начать новую игру";
            buttonStart.Size = new Size(200, 100);
            buttonStart.Location = new Point(ClientSize.Width / 2 - 100, 350);
            buttonStart.Click += (sender, args) =>
            {
                File.WriteAllText(path, string.Empty);
                var gameForm1 = new Lvl1() { ReturnForm = this };
                //Cursor.Hide();
                this.Hide();
                gameForm1.ShowDialog();
            };

            buttonDownload.Text = "Продолжить";
            buttonDownload.Size = new Size(200, 100);
            buttonDownload.Location = new Point(ClientSize.Width / 2 - 100, buttonStart.Bottom + 50);
            buttonDownload.Click += (sender, args) =>
            {
                StreamReader f = new StreamReader(path);
                string text = f.ReadLine();
                f.Close();
                Form gameForm;
                if (text == "Lvl1")
                    gameForm = new Lvl1() { ReturnForm = this };
                if (text == "Lvl2")
                    gameForm = new Lvl2() { ReturnForm = this };
                if (text == "Lvl3")
                    gameForm = new Lvl3() { ReturnForm = this };
                if (text == "Lvl4")
                    gameForm = new Lvl4() { ReturnForm = this };
                if (text == "Lvl5")
                    gameForm = new Lvl5() { ReturnForm = this };
                if (text == "Lvl6")
                    gameForm = new Lvl6() { ReturnForm = this };
                else
                    gameForm = new LvlEnd() { ReturnForm = this };
                this.Hide();
                gameForm.ShowDialog();
            };

                buttonSettings.Text = "Настройки";
            buttonSettings.Size = new Size(200, 100);
            buttonSettings.Location = new Point(ClientSize.Width / 2 - 100, buttonDownload.Bottom + 50);
            buttonSettings.Click += (sender, args) =>
            {
                //var formSettings = new SettingsForm();
                //formSettings.ShowDialog();
            };

            buttonExit.Text = "Выход";
            buttonExit.Size = new Size(200, 100);
            buttonExit.Location = new Point(ClientSize.Width / 2 - 100, buttonSettings.Bottom + 50);
            buttonExit.Click += (sender, args) =>
            {
                Application.Exit();
            };
        }
    }
}
