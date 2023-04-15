﻿using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy adduser.xaml
    /// </summary>
    public partial class adduser : Window
    {
        public adduser()
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
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            deleteuser newpage = new deleteuser();
            newpage.Show();
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string Name = name_user.Text;
            string surname = surname_user.Text;
            string id_user = id_user_n.Text;
            string email = mail.Text;
            string phone = phone_number.Text;
            string stanowisko = position.Text;
            string rola = role.ToString();

            string Myconnect = "SERVER=localhost;DATABASE=mydb;UID=root;PASSWORD=**;";
            string query= " INSERT INTO `mydb`.`users_data`" +
                " (`id_user`, `name`, `surname`, `e_maill`, `phone`, `stanowisko`, `rola`) VALUES " +
                "\r\n('" + this.id_user_n.Text+ "', '" +this.name_user.Text+ "', '" +this.surname_user.Text+ "', '" +this.mail.Text+ "', '" +this.phone_number.Text+ "','"+this.position.Text+"','"+rola+"'); ";
            MySqlConnection Connect = new MySqlConnection(Myconnect);
            MySqlCommand comand = new MySqlCommand(query, Connect);
            MySqlDataReader MyReader2;
            Connect.Open();
            MyReader2 = comand.ExecuteReader();
            MessageBox.Show("Zapisano Użytkownika");
            while (MyReader2.Read()) { }
            Connect.Close();
        }

    }
}
