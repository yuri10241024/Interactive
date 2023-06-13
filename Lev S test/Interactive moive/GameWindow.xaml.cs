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

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (parent != null)
            {
                parent.Close();
            }
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
