using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Logika interakcji dla klasy history.xaml
    /// </summary>
    public partial class history : Window
    {
        string connectionString = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=Oraclessie1;";
        public history()
        {
            InitializeComponent();
            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("select * from orders order by date desc", connection);
            try { connection.Open(); }
            catch { MessageBox.Show("Nie można nawiązać połączenia"); }
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            pharmacyDataGrid.ItemsSource = dt.DefaultView;
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

        private void bt_baskey_Click(object sender, RoutedEventArgs e)
        {
            basket mw = new basket();
            mw.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            client_med mw = new client_med();
            mw.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            signin newpage = new signin();
            newpage.Show();
            this.Close();
        }

        private void delete_medicin(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("select * from orders order by date desc", connection);
            try { connection.Open(); }
            catch { MessageBox.Show("Nie można nawiązać połączenia"); }
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();

            DataTable dataTable =dt; // Zastąp to odpowiednią logiką do pobrania DataTable

            string filePath = "C:\\Users\\agata\\historia.txt"; // Podaj ścieżkę docelowego pliku tekstowego

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        writer.Write(item.ToString());
                        writer.Write("\t"); // Separator między wartościami (możesz dostosować go do swoich potrzeb)
                    }
                    writer.WriteLine(); // Nowa linia po każdym wierszu
                }
            }

            MessageBox.Show("Zapisano do pliku.");
        }
    }
}
