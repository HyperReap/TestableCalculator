using Mathematics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MathUtilsSimple Math { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Math = new MathUtilsSimple();
            //Debugger.Launch(); //TODO:: Debugger Launch
        }

        private void WriteIntoInput(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn is not null)
            {
                if (btn.Content.Equals("x"))
                    this.Input.Text += "*"; 
                else if (btn.Content.Equals("÷"))
                    this.Input.Text += "/";
                else
                    this.Input.Text += btn.Content;
            }
        }

        private void RemoveLastFromInput(object sender, RoutedEventArgs e)
        {
            if(this.Input.Text.Length > 0)
                this.Input.Text = this.Input.Text.Substring(0, this.Input.Text.Length - 1);
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            this.Input.Text = Math.Evaluate(this.Input.Text);
        }
    }
}
