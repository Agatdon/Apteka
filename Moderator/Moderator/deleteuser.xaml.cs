using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static System.Net.Mime.MediaTypeNames;

namespace Moderator
{
    /// <summary>
    /// Logika interakcji dla klasy deleteuser.xaml
    /// </summary>
    public partial class deleteuser : Window
    {
        string Myconnect = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=Oraclessie1;";
        string connectionString = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=Oraclessie1;";
        public deleteuser()
        {
            InitializeComponent();
            /*var conventor = new BrushConverter();
            ObservableCollection<UserData> user = new ObservableCollection<UserData>();

            user.Add(new UserData { id = "1111", name = "Anna", surname = "Kowalska", position = "Administrator" });
            user.Add(new UserData { id = "1112", name = "Andrzej", surname = "Kowalski", position = "Kierownik" });
            user.Add(new UserData { id = "1113", name = "Adrian", surname = "Kowal", position = "Farmaceuta" });
            user.Add(new UserData { id = "1114", name = "Agnieszka", surname = "Kowal", position = "Farmaceuta" });
            user.Add(new UserData { id = "1115", name = "Agata", surname = "Nowak", position = "Pomoc apteczna" });


            userDataGrid.ItemsSource = user;*/

            

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("select * from users_data", connection);
            connection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            userDataGrid.ItemsSource = dt.DefaultView;
        }
        private void Border_MouseDown(object senior, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object senior, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
                }
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            adduser au = new adduser();
            au.Show();
            this.Close();

        }
        private void show_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (userDataGrid.SelectedIndex != -1)
            {
                
                for (int i=0; i < userDataGrid.SelectedIndex; i++)
                {
                    DataRowView row = (DataRowView)userDataGrid.SelectedItem
                        ;
                    DataRow s = row.Row;
                    // process stuff
                    //sprawdzenie warunków
                    // sprawdzić break
                    string id = (string)s[0];

                    MessageBoxResult r =MessageBox.Show("Czy na pewno chcesz usunąć użytkownika?", "Alert", MessageBoxButton.YesNo);
                    
                   if (r == MessageBoxResult.Yes)
                   {
                        string query0 = " DELETE FROM `mydb`.`user_account` where id_user= '" + id + "'; ";
                        string query = " DELETE FROM `mydb`.`users_data` where id_user= '" + id + "'; ";
                        MySqlConnection Connect = new MySqlConnection(Myconnect);
                        MySqlCommand comand0 = new MySqlCommand(query0, Connect);
                        MySqlCommand comand = new MySqlCommand(query, Connect);
                        MySqlDataReader MyReader2;
                        MySqlDataReader MyReader3;
                        Connect.Open();
                        MyReader2 = comand0.ExecuteReader();
                        while (MyReader2.Read()) { }
                        Connect.Close();
                        Connect.Open();
                        MyReader3 = comand.ExecuteReader();
                        MessageBox.Show("Usunięto Użytkownika");
                        while (MyReader3.Read()) { }
                        Connect.Close();
                        //break;
                    }
                    else if(r== MessageBoxResult.No)
                    { MessageBox.Show("Nie usunięto Użytkownika"); break; }
                    
                }
                MySqlConnection connection = new MySqlConnection(Myconnect);

                MySqlCommand cmd = new MySqlCommand("select * from users_data", connection);
                connection.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                connection.Close();
                userDataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            signin newpage = new signin();
            newpage.Show();
            this.Close();
        }
    }
}
