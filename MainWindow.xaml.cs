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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MOTOSalon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            Form frm2 = new Form();
            frm2.Show();
            this.Hide();
           // Close();
        }

        private void label_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 150;
            da.To = this.Width - 20;
            da.Duration = TimeSpan.FromSeconds(5);
            label.BeginAnimation(Button.WidthProperty, da);
        }

        private void label1_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 150;
            da.To = this.Width - 20;
            da.Duration = TimeSpan.FromSeconds(5);
            label1.BeginAnimation(Button.WidthProperty, da);
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Close();
        }
    }
}
