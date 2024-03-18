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
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GreatSceneEditor
{
    public partial class MainWindow : Window
    {
        public Quest q;

        public string CurrentFileName = ""; 

        public bool ProjectLoaded = false;
        
        public ObservableCollection<Scene> OCScenes = new ObservableCollection<Scene>();

        public bool IsChanged;

        int Counter = 0;

        Scene SelectedScene;
        public MainWindow()
        {
            InitializeComponent();

            q = new Quest();
            SceneList.ItemsSource = OCScenes;

            VC1.TBVariantNum.Text = "Вариант 1";
            VC2.TBVariantNum.Text = "Вариант 2";
            VC3.TBVariantNum.Text = "Вариант 3";

            VC1.TBVariantNum.KeyDown += TextChanged;
            VC2.TBVariantNum.KeyDown += TextChanged;
            VC3.TBVariantNum.KeyDown += TextChanged;


            SPTools.Visibility = Visibility.Hidden;

            VC2.CBTurnOn.Click += CBTurnOn2_Click;
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
                SFD.Filter = ("json|*.json");
                SFD.ShowDialog();
                if (SFD.FileName == "")
                {
                    return;
                }
                CurrentFileName = SFD.FileName;
            }

            File.WriteAllText(CurrentFileName, JSON);

        }
        private void BTNOpen_Click(object sender, RoutedEventArgs e)
        {
            SaveLastScene();
            OpenFileDialog O = new OpenFileDialog();
            O.Filter = ("json|*.json");
            O.ShowDialog();
            if(string.IsNullOrEmpty(O.FileName))
            {
                return;
            }
            string JSON = File.ReadAllText(O.FileName);
            Quest SelectedQuest = JsonConvert.DeserializeObject<Quest>(JSON);
            OCScenes.Clear();
            OCScenes = new ObservableCollection<Scene>(SelectedQuest.ListOfScenes);
            SceneList.ItemsSource = OCScenes;
            q = SelectedQuest;

            Scene LastScene = OCScenes.OrderByDescending(S => S.countScene).FirstOrDefault();
            if(LastScene != null)
            {
                Counter = LastScene.countScene + 1;
            }
            else
            {
                Counter = 0;
            }

            VC1.TBVariantNum.Text = "Вариант 1";
            VC2.TBVariantNum.Text = "Вариант 2";
            VC3.TBVariantNum.Text = "Вариант 3";

            SceneList.Visibility = Visibility.Visible;
            SPTools.Visibility = Visibility.Visible;

            ProjectLoaded = true;
        }
        private bool ValidateID(out string message)
        {
            int id;

            message = "";

            if(!int.TryParse(ID.Text, out id))
            {
                message = "ID сцены может быть только целым числом";
                return false;
            }

            //Scene S = OCScenes.Where(sc => sc.countScene == id).FirstOrDefault();//Вернуться с учителем

            //if (S != null)
            //{
            //    message = "Такой ID сцены уже используется";
            //    return false;
            //}

            if (!int.TryParse(VC1.TBID.Text, out id))
            {
                message = "ID варианта 1 может быть только целым числом";
                return false;
            }
            
            if (!int.TryParse(VC2.TBID.Text, out id) && VC2.CBTurnOn.IsChecked == true)
            {
                message = "ID варианта 2 может быть только целым числом";
                return false;
            }
            if (!int.TryParse(VC3.TBID.Text, out id) && VC3.CBTurnOn.IsChecked == true)
            {
                message = "ID варианта 3 может быть только целым числом";
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

                if(CBIsFinal.IsChecked == true)
                {
                    SelectedScene.IsFinalScene = true;
                }
                else
                {
                    SelectedScene.IsFinalScene = false;
                }

                if(CBIsStart.IsChecked == true)
                {
                    SelectedScene.IsStartScene = true;
                }
                else
                {
                    SelectedScene.IsStartScene = false;
                }

                

                if (VC1.CBTurnOn.IsChecked == true)
                {
                    SelectedScene.ListOfVariants.Add(new Variant
                    {
                        TargetID = int.Parse(VC1.TBID.Text),
                        Description = VC1.TBDescription.Text
                    });//Анонимная переменная 
                }
                else
                {
                    //SelectedScene.ListOfVariants
                }

                if(VC2.CBTurnOn.IsChecked == true)
                {
                    SelectedScene.ListOfVariants.Add(new Variant
                    {
                        TargetID = int.Parse(VC2.TBID.Text),
                        Description = VC2.TBDescription.Text
                    });
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
                Counter++;
                Sc.countScene = Counter;
                //ID.Text = Sc.countScene.ToString();
                Sc.Title = ns.TBSceneName.Text;
                q.ListOfScenes.Add(Sc);

                OCScenes.Add(Sc);
                SceneList.SelectedIndex = OCScenes.Count - 1;

                UnblockScene();
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
                UnblockScene();
                if (ProjectLoaded == true)
                {
                    //TODO:проверить что предидущий проект сохранён
                }
                q = new Quest();
                TitleOfSelectedItem.Text = "";
                ID.Text = "0";
                MainVideo.Text = "";
                IntermediateVideo.Text = "";
                VC1.TBID.Text = "0";
                VC1.TBDescription.Text = "";
                VC2.TBID.Text = "0";
                VC2.TBDescription.Text = "";
                VC3.TBID.Text = "0";
                VC3.TBDescription.Text = "";
            }
            else
            {
                if (ProjectLoaded == false)
                {
                    BlockScene();
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

            string message;

            if(!ValidateID(out message))
            {
                TBMessage.Text = message;
                SceneList.SelectedItem = SelectedScene;
                return;
            }

            Scene NewScene = (SceneList.SelectedItem as Scene);//Преобразование в объект новой сцены, т.е. при переключении
            SaveLastScene();
            SelectedScene = NewScene;//Совокупность данных
            TitleOfSelectedItem.Text = NewScene.Title;
            ID.Text = NewScene.countScene.ToString();   
            MainVideo.Text = NewScene.pathToVideo;
            IntermediateVideo.Text = NewScene.IntermediateVideo;//TODO: cвязка данных title это всё с bindin'гом
            CBIsStart.IsChecked = NewScene.IsStartScene;
            CBIsFinal.IsChecked = NewScene.IsFinalScene;


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
                VC2.TBID.Text = "";
                VC2.TBDescription.Text = "";
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
                VC3.TBID.Text = "";
                VC3.TBDescription.Text = "";
            }
        }
        public void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F12)
            {
                BTNSave_Click(null, null);
            }
        }
        private void BTNMainVideo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog O = new OpenFileDialog();
            O.Filter = ("mpeg Files|*.mp4|avi Files|*.avi");
            O.ShowDialog();
            MainVideo.Text = O.FileName;
        }
        private void BTNInterVideo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog O = new OpenFileDialog();
            O.Filter = ("mpeg Files|*.mp4|avi Files|*.avi");
            O.ShowDialog();
            IntermediateVideo.Text = O.FileName;
        }
        private void CBTurnOn2_Click(object sender, RoutedEventArgs e)
        {
            if(VC2.CBTurnOn.IsChecked == true)
            {
                VC3.CBTurnOn.IsEnabled = true;
            }
            else
            {
                VC3.CBTurnOn.IsChecked = false;
                VC3.CBTurnOn.IsEnabled = false;
            }
        }
        private void VC1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        Regex regex = new Regex(@"^\d+$");//

        private void ID_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (regex.IsMatch(ID.Text))
            {
                ID.Foreground = Brushes.Black;
            }
            else
            {
                ID.Foreground = Brushes.Red;
            }

            IsChanged = true;
        }
        private void BlockScene()
        {
            SceneList.Visibility = Visibility.Hidden;
            SPTools.Visibility = Visibility.Hidden;
        }
        private void UnblockScene()
        {
            SPTools.Visibility = Visibility.Visible;
            SceneList.Visibility = Visibility.Visible;
        }
        public void ChangedP()
        {
            IsChanged = true;
        }
        public void TextChanged(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ChangedP();
        }
        private void SaveProjectWindow()
        {
            SaveWindow SW = new SaveWindow();
            SW.ShowDialog();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)//параметр при закрытии окна
        {
            if (IsChanged)
            {
                SaveProjectWindow();
            }
        }

        private void CBIsFinal_Click(object sender, RoutedEventArgs e)
        {
            if(CBIsFinal.IsChecked == true)
            {
                VC1.CBTurnOn.IsChecked = false;
                VC2.CBTurnOn.IsChecked = false;
                VC3.CBTurnOn.IsChecked = false;
                VC1.IsEnabled = false;
                VC2.IsEnabled = false;
                VC3.IsEnabled = false;
            }
            else
            {
                VC1.CBTurnOn.IsChecked = true;
                VC2.CBTurnOn.IsChecked = false;
                VC3.CBTurnOn.IsChecked = false;
                VC1.IsEnabled = true;
                VC2.IsEnabled = true;
                VC3.IsEnabled = true;
            }
            SaveLastScene();
        }

        private void ID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CBIsStart_Click(object sender, RoutedEventArgs e)
        {
            SaveLastScene();
        }

        /* private void TitleOfSelectedItem_TextChanged(object sender, TextChangedEventArgs e)
         {
             if(SelectedScene == null)
             {
                 return;
             }
             SelectedScene.Title = TitleOfSelectedItem.Text;

         }*/
        //TODO: Сделать расширение с большим кол-вом вариантов.
    }
}