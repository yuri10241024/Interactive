using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public Action ChangedProject;
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
        }

        private void CBTurnOn_Click(object sender, RoutedEventArgs e)
        {
            CBChecked();
        }

        void CBChecked()
        {
            if (CBTurnOn.IsChecked == true)
            {
                if (TBDescription != null)
                {
                    TBDescription.IsEnabled = true;
                    TBID.IsEnabled = true;
                }
            }
            else
            {
                if (TBDescription != null)
                {
                    TBDescription.IsEnabled = false;
                    TBID.IsEnabled = false;
                }
            }
        }

        private void CBTurnOn_Checked(object sender, RoutedEventArgs e)
        {
            CBChecked();
        }

        private void CBTurnOn_Unchecked(object sender, RoutedEventArgs e)
        {
            CBChecked();
        }

        Regex regex = new Regex(@"^\d+$");//

        private void TBID_KeyDown(object sender, KeyEventArgs e)
        {
            if (regex.IsMatch(TBID.Text))
            {
                TBID.Foreground = Brushes.Black;
            }
            else
            {
                TBID.Foreground = Brushes.Red;
            }

            //ChangedProject();

        }
    }
}
