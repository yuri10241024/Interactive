﻿using System;
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
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace GreatSceneEditor
{
    public partial class MainWindow : Window
    {
        public Quest q;

        public string CurrentFileName = ""; 

        public bool ProjectLoaded = false;
        
        public ObservableCollection<Scene> OCScenes = new ObservableCollection<Scene>();

        Scene SelectedScene;
        public MainWindow()
        {
            InitializeComponent();

            q = new Quest();
            SceneList.ItemsSource = OCScenes;

            VC1.TBVariantNum.Text = "Вариант 1";
            VC2.TBVariantNum.Text = "Вариант 2";
            VC3.TBVariantNum.Text = "Вариант 3";
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
            SaveLastScene();
            string JSON = JsonConvert.SerializeObject(q);
            if (CurrentFileName == "")
            {
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.ShowDialog();
                if (SFD.FileName == "")
                {
                    return;
                }
                CurrentFileName = SFD.FileName;
            }

            File.WriteAllText(CurrentFileName, JSON);

        }

        private bool ValidateID()
        {
            int id;

            if(!int.TryParse(ID.Text, out id))
            {
                return false;
            }
            if(!int.TryParse(VC1.TBID.Text, out id))
            {
                return false;
            }
            if (!int.TryParse(VC2.TBID.Text, out id))//TODO: Проверять CheckBoxes isCheked
            {
                return false;
            }
            if (!int.TryParse(VC3.TBID.Text, out id))
            {
                return false;
            }
            return true;
        }

        private void SaveLastScene()
        {
            if (SelectedScene != null)
            {
                SelectedScene.Title = TitleOfSelectedItem.Text;

                SelectedScene.countScene = int.Parse(ID.Text);

                SelectedScene.pathToVideo = MainVideo.Text;

                SelectedScene.IntermediateVideo = IntermediateVideo.Text;

                SelectedScene.ListOfVariants = new List<Variant>();

                SelectedScene.ListOfVariants.Add(new Variant {
                TargetID = int.Parse(VC1.TBID.Text),
                Description = VC1.TBDescription.Text});//Анонимная переменная 

                if(VC2.CBTurnOn.IsChecked == true)
                {
                    SelectedScene.ListOfVariants.Add(new Variant
                    {
                        TargetID = int.Parse(VC2.TBID.Text),
                        Description = VC2.TBDescription.Text
                    });
                }
                else
                {
                    VC3.CBTurnOn.IsEnabled = false;
                }

                if (VC3.CBTurnOn.IsChecked == true)
                {
                    SelectedScene.ListOfVariants.Add(new Variant
                    {
                        TargetID = int.Parse(VC3.TBID.Text),
                        Description = VC3.TBDescription.Text
                    });
                }
                

            }
        }

        private void BTNAddScene_Click(object sender, RoutedEventArgs e)
        {
            NewScene ns = new NewScene();
            ns.ShowDialog();
            if(ns.IsCreated)
            {
                Scene Sc = new Scene();
                Sc.Title = ns.TBSceneName.Text;
                q.ListOfScenes.Add(Sc);

                OCScenes.Add(Sc);//TODO: При смене сцены нужно сохранять изменённые данные
                SceneList.SelectedIndex = OCScenes.Count - 1;
            }
            if (ns.IsCreated)
            {
                return;
            }
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
                IntermediateVideo.Text = "";
                VC1.TBID.Text = "";
                VC1.TBDescription.Text = "";
                VC2.TBID.Text = "";
                VC2.TBDescription.Text = "";
                VC3.TBID.Text = "";
                VC3.TBDescription.Text = "";
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
        
        private void SceneList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//TODO:Исключить потерю данных при переключении сцен. Т.е. проверить куда идёт какая ссылка.
//Выпадающий список ItemSource, есть разные способы сохранять и работать с данными. 
            if (SceneList.SelectedIndex == -1)//Defense АКА защита от вылета
            {
                return;
            }

            if(!ValidateID())
            {
                SceneList.SelectedItem = SelectedScene;
                return;
            }

            Scene NewScene = (SceneList.SelectedItem as Scene);//Преобразование в объект новой сцены, т.е. при переключении
            SaveLastScene();
            SelectedScene = NewScene;//Совокупность данных
            TitleOfSelectedItem.Text = NewScene.Title;
            ID.Text = NewScene.countScene.ToString();
            MainVideo.Text = NewScene.pathToVideo;
            IntermediateVideo.Text = NewScene.IntermediateVideo;
            if (NewScene.ListOfVariants.Count > 0)
            {
                VC1.TBID.Text = NewScene.ListOfVariants[0].TargetID.ToString();
                VC1.TBDescription.Text = NewScene.ListOfVariants[0].Description;
                VC1.CBTurnOn.IsChecked = true;
            }
            if (NewScene.ListOfVariants.Count > 1)
            {
                VC2.TBID.Text = NewScene.ListOfVariants[1].TargetID.ToString();
                VC2.TBDescription.Text = NewScene.ListOfVariants[1].Description;
                VC2.CBTurnOn.IsChecked = true;
            }
            else
            {
                VC2.CBTurnOn.IsChecked = false;
            }
            if (NewScene.ListOfVariants.Count > 2)
            {
                VC3.TBID.Text = NewScene.ListOfVariants[2].TargetID.ToString();
                VC3.TBDescription.Text = NewScene.ListOfVariants[2].Description;
                VC3.CBTurnOn.IsChecked = true;
            }
            else
            {
                VC3.CBTurnOn.IsChecked = false;
            }
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F12)
            {
                BTNSave_Click(null, null);
            }
        }

        private void BTNMainVideo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog O = new OpenFileDialog();
            O.ShowDialog();
            MainVideo.Text = O.FileName;
        }

        private void BTNInterVideo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog O = new OpenFileDialog();
            O.ShowDialog();
            IntermediateVideo.Text = O.FileName;
        }

        //TODO: Сделать расширение с большим кол-вом вариантов.
    }//D:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое
}