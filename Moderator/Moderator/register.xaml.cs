using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Moderator
{
    /// <summary>
    /// Logika interakcji dla klasy register.xaml
    /// </summary>
    public partial class register : Window
    {
        public register()
        {
            InitializeComponent();
        }
        private void Border_MouseDown(object senior, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string Name = name_user.Text;
            string surname = surname_user.Text;
            string id_user = id_user_n.Text;
            string email = mail.Text;
            string rola = role.Text;

            if (password.Password == password2.Password)
            {
                string Myconnect = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=Oraclessie1;";
                string query = " INSERT INTO `mydb`.`users_data`" +
                    " (`id_user`, `name`, `surname`, `e_maill`, `rola` ) VALUES " +
                    "\r\n('" + this.id_user_n.Text + "', '" + this.name_user.Text + "', '" + this.surname_user.Text + "', '" + this.mail.Text + "', '" + rola + "'); ";
                string query2= "Insert into `mydb`.`user_account`" + "(`id_user`,`password`) VALUES " + "\r\n('"+this.id_user_n.Text+"', '"+this.password.Password+"');";
                MySqlConnection Connect = new MySqlConnection(Myconnect);
                MySqlCommand comand = new MySqlCommand(query, Connect);
                
                MySqlDataReader MyReader2;

                Connect.Open();
                MyReader2 = comand.ExecuteReader();
                while (MyReader2.Read()) { }
                Connect.Close();
                string Myconnect1 = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=Oraclessie1;";
                MySqlConnection Connect1 = new MySqlConnection(Myconnect1);
                MySqlCommand command2 = new MySqlCommand(query2, Connect1);
                MySqlDataReader MyReader1;
                Connect1.Open();
                MyReader1 = command2.ExecuteReader();
                MessageBox.Show("Zapisano Użytkownika");
                while (MyReader1.Read()) { }
                Connect1.Close();
            }
            else { MessageBox.Show("Hasła nie są takie same"); }
        }
    }
}
