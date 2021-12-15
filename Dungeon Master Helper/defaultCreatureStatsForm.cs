using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Dungeon_Master_Helper
{
    public partial class defaultCreatureStatsForm : Form
    {
        public defaultCreatureStatsForm(string creature)
        {
            InitializeComponent();
            object img = Dungeon_Master_Helper.Properties.monsterStatsResource.ResourceManager.GetObject(creature);
            pictureBox1.Image = (System.Drawing.Image)img;
        }
    }
}
