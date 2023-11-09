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
    /// Interaction logic for NewProjectWindow.xaml
    /// </summary>
    public partial class NewProjectWindow : Window
    {
        public bool NPWState = true;
        public NewProjectWindow()
        {
            
            InitializeComponent();
        }

        private void TBProjectName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBProjectName.Text == "Enter")
            {
                TBProjectName.Text = "";
            }
        }

        private void BTNNPWEnter_Click(object sender, RoutedEventArgs e)
        {
            NPWState = true;
            this.Close();
        }

        private void BTNNPWCancel_Click(object sender, RoutedEventArgs e)
        {
            NPWState = false;
            this.Close();
        }
    }
}
