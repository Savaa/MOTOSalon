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
using System.Windows.Shapes;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace MOTOSalon
{
    /// <summary>
    /// Логика взаимодействия для Form.xaml
    /// </summary>
    public partial class Form : Window
    {
       // string connectionString;
        public Form()
        {
            InitializeComponent();
           // connectionString = "Data Source = ACER\\LOXX; Initial Catalog = MAGAZIN; Integrated Security = True; User ID = \"\"; Password = \"\"";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           //button. IsEnabled = false;
           // button2.IsEnabled = false;
            Авторизация regi = new Авторизация();
            this.Hide();
            regi.Show();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            switch (MessageBox.Show("Уже уходите???", "Выход", MessageBoxButton.YesNo))
            {
                case MessageBoxResult.Yes:
                    Application.Current.Shutdown();
                    break;
                case MessageBoxResult.No:

                    break;
            }

        }

        private void button1_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

          //  button.IsEnabled = false;
            Регистрация regi = new Регистрация();
            this.Hide();
            regi.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ConnectionClass connection = new ConnectionClass();
            RegistryKey DB_con = Registry.CurrentUser;
            RegistryKey Connect_MAGAZIN = DB_con.CreateSubKey("MAGAZIN_DB");
            connection.Connection_Options(Connect_MAGAZIN.GetValue("DS").ToString(),
                Connect_MAGAZIN.GetValue("IC").ToString());
            SqlConnection connectCheck = new SqlConnection(connection.ConnectString);
            try
            {
                connectCheck.Open();
                MessageBox.Show("All Good");
            }
            catch
            {
                MessageBox.Show("All Bad");
            }

        }
    }
}
