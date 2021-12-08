using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public bool newVal = false;
        public bool equalAgain = false;
        public string previewHolder = string.Empty;
        public string operation = string.Empty;
        public string preview2Holder = string.Empty;
        public double newCalculated = 0;
        public double previewCalculated = 0;
        public double calculatedAnswer = 0;
        public double lastNumber = 0;
        public ArrayList paranLastValue = new ArrayList();
        public ArrayList paranOperations = new ArrayList();
        public int paranCounter = 0;
        public bool needChange = false;

        private void reset(bool preview1reset = true)
        {
            newVal = false;
            equalAgain = false;
            previewHolder = string.Empty;
            operation = string.Empty;
            newCalculated = 0;
            previewCalculated = 0;
            lastNumber = 0;
            if (preview1reset)
            {
                preview1.Text = "0";
            }
            preview2.Text = null;
            paranCounter = 0;
            for (int i = paranLastValue.Count; i != 0; i--)
            {
                paranLastValue.RemoveAt(paranLastValue.Count - 1);
                paranOperations.RemoveAt(paranOperations.Count - 1);
            }
        }
        // erasing buttons
        private void eraseButton_Click(object sender, EventArgs e)
        {
            // erase the last input
            if (preview1.Text.Length <= 1)
            {
                // if input is less than 1 it will just update the preview1 to "0"
                preview1.Text = "0";
            }
            else
            {
                if (equalAgain)
                {
                    // if recently equal
                    string hold = preview1.Text;
                    reset();
                    preview1.Text = hold;
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
                reset();
            }
            else
            {
                // this will clear the preview1 and reset it back to "0"
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
        private void ButtonPressed(string selectedNumber)
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
            preview1.Text += selectedNumber;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // add 1 in preview1
            ButtonPressed("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // add 2 in preview1
            ButtonPressed("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // add 3 in preview1
            ButtonPressed("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // add 4 in preview1
            ButtonPressed("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // add 5 in preview1
            ButtonPressed("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // add 6 in preview1
            ButtonPressed("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // add 7 in preview1
            ButtonPressed("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // add 8 in preview1
            ButtonPressed("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // add 9 in preview1
            ButtonPressed("9");
        }
        private void button0_Click(object sender, EventArgs e)
        {
            ButtonPressed("0");
        }
        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (!preview1.Text.Contains("."))
            {
                preview1.Text += ".";
            }
        }
        private void AfterOperation(string whatOperation)
        {
            preview2.Text = preview2Holder;
            newCalculated = previewCalculated;
            preview1.Text = previewCalculated.ToString();
            newVal = true;
            operation = whatOperation;
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
                else if (newVal)
                {
                    preview2Holder = preview2.Text.Remove(preview2.Text.Length - 3) + " + ";
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
                    else if (operation == "closingParan")
                    {
                        if (paranCounter == 0 && paranOperations.Count != 0)
                        {
                            for (int i = paranOperations.Count; i != 0; i--)
                            {
                                ParanEqual();
                            }
                            previewCalculated = newCalculated;
                            preview2Holder = preview2.Text + " + ";
                        }
                        else
                        {
                            previewCalculated = double.Parse(preview1.Text);
                            preview2Holder = preview2.Text + " + ";
                        }
                    }
                    else if (operation == "openParan")
                    {
                        previewCalculated = double.Parse(preview1.Text);
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
            AfterOperation("add");
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
                    preview2Holder = preview2.Text.Remove(preview2.Text.Length - 3) + " - ";
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
                    else if (operation == "closingParan")
                    {
                        if (paranCounter == 0 && paranOperations.Count != 0)
                        {
                            for (int i = paranOperations.Count; i != 0; i--)
                            {
                                ParanEqual();
                            }
                            previewCalculated = newCalculated;
                            preview2Holder = preview2.Text + " - ";
                        }
                        else
                        {
                            previewCalculated = double.Parse(preview1.Text);
                            preview2Holder = preview2.Text + " - ";
                        }
                    }
                    else if (operation == "openParan")
                    {
                        previewCalculated = double.Parse(preview1.Text);
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
            AfterOperation("minus");
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
                    preview2Holder = preview2.Text.Remove(preview2.Text.Length - 3) + " ÷ ";
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
                    else if (operation == "closingParan")
                    {
                        if (paranCounter == 0 && paranOperations.Count != 0)
                        {
                            for (int i = paranOperations.Count; i != 0; i--)
                            {
                                ParanEqual();
                            }
                            previewCalculated = newCalculated;
                            preview2Holder = preview2.Text + " ÷ ";
                        }
                        else
                        {
                            previewCalculated = double.Parse(preview1.Text);
                            preview2Holder = preview2.Text + " ÷ ";
                        }
                    }
                    else if (operation == "openParan")
                    {
                        previewCalculated = double.Parse(preview1.Text);
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
            AfterOperation("divide");
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
                    preview2Holder = preview2.Text.Remove(preview2.Text.Length - 3) + " × ";
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
                    else if (operation == "closingParan")
                    {
                        if (paranCounter == 0 && paranOperations.Count != 0)
                        {
                            for (int i = paranOperations.Count; i != 0; i--)
                            {
                                ParanEqual();
                            }
                            previewCalculated = newCalculated;
                            preview2Holder = preview2.Text + " × ";
                        }
                        else
                        {
                            previewCalculated = double.Parse(preview1.Text);
                            preview2Holder = preview2.Text + " × ";
                        }
                    }
                    else if (operation == "openParan")
                    {
                        previewCalculated = double.Parse(preview1.Text);
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
            AfterOperation("multiply");
        }
        private void AfterEqual()
        {
            for (int i = paranOperations.Count; i != 0; i--)
            {
                ParanEqual();
            }
            calculatedAnswer = newCalculated;
            preview2.Text = preview2.Text + lastNumber.ToString();
            ClosedTheParan();
            preview2.Text += " =";
            preview1.Text = calculatedAnswer.ToString();
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            //equal the function
            if (operation == "add")
            {
                if (!equalAgain)
                {
                    lastNumber = double.Parse(preview1.Text);
                    newCalculated = newCalculated + lastNumber;
                    AfterEqual();
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
                    newCalculated = newCalculated - lastNumber;
                    AfterEqual();
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
                    newCalculated = newCalculated / lastNumber;
                    AfterEqual();
                }
                else
                {
                    calculatedAnswer = newCalculated / lastNumber;
                    newCalculated = calculatedAnswer;
                    preview2.Text = preview1.Text + " / " + lastNumber.ToString() + " =";
                    preview1.Text = calculatedAnswer.ToString();
                }
            }
            else if (operation == "multiply")
            {
                if (!equalAgain)
                {
                    lastNumber = double.Parse(preview1.Text);
                    newCalculated = newCalculated * lastNumber;
                    AfterEqual();
                }
                else
                {
                    calculatedAnswer = newCalculated * lastNumber;
                    newCalculated = calculatedAnswer;
                    preview2.Text = preview1.Text + " * " + lastNumber.ToString() + " =";
                    preview1.Text = calculatedAnswer.ToString();
                }
            }
            else if (operation == "closingParan")
            {
                for (int i = paranOperations.Count; i != 0; i--)
                {
                    ParanEqual();
                }
                calculatedAnswer = newCalculated;
                ClosedTheParan();
                preview2.Text += " =";
                preview1.Text = calculatedAnswer.ToString();
                operation = string.Empty;
            }
            else if (operation == "openParan")
            {
                newCalculated = double.Parse(preview1.Text);
                for (int i = paranOperations.Count; i != 0; i--)
                {
                    ParanEqual();
                }
                calculatedAnswer = newCalculated;
                preview2.Text += preview1.Text;
                ClosedTheParan();
                preview2.Text += " =";
                preview1.Text = calculatedAnswer.ToString();
                operation = string.Empty;
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
            preview1.Text = (-1 * double.Parse(preview1.Text)).ToString();
        }
        private void ClosingParen(string whatOperation)
        {
            if (whatOperation == "closingParan")
            {
                preview2.Text += " ) ";
            }
            else
            {
                preview2.Text += preview1.Text + " ) ";
            }
            if (whatOperation == "openParan")
            {
                newCalculated = double.Parse(preview1.Text);
            }
            else if (whatOperation == "add")
            {
                newCalculated += double.Parse(preview1.Text);
            }
            else if (whatOperation == "minus")
            {
                newCalculated -= double.Parse(preview1.Text);
            }
            else if (whatOperation == "divide")
            {
                newCalculated /= double.Parse(preview1.Text);
            }
            else if (whatOperation == "multiply")
            {
                newCalculated *= double.Parse(preview1.Text);
            }
            else if (whatOperation == "closingParan")
            {
                string lastParanOperation = (string)paranOperations[paranOperations.Count - 1];
                double lastParanNumber = (double)paranLastValue[paranLastValue.Count - 1];
                paranOperations.RemoveAt(paranOperations.Count - 1);
                paranLastValue.RemoveAt(paranLastValue.Count - 1);
                if (lastParanOperation == "add")
                {
                    newCalculated = lastParanNumber + newCalculated;
                }
                else if (lastParanOperation == "minus")
                {
                    newCalculated = lastParanNumber - newCalculated;
                }
                else if (lastParanOperation == "divide")
                {
                    newCalculated = lastParanNumber / newCalculated;
                }
                else if (lastParanOperation == "multiply")
                {
                    newCalculated = lastParanNumber * newCalculated;
                }
            }
            preview1.Text = newCalculated.ToString();
        }
        private void ParanEqual()
        {
            string lastParanOperation = (string)paranOperations[paranOperations.Count - 1];
            double lastParanNumber = (double)paranLastValue[paranLastValue.Count - 1];
            paranOperations.RemoveAt(paranOperations.Count - 1);
            paranLastValue.RemoveAt(paranLastValue.Count - 1);
            if (lastParanOperation == "add")
            {
                newCalculated = lastParanNumber + newCalculated;
            }
            else if (lastParanOperation == "minus")
            {
                newCalculated = lastParanNumber - newCalculated;
            }
            else if (lastParanOperation == "divide")
            {
                newCalculated = lastParanNumber / newCalculated;
            }
            else if (lastParanOperation == "multiply")
            {
                newCalculated = lastParanNumber * newCalculated;
            }
        }
        private void ClosedTheParan()
        {
            if (paranCounter != 0)
            {
                for (int i = paranCounter; i != 0; i--)
                {
                    preview2.Text += " ) ";
                }
                operation = string.Empty;
            }
        }
        private void buttonOpenParen_Click(object sender, EventArgs e)
        {
            if (equalAgain)
            {
                reset(false);
            }
            if (preview2.Text.Length > 1)
            {
                if (operation != "openParan" || operation != "closingParan")
                {
                    paranLastValue.Add(newCalculated);
                    paranOperations.Add(operation);
                }
            }
            if (operation == "closingParan")
            {
                preview2.Text = " ( ";
            }
            else
            {
                preview2.Text += " ( ";
            }
            if (operation != string.Empty)
            {
                preview1.Text = "0";
                newCalculated = 0;
            }
            operation = "openParan";
            paranCounter++;
        }

        private void buttonCloseParen_Click(object sender, EventArgs e)
        {
            if (paranCounter != 0)
            {
                ClosingParen(operation);
                paranCounter--;
                operation = "closingParan";
            }
        }
    }
}
