using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            
            Button button = (Button)sender;
            string digit = button.Content.ToString();

            if(resbar.Content.ToString() == "0" && digit != "0")
            {
                resbar.Content = digit;
            }
            else
            {
                resbar.Content = resbar.Content + digit;
            }          
        }
        public void ACButtonClick(object sender, RoutedEventArgs e)
        {
            result = 0;
            resbar.Content= "0";
            lastNumber = 0;
        }
        
        public void PlusMinusButtonClick(object sender, RoutedEventArgs e)
        {
            double number = double.Parse(resbar.Content.ToString());
            resbar.Content= (-number).ToString();
        }
        public void PercentageButtonClick(object sender, RoutedEventArgs e)
        {
            double number = double.Parse(resbar.Content.ToString());
            resbar.Content= (number/100).ToString();
        }
        public void DotButtonClick(object sender, RoutedEventArgs e)
        {        
            if(!resbar.Content.ToString().Contains("."))
            {
                resbar.Content = resbar.Content + ".";
            }
        }
        public enum SelectedOperator
        {
            Addition,
            Substraction,
            Multiplication,
            Division
        }

        private SelectedOperator GetSelectedOperator()
        {
            return selectedOperator;
        }

        private void OperationBtnClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (Enum.TryParse(button.Tag.ToString(), out SelectedOperator selectedOperator))
                {
                    lastNumber = double.Parse(resbar.Content.ToString()) ;
                    this.selectedOperator = selectedOperator;
                    resbar.Content = "";
                }
            }
        }
        public void EqualsButtonClick(object sender, RoutedEventArgs e)
        {
                 double newNumber = double.Parse(resbar.Content.ToString());
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = MathService.Add(lastNumber, newNumber);
                        break;

                    case SelectedOperator.Substraction:
                    result = MathService.Subtract(lastNumber, newNumber);
                        break;

                    case SelectedOperator.Multiplication:
                    result = MathService.Multiply(lastNumber, newNumber);
                        break;

                    case SelectedOperator.Division:
                        if (newNumber != 0)
                        {
                        result = MathService.Divide(lastNumber, newNumber);
                        }
                        if(newNumber == 0)
                        {
                        string message = "sorry, this operation cannot be performed unless we break the laws of mathematics";
                        string title = "ERROR";
                        MessageBox.Show(message, title);
                    }
                        break;
                    default:
                        break;
                }
                resbar.Content = result.ToString();
        }
        }
}
