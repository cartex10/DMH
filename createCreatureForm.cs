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
        public createCreatureForm()
        {
            InitializeComponent();
        }

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
    }
}
