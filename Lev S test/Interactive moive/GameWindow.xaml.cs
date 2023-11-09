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
using Interactive_moive;
using System.IO;

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

        Quest q = new Quest();

        public GameWindow()
        {
            InitializeComponent();
            MainPlayer.MediaEnded += EndVideo;

            q = JsonConvert.DeserializeObject<Quest>(File.ReadAllText(@"D:\_STUDIOS\VISUAL_STUDIO\TrashFiles\3.1.json"));
            
            ShowScene(GetScene(0));
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (parent != null)
            {
                parent.Visibility = Visibility.Hidden;
            }
        }

        void ShowScene(Scene scene)
        {
            BTNSkip.Visibility = Visibility.Visible;

            IsMain = true;
            CurrentScene = scene;

            BSelected1.Visibility = Visibility.Collapsed;
            
            if(scene.ListOfVariants.Count > 0)
            {
                TBSelect1.Text = scene.ListOfVariants[0].Description;
            }
            
            if(scene.ListOfVariants.Count > 1)
            {
                TBSelect2.Text = scene.ListOfVariants[1].Description;
            }
            else
            {
                BSelected2.Visibility = Visibility.Collapsed;
            }
            if (scene.ListOfVariants.Count > 2)
            {
                TBSelect3.Text = scene.ListOfVariants[2].Description;
            }
            else
            {
                BSelected3.Visibility = Visibility.Collapsed;
            }

            MainPlayer.Source = new Uri (scene.pathToVideo);
            MainPlayer.Play();
        }

        Scene GetSceneHardCode(int Num)
        {
            Scene S = null;
            if (Num == 1)
            {
                S = new Scene();

                //https://drive.google.com/file/d/17VgEVf-pdvnFA12_0Wt8TcgXK2VN2-9Q/view?usp=sharing

                //S.IntermediateVideo = "https://drive.google.com/file/d/17VgEVf-pdvnFA12_0Wt8TcgXK2VN2-9Q/view?usp=sharing";

                S.IntermediateVideo = @"D:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое\Выбор варианта 1.mp4";

                //S.pathToVideo = "https://drive.google.com/file/d/17VgEVf-pdvnFA12_0Wt8TcgXK2VN2-9Q/view?usp=sharing";

                S.pathToVideo = @"D:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое\Начало игры.mp4";

                S.ListOfVariants = new List<Variant>();

                Variant v = new Variant();
                v.Description = "Разбудить";
                v.TargetID = 2;
                S.ListOfVariants.Add(v);

                v = new Variant();
                v.Description = "Пощадить";

                v.TargetID = 3;
                S.ListOfVariants.Add(v);

                S.countScene = 1;
            }
            if (Num == 2)
            {
                S = new Scene();

                S.IntermediateVideo = @"D:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое\Выбор варианта 2.mp4";

                S.pathToVideo = @"D:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое\Разбудить.mp4";

                S.ListOfVariants = new List<Variant>();

                Variant v = new Variant();
                v.Description = "Конец";
                v.TargetID = 4;
                S.ListOfVariants.Add(v);

                S.countScene = 2;
            }
            if (Num == 3)
            {
                S = new Scene();

                S.IntermediateVideo = @"D:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое\Выбор варианта 2.mp4";

                S.pathToVideo = @"D:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое\Пощадить.mp4";

                S.ListOfVariants = new List<Variant>();

                Variant v = new Variant();
                v.Description = "Конец";
                v.TargetID = 4;
                S.ListOfVariants.Add(v);


                S.countScene = 3;
            }
            if (Num == 4)
            {
                S = new Scene();

                S.pathToVideo = @"D:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое\Конец.mp4";

                S.ListOfVariants = new List<Variant>();

                Variant v = new Variant();
                v.Description = "Конец";
                v.TargetID = 4;
                S.ListOfVariants.Add(v);
                S.countScene = 4;
            }

            return S;
        }


        Scene GetScene(int Num)
        {
            Scene S = q.ListOfScenes.Where(s => s.countScene == Num).FirstOrDefault();//Что-то на страшном
            return S;
            
        }

        private void EndVideo(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(CurrentScene.IntermediateVideo))
            {
                Close();
                return;
            }

            BTNSkip.Visibility = Visibility.Collapsed;

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
            ShowScene(GetScene(CurrentScene.ListOfVariants[0].TargetID));
        }

        private void Border_MouseDown2(object sender, MouseButtonEventArgs e)
        {
            MainPlayer.Stop();
            ShowScene(GetScene(CurrentScene.ListOfVariants[1].TargetID));
        }

        private void Border_MouseDown3(object sender, MouseButtonEventArgs e)
        {
            MainPlayer.Stop();
            ShowScene(GetScene(CurrentScene.ListOfVariants[2].TargetID));
        }
        
        private void Window_Closed(object sender, EventArgs e)
        {
            parent.Visibility = Visibility.Visible;
        }

        private void Rectangle_MouseEnter(object sender, MouseEventArgs e)
        {
            BTNSkip.Opacity = 0.9;
        }

        private void Rectangle_MouseLeave(object sender, MouseEventArgs e)
        {
            BTNSkip.Opacity = 0;
        }

        private void BTNSkip_Click(object sender, RoutedEventArgs e)
        {
            EndVideo(null, null);
        }

        private void BTNSkip_MouseEnter(object sender, MouseEventArgs e)
        {
            BTNSkip.Opacity = 0.9;
        }

        private void BTNSkip_MouseLeave(object sender, MouseEventArgs e)
        {
            BTNSkip.Opacity = 0;
        }
    }
}
//TODO: Починить 2-ую кнопку.