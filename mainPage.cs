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
        }

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
        }

        public class Fighter : Creature
        {
            public int curr_hp;
            public List<int> conditions;
            public int init_roll;
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

        public void addToEncounter(Fighter toAdd)
        {
            //TO DO
            return;
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
            openFileDialog.ShowDialog();
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Creature));
            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog.FileName);
            Creature loaded = new Creature();
            loaded = (Creature)reader.Deserialize(file);
            file.Close();
            Fighter toAdd = new Fighter();
            toAdd = (Fighter)loaded;
            toAdd.curr_hp = toAdd.max_hp;
            addToEncounter(toAdd);
        }
    }
}
