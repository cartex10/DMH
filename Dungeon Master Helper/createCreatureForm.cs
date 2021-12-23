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


namespace Dungeon_Master_Helper
{
    public partial class createCreatureForm : Form
    {
        public createCreatureForm(mainPage inp)
        {
            this.father = inp;
            InitializeComponent();
        }

        public List<int> damageStr = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public bool playable = true;
        private mainPage father;

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
                dmg = damageStr,
                playable = playable,
                evasion = this.evasionCheckBox.Checked,
                max_hp = ToInt32(this.hpNumBox.Value),
                level = ToInt32(this.levelNumBox.Value),
                user_created = true
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
                string text1 = "Load this creature?";
                string text2 = "";
                var res = MessageBox.Show(text1, text2, MessageBoxButtons.YesNo);
                if(res == DialogResult.Yes)
                {
                    System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(mainPage.Creature));
                    System.IO.StreamReader file2 = new System.IO.StreamReader(saveFileDialog.FileName);
                    mainPage.Creature loaded = new mainPage.Creature();
                    loaded = (mainPage.Creature)reader.Deserialize(file2);
                    file.Close();
                    mainPage.Fighter toAdd = new mainPage.Fighter();
                    toAdd = loaded.Convert();
                    toAdd.id = this.father.nextLoadedID++;
                    this.father.addToEncounter(toAdd);
                }
                this.Close();
            }
        }

        private void EditDamageString(object sender, EventArgs e)
        {
            // TODO??? Dont know if this is working
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
*/              damageStr[index] = num;
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

        public void LoadFighter(mainPage.Fighter loader)
        {
            nameTextBox.Text = loader.name;
            levelNumBox.Value = ToInt32(loader.level);
            hpNumBox.Value = ToInt32(loader.max_hp);
            acNumBox.Value = ToInt32(loader.ac);
            ppNumBox.Value = ToInt32(loader.pp);
            strStatBox.Value = ToInt32(loader.str[0]);
            strMiscBox.Value = ToInt32(loader.str[1]);
            dexStatBox.Value = ToInt32(loader.dex[0]);
            dexMiscBox.Value = ToInt32(loader.dex[1]);
            conStatBox.Value = ToInt32(loader.con[0]);
            conMiscBox.Value = ToInt32(loader.con[1]);
            intStatBox.Value = ToInt32(loader.int_stat[0]);
            intMiscBox.Value = ToInt32(loader.int_stat[1]);
            wisStatBox.Value = ToInt32(loader.wis[0]);
            wisMiscBox.Value = ToInt32(loader.wis[1]);
            chaStatBox.Value = ToInt32(loader.cha[0]);
            chaMiscBox.Value = ToInt32(loader.cha[1]);
            
            if (loader.evasion) { evasionCheckBox.Checked = true; }
            int count = 0;
            foreach(int i in loader.dmg)
            {
                string dmgtype = Enum.GetName(typeof(mainPage.Damagetypes), count);
                System.Windows.Forms.Control panel = damageTable.Controls.Find(dmgtype + "Panel", true)[0];
                System.Windows.Forms.RadioButton butt = (System.Windows.Forms.RadioButton)panel.Controls.Find(dmgtype + "Butt" + i, true)[0];
                butt.Checked = true;
                damageStr[count] = i;
                count++;
            }
        }

        public void DisableAll()
        {
            nameTextBox.Enabled = false;
            levelNumBox.Enabled = false;
            hpNumBox.Enabled = false;
            acNumBox.Enabled = false;
            ppNumBox.Enabled = false;
            strStatBox.Enabled = false;
            strMiscBox.Enabled = false;
            dexStatBox.Enabled = false;
            dexMiscBox.Enabled = false;
            conStatBox.Enabled = false;
            conMiscBox.Enabled = false;
            intStatBox.Enabled = false;
            intMiscBox.Enabled = false;
            wisStatBox.Enabled = false;
            wisMiscBox.Enabled = false;
            chaStatBox.Enabled = false;
            chaMiscBox.Enabled = false;
            evasionCheckBox.Enabled = false;
            saveButton.Enabled = false;
            saveButton.Visible = false;
            for(int i = 0; i < 13; i++)
            {
                string dmgtype = Enum.GetName(typeof(mainPage.Damagetypes), i);
                System.Windows.Forms.Control panel = damageTable.Controls.Find(dmgtype + "Panel", true)[0];
                for(int j = 0; j < 4; j++)
                {
                    System.Windows.Forms.RadioButton butt = (System.Windows.Forms.RadioButton)panel.Controls.Find(dmgtype + "Butt" + j, true)[0];
                    butt.Enabled = false;
                }
            }
        }
    }
}
