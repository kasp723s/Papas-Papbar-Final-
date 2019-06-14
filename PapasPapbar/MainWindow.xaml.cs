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

namespace PapasPapbar
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
        private void Reservation_Click(object sender, RoutedEventArgs e)
        {
            UI.Reservation Switch = new UI.Reservation();
            Switch.Show();
            Close();
        }

        private void Membership_Click(object sender, RoutedEventArgs e)
        {
            UI.Membership Switch = new UI.Membership();
            Switch.Show();
            Close();
        }

        private void BoardgameLibrary_Click(object sender, RoutedEventArgs e)
        {
            UI.Boardgame Switch = new UI.Boardgame();
            Switch.Show();
            Close();
        }
        private void GameStats_Click(object sender, RoutedEventArgs e)
        {
            UI.GameStats Switch = new UI.GameStats();
            Switch.Show();
            Close();
        }
        private void Table_Click(object sender, RoutedEventArgs e)
        {
            UI.Table Switch = new UI.Table();
            Switch.Show();
            Close();
        }

    }
}
