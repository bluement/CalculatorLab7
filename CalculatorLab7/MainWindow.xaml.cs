using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorLab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber;
        double result = 0;
        private SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
            acButton.Click += ACButtonClick;
            equalsButton.Click += EqualsButtonClick;
            plusMinusButton.Click += PlusMinusButtonClick;
            percentageButton.Click += PercentageButtonClick;
            dotButton.Click += DotButtonClick;


        }  
        private void NumInput(object sender, EventArgs e)
        {
            string name = ((Button)sender).Name;
            string input = "";

            switch (name)
            {
                case "ZeroBtn":
                    input += "0";
                    result = double.Parse(input);
                    resbar.Content = input;
                    break;

                case "OneBtn":
                    input += "1";
                    result = double.Parse(input);
                    resbar.Content = input;
                    break;

                case "TwoBtn":
                    input += "2";
                    result = double.Parse(input);
                    resbar.Content = input;
                    break;

                case "ThreeBtn":
                    input += "3";
                    result = double.Parse(input);
                    resbar.Content = input;
                    break;

                case "FourBtn":
                    input += "4";
                    result = double.Parse(input);
                    resbar.Content = input;
                    break;

                case "FiveBtn":
                    input += "5";
                    result = double.Parse(input);
                    resbar.Content = input;
                    break;

                case "SixBtn":
                    input += "6";
                    result = double.Parse(input);
                    resbar.Content = input;
                    break;

                case "SevenBtn":
                    input += "7";
                    result = double.Parse(input);
                    resbar.Content = input;
                    break;

                case "EightBtn":
                    input += "8";
                    result = double.Parse(input);
                    resbar.Content = input;
                    break;

                case "NineBtn":
                    input += "9";
                    result = double.Parse(input);
                    resbar.Content = input;
                    break;
            }
        }
        public void ACButtonClick(object sender, RoutedEventArgs e)
        {
            result = 0;
            resbar.Content= result;
        }
        
        public void PlusMinusButtonClick(object sender, RoutedEventArgs e)
        {
            result *= -1;
            resbar.Content= result;
        }
        public void PercentageButtonClick(object sender, RoutedEventArgs e)
        {
            if(result != 0)
            {
                result /= 100;
                resbar.Content = result + "%";
                
            }
        }
        public void DotButtonClick(object sender, RoutedEventArgs e)
        {
            string resultString = result.ToString();
            
            if(!resultString.Contains("."))
            {
                result = double.Parse(resultString + ".");
                resbar.Content = result;
            }
        }
        public enum SelectedOperator
        {
            Addition,
            Substraction,
            Multiplication,
            Division
        }
        private void OperationBtnClick(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                if(Enum.TryParse(button.Tag.ToString(), out SelectedOperator selectedOperator)) 
                {
                    this.selectedOperator = selectedOperator;
                    lastNumber = result;
                    result = 0;
                    resbar.Content = "";
                }
            }
        }
        public void EqualsButtonClick(object sender, RoutedEventArgs e)
        {
            double output = 0;
            switch (selectedOperator)
            {
                case SelectedOperator.Addition:
                    double valAdd = result;
                    output = MathService.Add(lastNumber, valAdd);
                    break;

                case SelectedOperator.Substraction:
                    double valMinus = result;
                    output = MathService.Subtract(lastNumber, valMinus);
                    break;

                case SelectedOperator.Multiplication:
                    double valMult = result;
                    output = MathService.Multiply(lastNumber, valMult);
                    break;

                case SelectedOperator.Division:
                    double valDiv = result;
                    if(valDiv != 0) 
                    {
                        output = MathService.Divide(lastNumber, valDiv);
                    }
                    else
                    {
                        resbar.Content = "Cannot divide by zero";
                    }
                    break;
                default:
                    break;
            }
            resbar.Content = output.ToString();

        }
        }
}
