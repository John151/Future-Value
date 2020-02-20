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
        {       //converts user input to decimal numbers, years to int
            decimal monthlyInvestment =
                Convert.ToDecimal(txtMonthlyInvestment.Text);
            decimal yearlyInterestRate =
                Convert.ToDecimal(txtInterestRate.Text);
            int years = Convert.ToInt32(txtYears.Text);

            int months = years * 12;
            decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;
            //calculates the monthly interest rate, as in this scenerio the interest is calculated
            //every month, previous month's gains also gain interest
            decimal futureValue = this.CalculateFutureValue(monthlyInvestment,
                monthlyInterestRate, months);
           
            txtFurureValue.Text = futureValue.ToString("c");
            txtMonthlyInvestment.Focus();

        }

        private decimal CalculateFutureValue(decimal monthlyInvestment,
            decimal monthlyInterestRate, int months)
            {
            decimal futureValue = 0m;
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

        private void ClearFutureValue(object sender, EventArgs e)
        {
            txtFurureValue.Text = "";
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            txtMonthlyInvestment.Text = "";
            txtInterestRate.Text = "";
            txtYears.Text = "";
            txtFurureValue.Text = "";
        }

        private void txtInterestRate_DoubleClick(object sender, EventArgs e)
        {
            txtInterestRate.Text = "12";
        }
    }
}
