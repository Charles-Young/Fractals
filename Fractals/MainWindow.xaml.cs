using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;

namespace Fractals
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void MandelContainer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double containeraverage = MandelContainer.ActualHeight / MandelContainer.ActualWidth;
            m.Size = new Point(m.Size.Y * containeraverage, m.Size.Y);
        }
        private void maxIter_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            m.MaxIter = e.NewValue;
        }
        private void powerReal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            m.Power = new Point(e.NewValue, m.Power.Y);
        }
        private void powerImaginary_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            m.Power = new Point(m.Power.X, e.NewValue);
        }
        private void bailout_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            m.Bailout = e.NewValue;
        }

        private void popupDialog_OnClick(object sender, RoutedEventArgs e)
        {
            aboutwindow aboutwindow = new aboutwindow();
            aboutwindow.ShowDialog();
        }
        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void MaxNormal_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }
        private void Min_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Reset_OnClick(object sender, RoutedEventArgs e)
        {
            maxIter.Value = 32;
            powerReal.Value = 2;
            powerImaginary.Value = 0;
            bailout.Value = 4;
        }
    }
}
