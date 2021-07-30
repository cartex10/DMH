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
        public removeInitForm(List<mainPage.Fighter> remList, mainPage original)
        {
            charList = remList;
            father = original;
            InitializeComponent();
            foreach(mainPage.Fighter i in charList)
            {
                creatureNameBox.AppendText(i.name);
                creatureNameBox.AppendText(Environment.NewLine);
            }
        }

        public List<mainPage.Fighter> charList;
        public mainPage father;

        private void butt_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button butt = (System.Windows.Forms.Button)sender;
            if((string)butt.Tag == "remove")
            {
                foreach(mainPage.Fighter i in charList)
                {
                    var fighter = father.fighterList.Find(r => Convert.ToString(r.id) == Convert.ToString(i.id));
                    fighter.init_roll = -9;
                    father.RemoveFromInitiative(fighter);
                }
            }
            this.Close();
        }
    }
}
