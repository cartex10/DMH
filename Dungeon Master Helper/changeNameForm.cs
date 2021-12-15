using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dungeon_Master_Helper
{
    public partial class changeNameForm : Form
    {
        public changeNameForm(mainPage.Fighter fighter, TableLayoutPanel table)
        {
            savedFighter = fighter;
            savedTable = table;
            InitializeComponent();
            label1.Text = label1.Text + fighter.name;
        }

        public mainPage.Fighter savedFighter;
        public TableLayoutPanel savedTable;

        private void ButtClick(object sender, EventArgs e)
        {
            Button butt = (Button)sender;
            if(butt.Text.Equals("Accept"))
            {
                Console.WriteLine("test1");
                if (nameBox.Text.Equals(""))
                {
                    MessageBox.Show("No name inputted", "Error");
                    return;
                }
                else
                {
                    savedFighter.name = nameBox.Text;
                    foreach (Control control in savedTable.Controls)
                    {
                        if (Convert.ToString(control.Tag) == "name") { control.Text = nameBox.Text; }
                    }
                }
            }
            this.Close();
            return;
        }
    }
}
