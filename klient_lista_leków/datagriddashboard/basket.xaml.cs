using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;

namespace client_med
{
    /// <summary>
    /// Logika interakcji dla klasy basket.xaml
    /// </summary>
    public partial class basket : Window
    {
        public basket()
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
    } 
   
}