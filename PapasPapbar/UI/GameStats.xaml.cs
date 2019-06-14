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
using System.Windows.Shapes;

namespace PapasPapbar.UI
{
    /// <summary>
    /// Interaction logic for GameStats.xaml
    /// </summary>
    public partial class GameStats : Window
    {
        public GameStats()
        {
            InitializeComponent();
        }
        private void GameStats_Tilbage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Switch = new MainWindow();
            Switch.Show();
            Close();
        }
    }
}
