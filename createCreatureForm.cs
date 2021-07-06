using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Convert;
//using System.
//using System.Text.Json.Serialization;


namespace Dungeon_Master_Helper
{
    public partial class createCreatureForm : Form
    {
        public createCreatureForm()
        {
            InitializeComponent();
        }

        public List<int> damageStr = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public bool playable = true;

        private void CalculateStats(object sender, EventArgs e)
        {
            System.Windows.Forms.NumericUpDown item = (System.Windows.Forms.NumericUpDown)sender;
            string tag = (string)item.Tag;
            decimal num;
            string text;

            switch (tag)
            {
                case "str":
                    num = (Math.Floor((this.strStatBox.Value - 10) / 2)) + this.strMiscBox.Value;
                    text = Convert.ToString(num);
                    if (num >= 0)
                    {
                        text = "+" + text;
                    }
                    this.strModBox.Text = text;
                    break;
                case "dex":
                    num = (Math.Floor((this.dexStatBox.Value - 10) / 2)) + this.dexMiscBox.Value;
                    text = Convert.ToString(num);
                    if (num >= 0)
                    {
                        text = "+" + text;
                    }
                    this.dexModBox.Text = text;
                    break;
                case "con":
                    num = (Math.Floor((this.conStatBox.Value - 10) / 2)) + this.conMiscBox.Value;
                    text = Convert.ToString(num);
                    if (num >= 0)
                    {
                        text = "+" + text;
                    }
                    this.conModBox.Text = text;
                    break;
                case "int":
                    num = (Math.Floor((this.intStatBox.Value - 10) / 2)) + this.intMiscBox.Value;
                    text = Convert.ToString(num);
                    if (num >= 0)
                    {
                        text = "+" + text;
                    }
                    this.intModBox.Text = text;
                    break;
                case "wis":
                    num = (Math.Floor((this.wisStatBox.Value - 10) / 2)) + this.wisMiscBox.Value;
                    text = Convert.ToString(num);
                    if (num >= 0)
                    {
                        text = "+" + text;
                    }
                    this.wisModBox.Text = text;
                    break;
                case "cha":
                    num = (Math.Floor((this.chaStatBox.Value - 10) / 2)) + this.chaMiscBox.Value;
                    text = Convert.ToString(num);
                    if (num >= 0)
                    {
                        text = "+" + text;
                    }
                    this.chaModBox.Text = text;
                    break;
            }
            
        }

        private void DamageHover(object sender, EventArgs e)
        {
            System.Windows.Forms.PictureBox item = (System.Windows.Forms.PictureBox)sender;
            string tag = (string)item.Tag;
            damageTooltip.SetToolTip(item, tag + " damage");
        }

        private void SaveCreature(object sender, EventArgs e)
        {
            int strMod = ToInt32((Math.Floor((this.strStatBox.Value - 10) / 2)) + this.strMiscBox.Value);
            var strList = new List<int>
            {
                ToInt32(this.strStatBox.Value),
                ToInt32(this.strMiscBox.Value),
                ToInt32(strMod)
            };

            int dexMod = ToInt32((Math.Floor((this.dexStatBox.Value - 10) / 2)) + this.dexMiscBox.Value);
            var dexList = new List<int>
            {
                ToInt32(this.dexStatBox.Value),
                ToInt32(this.dexMiscBox.Value),
                ToInt32(dexMod)
            };

            int conMod = ToInt32((Math.Floor((this.conStatBox.Value - 10) / 2)) + this.conMiscBox.Value);
            var conList = new List<int>
            {
                ToInt32(this.conStatBox.Value),
                ToInt32(this.conMiscBox.Value),
                ToInt32(conMod)
            };

            int intMod = ToInt32((Math.Floor((this.intStatBox.Value - 10) / 2)) + this.intMiscBox.Value);
            var intList = new List<int>
            {
                ToInt32(this.intStatBox.Value),
                ToInt32(this.intMiscBox.Value),
                ToInt32(intMod)
            };

            int wisMod = ToInt32((Math.Floor((this.wisStatBox.Value - 10) / 2)) + this.wisMiscBox.Value);
            var wisList = new List<int>
            {
                ToInt32(this.wisStatBox.Value),
                ToInt32(this.wisMiscBox.Value),
                ToInt32(wisMod)
            };

            int chaMod = ToInt32((Math.Floor((this.chaStatBox.Value - 10) / 2)) + this.chaMiscBox.Value);
            var chaList = new List<int>
            {
                ToInt32(this.chaStatBox.Value),
                ToInt32(this.chaMiscBox.Value),
                ToInt32(chaMod)
            };

            List<int> dmg = damageStr;

            var toSave = new mainPage.Creature
            {
                name = this.nameTextBox.Text,
                ac = ToInt32(this.acNumBox.Value),
                pp = ToInt32(this.ppNumBox.Value),
                str = strList,
                dex = dexList,
                con = conList,
                wis = wisList,
                int_stat = intList,
                cha = chaList,
                dmg = dmg,
                playable = playable,
                evasion = this.evasionCheckBox.Checked,
                max_hp = ToInt32(this.hpNumBox.Value),
                level = ToInt32(this.levelNumBox)
            };

            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(mainPage.Creature));
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog
            {
                DefaultExt = "xml",
                Filter = "XML files (*.xml)|*.creature.xml",
                Title = "Save Creature",
                AddExtension = true,
                SupportMultiDottedExtensions = true
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName != "")
            {
                System.IO.FileStream file = System.IO.File.Create(saveFileDialog.FileName);
                writer.Serialize(file, toSave);
                file.Close();
                this.Close();
            }
        }

        private void EditDamageString(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton item = (System.Windows.Forms.RadioButton)sender;
            if (item.Checked)
            {
                string[] thesplit = ((string)item.Tag).Split(' ');
                Enum.TryParse(thesplit[0], out mainPage.Damagetypes type);
                int num = ToInt32(thesplit[1]);
                int index = (int)type;
/*                string newdmg = "";
                foreach(int i in damageStr)
                {
                    if(i == index)
                    {
                        newdmg += num;
                    }
                    else
                    {
                        newdmg += damageStr[i];
                    }
                }
*/                damageStr[index] = num;
            }
            
        }

        private void PcCheck(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton item = (System.Windows.Forms.RadioButton)sender;
            if (item.Checked)
            {
                switch (item.Name)
                {
                    case "pcButt":
                        playable = true;
                        break;
                    case "npcButt":
                        playable = false;
                        break;
                }
            }
        }
    }
}
