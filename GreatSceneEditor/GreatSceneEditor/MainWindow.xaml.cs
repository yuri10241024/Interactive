using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Interactive_moive;
using System.IO;
using System.Collections.Generic;


namespace GreatSceneEditor
{

    public partial class MainWindow : Window
    {
        public Quest q;
        public Quest vq;

        public MainWindow()
        {
            InitializeComponent();
            CreateTestQuest();
            SceneList.ItemsSource = q.ListOfScenes;
        }

        void CreateTestQuest2()
        {
            vq = new Quest();
            vq.ListOfScenes = new List<Scene>();
            vq.PathToVideoFolder = @"D:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое";
            Scene vs = new Scene();

        }

        void CreateTestQuest()
        {
            q = new Quest();
            q.ListOfScenes = new List<Scene>();
            q.PathToVideoFolder = @"D:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое";
            Scene s = new Scene();
            s.Title = "scene 1";
            q.ListOfScenes.Add(s);

            s = new Scene();
            s.Title = "scene 2";
            q.ListOfScenes.Add(s);

        }

        private void AddSmth_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TitleOfSelectedItem_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TitleOfSelectedItem.Text == "Selected Item")
            {
                TitleOfSelectedItem.Text = "";
            }
        }

        
    }//D:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое
}
