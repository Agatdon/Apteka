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
    /// Logika interakcji dla klasy addMedicin.xaml
    /// </summary>
    public partial class addMedicin : Window
    {
        public string Myconnect = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=;";
        public addMedicin()
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
            modifyMedicin mw = new modifyMedicin();
            mw.Show();
            this.Close();
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            deleteMedicin newpage = new deleteMedicin();
            newpage.Show();
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // dodać klasę pobierającą te wartości (maja one byc const)
            if (Medicine_name.Text == null)
            { MessageBox.Show("Nieprawidłowa nazwa"); }
            string Name = Medicine_name.Text;
            if (substance.Text == null )
            { MessageBox.Show("Nieprawidłowa substancja"); }
            string substance_ = substance.Text;

            string form_ = form.Text;
            if (form.Text == null)
            { MessageBox.Show("Nieprawidłowa forma leku"); }
            string price_ = price.Text;


            string query = " INSERT INTO `mydb`.`medicines`" +
                " (`name_m`, `substance`, `form`, `price`) VALUES " +
                "\r\n('" + Name + "', '" + substance_ + "', '" +form_+ "', '" + price_ + "'); ";
            MySqlConnection Connect = new MySqlConnection(Myconnect);
            MySqlCommand comand = new MySqlCommand(query, Connect);
            MySqlDataReader MyReader2;
            Connect.Open();
            MyReader2 = comand.ExecuteReader();
            MessageBox.Show("Zapisano Użytkownika");
            while (MyReader2.Read()) { }
            Connect.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            signin newpage = new signin();
            newpage.Show();
            this.Close();
        }
    }
}
