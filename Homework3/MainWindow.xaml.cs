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

namespace Homework3
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Tip tip;

        public MainWindow()
        {
            this.InitializeComponent();
            tip = new Tip();
        }

        private void Amount_LostFocus(object sender, RoutedEventArgs e)
        {
           
        }

        private void Amount_GotFocus(object sender, RoutedEventArgs e)
        {
            Amount.Text = "￥";
        }

        private void Amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            performCalculation();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            performCalculation();
        }

        private void performCalculation()
        {
            var selectedRadio = myStackPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
            if (selectedRadio != null)
            {
                tip.CalculateTip(Amount.Text, double.Parse(selectedRadio.Tag.ToString()));
            }
            if (tip != null)
            {
                amountToTipTextBlock.Text = tip.TipAmount;
                Total.Text = tip.TotalAmount;
            }
        }
    }
}
