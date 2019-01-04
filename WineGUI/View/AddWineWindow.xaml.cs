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

namespace WineGUI.View
{
    /// <summary>
    /// Interaction logic for AddWineWindow.xaml
    /// </summary>
    public partial class AddWineWindow : Window
    {
        public AddWineWindow()
        {
            InitializeComponent();
            AddContainer.Content = new WineDetailView();
        }
    }
}