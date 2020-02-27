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

            if (DataCheck(txtMonthlyInvestment.Text, txtInterestRate.Text, txtYears.Text))
            {
                if (DataTypeCheck(txtMonthlyInvestment.Text, txtInterestRate.Text,
           txtYears, out decimal monthlyInvestment, out decimal yearlyInterestRate,
          out int years))
                { 
                    int months = years * 12;
                decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;
                //calculates the monthly interest rate, as in this scenerio the interest is calculated
                //every month, previous month's gains also gain interest
                decimal futureValue = this.CalculateFutureValue(monthlyInvestment,
                    monthlyInterestRate, months);

                txtFurureValue.Text = futureValue.ToString("c");
                txtMonthlyInvestment.Focus();
                }

            }
            else
            {
                MessageBox.Show("Please enter a value in each box", "Error");
            }
        }
        private bool DataCheck(string txtMonthlyInvestment, string txtInterestRate,
            string txtYears)
        {   //checks if data is entered
            if (String.IsNullOrEmpty(txtMonthlyInvestment))
            {
                return false;
            }
            if (String.IsNullOrEmpty(txtMonthlyInvestment))
            {
                return false;
            }
            if (String.IsNullOrEmpty(txtYears))
            {
                return false;
            }
            return true;
        }
        private bool DataTypeCheck(string txtMonthlyInvestment, string txtInterestRate,
         string txtYears, out decimal monthlyInvestment, decimal yearlyInterestRate, 
         int months)
        {   //checks if valid data is entered
            try
            {
                monthlyInvestment =
                    Convert.ToDecimal(txtMonthlyInvestment.Text);
                yearlyInterestRate =
                    Convert.ToDecimal(txtInterestRate.Text);
                years = Convert.ToInt32(txtYears.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please check the data entered, use only numbers", "Error");
            }
            catch (OverflowException)
            {
                MessageBox.Show("An overflow exception has occured. Please use a smaller number", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
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
