using Moderator;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Moderator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class deleteMedicin : Window
    {
        string Myconnect = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=Oraclessie1;";
        public deleteMedicin()
        {
            InitializeComponent();
            /*var conventor = new BrushConverter();
            ObservableCollection<PharamcyData> lek = new ObservableCollection<PharamcyData>();

            lek.Add(new PharamcyData { Name = "Accard", srodek = "Kwas jakiś", dawka = "tabletki", cena = "15.89" });
            lek.Add(new PharamcyData { Name = "Hitaxa", srodek = "coś", dawka = "tabletki", cena = "17.99" });
            lek.Add(new PharamcyData { Name = "Nimesil", srodek = "Kwas jakiś", dawka = "proszek", cena = "5.89" });
            lek.Add(new PharamcyData { Name = "Accard", srodek = "Kwas jakiś", dawka = "tabletki", cena = "15.89" });
            lek.Add(new PharamcyData { Name = "Hitaxa", srodek = "coś", dawka = "tabletki", cena = "17.99" });
            lek.Add(new PharamcyData { Name = "Nimesil", srodek = "Kwas jakiś", dawka = "proszek", cena = "5.89" });
            lek.Add(new PharamcyData { Name = "Accard", srodek = "Kwas jakiś", dawka = "tabletki", cena = "15.89" });
            lek.Add(new PharamcyData { Name = "Hitaxa", srodek = "coś", dawka = "tabletki", cena = "17.99" });
            lek.Add(new PharamcyData { Name = "Nimesil", srodek = "Kwas jakiś", dawka = "proszek", cena = "5.89" });
            lek.Add(new PharamcyData { Name = "Accard", srodek = "Kwas jakiś", dawka = "tabletki", cena = "15.89" });
            lek.Add(new PharamcyData { Name = "Hitaxa", srodek = "coś", dawka = "tabletki", cena = "17.99" });
            lek.Add(new PharamcyData { Name = "Nimesil", srodek = "Kwas jakiś", dawka = "proszek", cena = "5.89" });
            lek.Add(new PharamcyData { Name = "Accard", srodek = "Kwas jakiś", dawka = "tabletki", cena = "15.89" });
            lek.Add(new PharamcyData { Name = "Hitaxa", srodek = "coś", dawka = "tabletki", cena = "17.99" });
            lek.Add(new PharamcyData { Name = "Nimesil", srodek = "Kwas jakiś", dawka = "proszek", cena = "5.89" });

            pharmacyDataGrid.ItemsSource = lek;*/
            //string connectionString = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=;";

            MySqlConnection connection = new MySqlConnection(Myconnect);

            MySqlCommand cmd = new MySqlCommand("select * from medicines", connection);
            try { connection.Open(); }
            catch { MessageBox.Show("Nie można nawiązać połączenia"); }
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

        private void delete_medicin(object sender, RoutedEventArgs e)
        {
            if (userDataGrid.SelectedIndex != -1)
            {
               // string Myconnect = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=;";
                for (int i = 0; i < userDataGrid.SelectedIndex; i++)
                {
                    DataRowView row = (DataRowView)userDataGrid.SelectedItem;
                    DataRow s = row.Row;
                    // process stuff
                    string name = (string)s[0];

                    MessageBoxResult r = MessageBox.Show("Czy na pewno chcesz usunąć lek?", "Alert", MessageBoxButton.YesNo);

                    if (r == MessageBoxResult.Yes)
                    {
                        string query = " DELETE FROM `mydb`.`medicines` where name_m= '" + name + "'; ";
                        MySqlConnection Connect = new MySqlConnection(Myconnect);
                        MySqlCommand comand = new MySqlCommand(query, Connect);
                        MySqlDataReader MyReader2;
                        Connect.Open();
                        MyReader2 = comand.ExecuteReader();
                        while (MyReader2.Read()) { }
                        Connect.Close();
                        MessageBox.Show(@"Usunięto lek "+name);
                        break;
                    }
                    else if (r == MessageBoxResult.No)
                    { MessageBox.Show("Nie usunięto leku "+name); break; }

                }
                MySqlConnection connection = new MySqlConnection(Myconnect);

                MySqlCommand cmd = new MySqlCommand("select * from medicines", connection);
                connection.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                connection.Close();
                userDataGrid.ItemsSource = dt.DefaultView;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            modifyMedicin mw = new modifyMedicin();
            mw.Show();
            this.Close();
        }

        
    }
    public class PharamcyData
    {
        public string Name { get; set; }
        public string substance { get; set; }
        public string form { get; set; }
        public string price { get; set; }

    }
}
