using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Future_Value
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //converts user input to decimal numbers, years to intiger
            decimal monthlyInvestment =
                Convert.ToDecimal(txtMonthlyInvestment.Text);
            decimal yearlyInterestRate =
                Convert.ToDecimal(txtInterestRate.Text);
            int years = Convert.ToInt32(txtYears.Text);

            int months = years * 12;
            decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;
            //calculates the monthly interest rate, as in this scenerio the interest is calculated
            //every month, previous month's gains also gain interest

            decimal futureValue = 0m; //starting value placeholder 
            futureValue = calculateFurureValue(monthlyInvestment, months, monthlyInterestRate, futureValue);

            txtFurureValue.Text = futureValue.ToString("c");
            txtMonthlyInvestment.Focus();

        }

        private static decimal calculateFurureValue(decimal monthlyInvestment, int months, decimal monthlyInterestRate, decimal futureValue)
        {
            //loop that sums the value with repeating investments, accruing interest every month
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment)
                    * (1 + monthlyInterestRate);
            }

            return futureValue;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
