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
using Interactive_moive;


namespace GreatSceneEditor
{
    /// <summary>
    /// Interaction logic for VariantControl.xaml
    /// </summary>
    public partial class VariantControl : UserControl
    {
        List<VariantType> VariantTypes = new List<VariantType>();

        public VariantControl()
        {
            InitializeComponent();

            //VariantTypes
            VariantType V = new VariantType("Film","Фильм");
            VariantTypes.Add(V);

            V = new VariantType("Retry", "Повтор");
            VariantTypes.Add(V);

            V = new VariantType("Quit", "Завершить");
            VariantTypes.Add(V);

            CBVariants.ItemsSource = VariantTypes;
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
