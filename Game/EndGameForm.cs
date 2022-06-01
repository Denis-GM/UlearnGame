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
    public partial class EndGameForm : Form
    {
        public Form ReturnForm;
        public EndGameForm()
        {
            InitializeComponent();
            Cursor.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var gameForm1 = new Lvl1() { ReturnForm = this };
            //Cursor.Hide();
            this.Close();
            gameForm1.Show();
            ReturnForm.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReturnForm.Close(); // здесь сохранять
            //ReturnForm.Hide(); // здесь сохранять
            this.Close();
            new MenuForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
