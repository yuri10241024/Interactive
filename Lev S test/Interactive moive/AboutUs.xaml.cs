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
using System.IO;

namespace Interactive_moive
{
    /// <summary>
    /// Interaction logic for AboutUs.xaml
    /// </summary>
    public partial class AboutUs : Window
    {
        public AboutUs()
        {
            InitializeComponent();
            ReadAboutUs(@"C:\Lev S test\AboutUs\AboutUs.txt");
        }

        void ReadAboutUs(string path)
        {
            string[] str = File.ReadAllLines(path);

            for(int i = 0; i < str.Length; i++)
            {
                TBAboutUs.Text = str[i];
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.ShowDialog();
        }
    }
}
