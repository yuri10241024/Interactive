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
            GetScene(1);
            //MainPlayer.Source = new Uri(@"C:\Users\USER\Downloads\futaj-simvoli-monitora-sekundomer-2_(VIDEOMIN.NET).mp4");
            MainPlayer.MediaEnded += EndVideo;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (parent != null)
            {
                parent.Close();
            }
        }

        void ShowScene(Scene scene)
        {
            BSelected1.Visibility = Visibility.Collapsed;
            BSelected2.Visibility = Visibility.Collapsed;
            BSelected3.Visibility = Visibility.Collapsed;

            TBSelect1.Text = scene.buttonText[0];
            TBSelect2.Text = scene.buttonText[1];
            TBSelect3.Text = scene.buttonText[2];
        }

        Scene GetScene(int Num)
        {
            Scene S = null;
            if (Num == 1)
            {
                S = new Scene();
                

                S.pathToVideo = @"E:\100\9 день\C0208.MP4";

                S.buttonText = new string[3];
                S.buttonText[0]= "Конец";
                S.buttonText[1]= "Не конец";

                S.Variants = new int[3];

                S.Variants[0] = 1;//Номер сцены к которому мы перейдем в случае нажатия
                S.Variants[1] = 2;

                S.countScene = 1;
            }
            return S;
        }

        private void EndVideo(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TBSelect2.Text))
            {
                BSelected2.Visibility = Visibility.Visible;
            }
            if (!string.IsNullOrEmpty(TBSelect3.Text))
            {
                BSelected3.Visibility = Visibility.Visible;
            }

            BSelected1.Visibility = Visibility.Visible;
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
