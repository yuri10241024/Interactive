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

        public bool ProjectLoaded = false;

        public MainWindow()
        {
            InitializeComponent();

            q = new Quest();


            VC1.TBVariantNum.Text = "Вариант 1";
            VC2.TBVariantNum.Text = "Вариант 2";
            VC3.TBVariantNum.Text = "Вариант 3";
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
        private void TitleOfSelectedItem_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TitleOfSelectedItem.Text == "Selected Item")
            {
                TitleOfSelectedItem.Text = "";
            }
        }

        private void BTNSave_Click(object sender, RoutedEventArgs e)
        {
            string JSON = JsonConvert.SerializeObject(q);
            File.WriteAllText("Text.JSON", JSON);
        }

        private void BTNAddScene_Click(object sender, RoutedEventArgs e)
        {
            NewScene ns = new NewScene();
            ns.ShowDialog();
            
            Scene Sc = new Scene();
            Sc.Title = ns.TBSceneName.Text;//TODO:Исправить логическую ошибку
            q.ListOfScenes.Add(Sc);
            SceneList.ItemsSource = q.ListOfScenes;
        }

        private void BTNNew_Click(object sender, RoutedEventArgs e)
        {
            NewProjectWindow npw = new NewProjectWindow();
            npw.ShowDialog();
            
            if(npw.NPWState)
            {
                this.Title = npw.TBProjectName.Text;
                SceneList.Visibility = Visibility.Visible;
                SPTools.Visibility = Visibility.Visible;
                if (ProjectLoaded == true)
                {
                    //TODO:проверить что предидущий проект сохранён
                }
                q = new Quest();
                TitleOfSelectedItem.Text = "";
                ID.Text = "";
                MainVideo.Text = "";//TODO: Обнулить текст(((

                VC1.TBID.Text = "";
                VC1.TBDescription.Text = "";

            }
            else
            {
                if (ProjectLoaded == false)
                {
                    SceneList.Visibility = Visibility.Hidden;
                    SPTools.Visibility = Visibility.Hidden;
                }
            }
        }
    }//D:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое
}