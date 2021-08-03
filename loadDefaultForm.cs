using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Dungeon_Master_Helper
{
    public partial class loadDefaultForm : Form
    {
        public loadDefaultForm()
        {
            chooseLabelList = new List<System.Windows.Forms.Label>();
            InitializeComponent();
            chooseLabelList.Add(this.label1);
            chooseLabelList[0].Text = TurnToName(Enum.GetName(typeof(monsters), 0));

            foreach (int i in Enum.GetValues(typeof(monsters)))
            {
                if (i != 0)
                {
                    chooseLabelList.Add(new System.Windows.Forms.Label
                    {
                        Anchor = System.Windows.Forms.AnchorStyles.Left,
                        AutoSize = true,
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                        Location = new System.Drawing.Point(3, 7),
                        Name = "label1",
                        Size = new System.Drawing.Size(51, 20),
                        TabIndex = 0,
                        Text = TurnToName(Enum.GetName(typeof(monsters), i)),
                        Margin = new System.Windows.Forms.Padding(3, 10, 3, 10),
                        Tag = i
                });
                    this.defaultTable.Controls.Add(chooseLabelList[i], 0, i);
                }
            }
        }

        public List<System.Windows.Forms.Label> chooseLabelList;
        public List<System.Windows.Forms.Label> chosenLabelList;
        public List<System.Windows.Forms.TableLayoutPanel> selectedToMoveList;
        public List<System.Windows.Forms.TableLayoutPanel> selectedToRemoveList;

        public string TurnToName(string input)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            return myTI.ToTitleCase(input.Replace('_', ' '));
        }
    }
}
