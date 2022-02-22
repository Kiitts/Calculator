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
        public bool alreadyPreview2 = false;
        public bool squared = false;
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
            alreadyPreview2 = false;
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
        private void hypButton_Click(object sender, EventArgs e)
        {
            Button[] buttons = new Button[] {sinButton, cosButton, tanButton,
                secButton, cscButton, cotButton};
            if (!buttons[0].Text.Contains('h'))
            {
                if (buttons[0].Text.Contains("⁻¹"))
                {
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        if (i < 3)
                        {
                            buttons[i].Text = buttons[i].Text.Remove(buttons[i].Text.Length - 2) + "h⁻¹";
                        }
                        else
                        {
                            buttons[i].Text += "h";
                        }
                    }
                }
                else
                {
                    for (int i = 0; i<buttons.Length; i++)
                    {
                        buttons[i].Text += "h";
                    }
                }
            }
            else
            {
                for(int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Text = buttons[i].Text.Replace("h", String.Empty);
                }
            }
        }

        private void changeTrigoButton_Click(object sender, EventArgs e)
        {
            //change trigometry buttons and others
            Button[] buttons = new Button[] { sinButton, cosButton, tanButton,
                secButton, cscButton, cotButton };
            if(buttons[0].Text.Contains("⁻¹"))
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Text = buttons[i].Text.Remove(buttons[i].Text.Length - 2);
                }
                xSquaredButton.Text = "x²"; squareRootButton.Text = "√x"; exponentButton.Text = "x^y";
                exponentialTen.Text = "10^x"; logButton.Text = "log"; lnButton.Text = "ln";
            }
            else
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Text += "⁻¹";
                }
                xSquaredButton.Text = "x³"; squareRootButton.Text = "³√x"; exponentButton.Text = "y√x";
                exponentialTen.Text = "2^x"; logButton.Text = "logᵧx"; lnButton.Text = "e^x";
            }
        }

        // numerical buttons
        private void ButtonPressed(string selectedNumber)
        {
            if (preview1.Text == "0" || newVal || equalAgain || squared)
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
                preview1.Text = string.Empty;
                equalAgain = false;
                squared = false;
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
        private void preview2HolderOperation(string previewSymbol)
        {
            if (alreadyPreview2)
            {
                preview2Holder = preview2.Text + $" {previewSymbol} ";
                alreadyPreview2 = false;
            }
            else
            {
                preview2Holder = preview2.Text + preview1.Text + $" {previewSymbol} ";
            }
        }
        private void Operational(string whatOperation, string previewSymbol)
        {
            
            if (preview2.Text.Length > 1)
            {
                // if the preview2 has values
                if (equalAgain)
                {
                    // if recently equal
                    preview2Holder = preview1.Text + $" {previewSymbol} ";
                    previewCalculated = newCalculated;
                    equalAgain = false;
                }
                else if (newVal)
                {
                    preview2Holder = preview2.Text.Remove(preview2.Text.Length - 3) + $" {previewSymbol} ";
                    previewCalculated = newCalculated;
                }
                else
                {
                    if (operation == "minus")
                    {
                        // if the last operation is subtraction, the preview will show
                        // the value of the last calculated number minus the last input.
                        if (squared)
                        {
                            previewCalculated = newCalculated;
                            preview2Holder = preview2.Text + " +";
                            squared = false;
                        }
                        else
                        {
                            previewCalculated = newCalculated - double.Parse(preview1.Text);
                            preview2HolderOperation(previewSymbol);
                        }
                    }
                    else if (operation == "divide")
                    {
                        // if the last operation is division, the preview will show
                        // the value of the last calculated number divide the last input.
                        if (squared)
                        {
                            previewCalculated = newCalculated;
                            preview2Holder = preview2.Text + " +";
                            squared = false;
                        }
                        else
                        {
                            previewCalculated = newCalculated / double.Parse(preview1.Text);
                            preview2HolderOperation(previewSymbol);
                        }
                    }
                    else if (operation == "multiply")
                    {
                        // if the last operation is division, the preview will show
                        // the value of the last calculated number divide the last input.
                        if (squared)
                        {
                            previewCalculated = newCalculated;
                            preview2Holder = preview2.Text + " +";
                            squared = false;
                        }
                        else
                        {
                            previewCalculated = newCalculated * double.Parse(preview1.Text);
                            preview2HolderOperation(previewSymbol);
                        }
                    }
                    else if (operation == "add")
                    {
                        if (squared)
                        {
                            previewCalculated = newCalculated;
                            preview2Holder = preview2.Text + " +";
                            squared = false;
                        }
                        else
                        {
                            previewCalculated = newCalculated + double.Parse(preview1.Text);
                            preview2HolderOperation(previewSymbol);
                        }
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
                            preview2Holder = preview2.Text + $" {previewSymbol} ";
                        }
                        else
                        {
                            previewCalculated = double.Parse(preview1.Text);
                            preview2Holder = preview2.Text + $" {previewSymbol} ";
                        }
                    }
                    else if (operation == "openParan")
                    {
                        previewCalculated = double.Parse(preview1.Text);
                        preview2HolderOperation(previewSymbol);
                    }
                    else
                    {
                        previewCalculated = double.Parse(preview1.Text);
                        preview2HolderOperation(previewSymbol);
                    }
                }
            }
            else
            {
                previewCalculated = double.Parse(preview1.Text);
                preview2Holder = preview1.Text + $" {previewSymbol} ";
            }
            preview2.Text = preview2Holder;
            newCalculated = previewCalculated;
            preview1.Text = previewCalculated.ToString();
            newVal = true;
            operation = whatOperation;
        }
        private void buttonAddition_Click(object sender, EventArgs e)
        {
            Operational("add", "+");
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            Operational("minus", "-");
        }
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            Operational("divide", "÷");
        }
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            Operational("multiply", "×");
        }
        private void AfterEqual()
        {
            for (int i = paranOperations.Count; i != 0; i--)
            {
                ParanEqual();
            }
            calculatedAnswer = newCalculated;
            if (alreadyPreview2)
            {
                preview2.Text = preview2.Text;
                alreadyPreview2 = false;
            }
            else
            {
                if (!squared)
                {
                    preview2.Text = preview2.Text + lastNumber.ToString();
                }
            }
            ClosedTheParan();
            preview2.Text += " =";
            preview1.Text = calculatedAnswer.ToString();
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            //equal the function
            if(squared)
            {
                if (!equalAgain)
                {
                    AfterEqual();
                }
                else
                {
                    preview2.Text = preview1.Text + " =";
                    preview1.Text = newCalculated.ToString();
                }
            }
            else if (operation == "add")
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
            Button[] buttons = new Button[] {angleButton, button0, button1, button2, button3, button4,
            button5, button6, button7, button8, button9, eraseButton, changeTrigoButton, sinButton,
            cosButton, tanButton, secButton, cscButton, hypButton, cosButton, xSquaredButton, buttonOverX,
            buttonAbsolute, buttonExponential, buttonModulus, squareRootButton, buttonOpenParen,
            buttonCloseParen, buttonFactorial, buttonDivide, buttonMultiply, buttonAddition, buttonSubtract,
            buttonEqual, exponentButton, exponentialTen,logButton, lnButton, buttonNegativePositive,
            buttonDot};

            if (preview1.Text != "0")
            {
                clearButton.Text = "CE";
            }
            else
            {
                clearButton.Text = "C";
            }
            if(preview1.Text == "NaN" || preview1.Text == "∞")
            {
                for(int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Enabled = true;
                }
            }
        }

        private void buttonNegativePositive_Click(object sender, EventArgs e)
        {
            if (preview1.Text != "0")
            {
                preview1.Text = (-1 * double.Parse(preview1.Text)).ToString();
            }
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
        private double GetAngleValue(string whatAngle, double theValue)
        {
            switch(whatAngle)
            {
                case "sin":
                    return Math.Sin(theValue);
                case "cos":
                    return Math.Cos(theValue);
                case "tan":
                    return Math.Tan(theValue);
                case "sec":
                    return 1 / Math.Cos(theValue);
                case "csc":
                    return 1 / Math.Sin(theValue);
                case "cot":
                    return 1 / Math.Tan(theValue);
                case "sin⁻¹":
                    return Math.Asin(theValue);
                case "cos⁻¹":
                    return Math.Acos(theValue);
                case "tan⁻¹":
                    return Math.Atan(theValue);
                case "sec⁻¹":
                    return 1 / Math.Acos(theValue);
                case "csc⁻¹":
                    return 1 / Math.Asin(theValue);
                case "cot⁻¹":
                    return 1 / Math.Atan(theValue);
                case "sinh":
                    return Math.Sinh(theValue);
                case "cosh":
                    return Math.Cosh(theValue);
                case "tanh":
                    return Math.Tanh(theValue);
                case "sech":
                    return 1 / Math.Cosh(theValue);
                case "csch":
                    return 1 / Math.Sinh(theValue);
                case "coth":
                    return 1 / Math.Tanh(theValue);
            }
            return 0;
        }

        private void AngleOperation(string whatAngle)
        {
            double holderAngle = 0;
            if (angleButton.Text == "DEG")
            {
                preview2.Text += $"{whatAngle}₀({preview1.Text})";
                holderAngle = Math.Round(GetAngleValue(whatAngle, double.Parse(preview1.Text)));
                preview1.Text = (holderAngle*(Math.PI/180)).ToString();
            }
            else if (angleButton.Text == "RAD")
            {
                preview2.Text += $"{whatAngle}ᵣ({preview1.Text})";
                holderAngle = Math.Round(GetAngleValue(whatAngle, double.Parse(preview1.Text)), 11);
                preview1.Text = holderAngle.ToString();
            }
            else
            {
                preview2.Text += $"{whatAngle}₉({preview1.Text})";
                holderAngle = Math.Round(GetAngleValue(whatAngle, double.Parse(preview1.Text) *
                     Math.PI / 200), 11);
                preview1.Text = holderAngle.ToString();
            }
            alreadyPreview2 = true;
        }

        private void sinButton_Click(object sender, EventArgs e)
        {
            AngleOperation(sinButton.Text);
        }

        private void cosButton_Click(object sender, EventArgs e)
        {
            AngleOperation(cosButton.Text);
        }

        private void tanButton_Click(object sender, EventArgs e)
        {
            AngleOperation(tanButton.Text);
        }

        private void secButton_Click(object sender, EventArgs e)
        {
            AngleOperation(secButton.Text);
        }

        private void cscButton_Click(object sender, EventArgs e)
        {
            AngleOperation(cscButton.Text);
        }

        private void cotButton_Click(object sender, EventArgs e)
        {
            AngleOperation(cotButton.Text);
        }

        private void xSquareSupport()
        {
            preview1.Text = newCalculated.ToString();
            newVal = false;
            squared = true;
        }
        private void xSquaredOtherSupport(double toThe = 2)
        {
            if (operation == "add")
            {
                newCalculated += Math.Pow(double.Parse(preview1.Text), 2);
                preview2.Text += $" sqr({preview1.Text})";
                xSquareSupport();
            }
            else if (operation == "minus")
            {
                newCalculated -= Math.Pow(double.Parse(preview1.Text), 2);
                preview2.Text += $" sqr({preview1.Text})";
                xSquareSupport();
            }
            else if (operation == "divide")
            {
                newCalculated /= Math.Pow(double.Parse(preview1.Text), 2);
                preview2.Text += $" sqr({preview1.Text})";
                xSquareSupport();
            }
            else if (operation == "multiply")
            {
                newCalculated *= Math.Pow(double.Parse(preview1.Text), 2);
                preview2.Text += $" sqr({preview1.Text})";
                xSquareSupport();
            }
            else
            {
                preview2.Text += $"sqr({preview1.Text})";
                newCalculated = Math.Pow(double.Parse(preview1.Text), 2);
                xSquareSupport();
            }
        }
        private void xSquaredButton_Click(object sender, EventArgs e)
        {
            xSquaredOtherSupport();
        }
    }
}
