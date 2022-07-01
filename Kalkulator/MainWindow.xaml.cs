using System;
using System.Windows;

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Constructors

        #pragma warning disable CS8618
        public MainWindow()
        #pragma warning restore CS8618
        {
            InitializeComponent();
            SetStartupData();
        }

        #endregion

        #region Operations

        private void SetStartupData()
        {
            labelContent = "";
            currentOperation = '\0';
            isOperationSet = false;
            number = 0;
            SetLabelContent();
        }

        private void SetLabelContent()
        {
            LabelOutput.Content = labelContent;
        }

        /// <summary>
        /// Checking if LabelOutput has maximum or minumum size. Send true if checking max size, false if checking min size of LabelOutput
        /// </summary>
        /// <param name="max"></param>
        /// <returns>False if LabelOutput has specific size, true otherwise</returns>
        private bool CheckLabelSize(bool max)
        {
            #pragma warning disable CS8602
            return max == true 
                ? LabelOutput.Content.ToString().Length != LABEL_CONTENT_MAX_SIZE
                : LabelOutput.Content.ToString().Length != LABEL_CONTENT_MIN_SIZE;
            #pragma warning restore CS8602
        }

        private bool CheckIfOperationIsSet()
        {
            if(isOperationSet)
            {
                isOperationSet=false;
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Button Click Operations

        private void ButtonNumber0_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckLabelSize(true))
                return;
            if (CheckIfOperationIsSet())
            {
                labelContent = "0";
            }
            else
            {
                labelContent = Convert.ToDecimal(labelContent + "0").ToString();
            }
            SetLabelContent();
        }

        private void ButtonNumber1_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckLabelSize(true))
                return;
            if (CheckIfOperationIsSet())
            {
                labelContent = "1";
            }
            else
            {
                labelContent = Convert.ToDecimal(labelContent + "1").ToString();
            }
            SetLabelContent();
        }

        private void ButtonNumber2_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckLabelSize(true))
                return;
            if (CheckIfOperationIsSet())
            {
                labelContent = "2";
            }
            else
            {
                labelContent = Convert.ToDecimal(labelContent + "2").ToString();
            }
            SetLabelContent();
        }

        private void ButtonNumber3_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckLabelSize(true))
                return;
            if (CheckIfOperationIsSet())
            {
                labelContent = "3";
            }
            else
            {
                labelContent = Convert.ToDecimal(labelContent + "3").ToString();
            }
            SetLabelContent();
        }

        private void ButtonNumber4_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckLabelSize(true))
                return;
            if (CheckIfOperationIsSet())
            {
                labelContent = "4";
            }
            else
            {
                labelContent = Convert.ToDecimal(labelContent + "4").ToString();
            }
            SetLabelContent();
        }

        private void ButtonNumber5_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckLabelSize(true))
                return;
            if (CheckIfOperationIsSet())
            {
                labelContent = "5";
            }
            else
            {
                labelContent = Convert.ToDecimal(labelContent + "5").ToString();
            }
            SetLabelContent();
        }

        private void ButtonNumber6_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckLabelSize(true))
                return;
            if (CheckIfOperationIsSet())
            {
                labelContent = "6";
            }
            else
            {
                labelContent = Convert.ToDecimal(labelContent + "6").ToString();
            }
            SetLabelContent();
        }

        private void ButtonNumber7_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckLabelSize(true))
                return;
            if (CheckIfOperationIsSet())
            {
                labelContent = "7";
            }
            else
            {
                labelContent = Convert.ToDecimal(labelContent + "7").ToString();
            }
            SetLabelContent();
        }

        private void ButtonNumber8_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckLabelSize(true))
                return;
            if (CheckIfOperationIsSet())
            {
                labelContent = "8";
            }
            else
            {
                labelContent = Convert.ToDecimal(labelContent + "8").ToString();
            }
            SetLabelContent();
        }

        private void ButtonNumber9_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckLabelSize(true))
                return;
            if (CheckIfOperationIsSet())
            {
                labelContent = "9";
            }
            else
            {
                labelContent = Convert.ToDecimal(labelContent + "9").ToString();
            }
            SetLabelContent();
        }

        private void ButtonDeleteOperation_Click(object sender, RoutedEventArgs e)
        {
            SetStartupData();
        }

        private void ButtonEqualOperation_Click(object sender, RoutedEventArgs e)
        {
            if (currentOperation == '\0') { }
            else if (currentOperation == '+')
            {
                number += Convert.ToDecimal(labelContent);
                labelContent = number.ToString();
                SetLabelContent();
                isOperationSet = false;
            }
            else if (currentOperation == '-')
            {
                number -= Convert.ToDecimal(labelContent);
                labelContent = number.ToString();
                SetLabelContent();
                isOperationSet = false;
            }
            else if (currentOperation == '*')
            {
                number *= Convert.ToDecimal(labelContent);
                labelContent = number.ToString();
                SetLabelContent();
                isOperationSet = false;
            }
            else if (currentOperation == '/')
            {
                if (labelContent == "0")
                {
                    labelContent = "Dividing by 0?";
                    number = 0;
                }
                else
                {
                    number /= Convert.ToDecimal(labelContent);
                    labelContent = number.ToString();
                }                
                SetLabelContent();
                isOperationSet = false;
            }
            number = 0;
        }
        private void ButtonAddOperation_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckLabelSize(false))
                return;
            currentOperation = '+';
            
            if(number != 0)
            {
                try
                {
                    number += Convert.ToDecimal(labelContent);
                    labelContent = number.ToString();
                }
                catch(OverflowException)
                {
                    number = Convert.ToDecimal(labelContent);
                    labelContent = number.ToString();
                }
                SetLabelContent();
            }
            else
            {
                try
                {
                    number = Convert.ToDecimal(labelContent);
                }
                catch (FormatException)
                {
                    SetStartupData();
                    return;
                }
            }
            isOperationSet = true;
        }
        private void ButtonSubtractOperation_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckLabelSize(false))
                return;
            currentOperation = '-';
            if (number != 0)
            {
                try
                {
                    number -= Convert.ToDecimal(labelContent);
                    labelContent = number.ToString();
                }
                catch(OverflowException)
                {
                    number = Convert.ToDecimal(labelContent);
                    labelContent = number.ToString();
                }
                SetLabelContent();
            }
            else
            {
                try
                {
                    number = Convert.ToDecimal(labelContent);
                }
                catch (FormatException)
                {
                    SetStartupData();
                    return;
                }
            }
            isOperationSet = true;
        }
        private void ButtonMultiplyOperation_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckLabelSize(false))
                return;
            currentOperation = '*';
            if (number != 0)
            {
                try
                {
                    number *= Convert.ToDecimal(labelContent);
                    labelContent = number.ToString();
                }
                catch (OverflowException)
                {
                    number = Convert.ToDecimal(labelContent);
                    labelContent = number.ToString();                   
                }
                SetLabelContent();
            }
            else
            {
                try
                {
                    number = Convert.ToDecimal(labelContent);
                }
                catch (FormatException)
                {
                    SetStartupData();
                    return;
                }
            }
            isOperationSet = true;
        }
        private void ButtonDivideOperation_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckLabelSize(false))
                return;
            currentOperation = '/';
            if (number != 0)
            {
                if (labelContent == "0")
                {
                    labelContent = "Dividing by 0?";
                }
                else
                {
                    try
                    {
                        number /= Convert.ToDecimal(labelContent);
                        labelContent = number.ToString();
                    }
                    catch(OverflowException)
                    {
                        number = Convert.ToDecimal(labelContent);
                        labelContent = number.ToString();
                    }
                }
                SetLabelContent();

            }
            else
            {
                try
                {
                    number = Convert.ToDecimal(labelContent);
                }
                catch (FormatException)
                {
                    SetStartupData();
                    return;
                }
            }
            isOperationSet = true;
        }

        #endregion

        #endregion

        #region Data Members

        private string labelContent;
        private char currentOperation;
        private bool isOperationSet;
        decimal number;

        #endregion

        #region Constants

        private const int LABEL_CONTENT_MAX_SIZE = 18;
        private const int LABEL_CONTENT_MIN_SIZE = 0;

        #endregion

    }
}
