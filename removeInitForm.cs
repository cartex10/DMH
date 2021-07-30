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
    public partial class removeInitForm : Form
    {
        public removeInitForm(List<mainPage.Fighter> addList, mainPage original)
        {
            charList = addList;
            father = original;
            InitializeComponent();
            string nametext = "";
            foreach(mainPage.Fighter i in charList)
            {
                nametext += i.name + "\n";
            }
            creatureNameBox.Text = nametext;
        }

        public List<mainPage.Fighter> charList;
        public mainPage father;

        private void butt_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button butt = (System.Windows.Forms.Button)sender;
            if((string)butt.Tag == "remove")
            {
                
            }
        }
    }
}
