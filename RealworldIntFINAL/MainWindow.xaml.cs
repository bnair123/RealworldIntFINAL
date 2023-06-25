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

namespace RealworldIntFINAL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddStockClicked(object sender, RoutedEventArgs e)//Add Stock Is Clicked 
        {
            MessageBox.Show("Adding stock LMAO + UR MUM");
        }

        private void RemoveStockClicked(object sender, RoutedEventArgs e)//Remove Stock Is Clicked
        {
            MessageBox.Show("Removing stock LMAO + UR MUM");
        }

        private void UserInputIsBadClicked(object sender, RoutedEventArgs e)//Someone Needs True Guidance In Life
        {
            MessageBox.Show($"I don't remmember this language but I will teach it to you.");
        }
    }
}
