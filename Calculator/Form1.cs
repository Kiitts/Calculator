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
    public partial class Form1 : Form
    {
        public bool newVal = false;
        public bool equalAgain = false;
        public bool numberNegative = false;
        public string previewHolder = string.Empty;
        public string operation = string.Empty;
        public string preview2Holder = string.Empty;
        public double newCalculated = 0;
        public double previewCalculated = 0;
        public double calculatedAnswer = 0;
        public double lastNumber = 0;

        public bool needChange = false;

        // erasing buttons
        private void eraseButton_Click(object sender, EventArgs e)
        {
            // erase the last input
            if (preview1.Text.Length <= 1)
            {
                // if input is less than 1 it will just update the preview1 to "0"
                preview1.Text = "0";
                numberNegative = false;
            }
            else
            {
                if (equalAgain)
                {
                    // if recently equal
                    preview2.Text = null;
                    newCalculated = 0;
                    numberNegative = false;
                    operation = string.Empty;
                    equalAgain = false;
                }
                else
                {
                    // this will remove the last input in the preview1
                    preview1.Text = preview1.Text.Remove(preview1.Text.Length - 1);
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // clear inputs or everything
            if (clearButton.Text == "C")
            {
                // this will clear all the data been made in calculator
                newVal = false;
                equalAgain = false;
                previewHolder = string.Empty;
                operation = string.Empty;
                numberNegative = false;
                preview2Holder = string.Empty;
                newCalculated = 0;
                previewCalculated = 0;
                lastNumber = 0;
                preview1.Text = "0";
                preview2.Text = null;
            }
            else
            {
                // this will clear the preview1 and reset it back to "0"
                numberNegative = false;
                preview1.Text = "0";
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void angleButton_Click(object sender, EventArgs e)
        {
            if (angleButton.Text == "DEG")
            {
                angleButton.Text = "RAD";
            }
            else if (angleButton.Text == "RAD")
            {
                angleButton.Text = "GRAD";
            }
            else
            {
                angleButton.Text = "DEG";
            }
        }

        private void changeTrigoButton_Click(object sender, EventArgs e)
        {
            //change trigometry buttons and others
            if (needChange)
            {
                Button[] buttons = new Button[] {sinButton, cosButton, tanButton,
                secButton, scsButton, cotButton};
                string[] buttonsName = new string[] {"sin", "cos", "tan",
                "sec", "scs", "cot"};
                var buttonsAndName = buttons.Zip(buttonsName, (t, n) =>
                    new { ButtonsObj = t, ButtonNames = n });
                foreach (var x in buttonsAndName)
                {
                    x.ButtonsObj.Image = null;
                    x.ButtonsObj.Text = x.ButtonNames;
                }

                buttons = new Button[]
                {
                    xSquaredButton, squareRootButton, exponentButton, exponentialTen,
                    logButton, lnButton
                };
                buttonsName = new string[]
                {
                    "x^2", "2√x", "x^y", "10^x", "log", "ln"
                };
                buttonsAndName = buttons.Zip(buttonsName, (t, n) =>
                    new { ButtonsObj = t, ButtonNames = n });
                foreach (var x in buttonsAndName)
                {
                    x.ButtonsObj.Text = x.ButtonNames;
                }

                needChange = false;
            }
            else
            {
                Button[] buttons = new Button[] {sinButton, cosButton, tanButton,
                secButton, scsButton, cotButton};
                string[] buttonsName = new string[] {"arcsin.png", "arccos.png", "arctan.png",
                "arcsec.png", "arcscs.png", "arccot.png"};
                var buttonsAndName = buttons.Zip(buttonsName, (t, n) =>
                    new { ButtonsObj = t, ButtonNames = n });
                foreach (var x in buttonsAndName)
                {
                    x.ButtonsObj.Text = null;
                    x.ButtonsObj.Image = Image.FromFile("data/image/" + x.ButtonNames);
                }

                buttons = new Button[]
                {
                    xSquaredButton, squareRootButton, exponentButton, exponentialTen,
                    logButton, lnButton
                };
                buttonsName = new string[]
                {
                    "x^3", "3√x", "y√x", "2^x", "logx^y", "e^x"
                };
                buttonsAndName = buttons.Zip(buttonsName, (t, n) =>
                    new { ButtonsObj = t, ButtonNames = n });
                foreach (var x in buttonsAndName)
                {
                    x.ButtonsObj.Text = x.ButtonNames;
                }

                needChange = true;
            }
        }

        // numerical buttons

        private void button1_Click(object sender, EventArgs e)
        {
            // add 1 in preview1
            if (preview1.Text == "0" || newVal || equalAgain)
            {
                if (newVal)
                {
                    newVal = false;
                }
                if (equalAgain)
                {
                    preview2.Text = null;
                    operation = string.Empty;
                    previewHolder = string.Empty;
                    newCalculated = 0;
                    lastNumber = 0;
                }
                preview1.Text = null;
                equalAgain = false;
            }
            preview1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // add 2 in preview1
            if (preview1.Text == "0" || newVal || equalAgain)
            {
                if (newVal)
                {
                    newVal = false;
                }
                if (equalAgain)
                {
                    preview2.Text = null;
                    operation = string.Empty;
                    previewHolder = string.Empty;
                    newCalculated = 0;
                    lastNumber = 0;
                }
                preview1.Text = null;
                equalAgain = false;
            }
            preview1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // add 3 in preview1
            if (preview1.Text == "0" || newVal || equalAgain)
            {
                if (newVal)
                {
                    newVal = false;
                }
                if (equalAgain)
                {
                    preview2.Text = null;
                    operation = string.Empty;
                    previewHolder = string.Empty;
                    newCalculated = 0;
                    lastNumber = 0;
                }
                preview1.Text = null;
                equalAgain = false;
            }
            preview1.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // add 4 in preview1
            if (preview1.Text == "0" || newVal || equalAgain)
            {
                if (newVal)
                {
                    newVal = false;
                }
                if (equalAgain)
                {
                    preview2.Text = null;
                    operation = string.Empty;
                    previewHolder = string.Empty;
                    newCalculated = 0;
                    lastNumber = 0;
                }
                preview1.Text = null;
                equalAgain = false;
            }
            preview1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // add 5 in preview1
            if (preview1.Text == "0" || newVal || equalAgain)
            {
                if (newVal)
                {
                    newVal = false;
                }
                if (equalAgain)
                {
                    preview2.Text = null;
                    operation = string.Empty;
                    previewHolder = string.Empty;
                    newCalculated = 0;
                    lastNumber = 0;
                }
                preview1.Text = null;
                equalAgain = false;
            }
            preview1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // add 6 in preview1
            if (preview1.Text == "0" || newVal || equalAgain)
            {
                if (newVal)
                {
                    newVal = false;
                }
                if (equalAgain)
                {
                    preview2.Text = null;
                    operation = string.Empty;
                    previewHolder = string.Empty;
                    newCalculated = 0;
                    lastNumber = 0;
                }
                preview1.Text = null;
                equalAgain = false;
            }
            preview1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // add 7 in preview1
            if (preview1.Text == "0" || newVal || equalAgain)
            {
                if (newVal)
                {
                    newVal = false;
                }
                if (equalAgain)
                {
                    preview2.Text = null;
                    operation = string.Empty;
                    previewHolder = string.Empty;
                    newCalculated = 0;
                    lastNumber = 0;
                }
                preview1.Text = null;
                equalAgain = false;
            }
            preview1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // add 8 in preview1
            if (preview1.Text == "0" || newVal || equalAgain)
            {
                if (newVal)
                {
                    newVal = false;
                }
                if (equalAgain)
                {
                    preview2.Text = null;
                    operation = string.Empty;
                    previewHolder = string.Empty;
                    newCalculated = 0;
                    lastNumber = 0;
                }
                preview1.Text = null;
                equalAgain = false;
            }
            preview1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // add 9 in preview1
            if (preview1.Text == "0" || newVal || equalAgain)
            {
                if (newVal)
                {
                    newVal = false;
                }
                if (equalAgain)
                {
                    preview2.Text = null;
                    operation = string.Empty;
                    previewHolder = string.Empty;
                    newCalculated = 0;
                    lastNumber = 0;
                }
                preview1.Text = null;
                equalAgain = false;
            }
            preview1.Text += "9";
        }
        private void button0_Click(object sender, EventArgs e)
        {
            if (preview1.Text == "0" || newVal || equalAgain)
            {
                if (newVal)
                {
                    newVal = false;
                }
                if (equalAgain)
                {
                    preview2.Text = null;
                    operation = string.Empty;
                    previewHolder = string.Empty;
                    newCalculated = 0;
                    lastNumber = 0;
                }
                preview1.Text = null;
                equalAgain = false;
            }
            preview1.Text += "0";
        }
        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (!preview1.Text.Contains("."))
            {
                preview1.Text += ".";
            }
        }

        private void buttonAddition_Click(object sender, EventArgs e)
        {
            // add number
            if (preview2.Text.Length > 1)
            {
                // if the preview2 has values
                if (equalAgain)
                {
                    // if recently equal
                    preview2Holder = preview1.Text + " + ";
                    previewCalculated = newCalculated;
                    equalAgain = false;
                }
                else if(newVal)
                {
                    preview2Holder = preview1.Text + " + ";
                    previewCalculated = newCalculated;
                }
                else
                {
                    if (operation == "minus")
                    {
                        // if the last operation is subtraction, the preview will show
                        // the value of the last calculated number minus the last input.
                        previewCalculated = newCalculated - double.Parse(preview1.Text);
                        preview2Holder = preview2.Text + preview1.Text + " + ";
                    }
                    else if (operation == "divide")
                    {
                        // if the last operation is division, the preview will show
                        // the value of the last calculated number divide the last input.
                        previewCalculated = newCalculated / double.Parse(preview1.Text);
                        preview2Holder = preview2.Text + preview1.Text + " + ";
                    }
                    else if (operation == "multiply")
                    {
                        // if the last operation is division, the preview will show
                        // the value of the last calculated number divide the last input.
                        previewCalculated = newCalculated * double.Parse(preview1.Text);
                        preview2Holder = preview2.Text + preview1.Text + " + ";
                    }
                    else
                    {
                        previewCalculated = newCalculated + double.Parse(preview1.Text);
                        preview2Holder = preview2.Text + preview1.Text + " + ";
                    }
                }
            }
            else
            {
                previewCalculated = double.Parse(preview1.Text);
                preview2Holder = preview1.Text + " + ";
            }
            preview2.Text = preview2Holder;
            newCalculated = previewCalculated;
            preview1.Text = previewCalculated.ToString();
            newVal = true;
            numberNegative = false;
            operation = "add";
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            // subtract number
            if (preview2.Text.Length > 0)
            {
                // if preview 2 has values
                if (equalAgain)
                {
                    // if recently equal
                    preview2Holder = preview1.Text + " - ";
                    previewCalculated = newCalculated;
                    equalAgain = false;
                }
                else if (newVal)
                {
                    preview2Holder = preview1.Text + " - ";
                    previewCalculated = newCalculated;
                }
                else
                {
                    if (operation == "add")
                    {
                        // if the last operation is addition, the preview will show
                        // the value of the last calculated number plus the last input.
                        previewCalculated = newCalculated + double.Parse(preview1.Text);
                        preview2Holder = preview2.Text + preview1.Text + " - ";
                    }
                    else if (operation == "divide")
                    {
                        // if the last operation is division, the preview will show
                        // the value of the last calculated number divide the last input.
                        previewCalculated = newCalculated / double.Parse(preview1.Text);
                        preview2Holder = preview2.Text + preview1.Text + " - ";
                    }
                    else if (operation == "multiply")
                    {
                        // if the last operation is division, the preview will show
                        // the value of the last calculated number divide the last input.
                        previewCalculated = newCalculated * double.Parse(preview1.Text);
                        preview2Holder = preview2.Text + preview1.Text + " - ";
                    }
                    else
                    {
                        previewCalculated = newCalculated - double.Parse(preview1.Text);
                        preview2Holder = preview2.Text + preview1.Text + " - ";
                    }
                }
            }
            else
            {
                previewCalculated = double.Parse(preview1.Text);
                preview2Holder = preview1.Text + " - ";
            }
            preview2.Text = preview2Holder;
            newCalculated = previewCalculated;
            preview1.Text = previewCalculated.ToString();
            newVal = true;
            numberNegative = false;
            operation = "minus";
        }
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (preview2.Text.Length > 0)
            {
                // if preview 2 has values
                if (equalAgain)
                {
                    // if recently equal
                    preview2Holder = preview1.Text + " ÷ ";
                    previewCalculated = newCalculated;
                    equalAgain = false;
                }
                else if (newVal)
                {
                    preview2Holder = preview1.Text + " ÷ ";
                    previewCalculated = newCalculated;
                }
                else
                {
                    if (operation == "add")
                    {
                        // if the last operation is addition, the preview will show
                        // the value of the last calculated number plus the last input.
                        previewCalculated = newCalculated + double.Parse(preview1.Text);
                        preview2Holder = preview2.Text + preview1.Text + " ÷ ";
                    }
                    else if (operation == "minus")
                    {
                        // if the last operation is subtraction, the preview will show
                        // the value of the last calculated number minus the last input.
                        previewCalculated = newCalculated - double.Parse(preview1.Text);
                        preview2Holder = preview2.Text + preview1.Text + " ÷ ";
                    }
                    else if (operation == "multiply")
                    {
                        // if the last operation is division, the preview will show
                        // the value of the last calculated number divide the last input.
                        previewCalculated = newCalculated * double.Parse(preview1.Text);
                        preview2Holder = preview2.Text + preview1.Text + " ÷ ";
                    }
                    else
                    {
                        previewCalculated = newCalculated / double.Parse(preview1.Text);
                        preview2Holder = preview2.Text + preview1.Text + " ÷ ";
                    }
                }
            }
            else
            {
                previewCalculated = double.Parse(preview1.Text);
                preview2Holder = preview1.Text + " ÷ ";
            }
            preview2.Text = preview2Holder;
            newCalculated = previewCalculated;
            preview1.Text = previewCalculated.ToString();
            newVal = true;
            numberNegative = false;
            operation = "divide";
        }
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (preview2.Text.Length > 0)
            {
                // if preview 2 has values
                if (equalAgain)
                {
                    // if recently equal
                    preview2Holder = preview1.Text + " × ";
                    previewCalculated = newCalculated;
                    equalAgain = false;
                }
                else if (newVal)
                {
                    preview2Holder = preview1.Text + " × ";
                    previewCalculated = newCalculated;
                }
                else
                {
                    if (operation == "add")
                    {
                        // if the last operation is addition, the preview will show
                        // the value of the last calculated number plus the last input.
                        previewCalculated = newCalculated + double.Parse(preview1.Text);
                        preview2Holder = preview2.Text + preview1.Text + " × ";
                    }
                    else if (operation == "minus")
                    {
                        // if the last operation is subtraction, the preview will show
                        // the value of the last calculated number minus the last input.
                        previewCalculated = newCalculated - double.Parse(preview1.Text);
                        preview2Holder = preview2.Text + preview1.Text + " × ";
                    }
                    else if (operation == "divide")
                    {
                        // if the last operation is division, the preview will show
                        // the value of the last calculated number divide the last input.
                        previewCalculated = newCalculated / double.Parse(preview1.Text);
                        preview2Holder = preview2.Text + preview1.Text + " × ";
                    }
                    else
                    {
                        previewCalculated = newCalculated * double.Parse(preview1.Text);
                        preview2Holder = preview2.Text + preview1.Text + " × ";
                    }
                }
            }
            else
            {
                previewCalculated = double.Parse(preview1.Text);
                preview2Holder = preview1.Text + " × ";
            }
            preview2.Text = preview2Holder;
            newCalculated = previewCalculated;
            preview1.Text = previewCalculated.ToString();
            newVal = true;
            numberNegative = false;
            operation = "multiply";
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            //equal the function
            if (operation == "add")
            {
                if (!equalAgain)
                {
                    lastNumber = double.Parse(preview1.Text);
                    calculatedAnswer = newCalculated + lastNumber;
                    newCalculated = calculatedAnswer;
                    preview2.Text = preview2.Text + lastNumber.ToString() + " =";
                    preview1.Text = calculatedAnswer.ToString();
                }
                else
                {
                    calculatedAnswer = newCalculated + lastNumber;
                    newCalculated = calculatedAnswer;
                    preview2.Text = preview1.Text + " + " + lastNumber.ToString() + " =";
                    preview1.Text = calculatedAnswer.ToString();
                }
            }
            else if (operation == "minus")
            {
                if (!equalAgain)
                {
                    lastNumber = double.Parse(preview1.Text);
                    calculatedAnswer = newCalculated - lastNumber;
                    newCalculated = calculatedAnswer;
                    preview2.Text = preview2.Text + lastNumber.ToString() + " =";
                    preview1.Text = calculatedAnswer.ToString();
                }
                else
                {
                    calculatedAnswer = newCalculated - lastNumber;
                    newCalculated = calculatedAnswer;
                    preview2.Text = preview1.Text + " - " + lastNumber.ToString() + " =";
                    preview1.Text = calculatedAnswer.ToString();
                }
            }
            else if (operation == "divide")
            {
                if (!equalAgain)
                {
                    lastNumber = double.Parse(preview1.Text);
                    calculatedAnswer = newCalculated / lastNumber;
                    newCalculated = calculatedAnswer;
                    preview2.Text = preview2.Text + lastNumber.ToString() + " =";
                    preview1.Text = calculatedAnswer.ToString();
                }
                else
                {
                    calculatedAnswer = newCalculated / lastNumber;
                    newCalculated = calculatedAnswer;
                    preview2.Text = preview1.Text + " ÷ " + lastNumber.ToString() + " =";
                    preview1.Text = calculatedAnswer.ToString();
                }
            }
            else if (operation == "multiply")
            {
                if (!equalAgain)
                {
                    lastNumber = double.Parse(preview1.Text);
                    calculatedAnswer = newCalculated * lastNumber;
                    newCalculated = calculatedAnswer;
                    preview2.Text = preview2.Text + lastNumber.ToString() + " =";
                    preview1.Text = calculatedAnswer.ToString();
                }
                else
                {
                    calculatedAnswer = newCalculated * lastNumber;
                    newCalculated = calculatedAnswer;
                    preview2.Text = preview1.Text + " × " + lastNumber.ToString() + " =";
                    preview1.Text = calculatedAnswer.ToString();
                }
            }
            else
            {
                lastNumber = double.Parse(preview1.Text);
                calculatedAnswer = lastNumber;
                newCalculated = calculatedAnswer;
                preview2.Text = lastNumber + " =";
                preview1.Text = newCalculated.ToString();
            }
            equalAgain = true;
            numberNegative = false;
        }

        private void preview1_TextChanged(object sender, EventArgs e)
        {
            if (preview1.Text != "0")
            {
                clearButton.Text = "CE";
            }
            else
            {
                clearButton.Text = "C";
            }
        }

        private void buttonNegativePositive_Click(object sender, EventArgs e)
        {
            // this will convert any number to negative, if it's positive
            // and positive, if it's negative
            if (preview1.Text == "0")
            {
                preview1.Text = "0";
            }
            else
            {
                if (numberNegative == true)
                {
                    preview1.Text = preview1.Text.Remove(0, 1);
                    numberNegative = false;
                }
                else
                {
                    preview1.Text = $"-{preview1.Text}";
                    numberNegative = true;
                }
            }
        }
    }
}
