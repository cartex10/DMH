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
    public partial class calculatorForm : Form
    {
        public calculatorForm(int num, mainPage highest, System.Windows.Forms.Control higher)
        {
            startnum = num;
            grandfather = highest;
            father = higher;
            InitializeComponent();
            mainTextBox.Text = Convert.ToString(num);
            currstate = 0;
        }

        public enum calcstates
        {
            editNum1,
            selectingOp,
            editNum2,
            equalled
        }

        int startnum;
        mainPage grandfather;
        System.Windows.Forms.Control father;

        double num1, num2, result;
        char operation;
        calcstates currstate;

        public void numButt_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
            if(Convert.ToInt32(currstate) != 1 && Convert.ToInt32(currstate) != 3)
            {
                if (mainTextBox.Text == "0") { mainTextBox.Text = button.Text; }
                else { mainTextBox.AppendText(button.Text); }
            }
            else
            {
                currstate++;
                if (Convert.ToInt32(currstate) == 4) { currstate = (calcstates)0; }
                mainTextBox.Text = button.Text;
            }
            Console.WriteLine(Convert.ToInt32(currstate));
        }

        public void backspaceButt_Click(object sender, EventArgs e)
        {
            if(mainTextBox.Text.Length == 1) { mainTextBox.Text = "0"; }
            else { mainTextBox.Text = mainTextBox.Text.Remove(mainTextBox.Text.Length - 1, 1); }
        }

        public void halveButt_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(mainTextBox.Text);
            num = Math.Ceiling(num / 2);
            mainTextBox.Text = Convert.ToString(num);
        }

        private void equalsButt_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(currstate) > 0)
            {
                if (Convert.ToInt32(currstate) == 1)
                {
                    num2 = num1;
                    operation = '+';
                    currstate = (calcstates)3;
                }
                else if (Convert.ToInt32(currstate) == 2)
                {
                    num2 = Convert.ToInt32(mainTextBox.Text);
                    currstate++;
                }
                else if (Convert.ToInt32(currstate) == 3)
                {
                    num1 = result;
                }
                switch (operation)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case 'x':
                        result = num1 * num2;
                        break;
                    case '/':
                        result = Math.Floor(num1 / num2);
                        break;
                }
                Console.WriteLine(Convert.ToInt32(currstate));
                mainTextBox.Text = Convert.ToString(result);
            }
        }

        private void restartButt_Click(object sender, EventArgs e)
        {
            currstate = (calcstates)0;
            num1 = 0;
            num2 = 0;
            result = 0;
            mainTextBox.Text = "0";
        }

        private void dieRollButt_Click(object sender, EventArgs e)
        {
            grandfather.ShowNotImplementedDialog(sender, e);
        }

        private void operationButt_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
            operation = Convert.ToChar(button.Text);
            if(Convert.ToInt32(currstate) == 0)
            {
                num1 = Convert.ToInt32(mainTextBox.Text);
                currstate++;
            }
            else if (Convert.ToInt32(currstate) == 2) 
            { 
                num2 = Convert.ToInt32(mainTextBox.Text);
                equalsButt_Click(sender, e);
            }
            else if (Convert.ToInt32(currstate) == 3)
            {
                num1 = num2;
                currstate = (calcstates)1;
            }
            Console.WriteLine(Convert.ToInt32(currstate));
        }
    }
}
