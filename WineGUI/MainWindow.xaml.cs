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
using WineGUI.View;

namespace WineGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WineNavBtn_Click(object sender, RoutedEventArgs e)
        {
            ListContainer.Content = new WinesListView();
            DetailContainer.Content = new WineDetailView();

        }

        private void ProducerNavBtn_Click(object sender, RoutedEventArgs e)
        {
            ListContainer.Content = new ProducersListView();
            DetailContainer.Content = new ProducersListView();
        }

        private void TypeNavBtn_Click(object sender, RoutedEventArgs e)
        {
            ListContainer.Content = new TypesListView();
            DetailContainer.Content = new TypesListView();
        }
    }
}
