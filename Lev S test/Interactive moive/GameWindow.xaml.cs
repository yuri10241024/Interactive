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

        Scene CurrentScene;
        public bool IsMain;

        public GameWindow()
        {
            InitializeComponent();
            //MainPlayer.Source = new Uri(@"C:\Users\USER\Downloads\futaj-simvoli-monitora-sekundomer-2_(VIDEOMIN.NET).mp4");
            MainPlayer.MediaEnded += EndVideo;
            ShowScene(GetScene(1));
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
            IsMain = true;
            CurrentScene = scene;

            BSelected1.Visibility = Visibility.Collapsed;
            BSelected2.Visibility = Visibility.Collapsed;
            BSelected3.Visibility = Visibility.Collapsed;

            TBSelect1.Text = scene.buttonText[0];
            TBSelect2.Text = scene.buttonText[1];
            TBSelect3.Text = scene.buttonText[2];

            MainPlayer.Source = new Uri (scene.pathToVideo);
            MainPlayer.Play();
        }

        Scene GetScene(int Num)
        {
            Scene S = null;
            if (Num == 1)
            {
                S = new Scene();

                //https://drive.google.com/file/d/17VgEVf-pdvnFA12_0Wt8TcgXK2VN2-9Q/view?usp=sharing

                //S.IntermediateVideo = "https://drive.google.com/file/d/17VgEVf-pdvnFA12_0Wt8TcgXK2VN2-9Q/view?usp=sharing";

                S.IntermediateVideo = @"E:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое\Выбор варианта 1.mp4";

                //S.pathToVideo = "https://drive.google.com/file/d/17VgEVf-pdvnFA12_0Wt8TcgXK2VN2-9Q/view?usp=sharing";

                S.pathToVideo = @"E:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое\Начало игры.mp4";

                S.buttonText = new string[3];
                S.buttonText[0]= "Разбудить";
                S.buttonText[1]= "Пощадить";

                S.Variants = new int[3];

                S.Variants[0] = 2;//Номер сцены к которому мы перейдем в случае нажатия
                S.Variants[1] = 3;

                S.countScene = 1;
            }
            if (Num == 2)
            {
                S = new Scene();

                S.IntermediateVideo = @"E:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое\Выбор варианта 2.mp4";

                S.pathToVideo = @"E:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое\Разбудить.mp4";

                S.buttonText = new string[3];
                S.buttonText[0] = "Конец";

                S.Variants = new int[3];

                S.Variants[0] = 4;//Номер сцены к которому мы перейдем в случае нажатия

                S.countScene = 2;
            }
            if (Num == 3)
            {
                S = new Scene();

                S.IntermediateVideo = @"E:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое\Выбор варианта 2.mp4";

                S.pathToVideo = @"E:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое\Пощадить.mp4";

                S.buttonText = new string[3];
                S.buttonText[0] = "Конец";

                S.Variants = new int[3];

                S.Variants[0] = 4;//Номер сцены к которому мы перейдем в случае нажатия

                S.countScene = 3;
            }
            if (Num == 4)
            {
                S = new Scene();

                S.pathToVideo = @"E:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое\Конец.mp4";

                S.buttonText = new string[3];

                S.Variants = new int[3];

                S.Variants[0] = 4;//Номер сцены к которому мы перейдем в случае нажатия

                S.countScene = 4;
            }

            return S;
        }

        private void EndVideo(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(CurrentScene.IntermediateVideo))
            {
                Close();
                return;
            }

            Uri U = new Uri(CurrentScene.IntermediateVideo);
            MainPlayer.Source = new Uri(CurrentScene.IntermediateVideo);
            MainPlayer.Play();

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
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPlayer.Stop();
            ShowScene(GetScene(CurrentScene.Variants[0]));
        }

        private void Border_MouseDown2(object sender, MouseButtonEventArgs e)
        {
            MainPlayer.Stop();
            ShowScene(GetScene(CurrentScene.Variants[1]));
        }

        private void Border_MouseDown3(object sender, MouseButtonEventArgs e)
        {
            MainPlayer.Stop();
            ShowScene(GetScene(CurrentScene.Variants[2]));
        }
    }
}
