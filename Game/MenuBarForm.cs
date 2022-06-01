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
    public partial class MenuBarForm : Form
    {
        public Form ReturnForm;

        public MenuBarForm()
        {
            InitializeComponent();
        }
        
        private void Continue_Click(object sender, EventArgs e)
        {
            //Cursor.Hide();
            this.Hide();
        }

        private void Settings_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            ReturnForm.Close();
            this.Close();
            new MenuForm().Show();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\denis\source\repos\Проба пера\Проба пера\Saves\Saves.txt";
            string text = ReturnForm.Name;
            StreamWriter f = new StreamWriter(path);
            f.WriteLine(text);
            f.Close();
        }
    }
}
