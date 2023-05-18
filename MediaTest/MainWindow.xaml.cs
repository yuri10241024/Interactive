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

namespace MediaTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            player.Source = new Uri(@"F:\Кровсток\DSCF5354.MP4");
           // player.MediaFailed += Player_MediaFailed;
           // player.MediaEnded += Player_MediaEnded;//Событие - особый вид данных, к нему нельзя ничего присваивать
            //player.Play();

        }



       /* private void Player_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Media failed: "+ e.ErrorException);
        }

        private void Player_MediaEnded(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show("Media ended");
        }

        private void MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("HELLO!!!");
            
        }
        
        private void ME(object sender, MouseEventArgs e)
        {
            //hw.Background = Brushes.Red; 
            //MessageBox.Show("U have entered");
        }

        private void leave(object sender, MouseEventArgs e)
        {
            //hw.Background = Brushes.BlueViolet;
        }*/
    }
}
