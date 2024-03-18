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

namespace GreatSceneEditor
{
    /// <summary>
    /// Interaction logic for NewScene.xaml
    /// </summary>
    /// 
    
    public partial class NewScene : Window
    {
        public bool IsCreated;
        public NewScene()
        {
            InitializeComponent();
        }
            
        private void TBSceneName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBSceneName.Text == "Enter")
            {
                TBSceneName.Text = "";
            }
        }

        private void NSBTNCreate_Click(object sender, RoutedEventArgs e)
        {
            IsCreated = true;
            this.Close();
        }

        private void NSBTNCancel_Click(object sender, RoutedEventArgs e)
        {

            IsCreated = false;
            this.Close();
        }

        private void NSBTNCreate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                NSBTNCreate_Click(sender, e);
            }
            else
            {
                return;
            }
            
        }
    }
}
