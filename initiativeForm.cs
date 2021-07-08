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
    public partial class initiativeForm : Form
    {
        public initiativeForm(List<mainPage.Fighter> addList)
        {
            bool first = true;
            InitializeComponent();
            foreach (mainPage.Fighter toAdd in addList)
            {
                if (first)
                {
                    first = false;
                    this.initNameLabel.Text = toAdd.name;
                    this.initNumBox.Value = toAdd.dex[2];
                    this.baseTable.Tag = toAdd.id;
                    this.initNameLabel.Tag = toAdd.id;
                    this.initNumBox.Tag = toAdd.id;

                    initTableList = new List<TableLayoutPanel>
                    {
                        this.baseTable
                    };

                    initNameList = new List<System.Windows.Forms.Label>
                    {
                        this.initNameLabel
                    };

                    initNumList = new List<System.Windows.Forms.NumericUpDown>
                    {
                        this.initNumBox
                    };
                }
                else
                {
                    Clone(toAdd);
                }
            }
        }

        public List<System.Windows.Forms.TableLayoutPanel> initTableList;
        public List<System.Windows.Forms.Label> initNameList;
        public List<System.Windows.Forms.NumericUpDown> initNumList;
        public int index = 1;

        public void Clone(mainPage.Fighter toAdd)
        {
            string str = Convert.ToString(index);
            initTableList.Add(new System.Windows.Forms.TableLayoutPanel
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right))),
                ColumnCount = 2,
                Location = new System.Drawing.Point(4, 4),
                Name = "baseTable" + str,
                RowCount = 1,
                Size = new System.Drawing.Size(281, 37),
                TabIndex = 0
            });
            initTableList[index].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.59567F));
            initTableList[index].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.40433F));
            initTableList[index].RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));

            initNameList.Add(new System.Windows.Forms.Label
            {
                Anchor = System.Windows.Forms.AnchorStyles.None,
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 15F),
                Location = new System.Drawing.Point(10, 6),
                Name = "initNameLabel" + str,
                Size = new System.Drawing.Size(136, 25),
                TabIndex = 0,
                Text = toAdd.name
            });
            initTableList[index].Controls.Add(initNameList[index], 0, index);

            initNumList.Add(new System.Windows.Forms.NumericUpDown
            {
                Anchor = System.Windows.Forms.AnchorStyles.None,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 15F),
                Location = new System.Drawing.Point(188, 3),
                Name = "initNumBox" + str,
                Size = new System.Drawing.Size(60, 30),
                TabIndex = 1,
                Value = toAdd.dex[2]
            });
            initTableList[index].Controls.Add(initNumList[index], 1, index);

            index++;
            return;
        }
    }
}
