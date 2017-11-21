using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkVarneyGUICalc
{
    public partial class CalcForm : Form
    {
        /*Two class instances that the form works with. inputToString1 converts user input and program output to a string, while calc1 
        takes that input does the calculations and returns the result
        */
        InputMaker inputToString1 = new InputMaker();
        Calc calc1 = new Calc();
        public CalcForm()
        {
            InitializeComponent();
        }

        //Buttons Call method that Adds corresponding number or operator too string
        private void Number1_Click(object sender, EventArgs e)
        {
            inputToString1.AddToString('1');
            CalcOutput.Text = inputToString1.GetString();
        }

        private void Number2_Click(object sender, EventArgs e)
        {
            inputToString1.AddToString('2');
            CalcOutput.Text = inputToString1.GetString();
        }

        private void Number3_Click(object sender, EventArgs e)
        {
            inputToString1.AddToString('3');
            CalcOutput.Text = inputToString1.GetString();
        }

        private void Number4_Click(object sender, EventArgs e)
        {
            inputToString1.AddToString('4');
            CalcOutput.Text = inputToString1.GetString();
        }

        private void Number5_Click(object sender, EventArgs e)
        {
            inputToString1.AddToString('5');
            CalcOutput.Text = inputToString1.GetString();
        }

        private void Number6_Click(object sender, EventArgs e)
        {
            inputToString1.AddToString('6');
            CalcOutput.Text = inputToString1.GetString();
        }


        private void Number7_Click(object sender, EventArgs e)
        {
            inputToString1.AddToString('7');
            CalcOutput.Text = inputToString1.GetString();
        }

        private void Number8_Click(object sender, EventArgs e)
        {
            inputToString1.AddToString('8');
            CalcOutput.Text = inputToString1.GetString();
        }

        private void Number9_Click(object sender, EventArgs e)
        {
            inputToString1.AddToString('9');
            CalcOutput.Text = inputToString1.GetString();
        }

        private void Zeroz_Click(object sender, EventArgs e)
        {
            inputToString1.AddToString('0');
            CalcOutput.Text = inputToString1.GetString();
        }

        private void DecimalPt_Click(object sender, EventArgs e)
        {
            inputToString1.AddToString('.');
            CalcOutput.Text = inputToString1.GetString();
        }


        private void CalcForm_Load(object sender, EventArgs e)
        {

        }

        private void CalcOutput_Click(object sender, EventArgs e)
        {

        }

        private void Plus_Click(object sender, EventArgs e)
        {
            inputToString1.AddToString('+');
            CalcOutput.Text = inputToString1.GetString();
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            inputToString1.AddToString('-');
            CalcOutput.Text = inputToString1.GetString();
        }

        private void Times_Click(object sender, EventArgs e)
        {
            inputToString1.AddToString('*');
            CalcOutput.Text = inputToString1.GetString();
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            inputToString1.AddToString('/');
            CalcOutput.Text = inputToString1.GetString();
        }

        private void Modulo_Click(object sender, EventArgs e)
        {
            inputToString1.AddToString('%');
            CalcOutput.Text = inputToString1.GetString();
        }

        private void Power_Click(object sender, EventArgs e)
        {
            inputToString1.AddToString('^');
            CalcOutput.Text = inputToString1.GetString();
        }

        private void CL_Click(object sender, EventArgs e)
        {
            inputToString1.Clear();
            CalcOutput.Text = inputToString1.GetString();
        }

        private void CE_Click(object sender, EventArgs e)
        {
            inputToString1.Bckspc();
            CalcOutput.Text = inputToString1.GetString();
        }
        //Equalz event gets string from inputToString1 and sends to calc1, than sends result back to inputToString1
        private void Equalz_Click(object sender, EventArgs e)
        {
            string equation  = inputToString1.GetString();
            string result = calc1.DoCalc(equation);
            CalcOutput.Text = result;
            inputToString1.SetShouldIReplace(true);
            inputToString1.AddToString(result);
        }
    }
}
