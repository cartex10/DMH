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
        public calculatorForm(int num, System.Windows.Forms.Control import, mainPage.Fighter import2, mainPage highest)
        {
            startnum = num;
            toEdit = import;
            toEdit2 = import2;
            father = highest;
            InitializeComponent();
            mainTextBox.Text = Convert.ToString(num);
            currstate = 0;
            if(toEdit != null)
            {
                zeroButt.Enabled = false;
                oneButt.Enabled = false;
                twoButt.Enabled = false;
                threeButt.Enabled = false;
                fourButt.Enabled = false;
                fiveButt.Enabled = false;
                sixButt.Enabled = false;
                sevenButt.Enabled = false;
                eightButt.Enabled = false;
                nineButt.Enabled = false;
                backspaceButt.Enabled = false;
                restartButt.Enabled = false;
                dieRollButt.Enabled = false;
                halveButt.Enabled = false;
                divideButt.Enabled = false;
                multiplyButt.Enabled = false;
                equalsButt.Enabled = false;
            }
        }

        public enum calcstates
        {
            editNum1,
            selectingOp,
            editNum2,
            equalled
        }

        int startnum;
        System.Windows.Forms.Control toEdit;
        mainPage.Fighter toEdit2;
        mainPage father;

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
                mainTextBox.Text = Convert.ToString(result);
                if (toEdit != null)
                {
                    if(Convert.ToInt32(result) > toEdit2.max_hp)
                    {
                        string text = "This action would take this charcter's current hp above their max. Set hp to max?";
                        var res = MessageBox.Show(text, "Warning", MessageBoxButtons.YesNo);
                        if(res == DialogResult.Yes)
                        {
                            toEdit.Text = Convert.ToString(toEdit2.max_hp);
                            toEdit2.curr_hp = toEdit2.max_hp;
                        }
                        else
                        {
                            toEdit.Text = Convert.ToString(result);
                            toEdit2.curr_hp = Convert.ToInt32(result);
                        }
                    }
                    else if(Convert.ToInt32(result) < 0)
                    {
                        toEdit.Text = "0";
                        toEdit2.curr_hp = 0;
                    }
                    else
                    {
                        toEdit.Text = Convert.ToString(result);
                        toEdit2.curr_hp = Convert.ToInt32(result);
                    }
                    this.Close();
                }
            }
        }

        private void restartButt_Click(object sender, EventArgs e)
        {
            currstate = (calcstates)0;
            num1 = 0;
            num2 = 0;
            result = 0;
            mainTextBox.Text = Convert.ToString(startnum);
        }

        private void dieRollButt_Click(object sender, EventArgs e)
        {
            father.ShowNotImplementedDialog(sender, e);
        }

        private void operationButt_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
            operation = Convert.ToChar(button.Text);
            if(Convert.ToInt32(currstate) == 0)
            {
                num1 = Convert.ToInt32(mainTextBox.Text);
                currstate++;
                if (this.toEdit != null)
                {
                    zeroButt.Enabled = true;
                    oneButt.Enabled = true;
                    twoButt.Enabled = true;
                    threeButt.Enabled = true;
                    fourButt.Enabled = true;
                    fiveButt.Enabled = true;
                    sixButt.Enabled = true;
                    sevenButt.Enabled = true;
                    eightButt.Enabled = true;
                    nineButt.Enabled = true;
                    backspaceButt.Enabled = true;
                    restartButt.Enabled = true;
                    dieRollButt.Enabled = true;
                    halveButt.Enabled = true;
                    divideButt.Enabled = true;
                    multiplyButt.Enabled = true;
                    equalsButt.Enabled = true;
                }
            }
            else if (Convert.ToInt32(currstate) == 2) 
            { 
                num2 = Convert.ToInt32(mainTextBox.Text);
                equalsButt_Click(sender, e);
            }
            else if (Convert.ToInt32(currstate) == 3)
            {
                num1 = result;
                currstate = (calcstates)1;
            }
        }
    }
}
