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

namespace IncredibleVisualizer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void DrawLine(SceneBlock sceneBlock1, SceneBlock sceneBlock2)
        {
            double Top1 = Canvas.GetTop(sceneBlock1);
            double Left1 = Canvas.GetLeft(sceneBlock1);
            double Top2 = Canvas.GetTop(sceneBlock2);
            double Left2 = Canvas.GetLeft(sceneBlock2);
            double y1 = Top1 + 60;
            double y2 = Top2 + 60;
            double x1 = Left1 + 106;
            double x2 = Left2 + 106;
            Line line = new Line();
            line.X1 = x1;
            line.X2 = x2;
            line.Y1 = y1;
            line.Y2 = y2;
            //VelikijCanvasDrevnihRusov Children.
        }
    }
}
