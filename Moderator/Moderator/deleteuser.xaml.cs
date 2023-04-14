using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy deleteuser.xaml
    /// </summary>
    public partial class deleteuser : Window
    {
        public deleteuser()
        {
            InitializeComponent();
            var conventor = new BrushConverter();
            ObservableCollection<UserData> user = new ObservableCollection<UserData>();

            user.Add(new UserData { id = "1111", name = "Anna", surname = "Kowalska", position = "Administrator" });
            user.Add(new UserData { id = "1112", name = "Andrzej", surname = "Kowalski", position = "Kierownik" });
            user.Add(new UserData { id = "1113", name = "Adrian", surname = "Kowal", position = "Farmaceuta" });
            user.Add(new UserData { id = "1114", name = "Agnieszka", surname = "Kowal", position = "Farmaceuta" });
            user.Add(new UserData { id = "1115", name = "Agata", surname = "Nowak", position = "Pomoc apteczna" });


            userDataGrid.ItemsSource = user;
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
    }
}
