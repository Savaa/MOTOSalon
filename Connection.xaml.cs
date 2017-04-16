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

namespace MOTOSalon
{
    /// <summary>
    /// Логика взаимодействия для Connection.xaml
    /// </summary>
    public partial class Connection : Window
    {
        public Connection()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
         /*   RegistryKey DataBase_Connection = Registry.CurrentConfig;
            RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            Connection_Base_Party_Options.SetValue("DS", Encrypt.Encrypting(ServersCB.Text));
            Connection_Base_Party_Options.SetValue("IC", Encrypt.Encrypting("LogParol"));
            Connection_Base_Party_Options.SetValue("UID", Encrypt.Encrypting(UserName_text.Text));
            Connection_Base_Party_Options.SetValue("PDB", Encrypt.Encrypting(Pass_text.Text));
            */
        }
    }
}
