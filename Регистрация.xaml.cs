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
using Microsoft.Win32;
using System.Data;
using System.Drawing;


namespace MOTOSalon
{
    /// <summary>
    /// Логика взаимодействия для Регистрация.xaml
    /// </summary>
    public partial class Регистрация : Window
    {
        public Регистрация()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            /* Главная regi = new Главная();
             this.Hide();
             regi.Show();*/






            switch (passwordBox1.Password == passwordBox2.Password)
            {
                case (true):



                    string NewUserCkeck;
                    ConnectionClass ConCheck = new ConnectionClass();
                    /* RegistryKey DataBase_Connection = Registry.CurrentConfig;
                     RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_AUTO_OPTIOS");*/
                    ConCheck.Connection_Options("ACER\\LOXX", "LogParol");

                    SqlConnection connectionUser = new SqlConnection(ConCheck.ConnectString);

                    SqlCommand Select_USID = new SqlCommand("select COUNT([dbo].[Login_L].[ID_Login]) " +
                        "from [dbo].[Login_L] " +
                        "where [login] = '" + textBox.Text + "' and [pass] = '" + passwordBox1.Password + "'", connectionUser);
                    
                        connectionUser.Open();
                        NewUserCkeck = Select_USID.ExecuteScalar().ToString();
                    MessageBox.Show(NewUserCkeck);
                        connectionUser.Close();
                    if (Convert.ToInt32(NewUserCkeck) == 0)
                    {
                        SqlConnection connectionNewUserInsert = new SqlConnection(ConCheck.ConnectString);
                        /*SqlCommand SelectGuestRole = new SqlCommand("select ID_roli from [dbo].[roli] where Role_Name = 'Гость'"
                            , connectionNewUserInsert);
                        SqlCommand SelectTelNum = new SqlCommand("select max(ID_Login) from [dbo].[Login_L]", connectionUser);*/
                        SqlCommand CreateNewUser = new SqlCommand("Login_1_ADD", connectionNewUserInsert);
                        CreateNewUser.CommandType = CommandType.StoredProcedure;
                        CreateNewUser.Parameters.AddWithValue("@FAM", textBox4.Text);
                        CreateNewUser.Parameters.AddWithValue("@IM", textBox5.Text);
                        CreateNewUser.Parameters.AddWithValue("@OTCH", textBox3.Text);
                        CreateNewUser.Parameters.AddWithValue("@login", textBox.Text);
                        CreateNewUser.Parameters.AddWithValue("@pass", passwordBox1.Password);
                        CreateNewUser.Parameters.AddWithValue("@Roli_id", 2);
                        
                      
                            connectionNewUserInsert.Open();
                            CreateNewUser.ExecuteNonQuery();
                            MessageBox.Show("Вы прошли регистрацию!");
                            connectionNewUserInsert.Close();

                            Главная regi = new Главная();
                            this.Hide();
                            regi.Show();
                      /*  }
                        catch
                        {

                            MessageBox.Show("Вы не прошли регистрацию!");
                        }*/
                    }
                    else
                    {
                        MessageBox.Show("Пользователь с именем " + textBox5.Text + ", уже есть!");
                    }
                        Close();                    
                    break;
                case (false):
                    MessageBox.Show("Пароли не совпадают, повторите попытку");
                    break;
                    
            }
        }
            }
        }
    
