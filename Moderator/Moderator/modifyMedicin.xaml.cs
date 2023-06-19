using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Agreement.JPake;
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
    /// Logika interakcji dla klasy modifyMedicin.xaml
    /// dodanie wyszukiwania
    /// </summary>
    public partial class modifyMedicin : Window
    {
        string connectionString = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=;";
        public modifyMedicin()
        {
            InitializeComponent();

           
            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("select * from medicines", connection);
            connection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            Name_medicin.ItemsSource = dt.DefaultView;
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
           deleteMedicin mw = new deleteMedicin();
            mw.Show();
            this.Close();
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            addMedicin mw = new addMedicin();
            mw.Show();
            this.Close();
        }

        private void Name_medicin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Name_medicin.SelectedIndex != -1) 
            {

                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("select * from medicines", connection);
                connection.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                connection.Close();
                string curItem = Name_medicin.SelectedIndex.ToString();
                DataRowView row = (DataRowView)Name_medicin.SelectedItem;
                DataRow s = row.Row;
                // process stuff
                substance.Text = (string)s[1]; ;
                form.Text = (string)s[2];
                price.Text = s[3].ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)Name_medicin.SelectedItem;
            DataRow s = row.Row;
            string name_ = (string)s[0];
            Console.WriteLine(name_);
            string substance_ = substance.Text;
            string form_ = form.Text;
            string price_ = price.Text;

            //string connectionString = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("UPDATE `mydb`.`medicines` SET substance='"+substance_+"', form='"+form_+"', price='"+price_+"'" +
                " where name_m='"+name_+"'", connection);
            connection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            MessageBox.Show("Zaktualizowano");
           // formatowanie csv (leki)
            Name_medicin.UnselectAll();
            substance.Text ="";
            form.Text = "";
            price.Text ="";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            signin newpage = new signin();
            newpage.Show();
            this.Close();
        }

        private void txt_change(object sender, RoutedEventArgs e)
        {
            
                var searchName = txtFilter.Text;
                SearchByName(searchName);
            

        }
        private void SearchByName(string searchName)
        {
            // Przygotowanie listy pasujących leków
            DataTable drugs = new DataTable();
            drugs.Columns.Add("name_m", typeof(string));
            drugs.Columns.Add("Column2", typeof(string));
            drugs.Columns.Add("Column3", typeof(string));
            drugs.Columns.Add("Column4", typeof(string));
            

            // Pobierz listę wszystkich leków z bazy danych lub innego źródła danych
            /*List<string> allDrugs = new List<string>();

            foreach (var item in Name_medicin.Items)
            {
                DataRowView rowView = (DataRowView)item;
                string value = rowView["Name_m"].ToString();
                allDrugs.Add(value);
            }*/

            // Teraz allDrugs zawiera wszystkie wartości z listboxa
            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("select * from medicines", connection);
            connection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();

            // Przefiltruj leki na podstawie wpisywanej nazwy
            foreach (DataRow row in dt.Rows)
            {
                string drugName = row[0].ToString();
                if (drugName.StartsWith(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    DataRow newRow = drugs.NewRow();
                    newRow[0]= row[0].ToString();
                    newRow[1] = row[1].ToString();
                    newRow[2] = row[2].ToString();
                    newRow[3] = row[3].ToString();
                    drugs.Rows.Add(newRow);
                }
            }
            
            int x = 9;
            // Wyświetl listę pasujących leków w kontrolce ListBox lub innej odpowiedniej kontrolce
            Name_medicin.ItemsSource = drugs.DefaultView;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            addMedicin newpage = new addMedicin();
            newpage.Show();
            this.Close();
        }
    }
}
