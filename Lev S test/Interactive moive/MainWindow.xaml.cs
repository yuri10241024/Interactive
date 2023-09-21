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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace Interactive_moive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string PathToProject = @"D:\_STUDIOS\VISUAL_STUDIO\Programming\InteractiveMovie\Lev S test";
        public MainWindow()
        {
            InitializeComponent();
            //MessageBox.Show(System.Windows.SystemParameters.PrimaryScreenWidth.ToString());
            //MessageBox.Show(System.Windows.SystemParameters.PrimaryScreenHeight.ToString());
            TestScene2();
        }
        private void AboutUSBTN_Click(object sender, RoutedEventArgs e)
        {
            AboutUs aboutUs = new AboutUs();
            aboutUs.ShowDialog();
        }
        //if smth starts, close than open.
        private void BTNnewGame_Click(object sender, RoutedEventArgs e)
        {
            GameWindow test1 = new GameWindow();
            test1.parent = this;
            test1.ShowDialog();
            MessageBox.Show("Спасибо за внимание");
        }

        void TestScene()
        {
            Scene test1 = new Scene();
            test1.buttonText = new string[3];
            test1.countScene = 1;
            test1.pathToVideo = "fhwds";

            string str = JsonConvert.SerializeObject(test1);

            File.WriteAllText(@"C:\test1!!!", str);
        }

        void TestScene2()
        {
            Scene test1;


            string str = File.ReadAllText(@"D:\_STUDIOS\VISUAL_STUDIO\Programming\InteractiveMovie\Lev S test\Interactive moive\bin\Debug\testJson.json");

            test1 = JsonConvert.DeserializeObject<Scene>(str);
        
        }
    }
}
