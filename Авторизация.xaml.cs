using Microsoft.Win32;
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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;


namespace MOTOSalon
{
    /// <summary>
    /// Логика взаимодействия для Авторизация.xaml
    /// </summary>
    public partial class Авторизация : Window
    {
        public string USID;
        public string ISA;
        public string ALA;
        public string EOA;
        public string MA;
        public string PRA;
      //  Connection cw = new Connection();



        public Авторизация()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //*=================================================================
           // Главная regi = new Главная();
         //   this.Hide();
           // regi.Show();
            /*=================================================================*/

            ConnectionClass ConCheck = new ConnectionClass();
           /* RegistryKey DataBase_Connection = Registry.CurrentConfig;
            RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_AUTO_OPTIOS");*/
            ConCheck.Connection_Options("ACER\\LOXX", "LogParol");
            SqlConnection connectionUser = new SqlConnection(ConCheck.ConnectString);
            SqlCommand Select_USID = new SqlCommand("select [dbo].[Login_L].[ID_Login] " +
                "from [dbo].[Login_L] " +
                "where [login] = '" + textBox.Text + "' and [pass] = '" + passwordBox.Password + "'", connectionUser);
            SqlCommand Select_ISA = new SqlCommand("select [dbo].[roli].[Role_Name]" +
              " from [dbo].[Login_L] inner join[dbo].[roli] on " +
              "[dbo].[Login_L].[Roli_id] =[dbo].[roli].[ID_roli]" +
              "where [login]='" + textBox.Text + "' and [pass]='" + passwordBox.Password + "'", connectionUser);
            
              
            try
            {
                connectionUser.Open();
                USID = Select_USID.ExecuteScalar().ToString();
                ISA = Select_ISA.ExecuteScalar().ToString();
               /* MessageBox.Show(ISA);
                USID = Select_USID.ExecuteScalar().ToString();
                ISA = Select_ISA.ExecuteScalar().ToString();
                MessageBox.Show(ISA);
               connectionUser.Close();
                 */              connectionUser.Close();


                MessageBox.Show("Авторизация пройдена успешно");
                Главная regi = new Главная();
                this.Hide();
                regi.Show();
            }
            catch (Exception bl)
            {
                MessageBox.Show(bl.Message);
            }
          
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ConnectionClass ConCheck = new ConnectionClass();
            /*RegistryKey DataBase_Connection = Registry.CurrentConfig;
              RegistryKey Connection_Base_LogParol = DataBase_Connection.CreateSubKey("LogParol");*/
            ConCheck.Connection_Options("ACER\\LOXX", "LogParol");
            SqlConnection connectionCheck = new SqlConnection(ConCheck.ConnectString);

            try
            {
                connectionCheck.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            switch (connectionCheck.State == ConnectionState.Open)
            {
                case (true):
                    label11.Content = " - Подключение к источнику данных есть.";
                   
                    break;
                case (false):
                    label11.Content = " - Подключение к источнику данных отсутствует.";
                  
                    break;
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
     
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            Регистрация regi = new Регистрация();
            this.Hide();
            regi.Show();
        }
    }
}
