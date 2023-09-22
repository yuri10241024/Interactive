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

namespace GreatSceneEditor
{
    /// <summary>
    /// Interaction logic for VariantControl.xaml
    /// </summary>
    public partial class VariantControl : UserControl
    {
        public VariantControl()
        {
            InitializeComponent();
        }

        private void CBTurnOn_Click(object sender, RoutedEventArgs e)
        {
            if (CBTurnOn.IsChecked == true)
            {
                TBDescription.IsEnabled = true;
                TBID.IsEnabled = true;

            }
            else
            {
                TBDescription.IsEnabled = false;
                TBID.IsEnabled = false;
            }
        }
    }
}
