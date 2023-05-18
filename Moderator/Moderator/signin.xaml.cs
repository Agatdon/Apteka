using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math;
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
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;
using System.Xml.Linq;

namespace Moderator
{
    /// <summary>
    /// Logika interakcji dla klasy signin.xaml
    /// </summary>
    public partial class signin : Window
    {
        string role;
        string connectionString = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=Oraclessie1;";
        public signin()
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
            register newpage = new register();
            newpage.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = id.Text;
            string password = passy.Password;
            string idin;
            string passin;
            
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("Select * from `mydb`.`user_account` join `mydb`.`users_data` " +
                "on `user_account`.id_user=`users_data`.id_user where `user_account`.id_user like '" + name + "' and " +
                "`user_account`.password like '"+password+"'", connection);
            connection.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            { 
            passin = rdr[1].ToString();
            idin = rdr[0].ToString();
            
            
            }
            try
            {
                role = rdr[8].ToString();
            }
            catch
            {
                MessageBox.Show("Błędne dane");
                id.Text = "";
                passy.Password = "";
            }
            connection.Close();
            if (role == "moderator")
            {
                adduser newpage = new adduser();
                newpage.Show();
                this.Close();
            }
            else if(role=="farmaceuta")
            {
                modifyMedicin newpage = new modifyMedicin();
                newpage.Show();
                this.Close();
            }
            else if(role=="klient")
            {
                // tu będzie strona klienta
            }

        }
    }
}
