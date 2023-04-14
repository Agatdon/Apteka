using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;


namespace datagriddashboard
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

            pharmacyDataGrid.ItemsSource = lek;
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
    }

    public class PharamcyData
    {
        public string Name { get; set; }
        public string srodek { get; set; }
        public string dawka { get; set; }
        public string cena { get; set; }

    }
   
}
