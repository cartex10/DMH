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
    public partial class mainPage : Form
    {
        public mainPage()
        {
            InitializeComponent();
            selected = new List<System.Windows.Forms.TableLayoutPanel>();
        }

        public List<Fighter> fighterList;
        public List<System.Windows.Forms.TableLayoutPanel> fighterTableList;
        public List<System.Windows.Forms.Control> fighterPictureList;
        public List<List<System.Windows.Forms.Label>> fighterDescLabelList;
        public List<List<System.Windows.Forms.Label>> fighterLabelList;
        public int nextLoadedID = 0;
        public int picIndex = 1;
        public int descIndex = 6;
        public int changedIndex = 4;
        public int numChar = 0;

        public List<System.Windows.Forms.TableLayoutPanel> initTableList;
        public List<System.Windows.Forms.Control> initPictureList;
        public List<System.Windows.Forms.Label> initLabelList;
        public List<System.Windows.Forms.Label> initNumLabelList;
        public int initChar = 0;

        public List<System.Windows.Forms.TableLayoutPanel> selected;

        public class Creature
        {
            public string name = "NULL";
            public int ac = 10;
            public int pp = 10;
            public List<int> str;
            public List<int> dex;
            public List<int> con;
            public List<int> int_stat;
            public List<int> wis;
            public List<int> cha;
            public List<int> dmg;
            public bool playable = true;
            public bool evasion = false;
            public int max_hp = 1;
            public int level = 1;

            public Fighter Convert()
            {
                Fighter toReturn = new Fighter()
                {
                    name = this.name,
                    ac = this.ac,
                    pp = this.pp,
                    str = this.str,
                    dex = this.dex,
                    con = this.con,
                    int_stat = this.int_stat,
                    wis = this.wis,
                    cha = this.cha,
                    playable = this.playable,
                    evasion = this.evasion,
                    max_hp = this.max_hp,
                    level = this.level,
                    curr_hp = this.max_hp,

            };
                return toReturn;
            }
        }

        public class Fighter : Creature
        {
            public int curr_hp;
            public List<int> conditions;
            public int init_roll = -1;
            public int id;
        }

        public enum Damagetypes
        {
            acid,
            cold,
            fire,
            force,
            lightning,
            necrotic,
            poison,
            psychic,
            radiant,
            thunder,
            bludgeoning,
            piercing,
            slashing
        }

        private void newCreatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createCreatureForm createCreature = new createCreatureForm();
            createCreature.Show();
        }

        private void loadCreatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog
            {
                Title = "Open Creature"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Creature));
                System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog.FileName);
                Creature loaded = new Creature();
                loaded = (Creature)reader.Deserialize(file);
                file.Close();
                Fighter toAdd = new Fighter();
                toAdd = loaded.Convert();
                toAdd.id = nextLoadedID++;
                addToEncounter(toAdd);
            }
        }

        private void addToEncounter(Fighter toAdd)
        {
            if (!Convert.ToBoolean(toAdd.id))
            {
                fighterTableList = new List<System.Windows.Forms.TableLayoutPanel>
                {
                    this.baseFighterTable
                };
                fighterTableList[0].Tag = toAdd.id;

                fighterList = new List<Fighter>
                {
                    toAdd
                };

                fighterPictureList = new List<System.Windows.Forms.Control>
                {
                    baseFighterTable.Controls.Find("charPicBox", true)[0]
                };

                fighterDescLabelList = new List<List<System.Windows.Forms.Label>>
                {
                    new List<System.Windows.Forms.Label>
                    {
                        (System.Windows.Forms.Label)baseFighterTable.Controls.Find("charDescLabel1", true)[0],
                        (System.Windows.Forms.Label)baseFighterTable.Controls.Find("charDescLabel2", true)[0],
                        (System.Windows.Forms.Label)baseFighterTable.Controls.Find("charDescLabel3", true)[0],
                        (System.Windows.Forms.Label)baseFighterTable.Controls.Find("charDescLabel4", true)[0],
                        (System.Windows.Forms.Label)baseFighterTable.Controls.Find("charDescLabel5", true)[0],
                        (System.Windows.Forms.Label)baseFighterTable.Controls.Find("charDescLabel6", true)[0]
                    }
                };

                fighterLabelList = new List<List<System.Windows.Forms.Label>>
                {
                    new List<System.Windows.Forms.Label>
                    {
                        (System.Windows.Forms.Label)baseFighterTable.Controls.Find("charLabel1", true)[0],
                        (System.Windows.Forms.Label)baseFighterTable.Controls.Find("charLabel2", true)[0],
                        (System.Windows.Forms.Label)baseFighterTable.Controls.Find("charLabel3", true)[0],
                        (System.Windows.Forms.Label)baseFighterTable.Controls.Find("charLabel4", true)[0]
                    }
                };

                Control[] editting = this.baseFighterTable.Controls.Find("charLabel1", true);
                editting[0].Text = toAdd.name;

                editting = this.baseFighterTable.Controls.Find("charLabel2", true);
                editting[0].Text = Convert.ToString(toAdd.curr_hp);

                editting = this.baseFighterTable.Controls.Find("charLabel3", true);
                editting[0].Text = Convert.ToString(toAdd.ac);

                editting = this.baseFighterTable.Controls.Find("charLabel4", true);
                editting[0].Text = Convert.ToString(toAdd.pp);
                numChar = 1;
    }
            else
            {
                fighterList.Add(toAdd);
                CloneCreatureTable(toAdd);
            }
            return;
        }

        private void CloneCreatureTable(Fighter toAdd)
        {
            string charstr = Convert.ToString(numChar);
            fighterTableList.Add(new System.Windows.Forms.TableLayoutPanel
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            |     System.Windows.Forms.AnchorStyles.Left)
            |     System.Windows.Forms.AnchorStyles.Right))),
                ColumnCount = 7,
                Location = new System.Drawing.Point(1, 1),
                Margin = new System.Windows.Forms.Padding(0),
                Name = "baseFighterTable" + charstr,
                RowCount = 2,
                Size = new System.Drawing.Size(573, 80),
                TabIndex = 0,
                Tag = toAdd.id
        });
            fighterTableList[numChar].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            fighterTableList[numChar].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            fighterTableList[numChar].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            fighterTableList[numChar].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            fighterTableList[numChar].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            fighterTableList[numChar].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            fighterTableList[numChar].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            fighterTableList[numChar].RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            fighterTableList[numChar].RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            fighterTableList[numChar].Click += new System.EventHandler(this.CharacterClick);


            string str = Convert.ToString(picIndex);
            fighterPictureList.Add(new System.Windows.Forms.PictureBox
            {
                Image = global::Dungeon_Master_Helper.Properties.Resources.silhouette,
                Location = new System.Drawing.Point(10, 10),
                Margin = new System.Windows.Forms.Padding(10),
                Name = "charPicBox" + str,
                Size = new System.Drawing.Size(60, 60),
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                TabIndex = 0,
                TabStop = false
            });
            fighterTableList[numChar].Controls.Add(fighterPictureList[picIndex], 0, 0);
            fighterTableList[numChar].SetRowSpan(fighterPictureList[picIndex], 2);
            fighterPictureList[picIndex].Click += new System.EventHandler(this.CharacterClick);

            string descstr = Convert.ToString(descIndex++);
            var temp = new List<System.Windows.Forms.Label>
            {
                new System.Windows.Forms.Label
                {
                    Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))),
                    AutoSize = true,
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                    Location = new System.Drawing.Point(83, 20),
                    Name = "charDescLabel" + descstr,
                    Size = new System.Drawing.Size(55, 20),
                    TabIndex = 1,
                    Text = "Name"
                },
            };
            temp[0].Click += new System.EventHandler(this.CharacterClick);
            fighterTableList[numChar].Controls.Add(temp[0], 1, 0);
            descstr = Convert.ToString(descIndex++);
            temp.Add(new System.Windows.Forms.Label
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right))),
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Location = new System.Drawing.Point(203, 20),
                Name = "charDescLabel" + descstr,
                Size = new System.Drawing.Size(44, 20),
                TabIndex = 2,
                Text = "HP",
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            });
            temp[1].Click += new System.EventHandler(this.CharacterClick);
            fighterTableList[numChar].Controls.Add(temp[1], 2, 0);
            descstr = Convert.ToString(descIndex++);
            temp.Add(new System.Windows.Forms.Label
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right))),
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Location = new System.Drawing.Point(253, 20),
                Name = "charDescLabel" + descstr,
                Size = new System.Drawing.Size(44, 20),
                TabIndex = 3,
                Text = "AC",
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            });
            temp[2].Click += new System.EventHandler(this.CharacterClick);
            fighterTableList[numChar].Controls.Add(temp[2], 3, 0);
            descstr = Convert.ToString(descIndex++);
            temp.Add(new System.Windows.Forms.Label
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right))),
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Location = new System.Drawing.Point(303, 20),
                Name = "charDescLabel" + descstr,
                Size = new System.Drawing.Size(44, 20),
                TabIndex = 4,
                Text = "PP",
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            });
            temp[3].Click += new System.EventHandler(this.CharacterClick);
            fighterTableList[numChar].Controls.Add(temp[3], 4, 0);
            descstr = Convert.ToString(descIndex++);
            temp.Add(new System.Windows.Forms.Label
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right))),
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Location = new System.Drawing.Point(353, 20),
                Name = "charDescLabel" + descstr,
                Size = new System.Drawing.Size(105, 20),
                TabIndex = 5,
                Text = "Damage",
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            });
            temp[4].Click += new System.EventHandler(this.CharacterClick);
            fighterTableList[numChar].Controls.Add(temp[4], 5, 0);
            descstr = Convert.ToString(descIndex++);
            temp.Add(new System.Windows.Forms.Label
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right))),
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Location = new System.Drawing.Point(464, 20),
                Name = "charDescLabel" + descstr,
                Size = new System.Drawing.Size(106, 20),
                TabIndex = 6,
                Text = "Conditions",
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            });
            temp[5].Click += new System.EventHandler(this.CharacterClick);
            fighterTableList[numChar].Controls.Add(temp[5], 6, 0);
            fighterDescLabelList.Add(temp);

            string changedstr = Convert.ToString(changedIndex++);
            var newtemp = new List<System.Windows.Forms.Label>
            {
                new System.Windows.Forms.Label
                {
                    Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right))),
                    AutoSize = true,
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                    Location = new System.Drawing.Point(83, 50),
                    Name = "charLabel" + changedstr,
                    Size = new System.Drawing.Size(114, 20),
                    TabIndex = 7,
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                    Text = toAdd.name
                }
            };
            newtemp[0].Click += new System.EventHandler(this.CharacterClick);
            fighterTableList[numChar].Controls.Add(newtemp[0], 1, 1);
            changedstr = Convert.ToString(changedIndex++);
            newtemp.Add(new System.Windows.Forms.Label
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right))),
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10F),
                Location = new System.Drawing.Point(203, 51),
                Name = "charLabel" + changedstr,
                Size = new System.Drawing.Size(44, 17),
                TabIndex = 8,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Text = Convert.ToString(toAdd.curr_hp)
            });
            newtemp[1].Click += new System.EventHandler(this.CharacterClick);
            fighterTableList[numChar].Controls.Add(newtemp[1], 2, 1);
            changedstr = Convert.ToString(changedIndex++);
            newtemp.Add(new System.Windows.Forms.Label
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right))),
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10F),
                Location = new System.Drawing.Point(253, 51),
                Name = "charLabel" + changedstr,
                Size = new System.Drawing.Size(44, 17),
                TabIndex = 9,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Text = Convert.ToString(toAdd.ac)
            });
            newtemp[2].Click += new System.EventHandler(this.CharacterClick);
            fighterTableList[numChar].Controls.Add(newtemp[2], 3, 1);
            changedstr = Convert.ToString(changedIndex++);
            newtemp.Add(new System.Windows.Forms.Label
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right))),
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10F),
                Location = new System.Drawing.Point(303, 51),
                Name = "charLabel" + changedstr,
                Size = new System.Drawing.Size(44, 17),
                TabIndex = 10,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Text = Convert.ToString(toAdd.pp)
            });
            newtemp[3].Click += new System.EventHandler(this.CharacterClick);
            fighterTableList[numChar].Controls.Add(newtemp[3], 4, 1);
            fighterLabelList.Add(temp);
            this.fighterTable.Controls.Add(fighterTableList[numChar], 0, numChar);

            numChar++;
            picIndex++;
            return;
        }

        public void AddToInitiative(Fighter toAdd)
        {
            if (!Convert.ToBoolean(initChar))
            {
                initTableList = new List<System.Windows.Forms.TableLayoutPanel>
                {
                    this.baseInitTable
                };
                initPictureList = new List<System.Windows.Forms.Control> 
                { 
                    baseInitTable.Controls.Find("initPicBox", true)[0]
                };
                initLabelList = new List<System.Windows.Forms.Label>
                {
                    (System.Windows.Forms.Label)baseInitTable.Controls.Find("initLabel", true)[0]
                };
                initNumLabelList = new List<System.Windows.Forms.Label>
                {
                    (System.Windows.Forms.Label)baseInitTable.Controls.Find("initNumLabel", true)[0]
                };
                initLabelList[0].Text = toAdd.name;
                initNumLabelList[0].Text = Convert.ToString(toAdd.init_roll);
                initChar = 1;
            }
            else 
            {
                CloneInitiativeTable(toAdd);
                SortInitiativeTable();
            }
        }

        private void CloneInitiativeTable(Fighter toAdd)
        {
            string str = Convert.ToString(initChar);
            initTableList.Add(new System.Windows.Forms.TableLayoutPanel
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right))),
                ColumnCount = 3,
                Location = new System.Drawing.Point(1, 1),
                Margin = new System.Windows.Forms.Padding(0),
                Name = "baseInitTable" + str,
                RowCount = 1,
                Size = new System.Drawing.Size(235, 40),
                TabIndex = 0,
                Tag = toAdd.id
            });
            initTableList[initChar].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            initTableList[initChar].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            initTableList[initChar].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            initTableList[initChar].RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            initPictureList.Add(new System.Windows.Forms.PictureBox
            {
                Image = global::Dungeon_Master_Helper.Properties.Resources.silhouette,
                Location = new System.Drawing.Point(3, 3),
                Name = "initPicBox" + str,
                Size = new System.Drawing.Size(34, 34),
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                TabIndex = 0,
                TabStop = false,
            });
            initTableList[initChar].Controls.Add(initPictureList[initChar], 0, 0);

            initLabelList.Add(new System.Windows.Forms.Label
            {
                Anchor = System.Windows.Forms.AnchorStyles.Left,
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Location = new System.Drawing.Point(43, 7),
                Name = "initLabel" + str,
                Size = new System.Drawing.Size(0, 25),
                TabIndex = 1,
                Text = Convert.ToString(toAdd.name)
            });
            initTableList[initChar].Controls.Add(initLabelList[initChar], 1, 0);

            initNumLabelList.Add(new System.Windows.Forms.Label
            {
                Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right))),
                AutoSize = true,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12F),
                Location = new System.Drawing.Point(178, 10),
                Name = "initNumLabel" + str,
                Size = new System.Drawing.Size(54, 20),
                TabIndex = 2,
                Text = Convert.ToString(toAdd.init_roll)
            });
            initTableList[initChar].Controls.Add(initNumLabelList[initChar], 2, 0);
            this.initTable.Controls.Add(initTableList[initChar++], 0, initChar-1);
            return;
        }

        private void SortInitiativeTable()
        {
            List<Fighter> initted = fighterList.FindAll(r => r.init_roll != -1);
            List<Fighter> sorted = initted.OrderByDescending(r => r.init_roll).ToList();
            for(int i = 0; i < initted.Count; i++)
            {
                initLabelList[i].Text = sorted[i].name;
                initNumLabelList[i].Text = Convert.ToString(sorted[i].init_roll);
            }
            return;
        }

        private void CharacterClick(object sender, EventArgs e)
        {
            var type = sender.GetType();
            System.Windows.Forms.TableLayoutPanel mainTable;
            if(Convert.ToString(type) == "System.Windows.Forms.Label")
            {
                mainTable = (System.Windows.Forms.TableLayoutPanel)(((System.Windows.Forms.Label)sender).Parent);
            }
            else if (Convert.ToString(type) == "System.Windows.Forms.PictureBox")
            {
                mainTable = (System.Windows.Forms.TableLayoutPanel)(((System.Windows.Forms.PictureBox)sender).Parent);
            }
            else if (Convert.ToString(type) == "System.Windows.Forms.TableLayoutPanel")
            {
                mainTable = (System.Windows.Forms.TableLayoutPanel)sender;
            }
            else
            {
                Console.WriteLine(type);
                return;
            }

            if (selected.Contains(mainTable))
            {
                mainTable.BackColor = System.Drawing.SystemColors.Control;
                selected.Remove(mainTable);
            }
            else
            {
                mainTable.BackColor = System.Drawing.SystemColors.ControlDark;
                selected.Add(mainTable);
            }
        }

        private void ShowNotImplementedDialog(object sender, EventArgs e)
        {
            notImplementedForm nif = new notImplementedForm();
            nif.ShowDialog();
        }

        private void initiativeButt_Click(object sender, EventArgs e)
        {
            List<Fighter> notInit = new List<Fighter>();
            List<Fighter> initted = new List<Fighter>();
            foreach(System.Windows.Forms.TableLayoutPanel table in selected)
            {
                Fighter temp = fighterList.Find(r => Convert.ToInt32(r.id) == Convert.ToInt32(table.Tag));
                if(temp.init_roll == -1) { notInit.Add(temp); }
                else { initted.Add(temp); }
            }
            if(notInit.Count != 0)
            {
                initiativeForm initDialog = new initiativeForm(notInit, this);
                initDialog.ShowDialog();
            }
        }
    }
}
