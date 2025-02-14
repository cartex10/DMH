﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace Dungeon_Master_Helper
{
    public partial class loadDefaultForm : Form
    {
        public loadDefaultForm(mainPage inp)
        {
            father = inp;
            leftPanelList = new List<System.Windows.Forms.FlowLayoutPanel>();
            leftLabelList = new List<System.Windows.Forms.Label>();
            leftSelectedList = new List<System.Windows.Forms.FlowLayoutPanel>();
            rightPanelList = new List<System.Windows.Forms.FlowLayoutPanel>();
            rightLabelList = new List<System.Windows.Forms.Label>();
            rightSelectedList = new List<System.Windows.Forms.FlowLayoutPanel>();
            numBoxList = new List<System.Windows.Forms.NumericUpDown>();
            InitializeComponent();

            leftPanelList.Add(this.flowLayoutPanel1);
            leftPanelList[0].Tag = Enum.GetName(typeof(monsters), 0) + " left";
            leftLabelList.Add(this.label1);
            leftLabelList[0].Text = TurnToName(Enum.GetName(typeof(monsters), 0));
            leftLabelList[0].Tag = Enum.GetName(typeof(monsters), 0);

            foreach (int i in Enum.GetValues(typeof(monsters)))
            {
                if (i != 0)
                {
                    leftPanelList.Add(new System.Windows.Forms.FlowLayoutPanel
                    {
                        Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right))),
                        Location = new System.Drawing.Point(4, 4),
                        Name = "flowLayoutPanel1",
                        Size = new System.Drawing.Size(239, 34),
                        TabIndex = 1,
                        Tag = Enum.GetName(typeof(monsters), i) + " left",
                        Margin = new System.Windows.Forms.Padding(0)
                    });
                    defaultTable.Controls.Add(leftPanelList[i], 0, i);
                    leftPanelList[i].Click += new System.EventHandler(this.Select);

                    leftLabelList.Add(new System.Windows.Forms.Label
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
                        Tag = Enum.GetName(typeof(monsters), i)
                    });
                    leftPanelList[i].Controls.Add(leftLabelList[i]);
                    leftLabelList[i].Click += new System.EventHandler(this.Select);
                }
            }
        }

        private mainPage father;
        public List<System.Windows.Forms.FlowLayoutPanel> leftPanelList;
        public List<System.Windows.Forms.Label> leftLabelList;
        public List<System.Windows.Forms.FlowLayoutPanel> leftSelectedList;
        public List<System.Windows.Forms.FlowLayoutPanel> rightPanelList;
        public List<System.Windows.Forms.Label> rightLabelList;
        public List<System.Windows.Forms.FlowLayoutPanel> rightSelectedList;
        public List<System.Windows.Forms.NumericUpDown> numBoxList;

        public int selecting = 0;

        public string TurnToName(string input)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            return myTI.ToTitleCase(input.Replace('_', ' '));
        }

        private void Select(object sender, EventArgs e)
        {
            var type = sender.GetType();
            System.Windows.Forms.FlowLayoutPanel mainTable;
            if(Convert.ToString(type) == "System.Windows.Forms.FlowLayoutPanel") { mainTable = (System.Windows.Forms.FlowLayoutPanel)sender; }
            else if(Convert.ToString(type) == "System.Windows.Forms.Label") { mainTable = (System.Windows.Forms.FlowLayoutPanel)(((System.Windows.Forms.Label)sender).Parent); }
            else 
            {
                Console.WriteLine(type);
                return;
            }

            string[] taglist = mainTable.Tag.ToString().Split(' ');
            if(taglist[1] == "left")
            {
                if (leftSelectedList.Contains(mainTable))
                {
                    mainTable.BackColor = System.Drawing.SystemColors.Control;
                    leftSelectedList.Remove(mainTable);
                }
                else
                {
                    mainTable.BackColor = System.Drawing.SystemColors.ControlDark;
                    leftSelectedList.Add(mainTable);
                }
            }
            else if(taglist[1] == "right")
            {
                if (rightSelectedList.Contains(mainTable))
                {
                    mainTable.BackColor = System.Drawing.SystemColors.Control;
                    rightSelectedList.Remove(mainTable);
                }
                else
                {
                    mainTable.BackColor = System.Drawing.SystemColors.ControlDark;
                    rightSelectedList.Add(mainTable);
                }
            }
            return;
        }

        private void ButtClick(object sender, EventArgs e)
        {
            System.Windows.Forms.Button butt = (System.Windows.Forms.Button)sender;
            if(butt.Tag.ToString() == "LTR")
            {
                foreach(System.Windows.Forms.FlowLayoutPanel i in leftSelectedList)
                {
                    var checktag = i.Tag.ToString().Split(' ')[0];
                    bool skipTag = false;
                    foreach(System.Windows.Forms.Label j in rightLabelList)
                    {
                        if(checktag == j.Tag.ToString())
                        {
                            skipTag = true;
                            break;
                        }
                    }
                    if (skipTag) { continue; }

                    System.Windows.Forms.FlowLayoutPanel tempPanel = new System.Windows.Forms.FlowLayoutPanel
                    {
                        Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right))),
                        Location = new System.Drawing.Point(4, 4),
                        Name = "flowLayoutPanel1",
                        Size = new System.Drawing.Size(245, 40),
                        TabIndex = 1,
                        Tag = checktag + " right",
                        Margin = new System.Windows.Forms.Padding(0)
                    };
                    tempPanel.Click += new System.EventHandler(this.Select);
                    rightPanelList.Add(tempPanel);

                    System.Windows.Forms.Label tempLabel = new System.Windows.Forms.Label
                    {
                        Anchor = System.Windows.Forms.AnchorStyles.Left,
                        AutoSize = true,
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                        Location = new System.Drawing.Point(3, 7),
                        Name = "label1",
                        Size = new System.Drawing.Size(51, 20),
                        TabIndex = 0,
                        Text = TurnToName(checktag),
                        Margin = new System.Windows.Forms.Padding(3, 10, 3, 10),
                        Tag = checktag
                    };
                    rightLabelList.Add(tempLabel);
                    tempLabel.Click += new System.EventHandler(this.Select);
                    toAddTable.Controls.Add(tempPanel, 0, selecting);

                    System.Windows.Forms.NumericUpDown tempBox = new System.Windows.Forms.NumericUpDown
                    {
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                        Location = new System.Drawing.Point(252, 4),
                        Name = "numericUpDown1",
                        Size = new System.Drawing.Size(70, 35),
                        TabIndex = 0,
                        Value = 1,
                        Minimum = new decimal(new int[] {
                            1,
                            0,
                            0,
                            0 }),
                        Tag = checktag
                    };
                    numBoxList.Add(tempBox);
                    toAddTable.Controls.Add(tempBox, 1, selecting);
                    tempPanel.Controls.Add(tempLabel);

                    selecting++;
                }
            }
            else if(butt.Tag.ToString() == "RTL")
            {
                //TODO
                father.ShowNotImplementedDialog(sender, e);
            }
            SortRightTable();
        }

        private void SortRightTable()
        {
            rightPanelList = rightPanelList.OrderBy(r => r.Tag.ToString()).ToList();
            rightLabelList = rightLabelList.OrderBy(r => r.Tag.ToString()).ToList();
            numBoxList = numBoxList.OrderBy(r => r.Tag.ToString()).ToList();
            for(int i = 0; i < selecting; i++)
            {
                toAddTable.SetRow(rightPanelList[i], i);
                toAddTable.SetRow(numBoxList[i], i);
            }
        }

        private void Finish(object sender, EventArgs e)
        {
            List<mainPage.Fighter> toAdd = new List<mainPage.Fighter>();
            int saved = 0;
            foreach (System.Windows.Forms.NumericUpDown i in numBoxList)
            {
                string tofile = i.Tag.ToString() + "_creature";
                string stream = Dungeon_Master_Helper.Properties.monsterXML.ResourceManager.GetString(tofile); 
                TextReader reader = new StringReader(stream);
                mainPage.Creature loaded = (mainPage.Creature)new XmlSerializer(typeof(mainPage.Creature)).Deserialize(reader);
                mainPage.Fighter baseFighter = loaded.Convert();

                string name = loaded.name;
                string tag = i.Tag.ToString();
                for(int j = saved; j < saved + i.Value; j++)
                {
                    toAdd.Add(new mainPage.Fighter());
                    toAdd[j].Copy(baseFighter);
                    toAdd[j].tag = tag;
                    toAdd[j].id = father.nextLoadedID++;
                    toAdd[j].name = name + " " + Convert.ToString(j + 1);
                }
                saved += Convert.ToInt32(i.Value);
            }
            foreach (mainPage.Fighter f in toAdd)
            {
                father.addToEncounter(f);
            }
            this.Close();
        }
    }
}
