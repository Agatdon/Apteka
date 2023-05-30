using MySql.Data.MySqlClient;
using Mysqlx.Resultset;
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
    /// Logika interakcji dla klasy basket.xaml
    /// </summary>
    public partial class basket : Window
    {
        string Myconnect = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=Oraclessie1;";
        public basket()
        {
            InitializeComponent();
            //DataTable selectedItem = SharedData.Instance.SelectedItem;
            //pharmacyDataGrid.ItemsSource = selectedDataTable.DefaultView;
        }
        public basket(List<PharamcyData> lt)
        {
            InitializeComponent();
            //DataTable selectedItem = SharedData.Instance.SelectedItem;
            pharmacyDataGrid.ItemsSource = lt;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            client_med mw = new client_med();
            mw.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            history mw = new history();
            mw.Show();
            this.Close();
        }

        /*private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // zapisywanie zamówienia
            foreach (var item in pharmacyDataGrid.Items)
            {
                DataRowView row = (DataRowView)item;
                DataRow s = row.Row;
                string id = (string)s[0];
                Random random = new Random();
                int randomNumber = random.Next(100000, 1000000);
                DateTime currentDate = DateTime.Now.Date;

                string query0 = " Insert into `mydb`.`orders` ( idorders,name_mecinin, date) values( '"+randomNumber+"','"+ id+"','"+ currentDate+"');";
                    MySqlConnection Connect = new MySqlConnection(Myconnect);
                    MySqlCommand comand0 = new MySqlCommand(query0, Connect);
                    MySqlDataReader MyReader2;
                    Connect.Open();
                    MyReader2 = comand0.ExecuteReader();
                    while (MyReader2.Read()) { }
                    Connect.Close();
                MessageBox.Show("Usunięto Użytkownika");

            }
            
        }*/
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Zapisywanie zamówienia
            foreach (PharamcyData item in pharmacyDataGrid.Items)
            {
                string id = item.Name; // Zakładam, że w klasie PharamcyData jest pole Id
                Random random = new Random();
                int randomNumber = random.Next(100000, 1000000);
                DateTime currentDate = DateTime.Today;
                String.Format("{0:yyyy-mm-dd}", currentDate);
                string formattedDate = currentDate.ToString("yyyy-MM-dd");

                string query0 = " Insert into `mydb`.`orders` ( idorders,name_mecinin, date) values( '" + randomNumber + "','" + id + "','" + formattedDate + "');";
                MySqlConnection Connect = new MySqlConnection(Myconnect);
                MySqlCommand comand0 = new MySqlCommand(query0, Connect);
                MySqlDataReader MyReader2;
                Connect.Open();
                MyReader2 = comand0.ExecuteReader();
                while (MyReader2.Read()) { }
                Connect.Close();
                MessageBox.Show("Złożono zamówienie");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            signin newpage = new signin();
            newpage.Show();
            this.Close();
        }
    }
}
