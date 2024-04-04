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

namespace IncredibleVisualizer
{
    /// <summary>
    /// Interaction logic for SceneBlock.xaml
    /// </summary>
    public partial class SceneBlock : UserControl
    {
        public int SceneID;

        public SceneBlock()
        {
            InitializeComponent();
        }
        public void SetScene(Scene scene)
        {
            TBSceneDescription.Text = scene.Title;
            TBSceneID.Text = scene.ID.ToString();
            TBVar1.Text = scene.ListOfVariants[0].Description;
            if (scene.ListOfVariants.Count > 1)
            {
                TBVar2.Text = scene.ListOfVariants[1].Description;
            }
            if (scene.ListOfVariants.Count > 2)
            {
                TBVar3.Text = scene.ListOfVariants[2].Description;
            }
        }
    }
}
