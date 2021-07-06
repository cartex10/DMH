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

        public class creature
        {
            public string name;
            public int ac;
            public int pp;
            public List<int> str;
            public List<int> dex;
            public List<int> con;
            public List<int> int_stat;
            public List<int> wis;
            public List<int> cha;
            public List<int> dmg;
            public bool playable;
            public bool evasion;
        }

        public enum damagetypes
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
            openFileDialog.ShowDialog();
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(creature));
            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog.FileName);
            creature loaded = new creature();
            loaded = (creature)reader.Deserialize(file);
            file.Close();

        }
    }
}
