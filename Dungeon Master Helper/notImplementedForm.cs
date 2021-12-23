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
    public partial class notImplementedForm : Form
    {
        public notImplementedForm()
        {
            InitializeComponent();
        }

        private void VisitLink(object sender, EventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/cartex10/DMH");
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
