﻿using System;
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
    /// Interaction logic for NewScene.xaml
    /// </summary>
    public partial class NewScene : Window
    {
        public NewScene()
        {
            InitializeComponent();
        }
            
        private void TBSceneName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBSceneName.Text == "Enter")
            {
                TBSceneName.Text = "";
            }
        }
    }
}
