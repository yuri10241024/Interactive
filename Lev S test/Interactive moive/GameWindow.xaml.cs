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
using Newtonsoft.Json;

namespace Interactive_moive
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public Window parent = null;//инфа о любом окне.

        public GameWindow()
        {
            InitializeComponent();
            MainPlayer.Source = new Uri(@"C:\Users\USER\Downloads\futaj-simvoli-monitora-sekundomer-2_(VIDEOMIN.NET).mp4");
            MainPlayer.MediaEnded += EndVideo;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (parent != null)
            {
                parent.Close();
            }
        }

        private void EndVideo(object sender, RoutedEventArgs e)
        {
            BSelected1.Visibility = Visibility.Visible;
            BSelected2.Visibility = Visibility.Visible;
            BSelected3.Visibility = Visibility.Visible;
        }

        private void Border_MouseDown3(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Здравствуйте мир!");
        }

        private void Border_MouseDown2(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Здравствуйте мир2!");
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Здравствуйте мир3!");
        }
    }
}
