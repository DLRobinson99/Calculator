using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class calculatorApp : Form
    {

        private double currentValue = 0;


        private string currentOperator = "";
        public calculatorApp()
        {
            InitializeComponent();
        }



        private void BtnClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            textboxResult.Text += button.Text;

            UpdateCurrentSum(button.Text);
        }


        private void BtnOperationClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            Console.WriteLine($"BtnOperationClick: currentOperator={currentOperator}, currentValue={currentValue}, textboxResult={textboxResult.Text}");

            if (!string.IsNullOrEmpty(currentOperator) && !string.IsNullOrEmpty(textboxResult.Text))
            {
                double secondValue = double.Parse(textboxResult.Text);
                double result = CalculateResult(currentValue, secondValue, currentOperator);

                Console.WriteLine($"Result before operation: {result}");

                textboxResult.Text = result.ToString();

                currentOperator = "";
                currentValue = result;
            }

            if (!string.IsNullOrEmpty(textboxResult.Text))
            {
                currentValue = double.Parse(textboxResult.Text);
            }

            if (button.Text == "X" && textboxResult.Text.StartsWith("-"))
            {
                currentValue = -Math.Abs(currentValue);
                textboxResult.Text = currentValue.ToString();
                Console.WriteLine($"Adjusted value for multiplication: {currentValue}");
            }

            currentOperator = button.Text;

            UpdateCurrentSum(currentOperator);

            textboxResult.Text = "";

            Console.WriteLine($"BtnOperationClick: Updated values - currentOperator={currentOperator}, currentValue={currentValue}, textboxResult={textboxResult.Text}");
        }

        private void BtnEqualsClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentOperator) && !double.IsNaN(currentValue))
            {
                if (!string.IsNullOrEmpty(textboxResult.Text))
                {


                    double secondValue = double.Parse(textboxResult.Text);
                    double result = CalculateResult(currentValue, secondValue, currentOperator);

                    textboxResult.Text = result.ToString();

                    currentOperator = "";
                    currentValue = result;
                    currentSum.Text = result.ToString();




                }

                else

                {

                    MessageBox.Show("You must enter a second value before pressing the Equals button, as you have given no second value for operation to use");
                }

            }
        }

        private void BtnClearClick(object sender, EventArgs e)
        {
            textboxResult.Text = "";
            currentValue = 0;
            currentOperator = "";
            currentSum.Text = "";
            currentSum.Text = "";
        }

        private void UpdateCurrentSum(string value)
        {
            currentSum.Text += value;
        }



        private double CalculateResult(double currentValue, double secondValue, string currentOperator)
        {
            switch (currentOperator)
            {
                case "+":
                    return currentValue + secondValue;
                case "-":
                    return currentValue - secondValue;
                case "X":
                    return currentValue * secondValue;

                case "÷":
                    if (secondValue != 0)
                    {
                        return currentValue / secondValue;
                    }
                    else


                    {
                        MessageBox.Show("Cannot divide by zero", "Math Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return double.NaN;
                    }
                default:
                    return double.NaN;
            }
        }

   

        private void BtnCEClick(object sender, EventArgs e)
        {
            textboxResult.Text = "";
        }

        private void BtnToggleSwitch(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textboxResult.Text))
            {
                Console.WriteLine($"Before Toggle: currentValue={currentValue}, textboxResult={textboxResult.Text}");

                double parsedValue = double.Parse(textboxResult.Text);
                parsedValue = -parsedValue;  // Toggle the sign by multiplying by -1

                // Update both textboxResult and currentSum
                textboxResult.Text = parsedValue.ToString();
                currentSum.Text = parsedValue.ToString();  // Update currentSum as well

                Console.WriteLine($"After Toggle: currentValue={currentValue}, textboxResult={textboxResult.Text}");
            }
        }



    }
}