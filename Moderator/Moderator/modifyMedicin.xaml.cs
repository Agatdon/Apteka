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
    /// Logika interakcji dla klasy modifyMedicin.xaml
    /// </summary>
    public partial class modifyMedicin : Window
    {
        public modifyMedicin()
        {
            InitializeComponent();

            string connectionString = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=;";

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

        private void Name_medicin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Name_medicin.SelectedIndex != -1) 
            {
                string connectionString = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=;";

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

            string connectionString = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand cmd = new MySqlCommand("UPDATE `mydb`.`medicines` SET substance='"+substance_+"', form='"+form_+"', price='"+price_+"'" +
                " where name_m='"+name_+"'", connection);
            connection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            MessageBox.Show("Zaktualizowano");

            Name_medicin.UnselectAll();
            substance.Text ="";
            form.Text = "";
            price.Text ="";
        }
    }
}
