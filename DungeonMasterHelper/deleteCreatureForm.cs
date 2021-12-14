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
    public partial class deleteCreatureForm : Form
    {
        public deleteCreatureForm(List<mainPage.Fighter> remList)
        {
            charList = remList;
            InitializeComponent();
            foreach(mainPage.Fighter i in charList)
            {
                creatureNameBox.AppendText(i.name);
                creatureNameBox.AppendText(Environment.NewLine);
            }
        }

        public List<mainPage.Fighter> charList;

        private void butt_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "Delete") { this.DialogResult = DialogResult.OK; }
            if (((Button)sender).Text == "Cancel") { this.DialogResult = DialogResult.Cancel; }
            this.Close();
        }
    }
}
