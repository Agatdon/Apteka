using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
    /// Logika interakcji dla klasy sendmail.xaml
    /// </summary>
    public partial class sendmail : Window
    {
        public sendmail()
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            signin newpage = new signin();
            newpage.Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            client_med newpage = new client_med();
            newpage.Show();
            this.Close();
        }

        private void bt_baskey_Click(object sender, RoutedEventArgs e)
        {
            basket newpage = new basket();
            newpage.Show();
            this.Close();
        }

        private void BtClick_history(object sender, RoutedEventArgs e)
        {
            history newpage = new history();
            newpage.Show();
            this.Close();
        }
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            // Pobierz dane wpisane przez klienta
            string name = namex.Text;
            string email = mailx.Text;
            string message = messagex.Text;

            // Tworzenie wiadomości e-mail
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("adres nadawcy");
            mail.To.Add("adres odbiorcy");
            mail.Subject = "Nowa wiadomość od klienta";
            mail.Body = $"Imię: {name}\nE-mail: {email}\nWiadomość: {message}";

            // Konfiguracja serwera SMTP
            SmtpClient smtpClient = new SmtpClient("poczta.o2.pl", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("login", "hasło");

            try
            {
                // Wysyłanie wiadomości
                smtpClient.Send(mail);
                MessageBox.Show("Wiadomość została wysłana.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas wysyłania wiadomości: " + ex.Message);
            }
            namex.Text = " Imię i nazwisko";
            mailx.Text = "adres e-mail";
            messagex.Text = "Wiadomość...";
        }

        
    }
    public class Send
    {
        public string name { get; set; }
        public string mail { get; set; }
        public string message { get; set; }
    }
}
