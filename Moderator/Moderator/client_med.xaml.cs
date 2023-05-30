using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Resultset;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Moderator
{
    /// <summary>
    /// Logika interakcji dla klasy client_med.xaml
    /// </summary>
    public partial class client_med : Window
    {
        string Myconnect = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=;";
        DataTable dt = new DataTable();
        public client_med()
        {
            InitializeComponent();
            MySqlConnection connection = new MySqlConnection(Myconnect);

            MySqlCommand cmd = new MySqlCommand("select * from medicines", connection);
            try { connection.Open(); }
            catch { MessageBox.Show("Nie można nawiązać połączenia"); }
            
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
            history mw = new history();
            mw.Show();
            this.Close();
        }

        private void delete_medicin(object sender, RoutedEventArgs e)
        {
            List<PharamcyData> lista = GetSelectedItemsFromDataGrid(pharmacyDataGrid);
            int x = 9;
            basket mw = new basket(lista);
            mw.Show();
            this.Close();
        }




        private List<PharamcyData> GetSelectedItemsFromDataGrid(DataGrid dataGrid)
        {
            var selectedItems = new List<PharamcyData>();

            foreach (var selectedItem in dataGrid.SelectedItems)
            {
                if (selectedItem is DataRowView rowView)
                {
                    var dataRow = rowView.Row;
                    var name = (string)dataRow["name_m"];
                    var substance = (string)dataRow["substance"];
                    var form = (string)dataRow["form"];
                    var price = (string)dataRow["price"];

                    var pharmacyData = new PharamcyData
                    {
                        IsChecked = true, // Możesz ustawić to na true, ponieważ tylko zaznaczone elementy są iterowane
                        Name = name,
                        substance = substance,
                        form = form,
                        price = price
                    };

                    selectedItems.Add(pharmacyData);
                }
            }

            return selectedItems;
        }


        private childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                var child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                    return (childItem)child;
                else
                {
                    var childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            signin newpage = new signin();
            newpage.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // przejście do nowej karty
            sendmail newpage = new sendmail();
            newpage.Show();
            this.Close();
        }
    }
}
