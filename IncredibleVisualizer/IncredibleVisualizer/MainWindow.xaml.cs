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
using System.IO;
using Interactive_moive;


namespace IncredibleVisualizer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Quest quest = Quest.GetQuest(@"D:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое\Biggest project.json");
            a1_1.SetScene(quest.ListOfScenes[0]);
            a2_1.SetScene(quest.ListOfScenes[1]);
            a2_2.SetScene(quest.ListOfScenes[2]);
            a3_1.SetScene(quest.ListOfScenes[3]);

            ConnectBlocks(a1_1, a2_2);
            ConnectBlocks(a1_1, a2_1);
            ConnectBlocks(a2_1, a3_2);
        }



        void ShowQuest(Quest quest)
        {

        }

        private void DrawLine(SceneBlock sceneBlock1, SceneBlock sceneBlock2)
        {
            double Top1 = Canvas.GetTop(sceneBlock1);
            double Left1 = Canvas.GetLeft(sceneBlock1);
            double Top2 = Canvas.GetTop(sceneBlock2);
            double Left2 = Canvas.GetLeft(sceneBlock2);
            double y1 = Top1 + 60;
            double y2 = Top2 + 60;
            double x1 = Left1 + 212;
            double x2 = Left2;
            Line line = new Line();
            line.StrokeThickness = 2;
            line.Stroke = Brushes.Black;
            line.X1 = x1;
            line.X2 = x2;
            line.Y1 = y1;
            line.Y2 = y2;
            MainCanvas.Children.Add(line);
            Panel.SetZIndex(line, -5);
        }

        private void ConnectBlocks(SceneBlock s1, SceneBlock s2)
        {
            Line line = new Line();
            line.StrokeThickness = 2;
            line.Stroke = Brushes.Black;
            line.Y1 = Canvas.GetTop(s1) + 120;
            line.X1 = Canvas.GetLeft(s1) + 106;
            line.Y2 = Canvas.GetTop(s2);
            line.X2 = Canvas.GetLeft(s2) + 106;
            MainCanvas.Children.Add(line);
            Panel.SetZIndex(line, -5);
        }
    }
}
