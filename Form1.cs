﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPFCalculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        string operatorClicked = "";
        bool isOperatorClicked = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void click_button(object sender, EventArgs e)
        {
            if (resultBox.Text == "0" || (isOperatorClicked))
            {
                resultBox.Clear();
            }

            isOperatorClicked = false;
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!resultBox.Text.Contains("."))
                    resultBox.Text = resultBox.Text + button.Text;
            }
            else
            {
                resultBox.Text = resultBox.Text + button.Text;
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(resultValue != 0)
            {
                equalBtn.PerformClick();
                operatorClicked = button.Text;
                labelCurrentOperation.Text = resultValue + " " + operatorClicked;
                isOperatorClicked = true;
            }
            else
            {

                operatorClicked = button.Text;
                resultValue = Double.Parse(resultBox.Text);
                labelCurrentOperation.Text = resultValue + " " + operatorClicked;
                isOperatorClicked = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resultBox.Text = "0";
            labelCurrentOperation.Text= "";
            resultValue = 0;
        }

        private void equalBtn_Click(object sender, EventArgs e)
        {
            switch(operatorClicked)
            {
                case "+":
                    resultBox.Text = (resultValue + Double.Parse(resultBox.Text)).ToString(); 
                    break;
                case "-":
                    resultBox.Text = (resultValue - Double.Parse(resultBox.Text)).ToString(); 
                    break;
                case "×":
                    resultBox.Text = (resultValue *  Double.Parse(resultBox.Text)).ToString(); break;
                case "÷":
                    resultBox.Text = (resultValue / Double.Parse(resultBox.Text)).ToString(); break;
                default:
                    break;
            }
            resultValue = Double.Parse(resultBox.Text);
            labelCurrentOperation.Text = "";
        }

        private void k(object sender, EventArgs e)
        {

        }
    }
}
