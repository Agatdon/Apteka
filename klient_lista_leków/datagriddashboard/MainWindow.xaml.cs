using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace client_med
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var conventor = new BrushConverter();
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


            pharmacyDataGrid.ItemsSource = lek; //Pharm.ReadFile(@"C:/Users/agata/Documents/GitHub/Apteka/klient_lista_leków/Rejestr_Produktow_Leczniczych_calosciowy_stan_na_dzien_20230319.csv");
        }

        private void Border_MouseDown(object senior, MouseButtonEventArgs e)
        {
            if (e.ChangedButton==MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private bool IsMaximized=false;
        private void Border_MouseLeftButtonDown(object senior, MouseButtonEventArgs e)
        {
            if(e.ClickCount==2)
            {
                if(IsMaximized)
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

        private void Bt_baskey_Click(object sender, RoutedEventArgs e)
        {
            Window w1 = new basket();
            Main.NavigationService.Navigate(w1);
        }
    }

    public class PharamcyData
    {
        public string Name { get; set; }
        public string srodek { get; set; }
        public string dawka { get; set; }
        public string cena { get; set; }

    }
    public static class Pharm
    {
        /*public static List<PharamcyData> ReadFile(string filepath)
        {
            var lines = File.ReadAllLines(filepath);

            var data = from l in lines.Skip(1)
                       let split = l.Split(';')
                       select new PharamcyData
                       {
                           Name = split[1],
                           srodek = split[2],
                           dawka =split[8],
                           cena = split[7]
                       };
            return data.ToList();
        }*/
    }
   
}
